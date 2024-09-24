using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please input grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());
        int lastDigit = gradePercentage % 10;

        string grade;
        bool passed = false;

        if (gradePercentage >= 90)
        {
            grade = "A";
            passed = true;
        }
        else if (gradePercentage >= 80)
        {
            grade = "B";
            passed = true;
        }
        else if (gradePercentage >= 70)
        {
            grade = "C";
            passed = true;
        }
        else if (gradePercentage >= 70)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        if (lastDigit >= 7 && grade != "F")
        {
                grade = grade + "+";
        }
        else if (lastDigit < 3 && grade != "F")
        {
                grade = grade + "-";
        }

        Console.WriteLine($"Your grade is: {grade}");

        if (passed)
        {
            Console.WriteLine("You have passed your class");
        }
        else 
        {
            Console.WriteLine("Your grade is not high enough to pass.");
            Console.WriteLine("Dont give up! You can always take the class again.");
        }
    }
}