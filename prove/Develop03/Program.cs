using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new("And my father dwelt in a tent.", "1 Nephi", "2", "15");
        
        scripture.Display();
        Console.WriteLine();
        scripture.Display();
    }
}