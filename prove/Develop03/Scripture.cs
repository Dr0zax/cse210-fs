class Scripture
{
    private List<Word> _wordList = new();
    private bool _isFullyHidden = false;
    private int _hiddenCount = 0;
    private string _scripture;
    private Reference _reference;

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

    private void GenerateWordList()
    {
        string[] splitScripture = _scripture.Split(" ");
        foreach (string word in splitScripture)
        {
            Word newWord = new(word);
            _wordList.Add(newWord);
        }
    }

    private void ChooseRandomWord()
    {
        if (_hiddenCount == _wordList.Count())
        {
            _isFullyHidden = true;
        }

        Random random = new();
        int word = random.Next(_wordList.Count());
        if (!_wordList[word].IsHidden())
        {
            _wordList[word].Hide();
            _hiddenCount += 1;
        }
        else if (!_isFullyHidden)
        {
            ChooseRandomWord();
        }
    }

    public void Display()
    {
        if (!_isFullyHidden)
        {
            for (int i = 1; i <= 3; i++)
            {
                ChooseRandomWord();
            }

            Console.WriteLine(_reference.GetReference());
            foreach (Word word in _wordList)
            {
                Console.Write(word.GetWord() + " ");
            }
        }
    }

    public bool IsFullyHidden()
    {
        return _isFullyHidden;
    }
}