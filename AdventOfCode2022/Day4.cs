using System;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
    class Day4
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day4.txt");
            Regex r = new Regex(@"(?<x1>\d+)-(?<x2>\d+),(?<y1>\d+)-(?<y2>\d+)");

            int count = 0;
            foreach(var line in lines)
            {
                var m = r.Match(line);
                int x1 = int.Parse(m.Groups["x1"].Value);
                int x2 = int.Parse(m.Groups["x2"].Value);
                int y1 = int.Parse(m.Groups["y1"].Value);
                int y2 = int.Parse(m.Groups["y2"].Value);

                if ((x1 <= y1 && y2 <= x2) || (y1 <= x1 && x2 <= y2))
                    count++;
            }

            Console.WriteLine(count);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day4.txt");
            Regex r = new Regex(@"(?<x1>\d+)-(?<x2>\d+),(?<y1>\d+)-(?<y2>\d+)");

            int count = 0;
            foreach (var line in lines)
            {
                var m = r.Match(line);
                int x1 = int.Parse(m.Groups["x1"].Value);
                int x2 = int.Parse(m.Groups["x2"].Value);
                int y1 = int.Parse(m.Groups["y1"].Value);
                int y2 = int.Parse(m.Groups["y2"].Value);

                if ((x1 <= y1 && y2 <= x2) || (y1 <= x1 && x2 <= y2) || (x1 <= y1 && y1 <= x2) || y1 <= x1 && x1 <= y2)
                    count++;
            }

            Console.WriteLine(count);
            Console.Read();
        }
    }
}
