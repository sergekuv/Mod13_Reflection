using Mod13_Reflection.Domain;
using Mod13_Reflection.Serializers;
using System.Reflection.Metadata.Ecma335;

namespace Mod13_Reflection;


internal class Program
{
    static void Main(string[] args)
    {
        SerializationActions();
        DeSerializationActions();

        void DeSerializationActions()
        {
            int deSerializationIiterations = 100;
            Console.WriteLine("\n--DeSerialization--");
            Console.WriteLine("iterations in deserialization loop: " + deSerializationIiterations);

            string path = "Data\\ClassFSerialized2.txt";
            Console.WriteLine("\nNewtonSoft");
            SerializationLoop.RunDeSerialize<F>(new NewtonSoftSerializer(), deSerializationIiterations, path);

            Console.WriteLine("\nSystemText");
            SerializationLoop.RunDeSerialize<F>(new SystemTextSerizlizer(), deSerializationIiterations, path);

            Console.WriteLine("\nMySlowDeSerializer");
            SerializationLoop.RunDeSerialize<F>(new MySlowSerializer(), deSerializationIiterations, path);

        }

        void SerializationActions()
        {
            int serializationIiterations = 100;
            F argument = new();
            Console.WriteLine("--Serialization--");
            Console.WriteLine($"This is how newly created {argument.GetType()} object looks like: \n" + argument.ToString());
            Console.WriteLine("Iterations in serialization loop: " + serializationIiterations);

            Console.WriteLine("\nNewtonSoft");
            SerializationLoop.RunSerialize<F>(argument, new NewtonSoftSerializer(), serializationIiterations);

            Console.WriteLine("\nSystemText");
            SerializationLoop.RunSerialize<F>(argument, new SystemTextSerizlizer(), serializationIiterations);

            Console.WriteLine("\nMySlowSerializer");
            SerializationLoop.RunSerialize<F>(argument, new MySlowSerializer(), serializationIiterations);
            Console.WriteLine();
        }
    }
}