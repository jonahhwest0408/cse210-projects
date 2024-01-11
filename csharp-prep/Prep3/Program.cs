using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomNumber= new Random();
        int magicNumber = randomNumber.Next(1, 101);

        int guess = -1;
        int attempts = 0;

        while (guess != magicNumber)
        {
            Console.WriteLine("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            attempts++;

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }

        Console.WriteLine($"It took you {attempts} attempts to guess the number.");
    }     
}