using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod13_Reflection.Serializers;

namespace Mod13_Reflection;

internal static class SerializationLoop
{
    public static void RunSerialize<T>(T argumentToSerialize, ISerializer serializer, int count) where T : new()
    {
        Console.WriteLine("\tresult: " + serializer.Serialize(new T()));

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        for (int i = 0; i < count; i++)
        {
            string st = serializer.Serialize(argumentToSerialize);
        }

        stopWatch.Stop();
        Console.WriteLine("\tticks elapsed: " + stopWatch.Elapsed.Ticks.ToString("#,0"));
    }

    public static void RunDeSerialize<T>(ISerializer serializer, int count, string path) where T : new()
    {
        T result = new();
        string st = ReadFromTextFile(path);
        Console.WriteLine("\tString looks like: " + st);

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        for (int i = 0; i < count; i++)
        {
            result = serializer.Deserialize<T>(st);
        }

        stopWatch.Stop();
        Console.WriteLine("\tDeserialization result: " + result?.ToString());
        Console.WriteLine("\tticks elapsed: " + stopWatch.Elapsed.Ticks.ToString("#,0"));


        string ReadFromTextFile(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
                Console.WriteLine("Будет десериализована такая строка: {\"i1\":11,\"i2\":22,\"i3\":33,\"i4\":44,\"i5\":55}");
                return "{\"i1\":11,\"i2\":22,\"i3\":33,\"i4\":44,\"i5\":55}";
            }
        }
    }
}
