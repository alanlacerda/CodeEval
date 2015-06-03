using System;

namespace MultiplicationTables
{
    class Program
    {
        static void Main(string[] args)
        {
            byte x, y;

            for(x = 1; x <= 12; x++)
            {
                for (y = 1; y <= 12; y++)
                {
                    Console.Write((y * x).ToString().PadLeft(4));
                }
                if (x < 12)
                {
                    Console.Write('\n');
                }
            }
        }        
    }
}
