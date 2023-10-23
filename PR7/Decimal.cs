using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR7
{
    public class Decimal
    {
        private char[] digits = new char[100];
        public static bool operator >(Decimal a, Decimal b)
        {
            for (int i = 0; i < 100; i++)
            {
                if (a.digits[i] > b.digits[i])
                    return true;
                if (a.digits[i] < b.digits[i])
                    return false;
            }
            return false; 
        }

        public static bool operator <(Decimal a, Decimal b)
        {
            return !(a > b) && a != b;
        }

        public static bool operator >=(Decimal a, Decimal b)
        {
            return a > b || a == b;
        }

        public static bool operator <=(Decimal a, Decimal b)
        {
            return a < b || a == b;
        }

        public Decimal(string value)
        {
            if (value.Length > 100)
                throw new ArgumentOutOfRangeException("Value is too large for Decimal.");

            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsDigit(value[i]))
                    throw new ArgumentException("Invalid character in Decimal value.");

                digits[99 - i] = value[i];
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(100);
            bool leadingZero = true;

            for (int i = 0; i < 100; i++)
            {
                if (digits[i] != '0' || !leadingZero)
                {
                    sb.Append(digits[i]);
                    leadingZero = false;
                }
            }

            if (sb.Length == 0)
                sb.Append('0');

            return sb.ToString();
        }

        public static Decimal operator +(Decimal a, Decimal b)
        {
            char[] resultDigits = new char[100];
            int carry = 0;

            for (int i = 99; i >= 0; i--)
            {
                int sum = (a.digits[i] - '0') + (b.digits[i] - '0') + carry;
                resultDigits[i] = (char)((sum % 10) + '0');
                carry = sum / 10;
            }

            return new Decimal(new string(resultDigits));
        }

        public static Decimal operator -(Decimal a, Decimal b)
        {
            char[] resultDigits = new char[100];
            int borrow = 0;

            for (int i = 99; i >= 0; i--)
            {
                int diff = (a.digits[i] - '0') - (b.digits[i] - '0') - borrow;
                if (diff < 0)
                {
                    diff += 10;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }
                resultDigits[i] = (char)(diff + '0');
            }

            return new Decimal(new string(resultDigits));
        }

        public static Decimal operator *(Decimal a, Decimal b)
        {
            Decimal result = new Decimal("0");

            for (int i = 99; i >= 0; i--)
            {
                Decimal partialProduct = MultiplyByDigit(a, b.digits[i] - '0');
                result = result + ShiftLeft(partialProduct, 99 - i);
            }

            return result;
        }

        public static Decimal operator /(Decimal a, Decimal b)
        {
            if (b == new Decimal("0"))
                throw new DivideByZeroException("Division by zero.");

            Decimal quotient = new Decimal("0");
            Decimal remainder = a;

            while (remainder >= b)
            {
                Decimal multiple = b;
                int count = 1;

                while (remainder >= (multiple + b))
                {
                    multiple = multiple + b;
                    count++;
                }

                remainder = remainder - multiple;
                quotient = quotient + new Decimal(count.ToString());
            }

            return quotient;
        }


        private static Decimal MultiplyByDigit(Decimal a, int digit)
        {
            if (digit < 0 || digit > 9)
                throw new ArgumentException("Invalid digit for multiplication.");

            char[] resultDigits = new char[100];
            int carry = 0;

            for (int i = 99; i >= 0; i--)
            {
                int product = (a.digits[i] - '0') * digit + carry;
                resultDigits[i] = (char)((product % 10) + '0');
                carry = product / 10;
            }

            return new Decimal(new string(resultDigits));
        }

        private static Decimal ShiftLeft(Decimal a, int shift)
        {
            if (shift < 0)
                throw new ArgumentException("Negative shift value.");

            char[] resultDigits = new char[100];

            for (int i = 0; i < 100; i++)
            {
                if (i + shift < 100)
                    resultDigits[i + shift] = a.digits[i];
                else
                    resultDigits[i] = '0';
            }

            return new Decimal(new string(resultDigits));
        }
    }

}
