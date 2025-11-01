using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise1 Project.");
        Console.Write("What is your first name?: ");
        string fname = Console.ReadLine();

        Console.Write("What is your last name?: ");
        string lname = Console.ReadLine();
        
        Console.Write($"Your name is {lname}, {fname} {lname}.");
    }
}