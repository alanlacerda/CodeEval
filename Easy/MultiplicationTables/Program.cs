using System;

namespace MultiplicationTables
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int x = 1; x < 13; ++x)
            {
                for (int y = 1; y < 13; ++y)
                {
                    Console.Write((x * y).ToString().PadLeft(4));
                }

                Console.Write(Environment.NewLine);
            } 
        }        
    }
}