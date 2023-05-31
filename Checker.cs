namespace Task3;

public static class Checker
{
    public static int CheckWinner(int computerMove, int move, string[] args)
    {
        int moves = args.Length;

        if (computerMove == move)
            return 0;
        else if (((move <= moves / 2) && (computerMove > move && computerMove <= move + moves / 2)) ||
            ((move > moves / 2) && (computerMove < move - moves / 2 || computerMove > move)))
            return -1;
        else 
            return 1;
    }
}
