using System;
using System.ComponentModel.Design;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("    1. Create New Goal");
            Console.WriteLine("    2. List Goals");
            Console.WriteLine("    3. Save Goals");
            Console.WriteLine("    4. Load Goals");
            Console.WriteLine("    5. Record Event");
            Console.WriteLine("    6. Quit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("List of Goal Names:");

        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.Name);
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("List of Goal Details:");

        foreach (var goal in _goals)
        {
            Console.WriteLine($"Name: {goal.Name}");
            Console.WriteLine($"Description: {goal.Description}");

            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"Completed: {checklistGoal.AmountCompleted}/{checklistGoal.Target}");
            }

            Console.WriteLine();
        }
        Start();
    }

    public void CreateGoal()
    {
        Console.WriteLine("The type of goals are:");
        Console.WriteLine("    1. Simple Goal");
        Console.WriteLine("    2. Eternal Goal");
        Console.WriteLine("    3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalTypeChoice = Console.ReadLine();

        string name, description, points;
        int bonusFrequency = 0;
        int bonusPoints = 0;

        Console.Write("What is the name of your goal? ");
        name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        points = Console.ReadLine();

        _score += int.Parse(points); 

        int target = 0;

         if (goalTypeChoice == "3") 
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus amount of points for completing this goal? ");
            bonusPoints = int.Parse(Console.ReadLine());
        }

        switch (goalTypeChoice)
        {
        case "1":
            _goals.Add(new SimpleGoal(name, description, points));
            break;
        case "2":
            _goals.Add(new EternalGoals(name, description, points));
            break;
        case "3":
            _goals.Add(new ChecklistGoal(name, description, points, bonusFrequency, target, bonusPoints));
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
        }
        Start();
    }

    public void RecordEvent()
    {
        Console.WriteLine("Your goals are:"); //display the list of goals with corresponding numbers//
        for (int i = 0; i < _goals.Count; i++)
        {
            var goal = _goals[i];
            string completionStatus = goal is ChecklistGoal checklistGoal
                ? $"Completed: {checklistGoal.AmountCompleted}/{checklistGoal.Target}"
                : string.Empty;
            Console.WriteLine($"{i + 1}. {goal.Name} {completionStatus}");
        }

        Console.Write("What did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int selectedGoalIndex) && selectedGoalIndex > 0 && selectedGoalIndex <= _goals.Count)
        {
            var selectedGoal = _goals[selectedGoalIndex - 1];
            int pointsEarned = int.Parse(selectedGoal.Points);
            _score += pointsEarned;

            if (selectedGoal is ChecklistGoal checklistGoal)
            {
                checklistGoal.RecordCompletion();
            }

            Console.WriteLine($"Congratulations! You now have earned {pointsEarned} points!");

            DisplayPlayerInfo();
        }
        else
        {
            Console.WriteLine("Invalid input. Please select a valid goal.");
        }

        Start();
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var goal in _goals)
                {
                    if (goal is ChecklistGoal checklistGoal)
                    {
                        writer.WriteLine($"{_score}");
                        writer.WriteLine($"ChecklistGoal // {goal.Name}: {goal.Description} ({checklistGoal.AmountCompleted}/{checklistGoal.Target}) // {goal.Points}");
                    }
                    else
                    {
                        writer.WriteLine($"{_score}");
                        writer.WriteLine($"{goal.GetType().Name} // {goal.Name}: {goal.Description} // {goal.Points}");
                    }
                }
            }

            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter the name of the file containing the goals: ");
        string fileName = Console.ReadLine();

    try
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            _goals.Clear();

            string scoreLine = reader.ReadLine();
            if (scoreLine != null && int.TryParse(scoreLine, out int score))
            {
                _score = score;
            }

            while (!reader.EndOfStream)
            {
                string goalLine = reader.ReadLine();
                if (goalLine != null)
                {
                    string[] parts = goalLine.Split(new string[] { "//" }, StringSplitOptions.None);
                    if (parts.Length == 3)
                    {
                        string[] details = parts[1].Split(new string[] { ": " }, StringSplitOptions.None);
                        if (details.Length == 2)
                        {
                            string[] typeAndName = parts[0].Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                            string type = typeAndName[0].Trim();
                            string name = details[0].Trim();
                            string description = details[1].Trim();
                            string points = parts[2].Trim();

                            if (type == "ChecklistGoal")
                            {
                                string[] completionDetails = description.Split(new string[] { "(", "/", ")" }, StringSplitOptions.RemoveEmptyEntries);
                                if (completionDetails.Length == 3 && int.TryParse(completionDetails[1], out int amountCompleted) && int.TryParse(completionDetails[2], out int target))
                                {
                                    _goals.Add(new ChecklistGoal(name, description, points, amountCompleted, target, int.Parse(points)));
                                }
                            }
                            else
                            {
                                _goals.Add(new SimpleGoal(name, description, points));
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while loading goals: {ex.Message}");
    }
    if (!Console.IsOutputRedirected)
    {
        //attempt to clear the console//
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            Console.WriteLine("Unable to clear console. Press any key to return to the start menu..."); //handle the case where the console cannot be cleared//
            Console.ReadKey();
        }
    }
    Start(); 
    }

}
