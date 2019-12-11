using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Routers.Command;
using Tractor.Core.Routers.UI;

namespace Tractor.Core.Presenters.Tasks
{
    public class TaskViewPresenter : AbstractPresenter
    {
        public ITask Task { get; set; }

        public TaskViewPresenter(UIRouter router, ITask task) : base(router)
        {
            Task = task;
        }

        public void AddTask() => TaskMethods.AddTask(Router, Task);
        public void RemoveTask(ITask task) => TaskMethods.RemoveTask(Router, task);
        public void Edit() => TaskMethods.EditTask(Router, Task.Parent, Task);
        public void Cancel() => Router.RequestBack();
    }
}
