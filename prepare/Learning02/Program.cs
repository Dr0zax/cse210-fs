using System;

class Program
{
    static void Main(string[] args)
    {

        Job job = new();
        job._company = "Mircosoft";
        job._jobTitle = "Software Engineer";
        job._startYear = 2028;
        job._endYear = 2032;

        Job job1 = new();
        job1._jobTitle = "Software Engineer";
        job1._company = "Apple";
        job1._startYear = 2033;
        job1._endYear = 2039;

        Resume resume = new();
        resume._name = "Andrew Jeppesen";
        resume._jobs.Add(job);
        resume._jobs.Add(job1);

        resume.Display();
    }
}