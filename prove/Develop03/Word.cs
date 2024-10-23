class Word
{
    private string _word;
    private bool _hidden = false;

    public Word(string word)
    {
        _word = word;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public void Show()
    {
        _hidden = false;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public string GetWord()
    {
        if (!_hidden)
        {
            return _word;
        }
        else
        {
            string hiddenWord = "";
            foreach (char letter in _word)
            {
                hiddenWord += "_";
            }
            return hiddenWord;
        }
    }
}