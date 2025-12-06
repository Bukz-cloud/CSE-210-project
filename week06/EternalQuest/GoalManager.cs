using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // This is the main menu loop called by Program.Main
    public void Start()
    {
        while (true)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. List goal names");
            Console.WriteLine("2. List goal details");
            Console.WriteLine("3. Create a goal");
            Console.WriteLine("4. Record event");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    ListGoalNames();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    CreateGoal();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}"); // shows brief with checkbox
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type: 1=Simple, 2=Eternal, 3=Checklist");
        Console.Write("Type: ");
        string type = Console.ReadLine()?.Trim();

        Console.Write("Short name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Description: ");
        string desc = Console.ReadLine() ?? "";

        int points = ReadInt("Points (integer): ");

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, desc, points));
            Console.WriteLine("Simple goal created.");
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, desc, points));
            Console.WriteLine("Eternal goal created.");
        }
        else if (type == "3")
        {
            int target = ReadInt("Target count (how many times to finish): ");
            int bonus = ReadInt("Bonus points when target reached: ");
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
            Console.WriteLine("Checklist goal created.");
        }
        else
        {
            Console.WriteLine("Unknown type. Goal not created.");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        int selection = ReadInt($"Enter number (1-{_goals.Count}): ", 1, _goals.Count);
        int earned = _goals[selection - 1].RecordEvent();
        _score += earned;
        Console.WriteLine($"You earned {earned} points. Total: {_score}");
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save (e.g. goals.txt): ");
        string fileName = Console.ReadLine() ?? "goals.txt";

        try
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(_score);
                foreach (var g in _goals)
                {
                    sw.WriteLine(g.GetStringRepresentation());
                }
            }
            Console.WriteLine("Saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load (e.g. goals.txt): ");
        string fileName = Console.ReadLine() ?? "goals.txt";

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(fileName);
            if (lines.Length == 0)
            {
                Console.WriteLine("File empty.");
                return;
            }

            // First line should be score (int)
            if (!int.TryParse(lines[0], out int fileScore))
            {
                Console.WriteLine("Saved score invalid. Aborting load.");
                return;
            }

            _score = fileScore;
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Support both '|' and fallback comma if someone edited file manually
                string[] parts = line.Contains("|") ? line.Split('|') : line.Split(',');

                // minimal validation: at least 4 fields for Simple, 3 for Eternal, 7 for Checklist
                string type = parts[0].Trim();

                try
                {
                    if (type.Equals("Simple", StringComparison.OrdinalIgnoreCase))
                    {
                        if (parts.Length < 5) throw new FormatException("Simple goal requires 5 parts.");
                        string name = Unescape(parts[1]);
                        string desc = Unescape(parts[2]);
                        int points = int.Parse(parts[3]);
                        bool isComplete = bool.Parse(parts[4]);
                        _goals.Add(new SimpleGoal(name, desc, points, isComplete));
                    }
                    else if (type.Equals("Eternal", StringComparison.OrdinalIgnoreCase))
                    {
                        if (parts.Length < 4) throw new FormatException("Eternal goal requires 4 parts.");
                        string name = Unescape(parts[1]);
                        string desc = Unescape(parts[2]);
                        int points = int.Parse(parts[3]);
                        _goals.Add(new EternalGoal(name, desc, points));
                    }
                    else if (type.Equals("Checklist", StringComparison.OrdinalIgnoreCase))
                    {
                        if (parts.Length < 7) throw new FormatException("Checklist goal requires 7 parts.");
                        string name = Unescape(parts[1]);
                        string desc = Unescape(parts[2]);
                        int points = int.Parse(parts[3]);
                        int target = int.Parse(parts[4]);
                        int amountCompleted = int.Parse(parts[5]);
                        int bonus = int.Parse(parts[6]);
                        _goals.Add(new ChecklistGoal(name, desc, points, target, bonus, amountCompleted));
                    }
                    else
                    {
                        Console.WriteLine($"Skipping unknown goal type on line {i + 1}: {type}");
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine($"Skipping malformed line {i + 1}: {fe.Message}");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"Skipping malformed line {i + 1}: not enough fields.");
                }
            }

            Console.WriteLine("Load complete.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading: {ex.Message}");
        }
    }

    // small helper to read ints safely with optional bounds
    private int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int value))
            {
                if (value >= min && value <= max)
                    return value;
            }
            Console.WriteLine("Invalid integer. Try again.");
        }
    }

    // Helper to reverse escaping of pipe characters in stored strings
    private string Unescape(string s) => s?.Replace("¦", "|") ?? "";
}
