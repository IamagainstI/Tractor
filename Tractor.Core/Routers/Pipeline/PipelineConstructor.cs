using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Routers.UI;
using EmptyBox.Automation;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Interactors.Differences;
using Tractor.Core.Interactors.DataBases;

namespace Tractor.Core.Routers.Pipeline
{
    public class PipelineConstructor
    {
        public DifferenceMerger DifferenceMerger = new DifferenceMerger();
        public DifferenceDispenser DifferenceDispenser = new DifferenceDispenser();
        public RuntimeDifferenceHandler RuntimeDifferenceHandler = new RuntimeDifferenceHandler();
        public SynchronizationDifferenceHandler SynchronizationDifferenceHandler = new SynchronizationDifferenceHandler();
        public DataBaseDifferenceHandler DataBaseDifferenceHandler = new DataBaseDifferenceHandler(null);
        //public DataEditor TaskEditor = new DataEditor();
        public UIRouter Navigator = new UIRouter();

        public PipelineConstructor()
        {
            //При изменении элементов во время редактирования отправляем их в DataBaseDifferenceHandler
            _ = RuntimeDifferenceHandler >> DataBaseDifferenceHandler;
            //При получении элементов при синхронизации отпарвляем их в DataBaseDifferenceHandler
            //При получении IDifference от SynchronizationDifferenceHandler обрабатываем её и отправляем в DifferenceDispenser
            _ = SynchronizationDifferenceHandler >> DataBaseDifferenceHandler >> DifferenceDispenser;
            //При получении задачи для редактирования открываем соответствующий интерфейс
            //_ = TaskEditor >> Navigator;
        }
    }
}
