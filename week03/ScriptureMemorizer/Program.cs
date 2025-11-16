//Creativity: I added more scripture to the main class.

﻿using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       
        List<Scripture> scriptures = new List<Scripture>()
        {
            new Scripture(
                new Reference("Philippians", 2, 5, 6),
                "Let this mind be in you, which was also in Christ Jesus: 6 Who, being in the form of God, thought it not robbery to be equal with God:"
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding in all thy ways acknowledge him and he shall direct thy paths."
            ),

            new Scripture(
                new Reference("Psalm", 23, 1),
                "The Lord is my shepherd I shall not want."
            ),

            new Scripture(
                new Reference("Mosiah", 2, 41),
                "Consider the blessed and happy state of those that keep the commandments of God."
            )
        };

        
        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

       
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress ENTER to continue or type 'quit' to exit");

            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                return;

            scripture.HideRandomWords();

            if (scripture.isCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program ending...");
                return;
            }
        }
    }
}