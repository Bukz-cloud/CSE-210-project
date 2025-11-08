//Creativity: Enabled saving or loading of document to JSON for storage. 
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n Welcome to the Journal Program!");
            Console.WriteLine("\n Please select one of the following choices!");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save to JSON");
            Console.WriteLine("4. Load from JSON");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string entry = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(date, prompt, entry);
                    myJournal.AddEntry(newEntry);
                    Console.WriteLine(" Entry added successfully!");
                    break;

                case "2":
                    myJournal.DisplayAll();
                    break;

                case "3":
                    myJournal.SaveToFile();
                    break;

                case "4":
                    myJournal.LoadFromFile();
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Thanks for your time!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please choose 1–5.");
                    break;
            }
        }
    }
}