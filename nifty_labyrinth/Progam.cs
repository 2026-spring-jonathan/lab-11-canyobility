public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter your name:");
        string userName = Console.ReadLine() ?? "DefaultUser";
        var (links, mazeBody, startLocation) = MazeGenerator.GenerateMaze(userName, true);
        Console.WriteLine(mazeBody);
    }
}