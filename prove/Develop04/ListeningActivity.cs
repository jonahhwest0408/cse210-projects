using System;
using System.Collections.Generic;

public class ListeningActivity : Activity
{
    private int _count; 
    private List<string> _prompts;

    public ListeningActivity(string name, string description, int duration) : base(name, description, duration)
    {
        InitializePrompts();
    }

    private void InitializePrompts()
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine("Prompt: " + randomPrompt); 
        Console.WriteLine("You have a few seconds to think...");
        ShowCountDown(5); 
        GetListFromUser();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt() 
    {
        Random rnd = new Random();
        int index = rnd.Next(_prompts.Count);
        return _prompts[index];
    }

    public List<string> GetListFromUser()
    {
        Console.WriteLine("Start listing items. Press Enter after each item or press Enter to quit.");
        _count = 0;
        List<string> itemsList = new List<string>();
        string input;
        do
        {
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                itemsList.Add(input);
                _count++;
            }
        } while (!string.IsNullOrWhiteSpace(input) && _count < Duration);
        Console.WriteLine($"You listed {_count} items.");
        return itemsList;
    }
}
