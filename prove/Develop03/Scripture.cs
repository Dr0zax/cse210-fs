class Scripture
{
    public string _scripture;
    public List<Word> _wordList = new();
    public bool _isFullyHidden = false;
    public Reference _reference;

    public Scripture(string scripture, string book, string chapter, string verse) 
    {
        _scripture = scripture;
        _reference = new(book, chapter, verse);
        GenerateWordList();
    }

    public Scripture(string scripture, string book, string chapter, string verse, string verseEnd) 
    {
        _scripture = scripture;
        _reference = new(book, chapter, verse, verseEnd);
        GenerateWordList();
    }

    public void GenerateWordList()
    {
        string[] splitScripture = _scripture.Split(" ");
        foreach (string word in splitScripture)
        {
            Word newWord = new(word);
            _wordList.Add(newWord);
        }
    }

    private void ChooseRandomWords()
    {
        Random random = new();

        for (int i = 0; i <= 3; i++)
        {
            int word = random.Next(_wordList.Count());
            if (!_wordList[word].IsHidden())
            {
                _wordList[word].Hide();
            }
        }
    }

    public void Display()
    {
        ChooseRandomWords();

        Console.Write(_reference.GetReference() + " ");
        foreach (Word word in _wordList)
        {

            Console.Write(word.GetWord() + " ");
        }
    }
}