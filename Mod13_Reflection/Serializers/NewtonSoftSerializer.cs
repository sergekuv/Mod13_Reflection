namespace Mod13_Reflection.Serializers;

internal class NewtonSoftSerializer : ISerializer
{
    public string Serialize(object obj)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
    }

    public T Deserialize<T>(string st) where T : new()
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(st);
    }
}
