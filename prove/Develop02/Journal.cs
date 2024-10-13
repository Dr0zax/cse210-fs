class Journal 
{
    public List<Entry> entries = new();

    public void DisplayEntries() 
    {
        foreach (Entry entry in entries)
        {
            entry.DisplayContents();
        }
    }

    public void AddEntry() 
    {
        PromptGenerator promptGenerator = new();
        string prompt = promptGenerator.GeneratePrompt();

        Console.WriteLine(prompt);
        Console.Write("> ");
        
        string input = Console.ReadLine();
        string timestamp = DateTime.Now.ToShortDateString();
        Entry entry = new(timestamp, prompt, input);

        entries.Add(entry);
    }

    public void SaveFile() 
    {
        Console.WriteLine("Enter the name of the file (do not include file extention)");
        Console.Write("> ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter($"{fileName}.csv"))
        {
          foreach (Entry entry in entries)
          {
            outputFile.WriteLine(entry.getContents());
          }
        };
    }

    public void LoadFile()
    {
        entries.Clear();

        Console.WriteLine("Provide the file");
        Console.Write("> ");

        string fileName = Console.ReadLine();

        string[] lines = readFile(fileName);

        foreach (string line in lines) {
            string[] parts = line.Split(",,");
            string timestamp = parts[0];
            string prompt = parts[1];
            string content = parts[2];
            Entry entry = new(timestamp, prompt, content); 

            entries.Add(entry);
        }
    }
    
    private string[] readFile(string fileName) {
        string[] lines = System.IO.File.ReadAllLines(fileName);
        return lines;
    }
}