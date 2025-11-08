using System;
using System.Collections.Generic;
using System.IO;

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

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileFormat());
            }
        }
        Console.WriteLine($" Journal saved to {file}");
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            Console.WriteLine(" File not found!");
            return;
        }

        _entries.Clear();

        string[] rows = File.ReadAllLines(file);
        foreach (string row in rows)
        {
            Entry entry = Entry.FromFileFormat(row);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }

        Console.WriteLine($" Loaded {_entries.Count} entries from {file}");
    }
}
