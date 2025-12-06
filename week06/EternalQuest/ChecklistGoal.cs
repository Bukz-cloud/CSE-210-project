public class ChecklistGoal : Goal
{
    private int _target;
    private int _amountCompleted;
    private int _bonus;

    // Constructor for new goals
    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    // Constructor for loaded goals
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;

        // Award bonus if reaching target
        if (_amountCompleted >= _target)
        {
            return _points + _bonus;
        }

        return _points;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        // IMPORTANT — Always save in a format that matches LoadGoals
        return $"Checklist|{Escape(_shortName)}|{Escape(_description)}|{_points}|{_target}|{_amountCompleted}|{_bonus}";
    }
    private string Escape(string s) => s?.Replace("|", "¦") ?? "";

    public int GetAmountCompleted() => _amountCompleted;
    public int GetTarget() => _target;
    public int GetBonus() => _bonus;
}
