using System;
using System.IO;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;

        Directory.CreateDirectory("logs");
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"--- {_name} Activity ---");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(_description);

        Console.Write("\nHow long in seconds, would you like for your session?: ");
        Console.ResetColor();
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nGreat job!");
        Console.WriteLine($"You completed {_duration} seconds of the {_name} activity.");
        Console.ResetColor();
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        string[] sequence = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(sequence[i]);
            Console.ResetColor();

            Thread.Sleep(200);
            Console.Write("\b \b");
            i = (i + 1) % sequence.Length;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{i}");
            Console.ResetColor();

            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    // Logging helper method
    public void Log(string filename, string content)
    {
        string path = Path.Combine("logs", filename);

        File.AppendAllText(path,
            $"[{DateTime.Now}] {_name} Activity:\n{content}\n\n");
    }
}
