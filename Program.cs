namespace Task3;

public static class Programm
{
    public static void Main(string[] args)
    {
        if (args.Length < 3)
            Console.WriteLine($"You must enter at least 3 arguments, you entered only {args.Length}!");

        else if (args.Length % 2 == 0)
            Console.WriteLine("You need to enter an odd number of arguments!");

        else if (args.Length != args.Distinct().Count())
            Console.WriteLine("You entered same arguments!");

        else
        {
            var game = new Game();
            game.Start(args);
        }
        
    }
}
