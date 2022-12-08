using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
    class Day5
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day5.txt");

            Regex r = new Regex(@"move (?<count>\d+) from (?<from>\d+) to (?<to>\d+)");

            Stack<char>[] stacks = new Stack<char>[9];

            for(int i = 0; i < 9; ++i)
            {
                stacks[i] = new Stack<char>();
                for(int j = 7; j >= 0; --j)
                {
                    char c = lines[j][i * 4 + 1];
                    if (c >= 'A' && c <= 'Z')
                        stacks[i].Push(c);
                }
            }

            for(int i = 10; i < lines.Length; ++i)
            {
                var m = r.Match(lines[i]);
                int count = int.Parse(m.Groups["count"].Value);
                int from = int.Parse(m.Groups["from"].Value) - 1;
                int to = int.Parse(m.Groups["to"].Value) - 1;

                for(int j = 0; j < count; ++j)
                {
                    stacks[to].Push(stacks[from].Pop());
                }
            }

            for(int i = 0; i < stacks.Length; ++i)
            {
                Console.Write(stacks[i].Peek());
            }

            Console.WriteLine();
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day5.txt");

            Regex r = new Regex(@"move (?<count>\d+) from (?<from>\d+) to (?<to>\d+)");

            List<char>[] stacks = new List<char>[9];

            for (int i = 0; i < 9; ++i)
            {
                stacks[i] = new List<char>();
                for (int j = 7; j >= 0; --j)
                {
                    char c = lines[j][i * 4 + 1];
                    if (c >= 'A' && c <= 'Z')
                        stacks[i].Add(c);
                }
            }

            for (int i = 10; i < lines.Length; ++i)
            {
                var m = r.Match(lines[i]);
                int count = int.Parse(m.Groups["count"].Value);
                int from = int.Parse(m.Groups["from"].Value) - 1;
                int to = int.Parse(m.Groups["to"].Value) - 1;

                stacks[to].AddRange(stacks[from].GetRange(stacks[from].Count - count, count));
                stacks[from].RemoveRange(stacks[from].Count - count, count);
            }

            for (int i = 0; i < stacks.Length; ++i)
            {
                Console.Write(stacks[i][stacks[i].Count - 1]);
            }

            Console.WriteLine();
            Console.Read();
        }
    }
}
