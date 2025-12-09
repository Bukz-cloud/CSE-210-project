using System;

public class Running : Activity
{
    private double _distanceKm;

    public Running(DateTime date, int length, double distanceKm) 
        : base(date, length)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance()
    {
        return _distanceKm;
    }

    public override double GetSpeed()
    {
        return _distanceKm/GetLength() * 60;
    }

    public override double GetPace()
    {
        return GetLength()/GetDistance();
    }
}