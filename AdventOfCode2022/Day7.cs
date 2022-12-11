using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
    class Day7
    {
        public static void part1()
        {
            string[] lines = File.ReadAllLines("day7.txt");

            List<string> currentDirectory = new List<string>();

            Dictionary<string, int> directories = new Dictionary<string, int>
            {
                { "/", 0 }
            };

            Regex cd = new Regex(@"\$ cd (?<dir>.*)");
            Regex file = new Regex(@"(?<size>\d+) (?<name>.*)");

            for(int i = 0; i < lines.Length; ++i)
            {
                if (cd.IsMatch(lines[i]))
                {
                    Match m = cd.Match(lines[i]);

                    string dir = m.Groups["dir"].Value;

                    if (dir == "..")
                        currentDirectory.RemoveAt(currentDirectory.Count - 1);
                    else
                        currentDirectory.Add(dir);
                    
                }
                else if (file.IsMatch(lines[i]))
                {
                    Match m = file.Match(lines[i]);
                    int size = int.Parse(m.Groups["size"].Value);

                    string path = "";

                    directories["/"] += size;

                    for (int j = 1; j < currentDirectory.Count; ++j)
                    {
                        path += "/" + currentDirectory[j];

                        if (directories.TryGetValue(path, out int value))
                        {
                            directories[path] = value + size;
                        }
                        else
                        {
                            directories[path] = size;
                        }
                    }
                }
            }

            int sum = 0;

            foreach(var directory in directories)
            {
                if (directory.Value <= 100000)
                    sum += directory.Value;
            }

            Console.WriteLine(sum);
            Console.Read();
        }

        public static void part2()
        {
            string[] lines = File.ReadAllLines("day7.txt");

            List<string> currentDirectory = new List<string>();

            Dictionary<string, int> directories = new Dictionary<string, int>
            {
                { "/", 0 }
            };

            Regex cd = new Regex(@"\$ cd (?<dir>.*)");
            Regex file = new Regex(@"(?<size>\d+) (?<name>.*)");

            for (int i = 0; i < lines.Length; ++i)
            {
                if (cd.IsMatch(lines[i]))
                {
                    Match m = cd.Match(lines[i]);

                    string dir = m.Groups["dir"].Value;

                    if (dir == "..")
                        currentDirectory.RemoveAt(currentDirectory.Count - 1);
                    else
                        currentDirectory.Add(dir);

                }
                else if (file.IsMatch(lines[i]))
                {
                    Match m = file.Match(lines[i]);
                    int size = int.Parse(m.Groups["size"].Value);

                    string path = "";

                    directories["/"] += size;

                    for (int j = 1; j < currentDirectory.Count; ++j)
                    {
                        path += "/" + currentDirectory[j];

                        if (directories.TryGetValue(path, out int value))
                        {
                            directories[path] = value + size;
                        }
                        else
                        {
                            directories[path] = size;
                        }
                    }
                }
            }

            int currentUnusedSpace = 70000000 - directories["/"];

            int minSpaceNeeded = 30000000 - currentUnusedSpace;

            int smallestCandidate = int.MaxValue;

            foreach(var directory in directories)
            {
                if (directory.Value > minSpaceNeeded && directory.Value < smallestCandidate)
                    smallestCandidate = directory.Value;
            }

            Console.WriteLine(smallestCandidate);
            Console.Read();
        }
    }
}
