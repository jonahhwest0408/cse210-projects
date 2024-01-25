using System; //To exceed requirements, I set up a catch block function that handles System.IO.Excpetions. These lines of code will execute when an IOException is thrown. If the program doesn encounter an error, it will print a message indicating so, but will still function.//

public class Program
{
    static void Main()
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");

        
        Console.WriteLine($"{scripture.GetDisplayText()}\nType \"quit\" to exit");

        while (!scripture.IsCompletelyHidden())
        {
            string input = Console.ReadLine();
            
            if (input.ToLower() == "quit")
            {
                Console.WriteLine("User chose to quit.");
                return; 
            }

            scripture.HideRandomWords(3);

            
            try
            {
                Console.Clear();
                Console.WriteLine($"{scripture.GetDisplayText()}\nType \"quit\" to exit");
            }
            catch (System.IO.IOException)
            {
                Console.WriteLine($"Error: Unable to clear console.\n{scripture.GetDisplayText()}\nType \"quit\" to exit"); //error message tactic from W3Schools//
            }
        }

        Console.WriteLine("\nEnd of program.");
    }
}
