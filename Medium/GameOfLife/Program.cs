using System;

namespace GameOfLife
{
    static class Program
    {
        private const int GridDimension = 100;

        static void Main(string[] args)
        {
            var grid = new int[GridDimension, GridDimension];
            int rowIndex = 0;

            foreach (string line in System.IO.File.ReadLines(args[0]))
            {
                int columnIndex = 0;

                foreach (char cell in line)
                {
                    grid[rowIndex, columnIndex] = cell == '*' ? 1 : 0;
                    ++columnIndex;
                }

                ++rowIndex;
            }

            grid.Iterate(10);

            Console.Write(grid.ToStringGrid());
        }

        static string ToStringGrid(this int[,] grid)
        {
            var outGrid = new System.Text.StringBuilder((GridDimension * GridDimension) + (GridDimension * 2));

            for (int x = 0; x < GridDimension; ++x)
            {
                for (int y = 0; y < GridDimension; ++y)
                {
                    outGrid.Append(grid[x, y].ToCell());
                }

                outGrid.Append(Environment.NewLine);
            }

            return outGrid.ToString();
        }

        static char ToCell(this int isAlive)
        {
            return isAlive == 1 ? '*' : '.';
        }

        static void Iterate(this int[,] grid, int iterationCount)
        {
            var nextGrid = new int[GridDimension, GridDimension];

            for (int iteration = 0; iteration < iterationCount; ++iteration)
            {
                for (int x = 0; x < GridDimension; ++x)
                {
                    for (int y = 0; y < GridDimension; ++y)
                    {
                        nextGrid[x, y] = grid.NextState(x, y);
                    }
                }

                Array.Copy(nextGrid, 0, grid, 0, GridDimension * GridDimension);
            }
        }

        static int NextState(this int[,] grid, int x, int y)
        {
            int aliveNeighbors = grid.CountAliveNeighbors(x, y);

            if (grid[x, y] == 0) 
                return aliveNeighbors == 3 ? 1 : 0;

            if (aliveNeighbors < 2)
                return 0;

            if (aliveNeighbors < 4)
                return 1;

            return 0;
        }

        static int CountAliveNeighbors(this int[,] grid, int x, int y)
        {
            bool isLeftBound = x == 0;
            bool isRightBound = x == GridDimension - 1;
            bool isTopBound = y == 0;
            bool isBottomBound = y == GridDimension - 1;            
            
            int aliveNeighbors = 0;

            if (!isTopBound)
                aliveNeighbors += grid[x, y - 1];

            if (!isBottomBound)
                aliveNeighbors += grid[x, y + 1];
            
            if (!isRightBound)
            {
                aliveNeighbors += grid[x + 1, y];
                
                if (!isTopBound)
                    aliveNeighbors += grid[x + 1, y - 1];

                if (!isBottomBound)
                    aliveNeighbors += grid[x + 1, y + 1];
            }

            if (!isLeftBound)
            {
                aliveNeighbors += grid[x - 1, y];

                if (!isTopBound)
                    aliveNeighbors += grid[x - 1, y - 1];

                if (!isBottomBound)
                    aliveNeighbors += grid[x - 1, y + 1];
            }

            return aliveNeighbors;
        }
    }
}
