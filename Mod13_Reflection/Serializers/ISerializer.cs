using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod13_Reflection.Serializers
{
    internal interface ISerializer
    {
        string Serialize(object obj);
        T Deserialize<T>(string st) where T : new();
    }
}
