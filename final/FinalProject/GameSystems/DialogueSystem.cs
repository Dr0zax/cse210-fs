namespace FinalProject.GameSystems
{
    class DialogueSystem
    {
        public static void DialogueBox(string message)
        {
            Console.Write(message + " (Enter)");
            Console.ReadLine();
        }

        public static string InputBox(string message)
        {
            Console.Write(message + "> ");
            return Console.ReadLine();
        }
    }
}