namespace FinalProject.GameSystems
{
    class DialogueSystem
    {
        public static void DialogueBox(string message)
        {
            if (message == "")
            {
                Console.Write("(Enter)");
            }
            else
            {
                Console.Write(message + " (Enter)");
            }
            Console.ReadLine();
        }

        public static string InputBox(string message)
        {
            Console.Write(message + "> ");
           
            string input = Console.ReadLine();
          
            return input;
        }
    }
}