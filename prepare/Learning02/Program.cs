using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();  //instance of the Job class being created and assigned to the variable job1. job1 is the box holding the 4 variables.//
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();  //instance of the Job class being created and assigned to the variable job2. job2 is the box holding the 4 variables.//
        job2._company = "Apple";
        job2._jobTitle = "Manager";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume myResume = new Resume();  //instance of the Resume class being created and assigned to the variable myResume.//
        myResume._name = "Jonah West";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}