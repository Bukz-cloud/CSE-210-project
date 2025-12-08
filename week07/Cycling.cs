using System;

public class Cycling : Activity
{
    private double _speedKph;

    public Running(DateTime date, int length, double speedKph) 
        : base(date, length)
    {
        _speedKph = speedKph;
    }

    public override double GetDistance()
    {
        return (_speedKph * GetLength())/ 60;
    }

    public override double GetSpeed()
    {
        return _speedKph;
    }

    public override double GetPace()
    {
        return 60/GetSpeed();
    }
}