class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        TitleScreen();

        Game game = new();

        game.RunGame();
    }

    static void TitleScreen()
    {
        int consoleSizeWidth = Console.WindowWidth;
        int consoleSizeHeight = Console.WindowHeight;

        string[] title = [
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

        Console.SetCursorPosition(Console.CursorLeft, (consoleSizeHeight - title.Length) / 2);

        foreach (string line in title)
        {
            Console.SetCursorPosition((consoleSizeWidth - line.Length) / 2, Console.CursorTop);
            Console.WriteLine(line);
        }

        Console.SetCursorPosition(0, consoleSizeHeight - 1);
        Console.ReadLine();
        Console.Clear();
    }

}