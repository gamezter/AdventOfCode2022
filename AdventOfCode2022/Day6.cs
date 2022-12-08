using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    class Day6
    {
        public static void part1()
        {
            string line = File.ReadAllText("day6.txt");

            int[] chars = new int[26];

            int i = 0;
            for (; i < line.Length; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    int index = line[i + j] - 'a';
                    if (chars[index] > 0)
                        goto skip;
                    chars[index]++;
                }
                break;
                skip:
                Array.Clear(chars, 0, 26);
            }

            Console.WriteLine(i + 4);
            Console.Read();
        }

        public static void part2()
        {
            string line = File.ReadAllText("day6.txt");

            int[] chars = new int[26];

            int i = 0;
            for (; i < line.Length; ++i)
            {
                for(int j = 0; j < 14; ++j)
                {
                    int index = line[i + j] - 'a';
                    if (chars[index] > 0)
                        goto skip;
                    chars[index]++;
                }
                break;
                skip:
                Array.Clear(chars, 0, 26);
            }

            Console.WriteLine(i + 14);
            Console.Read();
        }
    }
}
