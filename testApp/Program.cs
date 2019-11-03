using EmptyBox.IO.Serializator;
using System;
using System.Text;
using Tractor.Core;
using Tractor.Core.Model;

namespace testApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Task T = new Task(Guid.NewGuid());
            Project P = new Project();
            Entity E = new Entity();
            Entity E1 = new Entity();
            Entity E2 = new Entity();
            T.State = TaskState.InWork;
            CreateProject(P);
            CreateTask(T, E, E1);
            CreateEntity(E2);
            BinarySerializer ser = new BinarySerializer(Encoding.UTF32);
            Guid[] a0 = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            byte[] arra = ser.Serialize(a0);
            Guid[] a1 = ser.Deserialize<Guid[]>(arra);
            Console.ReadKey();
        }

        static void CreateProject(Project P)
        {
            Console.Write("Введите назваие проекта: ");
            P.Name = Console.ReadLine();
            Console.Write("Введите опиcание проекта: ");
            P.Description = Console.ReadLine();
        }

        static void CreateTask(Task T, Entity E, Entity E1)
        {
            Console.Write("Введите название задачи: ");
            T.Name = Console.ReadLine();
            Console.Write("Введите опиcание задачи: ");
            T.Description = Console.ReadLine();
            Console.Write("Введите имя работника: ");
            E.Name = Console.ReadLine();
            T.Performer = E;
            Console.Write("Введите имя начальника: ");
            E1.Name = Console.ReadLine();
            T.Producer = E1;
            T.CreationDate = DateTime.Now;
            Console.Write("Введите дату cдачи задачи (год меcяц день): ");
            int Year = int.Parse(Console.ReadLine());
            int Month = int.Parse(Console.ReadLine());
            int Day = int.Parse(Console.ReadLine());
            T.LastStateChangeDate = new DateTime(Year, Month, Day);
            T.State = TaskState.ToDo;
        }

        static void CreateEntity(Entity E)
        {
            Console.Write("Введите имя работника: ");
            E.Name = Console.ReadLine();
        }
    }
}
