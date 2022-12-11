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

            for (int y = 0; y < height; ++y) // left side
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
    }
}
