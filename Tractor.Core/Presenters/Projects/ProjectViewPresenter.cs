using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Presenters.Tasks;
using Tractor.Core.Routers.Command;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Presenters.Projects
{
    public class ProjectViewPresenter : AbstractPresenter
    {
        public IProject Project { get; }
        public IEnumerable<ITask> ToDoTasks => Project.Tasks;
        public IEnumerable<ITask> InProgressTasks => Project.Tasks.Where(x => x.Progress.ProgressPercentage > 0 && x.Progress.ProgressPercentage < 1);
        public IEnumerable<ITask> DoneTasks => Project.Tasks.Where(x => x.Progress.ProgressPercentage == 1);

        public ProjectViewPresenter(UIRouter router, IProject presented) : base(router)
        {
            Project = presented;
            Project.PropertyChanged += PresentedProject_PropertyChanged;
        }

        private void PresentedProject_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Project.Tasks))
            {
                OnPropertyChanged(nameof(ToDoTasks));
                OnPropertyChanged(nameof(InProgressTasks));
                OnPropertyChanged(nameof(DoneTasks));
            }
        }

        public void AddTask() => TaskMethods.AddTask(Router, Project);
        public void RemoveTask(ITask task) => TaskMethods.RemoveTask(Router, task);
        public void AddProject() => ProjectMethods.AddProject(Router, Project);
        public void RemoveProject(IProject project) => ProjectMethods.RemoveProject(Router, project);
        public void ShowTask(ITask task) => TaskMethods.ShowTask(Router, task);
        public void EditTask(ITask task) => TaskMethods.EditTask(Router, Project, task);
        public void ShowProject(IProject project) => ProjectMethods.ShowProject(Router, project);
        public void EditProject(IProject project) => ProjectMethods.EditProject(Router, Project, project);
        public void Edit() => ProjectMethods.EditProject(Router, Project.Parent, Project);
    }
}
