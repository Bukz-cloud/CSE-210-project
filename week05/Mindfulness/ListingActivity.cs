using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
        : base("Thanks for choosing Listing Activity", "This activity helps you reflect by listing positive things in your life.")
    {
        _prompts = new List<string>()
        {
            "Who are people you appreciate?",
            "What are your personal strengths?",
            "What are you grateful for today?",
            "Who inspires you?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($" --- {prompt} --- ");
        Console.ResetColor();

        Console.Write("You may begin in: ");
        ShowCountDown(5);

        List<string> responses = GetListFromUser();
        _count = responses.Count;

        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nYou listed {_count} items:");
        Console.ResetColor();

        foreach (var item in responses)
        {
            Console.WriteLine("✔ " + item);
        }

        
        string logText = $"Prompt: {prompt}\nResponses:\n - " + string.Join("\n - ", responses);
        Log("listing_activity_log.txt", logText);

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random rnd = new Random();
        return _prompts[rnd.Next(_prompts.Count)];
    }

    public List<string> GetListFromUser()
    {
        List<string> entries = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            entries.Add(Console.ReadLine());
        }

        return entries;
    }
}
