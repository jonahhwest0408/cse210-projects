using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNumber = -1;

        while (userNumber != 0)
        {
            Console.WriteLine("Enter a number, press 0 to quit: ");
            string userInput = Console.ReadLine();
            userNumber = int.Parse(userInput);

            if (userNumber !=0)
            {
                numbers.Add(userNumber);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum of your numbers is {sum}.");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average of your numers is {average}.");

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        } 
        Console.WriteLine($"Your max number is {max}");
    }
}