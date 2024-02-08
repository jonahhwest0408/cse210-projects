//In order to receieve he extra credit, I implemented a debugging redirect in order to avoid getting an IO error. I also implemented error messages to help guide the user through error.//
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}