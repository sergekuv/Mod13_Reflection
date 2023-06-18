using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Mod13_Reflection.Serializers;

internal class MySlowSerializer : ISerializer
{
    public string Serialize(object obj)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("{");

        foreach (PropertyInfo pInfo in obj.GetType().GetProperties())
        {
            sb.Append("\"" + pInfo.Name + "\"");
            sb.Append(":");
            sb.Append(pInfo.GetValue(obj, null));
            sb.Append(",");
        }
        sb.Remove(sb.Length - 1, 1);
        sb.Append("}");
        return sb.ToString();
    }

    public T Deserialize<T>(string st) where T : new()
    {
        T t = new T();

        //Разбиваем строку на словарь из полей и значений
        //Корректно работать это будет далеко не всегда
        st = st.Trim(new char[] { ' ', '{', '}' });
        string[] propValueArray = st.Split(',');
        Dictionary<string, string> propValueDict = CreatePropValueDict(propValueArray);

        foreach (var prop in t.GetType().GetProperties())
        {
            var converter = TypeDescriptor.GetConverter(prop.PropertyType);
            if (converter != null)
            {
                try
                {
                    var valueToSet = converter.ConvertFromString(propValueDict[prop.Name]);
                    prop.SetValue(t, valueToSet);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        return t;
    }

    private static T Convert<T>(string input)
    {
        try
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                // Cast ConvertFromString(string text) : object to (T)
                return (T)converter.ConvertFromString(input);
            }
            return default(T);
        }
        catch (NotSupportedException)
        {
            return default(T);
        }
    }
    private Dictionary<string, string> CreatePropValueDict(string[] propValueArray)
    {
        Dictionary<string, string> dict = new();

        foreach (string item in propValueArray)
        {
            try
            {
                string[] st = item.Split(':');
                string key = st[0].Trim('"');
                string value = st[1];
                dict.Add(key, value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to create add pair {item} to dictionary: ");
            }
        }
        return dict;
    }
}
