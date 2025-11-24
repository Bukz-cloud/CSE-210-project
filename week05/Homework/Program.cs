using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment("Mary Waters", "European History");
        Console.WriteLine(assignment1.GetSummary());

        MathAssignment assignment2 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeWorkList());

        WritingAssignment assignment3 = new WritingAssignment("John Doe", "Narrative Essay", "Biafran Civil War");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}