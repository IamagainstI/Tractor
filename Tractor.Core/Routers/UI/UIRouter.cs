using EmptyBox.Automation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tractor.Core.Routers.UI
{
    public sealed class UIRouter : Pipeline<NavigationInfo>, IPipelineInput<NavigationInfo>
    {
        EventHandler<NavigationInfo> IPipelineInput<NavigationInfo>.Input => OnInput;

        public event EventHandler<string> NavigationRequested;

        public Stack<NavigationInfo> BackStack { get; } = new Stack<NavigationInfo>();
        public Stack<NavigationInfo> ForwardStack { get; } = new Stack<NavigationInfo>();
        public bool IsBackAvailable => BackStack.Count > 0;
        public bool IsFrowardAvailable => ForwardStack.Count > 0;
        public NavigationInfo CurrentView { get; private set; }

        private void OnInput(object sender, NavigationInfo info)
        {
            RequestNavigation(info);
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
            if (CurrentView != null)
            {
                BackStack.Push(CurrentView);
            }
            CurrentView = info;
            NavigationRequested?.Invoke(this, info.Name);
        }
    }
}
