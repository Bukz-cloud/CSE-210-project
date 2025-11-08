using System;

public class Entry
{
    public string _date { get; set; } = "";
    public string _promptText { get; set; } = "";
    public string _entryText { get; set; } = "";

    public Entry() { }

    public Entry(string date, string promptTeXt, string entryText)
    {
        _date = date;
        _promptText = promptTeXt;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
    }

    public string ToFileFormat()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length == 3)
        {
            return new Entry(parts[0], parts[1], parts[2]);
        }
        return null!;
    }
}
