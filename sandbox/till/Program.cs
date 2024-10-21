namespace till;

class Program
{
    static void Main(string[] args)
    {
        Bin bin = new("Dollar", 5, 1);

        bin.ModifyAmount(6);
        Console.WriteLine(bin.TotalValue());

    }
}
