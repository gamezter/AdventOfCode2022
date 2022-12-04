using System;
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
                int opponent = rounds[i][0] - 'A';
                int me = rounds[i][2] - 'X';
                if (opponent == ((me + 1) % 3)) // lose
                    score += 0;
                else if (opponent == me) // tie
                    score += 3;
                else if (me == ((opponent + 1) % 3)) // win
                    score += 6;

                score += me + 1;
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
                int opponent = rounds[i][0] - 'A';
                int outcome = rounds[i][2] - 'X';

                int sum = opponent + outcome;

                if (sum == 1 || sum == 4)
                    score += 1;
                else if (sum == 2)
                    score += 2;
                else if (sum == 0 || sum == 3)
                    score += 3;

                score += outcome * 3;
            }

            Console.WriteLine(score);
            Console.Read();
        }
    }
}
