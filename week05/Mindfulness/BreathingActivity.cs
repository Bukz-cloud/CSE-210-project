using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Welcome to Breathing Activity", "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Breathe in... ");
            Console.ResetColor();
            ShowCountDown(4);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Breathe out... ");
            Console.ResetColor();
            ShowCountDown(4);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
