using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralAssessment2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string fileName = "Fibonacci.txt";
            int count = 15;

            //write to file
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("First 15 Fibonacci Numbers :");
                for (int i = 0; i < count; i++)
                {
                    int fibNumber = Fibonacci(i);
                    writer.WriteLine(fibNumber);
                }
            }
            Console.WriteLine($"Fibonacci sequence saved successfully to '{fileName}'.");
            Console.ReadLine();
        }

        private static int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
