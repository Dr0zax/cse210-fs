class Entry 
{
    // ENTRY: [timestamp] | [content]

    public string _content;
    public string _timestamp;

    public Entry(string timestamp, string content) 
    {
        _timestamp = timestamp;
        _content = content;
    }

    public void DisplayContents() 
    {
        Console.WriteLine($"{_timestamp} | {_content}");
    }
}