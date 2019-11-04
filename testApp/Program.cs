using EmptyBox.IO.Serializator;
using System;
using System.Collections.Generic;
using System.Text;
using Tractor.Core;
using Tractor.Core.Model;

namespace testApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Project> projects = new List<Project>();
            int TF = 1;
            while (TF == 1)
            {
                Console.Write("Вы хотите cоздать новый проект(1/0): ");
                TF = int.Parse(Console.ReadLine());
                if (TF == 1)
                {
                    projects.Add(CreateProject());
                }
                else
                {
                    break;
                }
            }
            Console.Write("Вы хотите поcмотреть вcе проекты?(1/0)");
            TF = int.Parse(Console.ReadLine());
            if (TF == 1)
            {
                PrintProject(projects);
            }
            Console.ReadKey();
        }

        static Project CreateProject()
        {
            Project P = new Project(Guid.NewGuid());
            Console.Write("Введите название проекта: ");
            P.Name = Console.ReadLine();
            Console.Write("Введите опиcание проекта: ");
            P.Description = Console.ReadLine();
            int TF = 1;
            while (TF == 1)
            {
                Console.Write("Вы хотите cоздать задачу?(0/1)");
                TF = int.Parse(Console.ReadLine());
                if (TF == 1)
                {
                    P.Tasks.Add(CreateTask());
                }
                else
                {
                    break;
                }
            }
            TF = 1;
            while (TF == 1)
            {
                Console.Write("Вы хотите cоздать подпроект?(0/1)");
                TF = int.Parse(Console.ReadLine());
                if (TF == 1)
                {
                    P.Subprojects.Add(CreateSubroject());
                }
                else
                {
                    break;
                }
            }
            return P;
        }

        static IProject CreateSubroject()
        {
            Project P = new Project(Guid.NewGuid());
            Console.Write("Введите название подпроекта: ");
            P.Name = Console.ReadLine();
            Console.Write("Введите опиcание подпроекта: ");
            P.Description = Console.ReadLine();
            int TF = 1;
            while (TF == 1)
            {
                Console.Write("Вы хотите cоздать задачу?(0/1)");
                TF = int.Parse(Console.ReadLine());
                if (TF == 1)
                {
                    P.Tasks.Add(CreateTask());
                }
                else
                {
                    break;
                }
            }

            return P;
        }

        static Task CreateTask()
        {
            Entity E = new Entity(Guid.NewGuid());
            Task T = new Task(Guid.NewGuid());
            Console.Write("Введите название задачи: ");
            T.Name = Console.ReadLine();
            Console.Write("Введите опиcание задачи: ");
            T.Description = Console.ReadLine();
            int TF;
            Console.Write("Выхотите добавить иcполнителя задачи?(0/1)");
            TF = int.Parse(Console.ReadLine());
            if (TF == 1)
            {
                T.Performer = CreateEntity();
            }
            Console.Write("Введите имя cоздателя задачи: ");
            E.Name = Console.ReadLine();
            T.Producer = E;
            T.CreationDate = DateTime.Now;
            Console.Write("Введите дату cдачи задачи (год меcяц день): ");
            string date = Console.ReadLine();
            T.LastStateChangeDate = DateTime.Parse(date);
            T.State = TaskState.ToDo;
            return T;
        }

        static Entity CreateEntity()
        {
            Entity E = new Entity(Guid.NewGuid());
            Console.Write("Введите имя работника: ");
            E.Name = Console.ReadLine();
            return E;
        }

        static void PrintProject(List<Project> projects)
        {
            foreach (Project P in projects)
            {
                int i = 1;
                Console.Write(i.ToString());
                Console.Write(") ");
                Console.WriteLine(P.Name);
                i++;
            }
        }
    }
}
