using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR7
{
    public class FirstClass
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; }

        public FirstClass(int property1, string property2)
        {
            Property1 = property1;
            Property2 = property2;
        }

        public static bool operator ==(FirstClass obj1, FirstClass obj2)
        {
            if (ReferenceEquals(obj1, obj2))
                return true;
            if (obj1 is null || obj2 is null)
                return false;

            return obj1.Property1 == obj2.Property1 && obj1.Property2 == obj2.Property2;
        }

        public static bool operator !=(FirstClass obj1, FirstClass obj2)
        {
            return !(obj1 == obj2);
        }

        public override bool Equals(object obj)
        {
            if (obj is FirstClass other)
            {
                return Property1 == other.Property1 && Property2 == other.Property2;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Property1, Property2).GetHashCode();
        }
    }
}
