using ConsolePlayGround;
using System;
using System.Collections.Concurrent;
using System.Threading;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Hello, World!");
        // Console.WriteLine(DatePlay.DaysBetweenTwoDates(new DateTime(2022, 10, 3), DateTime.Now));
        // Console.WriteLine(DatePlay.AddWeeksToDate(new DateTime(2022, 7, 25), 12).ToString());

        // In this example, the time window is 30 seconds.
        var timeWindow = TimeSpan.FromSeconds(30);

        // Create a new concurrent dictionary and a timer.
        var dictionary = new ConcurrentDictionary<string, DateTime>();
        var timer = new Timer(CheckForExpiredItems, dictionary, timeWindow, timeWindow);

        // Add some items to the dictionary.
        dictionary.TryAdd("Key1", DateTime.Now);
        dictionary.TryAdd("Key2", DateTime.Now);
        dictionary.TryAdd("Key3", DateTime.Now);

        // Wait for the timer to expire.
        Thread.Sleep(timeWindow * 3);

        // Stop the timer and dispose of the dictionary.
        timer.Change(Timeout.Infinite, Timeout.Infinite);
        dictionary.Clear();
        dictionary = null;

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();

        // The values have been automatically removed from the dictionary
    }

    static void CheckForExpiredItems(object state)
    {
        // In this example, the time window is 30 seconds.
        var timeWindow = TimeSpan.FromSeconds(30);

        // Get the dictionary from the state object.
        var dictionary = (ConcurrentDictionary<string, DateTime>) state;

        // Check each item in the dictionary to see if it has expired.
        foreach (var item in dictionary)
        {
            if (DateTime.Now - item.Value > timeWindow)
            {
                // If the item has expired, remove it from the dictionary.
                dictionary.TryRemove(item.Key, out _);
            }
        }
    }
}
