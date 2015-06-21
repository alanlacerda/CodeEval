using System;

namespace OddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int odd = 1; odd < 100; odd += 2)
            {
               Console.WriteLine(odd);
            }
        }
    }
}
