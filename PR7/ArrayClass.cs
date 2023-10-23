using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR7
{
    public class ArrayClass
    {
        private int[] array;

        public ArrayClass(params int[] elements)
        {
            array = elements;
        }

        public static bool operator <(ArrayClass obj1, ArrayClass obj2)
        {
            return obj1.array.Sum() < obj2.array.Sum();
        }

        public static bool operator >(ArrayClass obj1, ArrayClass obj2)
        {
            return obj1.array.Sum() > obj2.array.Sum();
        }
    }
}
