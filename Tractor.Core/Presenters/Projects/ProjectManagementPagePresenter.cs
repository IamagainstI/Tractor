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
    public class ProjectManagementPagePresenter : AbstractPresenter, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IProject Project { get; }
        public IEnumerable<ITask> ToDoTasks => Project.Tasks;
        public IEnumerable<ITask> InProgressTasks => Project.Tasks.Where(x => x.Progress.ProgressPercentage > 0 && x.Progress.ProgressPercentage < 1);
        public IEnumerable<ITask> DoneTasks => Project.Tasks.Where(x => x.Progress.ProgressPercentage == 1);

        public ProjectManagementPagePresenter(UIRouter router, IProject presented) : base(router)
        {
            Project = presented;
            Project.PropertyChanged += PresentedProject_PropertyChanged;
        }

        private void PresentedProject_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Project.Tasks))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ToDoTasks)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InProgressTasks)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DoneTasks)));
            }
        }

        public void AddTask() => TaskMethods.AddTask(Router, Project);
        public void RemoveTask(ITask task) => TaskMethods.RemoveTask(Router, task);

        public void AddSubProject()
        {
            NavigationHistory history = new NavigationHistory()
            {
                Name = UIViews.PROJECT_MANAGEMENT_PAGE,
                PresenterType = typeof(ProjectManagementPagePresenter),
                Paths = new[]
                {
                    new List<Guid>(Router.CurrentDataBase.GetPath(Project)),
                    new List<Guid>() { Guid.NewGuid() }
                }
            };
            Router.RequestNavigation(history);
        }

    }
}
