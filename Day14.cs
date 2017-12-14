namespace advent_of_code_2017
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day14
    {
        private const string Problem1Input = @"wenycdww";

        public static int SolveProblem1()
        {
            var total = 0;
            for (int i = 0; i < 128; i++)
            {
                var hash = Day10.KnotHash(Problem1Input + "-" + i);
                var row = ToRow(hash);
                total += row.Where(c => c == '1').Count();
            }

            return total;
        }

        private static string ToRow(string hash)
        {
            return string.Join("", hash.Select(HexToBinary));
        }

        private static string HexToBinary(char hex)
        {
            var value = Convert.ToInt32(hex.ToString(), 16);
            return Convert.ToString(value, 2).PadLeft(4, '0');
        }

        public static int SolveProblem2()
        {
            var grid = new bool[128,128];

            for (int i = 0; i < 128; i++)
            {
                var hash = Day10.KnotHash(Problem1Input + "-" + i);
                var row = ToRow(hash);
                for (int j = 0; j < 128; j++)
                {
                    grid[j, i] = row[j] == '1';
                }
            }

            var inGroup = new HashSet<Tuple<int,int>>();
            var groups = 0;

            for (int x = 0; x < 128; x++)
            {
                for (int y = 0; y < 128; y++)
                {
                    var pos = new Tuple<int, int>(x, y);
                    if (!grid[x, y] || inGroup.Contains(pos))
                    {
                        continue;
                    }

                    groups++;

                    MapGroup(pos, grid, inGroup);
                }
            }

            return groups;
        }

        private static void MapGroup(Tuple<int, int> pos, bool[,] grid, HashSet<Tuple<int, int>> inGroup)
        {
            inGroup.Add(pos);

            checkNeighbour(pos.Item1 - 1, pos.Item2, grid, inGroup);
            checkNeighbour(pos.Item1 + 1, pos.Item2, grid, inGroup);
            checkNeighbour(pos.Item1, pos.Item2 - 1, grid, inGroup);
            checkNeighbour(pos.Item1, pos.Item2 + 1, grid, inGroup);
        }

        private static void checkNeighbour(int x, int y, bool[,] grid, HashSet<Tuple<int, int>> inGroup)
        {
            if (x < 0 || x > 127 || y < 0 || y > 127)
            {
                return;
            }

            var pos = new Tuple<int, int>(x, y);

            if (grid[x, y] && !inGroup.Contains(pos))
            {
                MapGroup(pos, grid, inGroup);
            }
        }
    }
}