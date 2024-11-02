using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssingment mathAssingment = new("Andrew Jeppesen", "Multiplication", "Section 7.3", "Problems 8-19");
        WritingAssignment writingAssignment = new("Andrew Jeppesen", "European History", "The Causes of World War II");
        // Assignment assignment = new("Andrew Jeppesen", "Multiplication");

        Console.WriteLine(mathAssingment.GetSummary());
        Console.WriteLine(mathAssingment.GetHomeworkList());

        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}