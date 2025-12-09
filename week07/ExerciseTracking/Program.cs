using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(
            new DateTime(2022, 11, 3), 30, 4.8));

        activities.Add(new Cycling(
            new DateTime(2022, 11, 3), 45, 20.0));

        activities.Add(new Swimming(
            new DateTime(2022, 11, 3), 25, 30));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        ActivityStorage.SaveSummaries(activities);
        Console.WriteLine("\nSummaries saved to file.");

        Console.WriteLine("\nSaved Activity Log:");
        List<string> stored = ActivityStorage.LoadSummaries();
        foreach (string entry in stored)
        {
            Console.WriteLine(entry);
        }
    }
}