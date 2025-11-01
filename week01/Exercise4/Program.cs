using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = -1;


        while (number != 0)
        {
            Console.Write("Enter the number (0 to quit): ");
            string num = Console.ReadLine();
            number = int.Parse(num);

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        int total = 0;
        foreach (int numb in numbers)
        {
            total += numb;
        }
        Console.WriteLine($"The total is: {total}");

        int highest = numbers[0];

        foreach (int numb1 in numbers)
        {
            if (numb1 > highest)
            {
                highest = numb1;
            }
        }
        Console.WriteLine($"The maximum number is: {highest}");
    }
}