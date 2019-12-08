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
    }
}
