using System;

public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
         return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{Escape(_shortName)}|{Escape(_description)}|{_points}";
    }
    private string Escape(string s) => s?.Replace("|", "¦") ?? "";
}
