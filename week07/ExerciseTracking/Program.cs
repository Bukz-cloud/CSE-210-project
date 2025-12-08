using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2025, 12, 3), 30, 4.8));

        activities.Add(new Cycling(new DateTime(2022, 10, 3), 45, 20.8));

        activities.Add(new Swimming(new DateTime(2023, 02, 20), 25, 30));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary)
        }
    }
}