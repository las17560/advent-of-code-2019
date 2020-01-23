using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day
{
    public class Day03
    {
        public void Run()
        {
            Console.WriteLine("03: Part 1: " + Calc("input/03.txt", 1));
            Console.WriteLine("03: Part 2: " + Calc("input/03.txt", 2));
        }

        public static int Calc(String input, int part)
        {
            StreamReader sr = new StreamReader(input);
            string[] wire1 = sr.ReadLine().Split(',');
            string[] wire2 = sr.ReadLine().Split(',');

            Dictionary<Point, int> points = new Dictionary<Point, int>();
            Dictionary<Point, int> intersections = new Dictionary<Point, int>();

            int x = 0;
            int y = 0;
            int steps = 0;


            foreach (String s in wire1)
            {
                char dir = char.Parse(s.Substring(0, 1));
                int dist = int.Parse(s.Substring(1));

                for (int i = 0; i < dist; i++)
                {
                    steps++;
                    switch (dir)
                    {
                        case 'R': x++; break;
                        case 'L': x--; break;
                        case 'U': y++; break;
                        case 'D': y--; break;
                        default: break;
                    };

                    Point p = new Point(x, y);
                    if (!points.ContainsKey(p))
                        points.Add(p, steps);
                }
            }
            x = 0;
            y = 0;
            steps = 0;

            foreach (String s in wire2)
            {
                char dir = char.Parse(s.Substring(0, 1));
                int dist = int.Parse(s.Substring(1));

                for (int i = 0; i < dist; i++)
                {
                    steps++;
                    switch (dir)
                    {
                        case 'R': x++; break;
                        case 'L': x--; break;
                        case 'U': y++; break;
                        case 'D': y--; break;
                        default: break;
                    }

                    Point p = new Point(x, y);
                    if (points.ContainsKey(p))
                        intersections.Add(p, points[p] + steps);
                }
            }

            if (part == 1)
                return ClosestManhattanDist(intersections);
            else if (part == 2)
                return intersections.Values.Min();
            else
                return -1;
        }

        private static int ClosestManhattanDist(Dictionary<Point, int> intersections)
        {
            int closest = -1;
            foreach (KeyValuePair<Point, int> p in intersections)
            {
                if (closest == -1 || ManhattanDist(p.Key) < closest)
                    closest = ManhattanDist(p.Key);
            }
            return closest;
        }

        private static int ManhattanDist(Point p)
        {
            return Math.Abs(p.GetX()) + Math.Abs(p.GetY());
        }
    }
    public class Point
    {
        private int x;
        private int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public override bool Equals(object o)
        {
            if (o == null || o.GetType() != typeof(Point))
                return false;
            Point p = (Point)o;
            return (p.x == x && p.y == y);
        }

        public override int GetHashCode() => new { x, y }.GetHashCode();
    }
}
