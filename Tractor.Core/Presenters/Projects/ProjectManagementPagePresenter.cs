using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Objects.Tasks;

namespace Tractor.Core.Presenters.Projects
{
    public class ProjectManagementPagePresenter : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IProject PresentedProject { get; }
        public IEnumerable<ITask> ToDoTasks => PresentedProject.Tasks.Where(x => x.Progress.ProgressPercentage == 0);
        public IEnumerable<ITask> InProgressTasks => PresentedProject.Tasks.Where(x => x.Progress.ProgressPercentage > 0 && x.Progress.ProgressPercentage < 1);
        public IEnumerable<ITask> DoneTasks => PresentedProject.Tasks.Where(x => x.Progress.ProgressPercentage == 1);

        public ProjectManagementPagePresenter(IProject presented)
        {
            PresentedProject = presented;
            PresentedProject.PropertyChanged += PresentedProject_PropertyChanged;
        }

        private void PresentedProject_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PresentedProject.Tasks))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ToDoTasks)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InProgressTasks)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DoneTasks)));
            }
        }
    }
}
