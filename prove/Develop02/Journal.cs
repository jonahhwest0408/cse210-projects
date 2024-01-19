using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void WriteNewEntry()
    {
        
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();  //Generates random prompts from the list//
        int randomIndex = random.Next(prompts.Length);
        string prompt = prompts[randomIndex];

        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Entry entry = new Entry(prompt, response);
        _entries.Add(entry);

        // Encouraging comment based on your preference
        string encouragingComment = GetEncouragingComment();
        Console.WriteLine(encouragingComment);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter a filename to save the journal: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename)) //StreamWriter object used to write the filename. "using" ensures StreamWriter is properly disposed//
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._prompt},{entry._response},{entry._dateString}"); //writer.Writeline = used to write text to a file specified by TextWriter//
            }
        }

        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile()
{
    Console.Write("Enter a filename to load the journal from: ");
    string filename = Console.ReadLine();

    if (File.Exists(filename))
    {
        _entries.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(',');
                string prompt = line[0];
                string response = line[1];
                string dateString = line[2]; //Assuming date is stored as a string//

                
                Entry entry = new Entry(prompt, response) //You can directly use dateString as it is stored as a string//
                {
                    _dateString = dateString
                };
                
                _entries.Add(entry);
            }
        }

        Console.WriteLine("Journal loaded successfully.");
    }
    else
    {
        Console.WriteLine("File not found. Please enter a valid filename.");
    }
}

private string GetEncouragingComment()
    {
        // You can customize this method to provide different encouraging comments
        string[] encouragingComments = {
            "Nice job!",
            "You're awesome!",
            "Great reflection!",
            "Well done!",
            "Keep it up!"
        };

        Random random = new Random();
        int randomIndex = random.Next(encouragingComments.Length);
        return encouragingComments[randomIndex];
    }

}
