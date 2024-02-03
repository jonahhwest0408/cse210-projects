using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description, int duration) : base(name, description, duration)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        BreatheInAndOut();
        DisplayEndingMessage();
    }

    private void BreatheInAndOut()
    {
        int durationInSeconds = _duration;
        while (durationInSeconds > 0)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(3); // Show countdown for 3 seconds

            Console.WriteLine("Breathe out...");
            ShowCountDown(3); // Show countdown for 3 seconds

            durationInSeconds -= 6; // Each cycle takes 6 seconds (3 seconds for inhaling and 3 seconds for exhaling)
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}... ");
            Thread.Sleep(1000); // Pause for 1 second
        }
        Console.WriteLine();
    }
}
