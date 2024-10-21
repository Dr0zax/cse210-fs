using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new();
        Console.WriteLine(fraction1.GetFractionalValue());
        Console.WriteLine(fraction1.GetDecimalValue());

        Fraction fraction2 = new(6);
        Console.WriteLine(fraction2.GetFractionalValue());
        Console.WriteLine(fraction2.GetDecimalValue());

        Fraction fraction3 = new(6, 7);
        Console.WriteLine(fraction3.GetFractionalValue());
        Console.WriteLine(fraction3.GetDecimalValue());
    }
}