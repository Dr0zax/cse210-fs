using System;

class Program
{
    static void Menu()
    {
        List<string> menu = [
            "\n1. Write",
            "2. Display",
            "3. Load",
            "4. Save",
            "5. Quit",
            ""
        ];

        foreach (string item in menu)
        {
            Console.WriteLine(item);
        }
    }

    static void Main(string[] args)
    {
        Journal journal = new();

        Console.WriteLine("Welcome to the journal program! select on option from the menu below");

        bool running = true;

        while (running)
        {
            Menu();
            Console.Write("> ");
            int userInput;
            userInput = int.Parse(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    journal.AddEntry();
                    break;
                case 2:
                    journal.DisplayEntries();
                    break;
                case 3:
                    journal.LoadFile();
                    break;
                case 4:
                    journal.SaveFile();
                    break;
                case 5:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Not a valid option");
                    break;
            }
        }
    }
}