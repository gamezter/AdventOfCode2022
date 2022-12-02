using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2022
{
    class Day1
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day1.txt");
            int max = 0;
            int calories = 0;
            for(int i = 0; i < lines.Length; i++)
            {
                if(int.TryParse(lines[i], out var value))
                {
                    calories += value;
                }
                else
                {
                    if (calories > max)
                        max = calories;
                    calories = 0;
                }
            }

            Console.WriteLine(max);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day1.txt");
            List<int> calories = new List<int>();
            int currentCalories = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (int.TryParse(lines[i], out var value))
                {
                    currentCalories += value;
                }
                else
                {
                    calories.Add(currentCalories);
                    currentCalories = 0;
                }
            }

            calories.Sort();

            Console.WriteLine(calories[calories.Count - 1] + calories[calories.Count - 2] + calories[calories.Count - 3]);
            Console.Read();
        }
    }
}
