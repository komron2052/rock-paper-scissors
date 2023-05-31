using System.Text;

namespace Task3;

public class Game
{
    public void Start(string[] args)
    {
        Start:
        while (true)
        {
            byte[] key = Hmac.GenerateRandomKey();
            var random = new Random();
            var computerMoveIndex = random.Next(0, args.Length);
            string computerMove = args[computerMoveIndex];

            Console.WriteLine($"HMAC: {Hmac.ByteArrayToString(Hmac.ComputeHMAC(computerMove, key))}");
            Console.WriteLine("Available moves:");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {args[i]}");
            }
            Console.WriteLine("0 - Exit");
            Console.WriteLine("? - Help");

            Console.Write("Enter your move: ");
            var playerMove = Console.ReadLine();
            if (playerMove != "?")
            {
                int move = int.Parse(playerMove);
                if (move == 0)
                    return;

                else if (move >= 1 && move <= args.Length)
                {
                    Console.WriteLine($"Your move: {args[move - 1]}");
                    Console.WriteLine($"Computer move: {computerMove}");
                    var winner = Checker.CheckWinner(computerMoveIndex + 1, move, args);
                    if (winner == 0)
                        Console.WriteLine("Draw!");
                    else if (winner == -1)
                        Console.WriteLine("Computer win!");
                    else if (winner == 1)
                        Console.WriteLine("You win!");
                    Console.WriteLine($"HMAC key: {Hmac.ByteArrayToString(key)}");
                }
                else
                    goto Start;
            }
            else
                Table.MakeTable(args);
            
        }
    }

}
