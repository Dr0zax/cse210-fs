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
        string timestamp = DateTime.Now.ToString();
        Entry entry = new(timestamp, input);
        Entry entry2 = new(timestamp, input);
        Entry entry3 = new(timestamp, input);

        entries.Add(entry);
    }

    public void SaveFile() 
    {

    }

    public void LoadFile()
    {
        Console.WriteLine("Provide a file");
        Console.Write("> ");

        string fileName = Console.ReadLine();

        string[] lines = readFile(fileName);

        foreach (string line in lines) {
            string[] parts = line.Split(" | ");
            Entry entry = new(parts[0], parts[1]); 

            entries.Add(entry);
        }
    }
    
    private string[] readFile(string fileName) {
        try
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            return lines;
        }
        catch (System.IO.FileNotFoundException)
        {
            
            throw;
        }

    }
}