using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Interactors.Differences;
using Tractor.Core.Objects;
using Tractor.Core.Objects.Tasks.Locations;
using System.Linq;

namespace Tractor.Core.Interactors.DataManagers
{
    public class TaskDataManagerHandler
    {
        public DifferenceHandler Difference;
        public TaskDataManagerHandler(DifferenceHandler @differences)
        {
            Difference = differences;
        }

        public void WriteNewTask(IEntity producer, DateTime dateTime, IDescription description, ITask parent,
            ITaskLocation location, IEntity performer, IList<IEntity> observers, string TaskType, Guid projectID)
        {
            switch(TaskType)
            {
                case "UsualTask":
                    ITask task = new UsualTask(producer, dateTime, description, parent, location, performer, observers);
                    break;
            }
            
        }

        public void WriteNewSubtask(IEntity producer, DateTime dateTime, IDescription description, ITask parent,
            ITaskLocation location, IEntity performer, IList<IEntity> observers, string TaskType, Guid taskID)
        {

        }

        public void RemoveTask(Guid taskID, Guid projectID)
        {
            IProject project = TestDataBase.Projects.Find(x => x.ID == projectID);
            Difference.AddSubscription(project);
            int index = TestDataBase.Projects.IndexOf(project);
            ITask task = (ITask)TestDataBase.Projects[index].Tasks.Where((x) => x.ID == taskID);
            Difference.AddSubscription(task);
            TestDataBase.Projects[index].RemoveTask(task);
            //тут формируем как-то дифференсы
        }

        public void AddDescription(Guid taskID, Guid projectID, IDescription description)
        {
            IProject project = TestDataBase.Projects.Find(x => x.ID == projectID);
            Difference.AddSubscription(project);
            int index = TestDataBase.Projects.IndexOf(project);
            ITask task = (ITask)TestDataBase.Projects[index].Tasks.Where((x) => x.ID == taskID);
            Difference.AddSubscription(task);
            ((UsualTask)TestDataBase.Projects[index].Tasks.Single(x => x.ID == taskID)).Description = description;
            //тут формируем как-то дифференсы
        }

        public void AddDependeci(Guid taskID, Guid projectID, ITask Dependeci)
        {
            IProject project = TestDataBase.Projects.Find(x => x.ID == projectID);
            Difference.AddSubscription(project);
            int index = TestDataBase.Projects.IndexOf(project);
            ITask task = (ITask)TestDataBase.Projects[index].Tasks.Where((x) => x.ID == taskID);
            Difference.AddSubscription(task);
            TestDataBase.Projects[index].Tasks.Single(x => x.ID == taskID).AddDependenci(Dependeci);
        }

        public void RemoveDependeci(Guid taskID, Guid projectID, Guid dependeciID)
        {

            IProject project = TestDataBase.Projects.Find(x => x.ID == projectID);
            int index = TestDataBase.Projects.IndexOf(project);
            ITask task = (ITask)TestDataBase.Projects[index].Tasks.Where((x) => x.ID == taskID);
            var dep = TestDataBase.Projects[index].Tasks.Single(x => x.ID == taskID).Dependencies.Single((x) => x.ID == dependeciID);
            TestDataBase.Projects[index].Tasks.Single(x => x.ID == taskID).RemoveDependenci(dep);
            //тут формируем как-то дифференсы
        }

        public void RemoveObserver(Guid taskID, Guid projectID, Guid ObcserverID)
        {

            IProject project = TestDataBase.Projects.Find(x => x.ID == projectID);
            Difference.AddSubscription(project);
            int index = TestDataBase.Projects.IndexOf(project);
            ITask task = (ITask)TestDataBase.Projects[index].Tasks.Where((x) => x.ID == taskID);
            Difference.AddSubscription(task);
            var dep = TestDataBase.Projects[index].Tasks.Single(x => x.ID == taskID).Observers.Single((x) => x.ID == ObcserverID);
            //TestDataBase.Projects[index].Tasks.Single(x => x.ID == taskID).RemoveObserver(dep);
        }

        public void SetTaskName(Guid taskID, Guid projectID, string name)
        {
            IProject project = TestDataBase.Projects.Find(x => x.ID == projectID);
            Difference.AddSubscription(project);
            int index = TestDataBase.Projects.IndexOf(project);
            ITask task = (ITask)TestDataBase.Projects[index].Tasks.Where((x) => x.ID == taskID);
            Difference.AddSubscription(task);
            
        }

    }

}
