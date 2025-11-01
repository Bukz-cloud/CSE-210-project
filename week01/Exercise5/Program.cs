using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNum = PromptUserNumber();
        int square = SquareNumber(userNum);
        DIsplayResult(userName, square);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favourite number: ");
        string response = Console.ReadLine();
        int number = int.Parse(response);
        return number;
    }
    static int SquareNumber(int number)
    {
        int sqrNum = number * number;
        return sqrNum;
    }
    static void DIsplayResult(string name, int sqrNum)
    {
        Console.WriteLine($"{name}, the square of your number is {sqrNum}");
    }
}