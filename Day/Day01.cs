using System;
using System.IO;
using System.Linq;

namespace Day
{
    public class Day01
    {
        public void Run()
        {
            var input = File.ReadAllLines("input/01.txt").Select(int.Parse).ToArray();

            Console.WriteLine("01: Part 1: " + input.Sum(CalculatePart1));
            Console.WriteLine("01: Part 2: " + input.Sum(CalculatePart2));
        }

        public static int CalculatePart1(int n)
        {
            return n / 3 - 2;
        }

        public static int CalculatePart2(int n)
        {
            int total = 0;
            int fuel = n;
            while (fuel / 3 - 2 > 0)
            {
                fuel = (fuel / 3 - 2);
                total += fuel;
            }
            return total;
        }
    }
}
