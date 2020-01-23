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

            Console.WriteLine("Part 1: " + input.Sum(CalculatePart1));
            Console.WriteLine("Part 2: " + input.Sum(CalculatePart2));
        }

        public static int CalculatePart1(int x)
        {
            return x / 3 - 2;
        }

        public static int CalculatePart2(int x)
        {
            int total = 0;
            int fuel = x;
            while (fuel / 3 - 2 > 0)
            {
                fuel = (fuel / 3 - 2);
                total += fuel;
            }
            return total;
        }
    }
}
