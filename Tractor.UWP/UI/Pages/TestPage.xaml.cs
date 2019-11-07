using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tractor.Core;
using Tractor.Core.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Tractor.UWP.UI.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class TestPage : Page
    {
        public ObservableCollection<ITask> Tasks { get; }

        public TestPage()
        {
            Tasks = new ObservableCollection<ITask>();
            Tasks.Add(
                new Task(Guid.NewGuid())
                {
                    CreationDate = DateTime.Now,
                    Description = "Test task description. You really need more?",
                    LastStateChangeDate = DateTime.Now,
                    Name = "Test task!",
                    Producer = new Entity() { Name = "djart" },
                    State = TaskState.ToDo
                }
            );
            this.InitializeComponent();
        }
    }
}
