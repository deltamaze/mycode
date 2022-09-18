class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var test = (new DateTime(2022, 10, 3) - DateTime.Now).TotalDays;
        Console.WriteLine(test.ToString());
    }

}
