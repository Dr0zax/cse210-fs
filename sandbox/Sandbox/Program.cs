using System;

class Program
{
    static void Main(string[] args)
    {
       LevelSystem levelSystem = new();

       string input = "";

       while (input != "quit")
       {
            Console.Clear();
            levelSystem.GenerateLevelBar();
            input = Console.ReadLine();
            levelSystem.AddXP(1);
       }
    }  
}