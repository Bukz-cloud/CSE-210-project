using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string shortName, string description, int points, bool isComplete)
        :base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if(!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{Escape(_shortName)}|{Escape(_description)}|{_points}|{_isComplete}";
    }
    private string Escape(string s) => s?.Replace("|", "¦") ?? "";
}
