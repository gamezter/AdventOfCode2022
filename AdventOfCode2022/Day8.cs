using System;
using System.IO;

namespace AdventOfCode2022
{
    class Day8
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day8.txt");

            int width = lines[0].Length;
            int height = lines.Length;

            bool[,] visible = new bool[width, height];

            for(int y = 0; y < height; ++y) // left side
            {
                int tallest = -1;
                for(int x = 0; x < width; ++x)
                {
                    int tree = lines[y][x] - '0';
                    if (tree > tallest)
                    {
                        visible[x, y] = true;
                        tallest = tree;
                    } 
                }
            }

            for (int y = 0; y < height; ++y) // right side
            {
                int tallest = -1;
                for (int x = width - 1; x >= 0; --x)
                {
                    int tree = lines[y][x] - '0';
                    if (tree > tallest)
                    {
                        visible[x, y] = true;
                        tallest = tree;
                    }
                }
            }

            for (int x = 0; x < width; ++x) // top side
            {
                int tallest = -1;
                for (int y = 0; y < height; ++y)
                {
                    int tree = lines[y][x] - '0';
                    if (tree > tallest)
                    {
                        visible[x, y] = true;
                        tallest = tree;
                    }
                }
            }

            for (int x = 0; x < width; ++x) // bottom side
            {
                int tallest = -1;
                for (int y = height - 1; y >= 0; --y)
                {
                    int tree = lines[y][x] - '0';
                    if (tree > tallest)
                    {
                        visible[x, y] = true;
                        tallest = tree;
                    }
                }
            }

            int count = 0;

            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    if (visible[x, y])
                        count++;
                }
            }

            Console.WriteLine(count);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day8.txt");

            int width = lines[0].Length;
            int height = lines.Length;

            int[,] score = new int[width, height];

            for (int y = 0; y < height; ++y) // left side
            {
                int[] highest = new int[10];
                for (int x = 0; x < width; ++x)
                {
                    int tree = lines[y][x] - '0';
                    score[x, y] = x - highest[tree];
                    for (int i = 0; i <= tree; ++i)
                        highest[i] = x;
                }
            }

            for (int y = 0; y < height; ++y) // right side
            {
                int[] highest = new int[10];
                for (int i = 0; i < 10; ++i)
                    highest[i] = width - 1;
                for (int x = width - 1; x >= 0; --x)
                {
                    int tree = lines[y][x] - '0';
                    score[x, y] *= highest[tree] - x;
                    for (int i = 0; i <= tree; ++i)
                        highest[i] = x;
                }
            }

            for (int x = 0; x < width; ++x) // top side
            {
                int[] highest = new int[10];
                for (int y = 0; y < height; ++y)
                {
                    int tree = lines[y][x] - '0';
                    score[x, y] *= y - highest[tree];
                    for (int i = 0; i <= tree; ++i)
                        highest[i] = y;
                }
            }

            for (int x = 0; x < width; ++x) // bottom side
            {
                int[] highest = new int[10];
                for (int i = 0; i < 10; ++i)
                    highest[i] = height - 1;
                for (int y = height - 1; y >= 0; --y)
                {
                    int tree = lines[y][x] - '0';
                    score[x, y] *= highest[tree] - y;
                    for (int i = 0; i <= tree; ++i)
                        highest[i] = y;
                }
            }

            int max = 0;

            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    if (score[x, y] > max)
                        max = score[x, y];
                }
            }

            Console.WriteLine(max);
            Console.Read();
        }
    }
}
