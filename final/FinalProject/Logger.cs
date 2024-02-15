using System;

public class Logger
{
    public void LogTransaction(Transaction transaction)
    {
        Console.WriteLine($"Transaction logged: {transaction.Item.Title} {transaction.Type} by {transaction.Member.Name} on {transaction.Date}");
    }

    public void LogError(string errorMessage)
    {
        Console.WriteLine($"Error logged: {errorMessage}");
    }
}
