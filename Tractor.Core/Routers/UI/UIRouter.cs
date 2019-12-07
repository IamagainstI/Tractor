using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core.Objects;
using Tractor.Core.Objects.DataBases;
using Tractor.Core.Routers.Command;

namespace Tractor.Core.Routers.UI
{
    public sealed class UIRouter : Pipeline<NavigationInfo, ICommand>, IPipelineInput<NavigationInfo>, IPipelineOutput<ICommand>
    {
        private EventHandler<ICommand> ICommand_Output;

        event EventHandler<ICommand> IPipelineOutput<ICommand>.Output
        {
            add => ICommand_Output += value;
            remove => ICommand_Output -= value;
        }

        EventHandler<NavigationInfo> IPipelineInput<NavigationInfo>.Input => OnInput;

        public event EventHandler<NavigationInfo> NavigationRequested;

        public Stack<NavigationInfo> BackStack { get; } = new Stack<NavigationInfo>();
        public Stack<NavigationInfo> ForwardStack { get; } = new Stack<NavigationInfo>();
        public bool IsBackAvailable => BackStack.Count > 0;
        public bool IsFrowardAvailable => ForwardStack.Count > 0;
        public NavigationInfo CurrentView { get; private set; }
        public TractorAccount CurrentAccount { get; private set; }
        public IDataBase CurrentDataBase { get; set; }

        private void OnInput(object sender, NavigationInfo info)
        {
            RequestNavigation(info);
        }

        private void Navigate(NavigationInfo info)
        {
            if (CurrentView != null)
            {
                BackStack.Push(CurrentView);
            }
            NavigationRequested?.Invoke(this, info);
            CurrentView = info;
        }

        public void RequestBack()
        {
            if (IsBackAvailable)
            {
                ForwardStack.Push(CurrentView);
                CurrentView = null;
                RequestNavigation(BackStack.Pop());
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
                RequestNavigation(ForwardStack.Pop());
            }
            else
            {
                throw new InvalidOperationException("Forward isn't available.");
            }
        }

        public void RequestNavigation(NavigationInfo info)
        {
            switch (info.Name)
            {
                case 
            }
        }
    }
}