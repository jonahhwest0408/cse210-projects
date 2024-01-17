using System;

public class Resume 
{
    public string _name;  //member variable//

    public List<Job> _jobs = new List<Job>();  //list of Job named _jobs//
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");  
        Console.WriteLine($"Jobs:");

        foreach (Job job in _jobs)  //loop that iterates over each element in the _jobs list aka Job.cs//
        {                           //Job job declares a variable named job of type Job the represents each element in the _jobs list//
            job.Display();          //Inside the foreach loop, the Display method of each Job object is called. This is achieved by invoking the Display method on the job variable, which represents an individual job in the _jobs list.//
        }
    }
}

