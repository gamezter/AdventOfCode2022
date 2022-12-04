using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2022
{
    class Day2
    {
        public static void part1()
        {
            string[] rounds = File.ReadAllLines("day2.txt");
            int score = 0;
            for (int i = 0; i < rounds.Length; i++)
            {
                char opponent = rounds[i][0];
                char me = rounds[i][2];
                if ((opponent == 'A' && me == 'Z') || (opponent == 'B' && me == 'X') || (opponent == 'C' && me == 'Y')) // lose
                    score += 0;
                else if (opponent == 'A' && me == 'X' || opponent == 'B' && me == 'Y' || opponent == 'C' && me == 'Z') // tie
                    score += 3;
                else if (opponent == 'A' && me == 'Y' || opponent == 'B' && me == 'Z' || opponent == 'C' && me == 'X') // win
                    score += 6;

                if (me == 'X')
                    score += 1;
                else if (me == 'Y')
                    score += 2;
                else if (me == 'Z')
                    score += 3;

            }

            Console.WriteLine(score);
            Console.Read();
        }

        public static void part2()
        {
            string[] rounds = File.ReadAllLines("day2.txt");
            int score = 0;
            for (int i = 0; i < rounds.Length; i++)
            {
                char opponent = rounds[i][0];
                char outcome = rounds[i][2];
                if(outcome == 'X')
                {
                    score += 0;
                    if (opponent == 'A')
                        score += 3;
                    else if (opponent == 'B')
                        score += 1;
                    else if (opponent == 'C')
                        score += 2;
                }
                else if(outcome == 'Y')
                {
                    score += 3;
                    if (opponent == 'A')
                        score += 1;
                    else if (opponent == 'B')
                        score += 2;
                    else if (opponent == 'C')
                        score += 3;
                }
                else if(outcome == 'Z')
                {
                    score += 6;
                    if (opponent == 'A')
                        score += 2;
                    else if (opponent == 'B')
                        score += 3;
                    else if (opponent == 'C')
                        score += 1;
                }
            }

            Console.WriteLine(score);
            Console.Read();
        }
    }
}
