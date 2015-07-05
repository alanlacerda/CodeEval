using System;

namespace GameOfLife
{
    static class Program
    {
        static void Main(string[] args)
        {
            var grid = LoadFromFile(args[0]);
            grid.Iterate(10);
            grid.Display();
        }

        static bool[][] LoadFromFile(string path)
        {
            var lines = System.IO.File.ReadAllLines(path);
            var grid = new bool[lines.Length][];
            
            for (int x = 0; x < grid.Length; ++x)
            {
                grid[x] = new bool[lines[x].Length];

                for (int y = 0; y < grid[x].Length; ++y)
                {
                    grid[x][y] = lines[x][y] == '*';
                }
            }

            return grid;
        }

        static void Iterate(this bool[][] grid, int count)
        {
            var nextGrid = new bool[grid.Length][];

            for (int iteration = 0; iteration < count; ++iteration)
            {
                for (int x = 0; x < grid.Length; ++x)
                {
                    nextGrid[x] = nextGrid[x] ?? new bool[grid.Length];

                    for (int y = 0; y < grid[x].Length; ++y)
                    {
                        nextGrid[x][y] = grid.NextState(x, y);
                    }
                }

                for (int x = 0; x < nextGrid.Length; ++x)
                {
                    Buffer.BlockCopy(nextGrid[x], 0, grid[x], 0, nextGrid[x].Length * sizeof(bool));
                }
            }
        }    

        static bool NextState(this bool[][] grid, int x, int y)
        {
            int aliveNeighbors = grid.CountAliveNeighbors(x, y);

            if (!grid[x][y])
                return aliveNeighbors == 3;

            return aliveNeighbors >= 2 && aliveNeighbors < 4;
        }

        static int CountAliveNeighbors(this bool[][] grid, int x, int y)
        {
            int aliveNeighbors = 0;

            if (y > 0)
                aliveNeighbors += grid[x][y - 1] ? 1 : 0;

            if (y < grid[x].Length - 1)
                aliveNeighbors += grid[x][y + 1] ? 1 : 0;

            if (x < grid.Length - 1)
            {
                aliveNeighbors += grid[x + 1][y] ? 1 : 0;

                if (y > 0)
                    aliveNeighbors += grid[x + 1][y - 1] ? 1 : 0;

                if (y < grid[x].Length - 1)
                    aliveNeighbors += grid[x + 1][y + 1] ? 1 : 0;
            }

            if (x > 0)
            {
                aliveNeighbors += grid[x - 1][y] ? 1 : 0;

                if (y > 0)
                    aliveNeighbors += grid[x - 1][y - 1] ? 1 : 0;

                if (y < grid[x].Length - 1)
                    aliveNeighbors += grid[x - 1][y + 1] ? 1 : 0;
            }

            return aliveNeighbors;
        }

        static void Display(this bool[][] grid)
        {
            for (int x = 0; x < grid.Length; ++x)
            {
                for (int y = 0; y < grid[x].Length; ++y)
                {
                    grid[x][y].Display();
                }

                Console.WriteLine(Environment.NewLine);
            }
        }

        static void Display(this bool cell)
        {
            Console.Write(cell ? '*' : '.');
        }
    }
}
