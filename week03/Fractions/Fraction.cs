using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int num)
    {
        _numerator = num;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    public string GetFractionString()
    {
        string result = $"{_numerator} / {_denominator}";
        return result;
    }

    public double GetDecimal()
    {
        double result2 = (double)_numerator / (double)_denominator;
        double roundedResult = Math.Round(result2, 2);
        return roundedResult;
    }
}