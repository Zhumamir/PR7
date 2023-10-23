using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR7
{
    public class Frac
    {
        public int Numerator { get; }
        public int Denominator { get; }

        public Frac(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public double ToDouble()
        {
            return (double)Numerator / Denominator;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Frac other = (Frac)obj;
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public override int GetHashCode()
        {
            return Numerator.GetHashCode() ^ Denominator.GetHashCode();
        }

        public static bool operator ==(Frac a, Frac b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (a is null || b is null)
                return false;

            return a.Numerator == b.Numerator && a.Denominator == b.Denominator;
        }

        public static bool operator !=(Frac a, Frac b)
        {
            return !(a == b);
        }

        public static Frac operator +(Frac a, Frac b)
        {
            int commonDenominator = a.Denominator * b.Denominator;
            int newNumerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            return Simplify(new Frac(newNumerator, commonDenominator));
        }

        public static Frac operator -(Frac a, Frac b)
        {
            int commonDenominator = a.Denominator * b.Denominator;
            int newNumerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            return Simplify(new Frac(newNumerator, commonDenominator));
        }

        public static Frac operator *(Frac a, Frac b)
        {
            int newNumerator = a.Numerator * b.Numerator;
            int newDenominator = a.Denominator * b.Denominator;
            return Simplify(new Frac(newNumerator, newDenominator));
        }

        public static Frac operator /(Frac a, Frac b)
        {
            int newNumerator = a.Numerator * b.Denominator;
            int newDenominator = a.Denominator * b.Numerator;
            return Simplify(new Frac(newNumerator, newDenominator));
        }

        private static int GCD(int a, int b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }

        private static Frac Simplify(Frac frac)
        {
            int gcd = GCD(frac.Numerator, frac.Denominator);
            return new Frac(frac.Numerator / gcd, frac.Denominator / gcd);
        }

        public double EvaluatePolynomial(double x, params Frac[] coefficients)
        {
            double result = 0.0;
            double xPower = 1.0;

            foreach (Frac coefficient in coefficients)
            {
                result += coefficient.ToDouble() * xPower;
                xPower *= x;
            }

            return result;
        }
    }
}
