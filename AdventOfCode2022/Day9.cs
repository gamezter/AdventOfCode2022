using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    class Day9
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day9.txt");

            int hx = 0;
            int hy = 0;
            int tx = 0;
            int ty = 0;
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            for(int i = 0; i < lines.Length; ++i)
            {
                char dir = lines[i][0];
                int m = int.Parse(lines[i].Substring(2));
                for (int j = 0; j < m; ++j)
                {
                    switch (dir)
                    {
                        case 'U':
                             hy++;
                            break;
                        case 'D':
                            hy--;
                            break;
                        case 'R':
                            hx++;
                            break;
                        case 'L':
                            hx--;
                            break;
                    }

                    int dx = hx - tx;
                    int dy = hy - ty;
                    if (Math.Abs(dx) > 1 || Math.Abs(dy) > 1)
                    {
                        if (dx > 0)
                            dx = 1;
                        else if (dx < 0)
                            dx = -1;
                        if (dy > 0)
                            dy = 1;
                        else if (dy < 0)
                            dy = -1;

                        tx += dx;
                        ty += dy;
                    }

                    visited.Add((tx, ty));
                }
            }

            Console.WriteLine(visited.Count);
            Console.Read();
        }
    }
}
