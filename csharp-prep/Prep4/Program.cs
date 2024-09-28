using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!");
        List<int> numberList = new();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int lastInput = -1;

        int sum = 0;
        int largest = 0;

        while (lastInput != 0)
        {   
            Console.Write("Enter a number: ");
            lastInput = int.Parse(Console.ReadLine());

            if (lastInput != 0) {
                numberList.Add(lastInput);
            }
        }

        foreach (int item in numberList)
        {
            sum += item;
            largest = Math.Max(largest, item);
        }

        float average = ((float)sum) / numberList.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is {largest}");
    }
}