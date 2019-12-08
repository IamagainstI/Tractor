using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Objects.Projects;
using Tractor.Core.Objects.Tasks;
using Tractor.Core.Routers.Command;

namespace Tractor.Core.Routers.UI
{
    public sealed class UIRouter : Pipeline<NavigationHistory, ICommand>, IPipelineInput<NavigationHistory>, IPipelineOutput<ICommand>
    {
        private event EventHandler<ICommand> ICommand_Output;

        event EventHandler<ICommand> IPipelineOutput<ICommand>.Output
        {
            add => ICommand_Output += value;
            remove => ICommand_Output -= value;
        }

        EventHandler<NavigationHistory> IPipelineInput<NavigationHistory>.Input => OnInput;

        public event EventHandler<NavigationInfo> NavigationRequested;

        public Stack<NavigationHistory> BackStack { get; } = new Stack<NavigationHistory>();
        public Stack<NavigationHistory> ForwardStack { get; } = new Stack<NavigationHistory>();
        public bool IsBackAvailable => BackStack.Count > 0;
        public bool IsFrowardAvailable => ForwardStack.Count > 0;
        public NavigationHistory CurrentView { get; set; }
        public TractorAccount CurrentAccount { get; set; }
        public IDataBase CurrentDataBase { get; set; }

        private Type GetUsualType(Type t)
        {
            if (t == typeof(ITask))
            {
                return typeof(UsualTask);
            }
            else if (t == typeof(IProject))
            {
                return typeof(UsualProject);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void OnInput(object sender, NavigationHistory info)
        {
            RequestNavigation(info);
        }

        private void Navigate(NavigationHistory info, bool isForward = false)
        {
            if (!isForward)
            {
                ForwardStack.Clear();
            }
            if (CurrentView != null)
            {
                BackStack.Push(CurrentView);
            }
            object presenter = null;
            if (info.PresenterType != null)
            {
                ConstructorInfo constructorInfo = info.PresenterType.GetConstructors().First();
                IEnumerable<ParameterInfo> @params = constructorInfo.GetParameters().Skip(1);
                IEnumerable<object> values = info.Paths.Select(CurrentDataBase.GetSpecifiedPath).Select(x => x.LastOrDefault());
                List<object> forInvoke = values.Select((x, y) => x ?? GetUsualType(@params.ElementAt(y).ParameterType).GetConstructors().First().Invoke(new object[] { info.Paths[y].First() })).ToList();
                forInvoke.Insert(0, this);
                presenter = constructorInfo.Invoke(forInvoke.ToArray());
            }
            NavigationRequested?.Invoke(this, new NavigationInfo() { PageName = info.Name, Presenter = presenter });
            CurrentView = info;
        }

        public void RequestBack()
        {
            if (IsBackAvailable)
            {
                ForwardStack.Push(CurrentView);
                CurrentView = null;
                Navigate(BackStack.Pop());
            }
            else
            {
                throw new InvalidOperationException("Back isn't available.");
            }
        }

        public void RequestForward()
        {
            if (IsFrowardAvailable)
            {
                BackStack.Push(CurrentView);
                CurrentView = null;
                Navigate(ForwardStack.Pop(), true);
            }
            else
            {
                throw new InvalidOperationException("Forward isn't available.");
            }
        }

        public void RequestNavigation(NavigationHistory info)
        {
            Navigate(info);
        }

        public void SendCommand(ICommand command)
        {
            ICommand_Output?.Invoke(this, command);
        }
    }
}