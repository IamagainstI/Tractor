using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tractor.Core.Objects.Entities.Permissions;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Objects.DataBases
{
    public static class DataBaseHelper
    {
        public static IEnumerable<object> GetSpecifiedPath(this IDataBase db, IEnumerable<Guid> path)
        {
            Stack<Guid> pathStack = new Stack<Guid>(path);
            object currentObject = null;
            while (pathStack.Count > 0)
            {
                Guid currentEntry = pathStack.Pop();
                if (currentObject == null)
                {
                    currentObject =
                        (object)db.Entities.FirstOrDefault(x => x.ID == currentEntry) ??
                        db.Projects.FirstOrDefault(x => x.ID == currentEntry);
                }
                else
                {
                    switch (currentObject)
                    {
                        case ITeam team:
                            currentObject = team.Members.FirstOrDefault(x => x.Key.ID == currentEntry);
                            break;
                        case IProject proj:
                            currentObject =
                                proj.Description.ID == currentEntry ? proj.Description :
                                (object)proj.Projects.FirstOrDefault(x => x.ID == currentEntry) ??
                                proj.Tasks.FirstOrDefault(x => x.ID == currentEntry);
                            break;
                        case ITask task:
                            currentObject =
                                task.Description.ID == currentEntry ? (object)task.Description :
                                task.Tasks.FirstOrDefault(x => x.ID == currentEntry);
                            break;
                    }
                    if (currentObject == null)
                    {
                        throw new Exception();
                    }
                }
                yield return currentObject;
            }
        }

        public static IEnumerable<Guid> GetPath(this IDataBase db, object obj)
        {
            switch (obj)
            {
                case ITask task:
                    if (task.Parent == null)
                    {
                        return Enumerable.Empty<Guid>();
                    }
                    else
                    {
                        return GetPath(db, task.Parent).Concat(Enumerable.Repeat(task.ID, 1));
                    }
                case IProject proj:
                    if (proj.Parent == null || proj.Parent is IDataBase)
                    {
                        return Enumerable.Empty<Guid>();
                    }
                    else
                    {
                        return GetPath(db, proj.Parent).Concat(Enumerable.Repeat(proj.ID, 1));
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        public static AccessType GetAccessType(this IDataBase db, IEntity entity)
        {
            if (db.Entities.Contains(entity))
            {
                AccessType? entityPerm = db.Permissions.FirstOrDefault(y => y is IEntityPermission entityP && entityP.Entity == entity)?.AccessType;
                if (!(entity is ITeam))
                {
                    IEnumerable<ITeam> teams = db.Teams.Where(x => x.Members.ContainsKey(entity));
                    AccessType? teamPerm = teams.Select(x =>
                    {
                        AccessType team = GetAccessType(db, x);
                        IPermission role = db.Permissions.FirstOrDefault(y => y is IEntityRolePermission rolePerm && rolePerm.EntityRole == x.Members[entity]);
                        return team & role?.AccessType;
                    }).Aggregate((x, y) => x | y);
                    entityPerm |= teamPerm;
                }
                return entityPerm ?? AccessType.None;
            }
            else
            {
                return AccessType.None;
            }
        }

        public static AccessType GetAccessType(this IProject db, IEntity entity)
        {
            if (db.Participants.ContainsKey(entity))
            {
                AccessType? entityPerm = db.Permissions.FirstOrDefault(y => y is IEntityPermission entityP && entityP.Entity == entity)?.AccessType;
                AccessType? rolePerm = db.Permissions.FirstOrDefault(x => x is IEntityPermission roleP && roleP.Entity == db.Participants[entity])?.AccessType;
                entityPerm |= rolePerm;
                return entityPerm ?? AccessType.None;
            }
            else
            {
                return AccessType.None;
            }
        }

        public static AccessType GetAccessType(this IDataBase db, IEntity entity, object obj)
        {
            AccessType dbAccessType = GetAccessType(db, entity);
            if (dbAccessType != AccessType.None)
            {
                switch (obj)
                {
                    case IEntity _:
                        return dbAccessType;
                    default:
                        IEnumerable<IProject> pathobj = GetSpecifiedPath(db, GetPath(db, obj)).Where(x => x is IProject).Select(x => x as IProject);
                        foreach (IProject proj in pathobj)
                        {
                            AccessType tmp = GetAccessType(db, entity, proj);
                            if (tmp == AccessType.None)
                            {
                                return AccessType.None;
                            }
                            else
                            {
                                dbAccessType = tmp;
                            }
                        }
                        break;
                }
                return dbAccessType;
            }
            return AccessType.None;
        }
    }
}
