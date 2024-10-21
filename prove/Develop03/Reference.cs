class Reference
{
    public string _book;
    public string _chapter;
    public string _verse;
    public string _verseEnd;

    public Reference(string book, string chapter, string verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public Reference(string book, string chapter, string verse, string verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _verseEnd = verseEnd;
    }

    public string GetReference()
    {
        if (_verseEnd != null)
        {
            return $"{_book} {_chapter}: {_verse}-{_verseEnd}";
        } 
        else
        {
            return $"{_book} {_chapter}: {_verse}";
        }
    }
}