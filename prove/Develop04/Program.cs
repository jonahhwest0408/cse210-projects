using System;

class Program
{
    static void Main(string[] args)
    {
        ShowMenu(); // Initial display of menu options

        // Loop to handle user input
        bool quit = false;
        while (!quit)
        {
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartBreathingActivity();
                    break;
                case "2":
                    StartReflectingActivity();
                    break;
                case "3":
                    StartListeningActivity();
                    break;
                case "4":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }

    static void StartBreathingActivity()
    {
        BreathingActivity breathingActivity = new BreathingActivity("Breathing", "Helps you relax by pacing your breathing", 60);
        Console.WriteLine("Starting Breathing Activity...");
        breathingActivity.Run();
        ShowMenu();
    }

    static void StartReflectingActivity()
    {
        ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting", "Reflect on times in your life when you have shown strength and resilience", 180);
        Console.WriteLine("Starting Reflecting Activity...");
        reflectingActivity.Run();
        ShowMenu();
    }

    static void StartListeningActivity()
    {
        ListeningActivity listeningActivity = new ListeningActivity("Listening", "Reflect on the good things in your life by listing them", 120);
        Console.WriteLine("Starting Listening Activity...");
        listeningActivity.Run();
        ShowMenu();
    }

    static void ShowMenu()
    {
        // Display menu options
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflecting activity");
        Console.WriteLine("3. Start listening activity");
        Console.WriteLine("4. Quit");
    }
}
