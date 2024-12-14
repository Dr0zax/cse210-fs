using FinalProject.GameSystems;

class Program
{
    static void Main(string[] args)
    {
        Game game = new();

        Console.Clear();
        TitleScreen();

        game.Run();

        DialogueSystem.DialogueBox("Thank You For Playing!");
    }

    static void TitleScreen()
    {
        int consoleSizeWidth = Console.WindowWidth;
        int consoleSizeHeight = Console.WindowHeight;

        string[] titleLarge = [
            "  _____    _____     _____     _______   _       _                 ",
            " |  __ \\  |  __ \\   / ____|   |__   __| | |     (_)                ",
            " | |__) | | |__) | | |  __       | |    | |__    _   _ __     __ _ ",
            " |  _  /  |  ___/  | | |_ |      | |    | '_ \\  | | | '_ \\   / _` |",
            " | | \\ \\  | |      | |__| |      | |    | | | | | | | | | | | (_| |",
            " |_|  \\_\\ |_|       \\_____|      |_|    |_| |_| |_| |_| |_|  \\__, |",
            "                                                              __/ |",
            "                                                             |___/ ",
            "",
            "Andrew Jeppesen",
            "",
            "Press Enter to Begin"
        ];

        string[] titleSmall = [
            "Rpg Thing",
            "",
            "Andrew Jeppesen",
            "",
            "Press Enter to Begin"
        ];

        try {
            Console.SetCursorPosition(Console.CursorLeft, (consoleSizeHeight - titleLarge.Length) / 2);

            foreach (string line in titleLarge)
            {
                Console.SetCursorPosition((consoleSizeWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line);
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            foreach (string line in titleSmall)
            {
                Console.SetCursorPosition((consoleSizeWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line);
            }
        }

        Console.SetCursorPosition(0, consoleSizeHeight - 1);
        DialogueSystem.DialogueBox("");
        Console.Clear();
    }

}