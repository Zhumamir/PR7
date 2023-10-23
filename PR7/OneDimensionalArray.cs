using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR7
{
    public class OneDimensionalArray
    {
        private int[] array;

        public OneDimensionalArray(int size)
        {
            array = new int[size];
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= array.Length)
                    throw new IndexOutOfRangeException("Index is out of range.");
                return array[index];
            }
            set
            {
                if (index < 0 || index >= array.Length)
                    throw new IndexOutOfRangeException("Index is out of range.");
                array[index] = value;
            }
        }

        public static bool operator ==(OneDimensionalArray a, OneDimensionalArray b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a is null || b is null)
                return false;
            if (a.array.Length != b.array.Length)
                return false;

            for (int i = 0; i < a.array.Length; i++)
            {
                if (a.array[i] != b.array[i])
                    return false;
            }

            return true;
        }

        public static bool operator !=(OneDimensionalArray a, OneDimensionalArray b)
        {
            return !(a == b);
        }

        public static int operator *(OneDimensionalArray a, OneDimensionalArray b)
        {
            if (a.array.Length != b.array.Length)
                throw new ArgumentException("Arrays must be of the same length for multiplication.");

            int result = 0;

            for (int i = 0; i < a.array.Length; i++)
            {
                result += a[i] * b[i];
            }

            return result;
        }

        public static OneDimensionalArray operator +(OneDimensionalArray a, OneDimensionalArray b)
        {
            if (a.array.Length != b.array.Length)
                throw new ArgumentException("Arrays must be of the same length for addition.");

            OneDimensionalArray result = new OneDimensionalArray(a.array.Length);

            for (int i = 0; i < a.array.Length; i++)
            {
                result[i] = a[i] + b[i];
            }

            return result;
        }

        public static int operator <=(OneDimensionalArray a, OneDimensionalArray b)
        {
            if (a.array.Length != b.array.Length)
                throw new ArgumentException("Arrays must be of the same length for comparison.");

            for (int i = 0; i < a.array.Length; i++)
            {
                if (a[i] > b[i])
                    return false;
            }

            return true;
        }

        public static implicit operator int(OneDimensionalArray a)
        {
            return a.array.Length;
        }
    }

}
