using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity(string name, string description, int duration) : base(name, description, duration)
    {
        InitializePrompts();
        InitializeQuestions();
    }

    private void InitializePrompts()
    {
        // Initialize prompts here
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
    }

    private void InitializeQuestions()
    {
        // Initialize questions here
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }

    private string GetRandomItem(List<string> list)
    {
        Random rnd = new Random();
        int index = rnd.Next(list.Count);
        return list[index];
    }

    public string GetRandomPrompt()
    {
        return GetRandomItem(_prompts);
    }

    public string GetRandomQuestion()
    {
        return GetRandomItem(_questions);
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Prompt: " + GetRandomPrompt());
        Console.WriteLine("You have a few seconds to think...");
        ShowSpinner(5); // Show spinner for 5 seconds
    }

    public void DisplayQuestions()
    {
        foreach (var question in _questions)
        {
            Console.WriteLine($"Question: {question}");
            ShowSpinner(5); // Show spinner for 5 seconds
        }
    }
}
