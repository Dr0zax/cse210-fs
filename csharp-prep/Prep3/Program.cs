using System;

class Program
{
    static void Main(string[] args)
    {
        Random rng = new Random();
        bool playing = true;

        while (playing) {
            int guess = -1;
            int magicNumber = rng.Next(1, 101);
            int guesses = 0;

            while (guess != magicNumber)
            {
                guesses++;
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                if (guess > magicNumber) {
                    Console.WriteLine("Lower");
                } 
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"You made {guesses} guess(es)!");
                }
            }

            Console.Write("Play again? ");
            string answer = Console.ReadLine();

            if (answer != "yes") {
                playing = false;
            }
        }
        
    }
}