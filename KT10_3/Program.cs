using System;

namespace KT10_3
{
    public struct ComplexNumber : IComparable<ComplexNumber>
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public int CompareTo(ComplexNumber other)
        {
            double thisMagnitude = Math.Sqrt(Real * Real + Imaginary * Imaginary);
            double otherMagnitude = Math.Sqrt(other.Real * other.Real + other.Imaginary * other.Imaginary);
            return thisMagnitude.CompareTo(otherMagnitude);
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }
    }

    public struct RationalNumber : IComparable<RationalNumber>
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero");

            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        public int CompareTo(RationalNumber other)
        {
            long left = (long)Numerator * other.Denominator;
            long right = (long)other.Numerator * Denominator;
            return left.CompareTo(right);
        }

        private void Simplify()
        {
            int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= gcd;
            Denominator /= gcd;

            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Complex numbers:");
            ComplexNumber complex1 = new ComplexNumber(3, 4);
            ComplexNumber complex2 = new ComplexNumber(1, 1);
            ComplexNumber complex3 = new ComplexNumber(4, 3);

            Console.WriteLine($"complex1: {complex1}");
            Console.WriteLine($"complex2: {complex2}");
            Console.WriteLine($"complex3: {complex3}");

            Console.WriteLine($"complex1.CompareTo(complex2): {complex1.CompareTo(complex2)}");
            Console.WriteLine($"complex2.CompareTo(complex1): {complex2.CompareTo(complex1)}");
            Console.WriteLine($"complex1.CompareTo(complex3): {complex1.CompareTo(complex3)}");

            Console.WriteLine("\nRational numbers:");
            RationalNumber rational1 = new RationalNumber(1, 2);
            RationalNumber rational2 = new RationalNumber(2, 3);
            RationalNumber rational3 = new RationalNumber(3, 6);

            Console.WriteLine($"rational1: {rational1}");
            Console.WriteLine($"rational2: {rational2}");
            Console.WriteLine($"rational3: {rational3}");

            Console.WriteLine($"rational1.CompareTo(rational2): {rational1.CompareTo(rational2)}");
            Console.WriteLine($"rational2.CompareTo(rational1): {rational2.CompareTo(rational1)}");
            Console.WriteLine($"rational1.CompareTo(rational3): {rational1.CompareTo(rational3)}");

            Console.WriteLine("\nFraction simplification:");
            RationalNumber simplified = new RationalNumber(4, 8);
            Console.WriteLine($"4/8 simplifies to: {simplified}");

            Console.WriteLine("\nSorting complex numbers:");
            ComplexNumber[] complexes = {
                new ComplexNumber(1, 1),
                new ComplexNumber(3, 4),
                new ComplexNumber(0, 2)
            };

            Array.Sort(complexes);
            foreach (var complex in complexes)
            {
                Console.WriteLine($"{complex}");
            }

            Console.WriteLine("\nSorting rational numbers:");
            RationalNumber[] rationals = {
                new RationalNumber(3, 4),
                new RationalNumber(1, 3),
                new RationalNumber(1, 2)
            };

            Array.Sort(rationals);
            foreach (var rational in rationals)
            {
                Console.WriteLine($"{rational}");
            }
        }
    }
}