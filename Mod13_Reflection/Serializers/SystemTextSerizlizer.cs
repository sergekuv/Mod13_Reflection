using System.Text.Json;

namespace Mod13_Reflection.Serializers;

internal class SystemTextSerizlizer : ISerializer
{
    public string Serialize(object obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public T Deserialize<T>(string st) where T : new()
    {
        return JsonSerializer.Deserialize<T>(st);
    }
}
