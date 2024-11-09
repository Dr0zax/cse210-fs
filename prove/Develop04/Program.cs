using System.Collections.Generic;

class Program
{
    static Dictionary<string, int> _log = new(){
        {"Breathing", 0},
        {"Relfection", 0},
        {"Lisiting", 0}
    };
    
    static void Menu()
    {
        List<string> menu = [
            "1. Start Breathing Activity",
            "2. Start Relfection Activity",
            "3. Start Lisitng Activity",
            "4. Quit"
        ];

        Console.WriteLine("Select an item from the menu:");

        foreach (string item in menu)
        {
            Console.WriteLine(item);
        }
    }

    static void Main(string[] args)
    {
        BreathingActivity breathingActivity = new("breathing activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        ReflectionActivity reflectionActivity = new("relfection activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        ListingActivity listingActivity = new("listing activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        bool running = true;
        while (running)
        {
            Console.Clear();
            Menu();
            Console.Write("> ");
            int userInput = int.Parse(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    _log["Breathing"]++;
                    Console.Clear();
                    breathingActivity.Activity();
                    break;
                case 2:
                    _log["Relfection"]++;
                    Console.Clear();
                    reflectionActivity.Activity();
                    break;
                case 3:
                    _log["Lisiting"]++;
                    Console.Clear();
                    listingActivity.Activity();
                    break;
                case 4:
                    running = false;
                    for (int i = 0; i < _log.Count; i++)
                    {
                        Console.WriteLine($"You completed the {_log.Keys.ElementAt(i)} Activity {_log.Values.ElementAt(i)} time(s)");
                    }
                    break;
                default:
                    Console.WriteLine("Not a valid option");
                    break;
            }
        }
    }
}