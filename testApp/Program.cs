using EmptyBox.IO.Serializator;
using System;
using System.Collections.Generic;
using System.Linq;
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
                PrintProjects(projects);
            }
            Console.Write("Какой проект вы хотите выбрать?");
            int ChoseProject = int.Parse(Console.ReadLine());
            if (ChoseProject < 1 || ChoseProject > (projects.Count))
            {
                Console.Write("Такого проекта нет.");
            }
            else
            {
                Project P = projects.ElementAt(ChoseProject - 1);
                Console.WriteLine("Что вы хотите cделать c этим проектом: \n1)Редактировать\n2)Cоздать задачу\n3)Показать задачи");
                int ChoseMovieP = int.Parse(Console.ReadLine());
                if (ChoseMovieP == 1)
                {
                    P = EditProject(P);
                }
                if (ChoseMovieP == 2)
                {
                    P.Tasks.Add(CreateTask());
                }
                else
                {
                    PrintTasks(P);
                }
                Console.Write("Какую задачу вы хотите выбрать?");
                int ChoseTask = int.Parse(Console.ReadLine());
                if (ChoseTask < 1 || ChoseTask > (P.Tasks.Count))
                {
                    Console.Write("Такой задачи нет.");
                }
                else
                {
                    Task T = (Task)P.Tasks.ElementAt(ChoseTask - 1);
                    Console.WriteLine("Что вы хотите cделать c этой задачей: \n1)Редактировать\n2)Cоздать подзадачу\n3)Удалить задачу\n4)Показать подзадачи");
                    int ChoseMovieT = int.Parse(Console.ReadLine());
                    if (ChoseMovieT == 1)
                    {
                        T = EditTask(T);
                    }
                    if (ChoseMovieT == 2)
                    {
                        T.Subtasks.Add(CreateSubtask());
                    }
                    if (ChoseMovieT == 3)
                    {
                        if (P.Tasks.Remove(T))
                        {
                            Console.WriteLine("Задача удалена.");
                        }
                    }
                    else
                    {
                        PrintSubtasks(T);
                    }
                }
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
            while (TF == 1)
            {
                Console.Write("Вы хотите cоздать подзадачу?(0/1)");
                TF = int.Parse(Console.ReadLine());
                if (TF == 1)
                {
                    T.Subtasks.Add(CreateSubtask());
                }
                else
                {
                    break;
                }
            }
            return T;
        }

        static Task CreateSubtask()
        {
            Entity E = new Entity(Guid.NewGuid());
            Task T = new Task(Guid.NewGuid());
            Console.Write("Введите название подзадачи: ");
            T.Name = Console.ReadLine();
            Console.Write("Введите опиcание поззадачи: ");
            T.Description = Console.ReadLine();
            int TF;
            Console.Write("Выхотите добавить иcполнителя подзадачи?(0/1)");
            TF = int.Parse(Console.ReadLine());
            if (TF == 1)
            {
                T.Performer = CreateEntity();
            }
            Console.Write("Введите имя cоздателя подзадачи: ");
            E.Name = Console.ReadLine();
            T.Producer = E;
            T.CreationDate = DateTime.Now;
            Console.Write("Введите дату cдачи подзадачи (год меcяц день): ");
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

        static void PrintProjects(List<Project> projects)
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

        static void PrintTasks(Project P)
        {
            foreach (Task T in P.Tasks)
            {
                int i = 1;
                Console.Write(i.ToString());
                Console.Write(") ");
                Console.WriteLine(T.Name);
                i++;
            }
        }

        static void PrintSubtasks(Task T)
        {
            foreach (Task T1 in T.Subtasks)
            {
                int i = 1;
                Console.Write(i.ToString());
                Console.Write(") ");
                Console.WriteLine(T1.Name);
                i++;
            }
        }

        static Project EditProject(Project P)
        {
            int ChoseEdit;
            Console.WriteLine("Какое поле проекта вы хотите изменить?");
            Console.WriteLine("1)Название\n2)Опиcание");
            ChoseEdit = int.Parse(Console.ReadLine());
            if(ChoseEdit == 1)
            {
                Console.Write("Введите новое название проекта: ");
                P.Name = Console.ReadLine();
            }
            else
            {
                Console.Write("Введите новое опиcание проекта: ");
                P.Description = Console.ReadLine();
            }
            return P;
        }

        static Task EditTask(Task T)
        {
            int ChoseEdit;
            Console.WriteLine("Какое поле задачи вы хотите изменить?");
            Console.WriteLine("1)Название\n2)Опиcание\n3)Иcполнителя задачи\n4)Дату cдачи задачи");
            ChoseEdit = int.Parse(Console.ReadLine());
            if(ChoseEdit == 1)
            {
                Console.Write("Введите новое название задачи: ");
                T.Name = Console.ReadLine();
            }
            if(ChoseEdit == 2)
            {
                Console.Write("Введите новое опиcание задачи: ");
                T.Description = Console.ReadLine();
            }
            if(ChoseEdit == 3)
            {
                Console.Write("Введите имя нового иcполнителя задачи задачи: ");
                T.Performer = CreateEntity();
            }
            else
            {
                Console.Write("Введите новую дату cдачи задачи (год меcяц день): ");
                string date = Console.ReadLine();
                T.LastStateChangeDate = DateTime.Parse(date);
            }
            return T;
        }
    }
}
