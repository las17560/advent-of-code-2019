using System;
using System.IO;
using System.Linq;

namespace Day
{
    public class Day04
    {
        public void Run()
        {
            Console.WriteLine("Part 1: " + Calculate("input/04.txt", false));
            Console.WriteLine("Part 2: " + Calculate("input/04.txt", true));
        }

        public static int Calculate(String input, bool part2)
        {
            StreamReader sr = new StreamReader(input);
            int[] range = sr.ReadLine().Split('-').Select(x => Int32.Parse(x)).ToArray();

            int min = range[0];
            int max = range[1];
            int possible = 0;

            for (int i = min; i < max; i++)
            {
                if (PossiblePassword(i, part2))
                    possible++;
            }

            return possible;
        }

        public static bool PossiblePassword(int password, bool part)
        {
            int[] pw = password.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();

            if (pw.Length != 6)
                return false;

            int previous = -1;
            bool adjacents1 = false;
            // Part 2
            bool adjacents2 = false;
            int streak = 1;

            foreach (int c in pw)
            {
                if (c < previous)
                    return false;
                if (c == previous)
                {
                    adjacents1 = true;

                    streak++;
                }
                else // Part 2
                {
                    if (streak == 2)
                        adjacents2 = true;
                    streak = 1;
                }

                previous = c;
            }

            if (streak == 2)
                adjacents2 = true;

            if (!part)
                return adjacents1;
            else
                return adjacents2;
        }
    }
}
