using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        Console.WriteLine("\n Journal Entries:");

        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
        }
        else
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter a file path and name to save (e.g., C:\\Users\\You\\Documents\\journal.json): ");
        string file = Console.ReadLine();

        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_entries, options);
            File.WriteAllText(file, json);
            Console.WriteLine($" Journal saved successfully to {file}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Error saving file: {ex.Message}");
        }
    }

    // Load entries from a JSON file
    public void LoadFromFile()
    {
        Console.Write("Enter the full path of the file to load (e.g., C:\\Users\\You\\Documents\\journal.json): ");
        string file = Console.ReadLine();

        try
        {
            if (File.Exists(file))
            {
                string json = File.ReadAllText(file);
                _entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>();
                Console.WriteLine($" Journal loaded successfully from {file}");
            }
            else
            {
                Console.WriteLine(" File not found. Please check the path and try again.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Error loading file: {ex.Message}");
        }
    }
}
