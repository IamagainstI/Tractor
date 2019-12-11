﻿using System;
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
    public class TaskEditPresenter : AbstractPresenter
    {
        public ITaskStorage Storage { get; }
        public ITask Task { get; set; }

        public TaskEditPresenter(UIRouter router, ITaskStorage storage, ITask task) : base(router)
        {
            Storage = storage;
            Task = task;
        }

        public void AddTask() => TaskMethods.AddTask(Router, Task);
        public void RemoveTask(ITask task) => TaskMethods.RemoveTask(Router, task);
        public void Save() => TaskMethods.SaveTask(Router, Storage, Task);
        public void Cancel() => Router.RequestBack();
    }
}
