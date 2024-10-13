class Costume
{
    // Attributes
    public string _headWear;
    public string _handWear;
    public string _footWear;
    public string _upperBodyWear;
    public string _lowerBodyWear;
    public string _accessoryWear;

    // Constructor

    public Costume(string head, string hand, string foot, string upperBody, string lowerBody, string accessory)
    {
        _headWear = head;
        _handWear = hand;
        _footWear = foot;
        _upperBodyWear = upperBody;
        _lowerBodyWear = lowerBody;
        _accessoryWear = accessory;
    }

    // Behaviors
    public void ShowWardobe()
    {
        string result = "";
        result += "Head wear: " + _headWear;
        result += "\nHand wear: " + _handWear;
        result += "\nFoot wear: " + _footWear;
        result += "\nUpper body wear: " + _upperBodyWear;
        result += "\nLower body wear: " + _lowerBodyWear;
        result += "\nAccessory: " + _accessoryWear;
        Console.WriteLine(result);
    }
}