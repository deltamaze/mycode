using ConsolePlayGround;

internal class Program
{
    private static void Main()
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(DatePlay.DaysBetweenTwoDates(new DateTime(2022, 10, 3), DateTime.Now));
    }

}
