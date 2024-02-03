using System;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration; // Changed access modifier to protected

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name} activity: {_description}");
        Console.WriteLine($"Duration: {_duration} seconds");
        Console.WriteLine("Get ready...");
        ShowSpinner(3); // Show spinner for 3 seconds
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Congratulations! You have completed the {_name} activity.");
        Console.WriteLine($"Total duration: {_duration} seconds");
        Console.WriteLine("Well done!");
        ShowSpinner(3); // Show spinner for 3 seconds
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}... ");
            Thread.Sleep(1000); // Pause for 1 second
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        // Implementation of countdown display
    }
    protected int Duration => _duration;
}



