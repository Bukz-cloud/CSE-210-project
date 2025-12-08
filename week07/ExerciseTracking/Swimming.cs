using System;

public class Running : Activity
{
    private int _numOfLaps;

    public Running(DateTime date, int length, int numOfLaps) 
        : base(date, length)
    {
        _numOfLaps = numOfLaps;
    }

    public override double GetDistance()
    {
        return (numOfLaps * 50) / 1000;
    }

    public override double GetSpeed()
    {
        return (GetDistance()/GetLength()) * 60;
    }

    public override double GetPace()
    {
        return GetLength()/GetDistance();
    }
}