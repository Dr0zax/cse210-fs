using System;

class Program
{
    static void Main()
    {
        Scripture scripture = new("Therefore go, my son, and thou shalt be favored of the Lord, because thou hast not murmured.\nAnd it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.", "1 Nephi", "3", "6", "7");
        
        Console.WriteLine("Welcome to the scripture memorizer!");
        Console.WriteLine("Press enter to hide more words, type \"quit\" to close the program");
        Console.Write("How many words do you want to hide?: ");
        int amountToHide = int.Parse(Console.ReadLine()); 

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the scripture memorizer!");
            Console.WriteLine("Press enter to hide more words, type \"quit\" to close the program");
            Console.WriteLine();
            scripture.Display(amountToHide);
            Console.Write("> ");
            string input = Console.ReadLine();

            if (scripture.IsFullyHidden())
            {
                Console.WriteLine("The scripture has been fully hidden");
                running = false;
            }

            if (input == "quit")
            {
                running = false;
            }
        }
    }
}