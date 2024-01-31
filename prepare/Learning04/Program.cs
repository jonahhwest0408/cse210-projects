using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Samuel Bennet", "Math");
        Console.WriteLine(a1.GetSummary());
        
        MathAssignment a2 = new MathAssignment("Jonah West", "Division", "4", "19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Jonah West", "History", "The Black Plague");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.WritingInformation());
    }
}