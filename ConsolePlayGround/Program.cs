using ConsolePlayGround;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Hello, World!");
        //Console.WriteLine(DatePlay.DaysBetweenTwoDates(new DateTime(2022, 10, 3), DateTime.Now));
        Console.WriteLine(DatePlay.AddWeeksToDate(new DateTime(2022, 7, 25), 12).ToString());
    }
}
