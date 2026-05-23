using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        int value = 1;
        int value2 = 4;
        Fraction fraction = new Fraction();
        Fraction fraction1 = new Fraction(value);
        Fraction fraction2 = new Fraction(value, value2);

        fraction.SetTop(1);
        fraction.SetBottom(2);

        Console.WriteLine(fraction.GetDecimalValue());
        Console.WriteLine(fraction.GetFractionString());

        Console.WriteLine(fraction1.GetDecimalValue());
        Console.WriteLine(fraction1.GetFractionString());

        Console.WriteLine(fraction2.GetDecimalValue());
        Console.WriteLine(fraction2.GetFractionString());
    }
}