class Entry 
{   
    // Entry:
    // [timestamp] | [prompt]
    // [content]

    public string _timestamp;
    public string _prompt;
    public string _content;

    public Entry(string timestamp, string prompt, string content) 
    {
        _timestamp = timestamp;
        _prompt = prompt;
        _content = content;
    }
    public void DisplayContents() 
    {
        Console.WriteLine($"\n{_timestamp} | {_prompt}");
        Console.WriteLine($"{_content}");
    }

    public string getContents()
    {
        return $"{_timestamp},,{_prompt},,{_content}";
    }
}