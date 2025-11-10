using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction newFraction1 = new Fraction();
        Console.WriteLine(newFraction1.GetFractionString());
        Console.WriteLine(newFraction1.GetDecimal());

        Fraction newFraction2 = new Fraction(5);
        Console.WriteLine(newFraction2.GetFractionString());
        Console.WriteLine(newFraction2.GetDecimal());

        Fraction newFraction3 = new Fraction(3, 4);
        Console.WriteLine(newFraction3.GetFractionString());
        Console.WriteLine(newFraction3.GetDecimal());

        Fraction newFraction4 = new Fraction(1, 3);
        Console.WriteLine(newFraction4.GetFractionString());
        Console.WriteLine(newFraction4.GetDecimal());
    }
}