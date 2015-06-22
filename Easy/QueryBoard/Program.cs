using System;

namespace QueryBoard
{
    class Program
    {
        const int BoardDimension = 256;

        delegate void BoardAction(int[,] board, params int[] values);

        static void SetRow(int[,] board, params int[] values)
        {
            for (int i = 0; i < BoardDimension; ++i)
            {
                board[values[0], i] = values[1];
            }
        }

        static void SetColumn(int[,] board, params int[] values)
        {
            for (int i = 0; i < BoardDimension; ++i)
            {
                board[i, values[0]] = values[1];
            }
        }

        static void QueryRow(int[,] board, params int[] values)
        {
            var sum = 0;

            for (int i = 0; i < BoardDimension; ++i)
            {
                sum += board[values[0], i];
            }

            Console.WriteLine(sum);
        }

        static void QueryColumn(int[,] board, params int[] values)
        {
            var sum = 0;

            for (int i = 0; i < BoardDimension; ++i)
            {
                sum += board[i, values[0]];
            }

            Console.WriteLine(sum);
        }

        static void Main(string[] args)
        {
            var board = new int[BoardDimension, BoardDimension];
            var operations = new System.Collections.Generic.Dictionary<string, BoardAction>()
            {
                {"SetRow", SetRow},
                {"SetCol", SetColumn},
                {"QueryRow", QueryRow},
                {"QueryCol", QueryColumn},
            };

            foreach(var line in System.IO.File.ReadLines(args[0]))
            {
                var arguments = line.Split(' ');
                
                operations[arguments[0]](board, int.Parse(arguments[1]), arguments.Length == 2 ? 0 : int.Parse(arguments[2]));
            }
        }
    }
}
