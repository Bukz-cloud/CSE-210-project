using System;

public class Swimming : Activity
{
    private int _numOfLaps;

    public Swimming(DateTime date, int length, int numOfLaps) 
        : base(date, length)
    {
        _numOfLaps = numOfLaps;
    }

    public override double GetDistance()
    {
        return _numOfLaps * 50 / 1000;
    }

    public override double GetSpeed()
    {
        return GetDistance()/GetLength() * 60;
    }

    public override double GetPace()
    {
        return GetLength()/GetDistance();
    }
}