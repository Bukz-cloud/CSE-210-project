using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        string keepPlaying = "yes";

        while (keepPlaying == "yes")
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 101);
            int guessNum = -1;
            int guessCount = 0;

            while (number != guessNum)
            {
                Console.Write("What is your guess?: ");
                string guess = Console.ReadLine();
                guessNum = int.Parse(guess);
                guessCount += 1;

                if (number > guessNum)
                {
                    Console.WriteLine("Higher");
                }
                else if (number < guessNum)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }
            Console.WriteLine($"You guessed {guessCount} times.");

            Console.Write("Do you want to play again? yes/no: ");
            keepPlaying = Console.ReadLine();

            if (keepPlaying == "no")
            {
                Console.Write("Thanks for your time. Goodbye!");
            }
        } 
    }
}