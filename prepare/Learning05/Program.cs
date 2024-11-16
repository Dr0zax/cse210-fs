using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new();

        shapes.Add(new Square("Green", 10));
        shapes.Add(new Rectangle("Red", 10, 20));
        shapes.Add(new Circle("Purple", 5));
        
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}");
        }
    }
}