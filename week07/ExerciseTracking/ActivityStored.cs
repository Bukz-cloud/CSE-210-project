using System;
using System.Collections.Generic;
using System.IO;

public static class ActivityStorage
{
    private static string _filePath = "activity_log.txt";

    public static void SaveSummaries(List<Activity> activities)
    {
        using (StreamWriter writer = new StreamWriter(_filePath, append: true))
        {
            foreach (Activity activity in activities)
            {
                writer.WriteLine(activity.GetSummary());
            }
        }
    }

    public static List<string> LoadSummaries()
    {
        List<string> summaries = new List<string>();

        if (File.Exists(_filePath))
        {
            foreach (string line in File.ReadAllLines(_filePath))
            {
                summaries.Add(line);
            }
        }

        return summaries;
    }
}
