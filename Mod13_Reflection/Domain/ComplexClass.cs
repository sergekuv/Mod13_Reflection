using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod13_Reflection.Domain
{
    internal class ComplexClass
    {
        public int IntProperty { get; set; }
        public decimal DecimalProperty { get; set; }
        public string StringProperty { get; set; }
        public F[] FProperty { get; set; }

        public ComplexClass()
        {
            IntProperty = 111;
            DecimalProperty = 222.22M;
            StringProperty = "s : t , r i n g";
            FProperty = new F[2]
            {
                new F(){ i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 },
                new F(){ i1 = 5, i2 = 4, i3 = 3, i4 = 2, i5 = 1 },
            };
        }
    }
}
