using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        string[] parts = text.Split(" ");
        foreach (string word in parts)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide = 3)
    {
        for (int i =0; i < numberToHide; i++)
        {
            int index = _random.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
    List<string> output = new List<string>();
    foreach (Word word in _words)
        {
            output.Add(word.GetDisplayText());
        }
        return $"{_reference.GetDisplayText()}\n\n{string.Join(" ", output)}";
    }
    public bool isCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden()) return false;
        }
        return true;
    }

}