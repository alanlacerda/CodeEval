using System;

namespace GameOfLife
{
    static class Program
    {
        private const int GridDimension = 100;
        private const int GridSize = GridDimension * GridDimension * sizeof(bool);

        static void Main(string[] args)
        {
            var grid = LoadFromFile(args[0]);
            grid.Iterate(10);
            grid.Display();
        }

        static bool[,] LoadFromFile(string path)
        {
            var lines = System.IO.File.ReadAllLines(path);
            var grid = new bool[GridDimension, GridDimension];

            for (int x = 0; x < GridDimension; ++x)
            {
                for (int y = 0; y < GridDimension; ++y)
                {
                    grid[x, y] = lines[x][y] == '*';
                }
            }

            return grid;
        }

        static void Display(this bool[,] grid)
        {
            for (int x = 0; x < GridDimension; ++x)
            {
                for (int y = 0; y < GridDimension; ++y)
                {
                    grid[x, y].Display();
                }

                Console.WriteLine(Environment.NewLine);
            }
        }

        static void Display(this bool isAlive)
        {
            Console.Write(isAlive? '*' : '.');
        }

        static void Iterate(this bool[,] grid, int count)
        {
            var nextGrid = new bool[GridDimension, GridDimension];

            for (int iteration = 0; iteration < count; ++iteration)
            {
                for (int x = 0; x < GridDimension; ++x)
                {
                    for (int y = 0; y < GridDimension; ++y)
                    {
                        nextGrid[x, y] = grid.NextState(x, y);
                    }
                }

                Buffer.BlockCopy(nextGrid, 0, grid, 0, GridSize);
            }
        }

        static bool NextState(this bool[,] grid, int x, int y)
        {
            int aliveNeighbors = grid.CountAliveNeighbors(x, y);

            if (!grid[x, y])
                return aliveNeighbors == 3;

            return aliveNeighbors >= 2 && aliveNeighbors < 4;
        }

        static int CountAliveNeighbors(this bool[,] grid, int x, int y)
        {
            bool isLeftBound = x == 0;
            bool isRightBound = x == GridDimension - 1;
            bool isTopBound = y == 0;
            bool isBottomBound = y == GridDimension - 1;            
            
            int aliveNeighbors = 0;

            if (!isTopBound)
                aliveNeighbors += grid[x, y - 1] ? 1 : 0;

            if (!isBottomBound)
                aliveNeighbors += grid[x, y + 1] ? 1 : 0;
            
            if (!isRightBound)
            {
                aliveNeighbors += grid[x + 1, y] ? 1 : 0;
                
                if (!isTopBound)
                    aliveNeighbors += grid[x + 1, y - 1] ? 1 : 0;

                if (!isBottomBound)
                    aliveNeighbors += grid[x + 1, y + 1] ? 1 : 0;
            }

            if (!isLeftBound)
            {
                aliveNeighbors += grid[x - 1, y] ? 1 : 0;

                if (!isTopBound)
                    aliveNeighbors += grid[x - 1, y - 1] ? 1 : 0;

                if (!isBottomBound)
                    aliveNeighbors += grid[x - 1, y + 1] ? 1 : 0;
            }

            return aliveNeighbors;
        }
    }
}
