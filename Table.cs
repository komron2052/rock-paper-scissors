using ConsoleTables;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public static class Table
    {
        public static void MakeTable(string[] args)
        {
            int size = args.Length + 1;
            var table = new ConsoleTable();

            List<string> columns = new List<string> { "Moves" };
            columns.AddRange(args);

            table.AddColumn(columns);

            for (int i = 1; i < size; i++)
            {
                var rowValues = new List<string> { args[i - 1] };

                for (int j = 1; j < size; j++)
                {
                    var winner = Checker.CheckWinner(i, j, args);
                    string result = "";
                    if (winner == 0)
                        result = "Draw";
                    else if (winner == 1)
                        result = "Lose";
                    else if (winner == -1)
                        result = "Win";

                    rowValues.Add(result);
                }

                table.AddRow(rowValues.ToArray());
            }

            table.Write();
        }
    }
}
