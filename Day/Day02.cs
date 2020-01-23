using System;
using System.IO;
using System.Linq;

namespace Day
{
    public class Day02
    {
        public void Run()
        {
            StreamReader sr = new StreamReader("input/02.txt");
            int[] data = sr.ReadLine().Split(',').Select(x => Int32.Parse(x)).ToArray();

            Console.WriteLine("02: Part 1: " + Calc(data, 12, 2));

            for (int noun = 0; noun < 100; noun++)
                for (int verb = 0; verb < 100; verb++)
                    if (Calc(data, noun, verb) == 19690720)
                    {
                        Console.WriteLine("02: Part 2: " + noun + ", " + verb + ", Result=" + (100 * noun + verb));
                        return;
                    }
        }

        public static int Calc(int[] input, int noun, int verb)
        {
            int[] data = (int[])input.Clone();
            data[1] = noun;
            data[2] = verb;
            int pos = 0;
            while (data[pos] != 99)
            {
                if (data[pos] == 1)
                    data[data[pos + 3]] = data[data[pos + 1]] + data[data[pos + 2]];
                else if (data[pos] == 2)
                    data[data[pos + 3]] = data[data[pos + 1]] * data[data[pos + 2]];

                pos += 4;
            }

            return data[0];
        }
    }
}
