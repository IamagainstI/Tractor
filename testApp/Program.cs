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
            T.CreationDate = DateTime.Now;
            T.Description = "Разобраться с непонятными моментами";
            T.LastStateChangeDate = DateTime.Now;
            T.Name = "Сериализатор";
            T.State = TaskState.InWork;
            BinarySerializer ser = new BinarySerializer(Encoding.UTF32);
            Guid[] a0 = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            byte[] arra = ser.Serialize(a0);
            Guid[] a1 = ser.Deserialize<Guid[]>(arra);
            Console.ReadKey();
        }
    }
}
