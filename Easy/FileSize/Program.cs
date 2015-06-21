using System;

namespace FileSize
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(new System.IO.FileInfo(args[0]).Length);
        }
    }
}
