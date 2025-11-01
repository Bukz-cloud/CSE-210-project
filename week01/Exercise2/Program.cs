using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string grade = Console.ReadLine();
        int score = int.Parse(grade);
        string letter = "";

        if (score >= 90)
        {
            letter = "A";
        }
        else if (score >= 80)
        {
            letter = "B";
        }
        else if (score >= 70)
        {
            letter = "C";
        }
        else if (score >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string sticker = "";
        int lastDigit = score % 10;

        if (lastDigit >= 7)
        {
            sticker = "+";
        }
        else if (lastDigit < 3)
        {
            sticker = "-";
        }

        if (letter == "A" && sticker == ("+"))
        {
            sticker = "";
        }
        else if (letter == "F" && sticker == ("-"))
        {
            sticker = "";
        }

        Console.WriteLine($"Your score is {score} and your grade is {sticker}{letter}"); 

            if (score >= 70)
            {
                Console.WriteLine("Congratulations! You pass the course.");
            }
            else
            {
                Console.Write("Sorry! You have to retake the course.");
            }
    }
}