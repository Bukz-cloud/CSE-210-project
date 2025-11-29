using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
        : base("Reflecting is a good habit", "This activity will help you to reflect on times you've shown strength or resilience.")
    {
        _prompts = new List<string>()
        {
            "Think of a time when you helped someone.",
            "Think of a time when you overcame a challenge.",
            "Think of a moment you felt proud of yourself."
        };

        _questions = new List<string>()
        {
            "Why was this meaningful to you?",
            "How did you feel after the experience?",
            "What did you learn about yourself?",
            "How can this help you in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        DisplayPrompt(prompt);

        Console.WriteLine("Reflect on the following questions:");

        List<string> questionsShown = new List<string>();

        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            string q = GetRandomQuestion();
            questionsShown.Add(q);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("> " + q);
            Console.ResetColor();

            ShowSpinner(5);
        }

    
        string logText = $"Prompt: {prompt}\nQuestions Asked:\n - " + string.Join("\n - ", questionsShown);
        Log("reflecting_activity_log.txt", logText);

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        return _prompts[new Random().Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        return _questions[new Random().Next(_questions.Count)];
    }

    public void DisplayPrompt(string prompt)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($" --- {prompt} --- ");
        Console.ResetColor();

        Console.WriteLine("\nPress Enter when you're ready...");
        Console.ReadLine();
    }
}
