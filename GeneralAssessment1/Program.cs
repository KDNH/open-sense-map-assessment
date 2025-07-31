using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralAssessment1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Number to start:");
            int rangeStart = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a Number to End:");
            int rangeEnd = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Numbers divisible by 3 or 5 between {rangeStart} and {rangeEnd}");
            int totalSum = printNumbers(rangeStart, rangeEnd);

            Console.WriteLine($"Sum is : {totalSum}");
            Console.ReadLine();

        }

        private static int printNumbers(int start, int end)
        {
            int sum = 0;

            for (int i = start; i <= end; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    Console.WriteLine(i);
                    sum = sum + i;
                }
            }
            return sum;
        }
    }
}
