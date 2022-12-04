using System;
using System.IO;

namespace AdventOfCode2022
{
    class Day3
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day3.txt");

            int sum = 0;
            foreach(var line in lines)
            {
                int size = line.Length / 2;
                for(int i = 0; i < size; ++i)
                {
                    char c = line[i];
                    if(line.IndexOf(c, size) != -1)
                    {
                        if(c >= 'a') // lowercase
                        {
                            sum += c - 'a' + 1;
                        }
                        else
                        {
                            sum += c - 'A' + 27;
                        }
                        break;
                    }
                }
            }

            Console.WriteLine(sum);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day3.txt");

            int sum = 0;
            for (int i = 0; i < lines.Length; i += 3)
            {
                string line1 = lines[i];
                string line2 = lines[i + 1];
                string line3 = lines[i + 2];
                for(int j = 0; j < line1.Length; ++j)
                {
                    char c = line1[j];
                    if(line2.IndexOf(c) != -1 && line3.IndexOf(c) != -1)
                    {
                        if (c >= 'a') // lowercase
                        {
                            sum += c - 'a' + 1;
                        }
                        else
                        {
                            sum += c - 'A' + 27;
                        }
                        break;
                    }
                }
            }

            Console.WriteLine(sum);
            Console.Read();
        }
    }
}
