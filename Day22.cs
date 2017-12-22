namespace advent_of_code_2017
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day22
    {
        private const string Problem1Input = @"#.#...###.#.##.#....##.##
..####.#.######....#....#
###..###.#.###.##.##..#.#
...##.....##.###.##.###..
....#...##.##..#....###..
##.#..###.#.###......####
#.#.###...###..#.#.#.#.#.
###...##..##..#..##......
##.#.####.#..###....#.###
.....#..###....######..##
.##.#.###....#..#####..#.
########...##.##....##..#
.#.###.##.#..#..#.#..##..
.#.##.##....##....##.#.#.
..#.#.##.#..##..##.#..#.#
.####..#..#.###..#..#..#.
#.#.##......##..#.....###
...####...#.#.##.....####
#..##..##..#.####.#.#..#.
#...###.##..###..#..#....
#..#....##.##.....###..##
#..##...#...##...####..#.
#.###..#.#####.#..#..###.
###.#...#.##..#..#...##.#
.#...#..#.#.#.##.####....";

        enum Direction
        {
            up,
            down,
            left,
            right,
        }

        public static int SolveProblem1()
        {
            var infected = new HashSet<Tuple<int, int>>();
            var rows = Utils.SplitToLines(Problem1Input).ToArray();
            var initialHeight = rows.Length;
            var initialWidth = rows[0].Length;
            var hOffset = initialWidth / 2;
            var vOffset = initialHeight / 2;

            for (int y = 0; y<initialHeight; y++) {
                var row = rows[y];
                for (int x=0; x<initialWidth; x++) {
                    if (row[x] == '#')
                    {
                        infected.Add(new Tuple<int, int>(x - hOffset, (-1 * y)+ vOffset));
                    }
                }
            }

            var position = new Tuple<int, int>(0,0);
            var infections = 0;
            var direction = Direction.up;

            for (int i=0; i<10000; i++)
            {
                if (infected.Contains(position))
                {
                    switch(direction)
                    {
                        case Direction.up:
                            direction = Direction.right;
                            break;
                        case Direction.right:
                            direction = Direction.down;
                            break;
                        case Direction.down:
                            direction = Direction.left;
                            break;
                        case Direction.left:
                            direction = Direction.up;
                            break;
                    }
                    infected.Remove(position);
                }
                else
                {
                    switch(direction)
                    {
                        case Direction.up:
                            direction = Direction.left;
                            break;
                        case Direction.right:
                            direction = Direction.up;
                            break;
                        case Direction.down:
                            direction = Direction.right;
                            break;
                        case Direction.left:
                            direction = Direction.down;
                            break;
                    }
                    infected.Add(position);
                    infections++;
                }

                switch(direction)
                {
                    case Direction.up:
                        position = new Tuple<int, int>(position.Item1, position.Item2 + 1);
                        break;
                    case Direction.right:
                        position = new Tuple<int, int>(position.Item1 + 1, position.Item2);
                        break;
                    case Direction.down:
                        position = new Tuple<int, int>(position.Item1, position.Item2 - 1);
                        break;
                    case Direction.left:
                        position = new Tuple<int, int>(position.Item1 - 1, position.Item2);
                        break;
                }
            }

            return infections;
        }

        enum States
        {
            clean,
            weakened,
            infected,
            flagged
        }

        public static int SolveProblem2()
        {
            var infected = new HashSet<Tuple<int, int>>();
            var weakened = new HashSet<Tuple<int, int>>();
            var flagged = new HashSet<Tuple<int, int>>();
            var rows = Utils.SplitToLines(Problem1Input).ToArray();
            var initialHeight = rows.Length;
            var initialWidth = rows[0].Length;
            var hOffset = initialWidth / 2;
            var vOffset = initialHeight / 2;

            for (int y = 0; y<initialHeight; y++) {
                var row = rows[y];
                for (int x=0; x<initialWidth; x++) {
                    if (row[x] == '#')
                    {
                        infected.Add(new Tuple<int, int>(x - hOffset, (-1 * y)+ vOffset));
                    }
                }
            }

            var position = new Tuple<int, int>(0,0);
            var infections = 0;
            var direction = Direction.up;

            for (int i=0; i<10000000; i++)
            {
                if (infected.Contains(position))
                {
                    switch(direction)
                    {
                        case Direction.up:
                            direction = Direction.right;
                            break;
                        case Direction.right:
                            direction = Direction.down;
                            break;
                        case Direction.down:
                            direction = Direction.left;
                            break;
                        case Direction.left:
                            direction = Direction.up;
                            break;
                    }
                    infected.Remove(position);
                    flagged.Add(position);
                }
                else if (weakened.Contains(position))
                {
                    weakened.Remove(position);
                    infected.Add(position);
                    infections++;
                }
                else if (flagged.Contains(position))
                {
                    switch(direction)
                    {
                        case Direction.up:
                            direction = Direction.down;
                            break;
                        case Direction.right:
                            direction = Direction.left;
                            break;
                        case Direction.down:
                            direction = Direction.up;
                            break;
                        case Direction.left:
                            direction = Direction.right;
                            break;
                    }
                    flagged.Remove(position);
                }
                else
                {
                    switch(direction)
                    {
                        case Direction.up:
                            direction = Direction.left;
                            break;
                        case Direction.right:
                            direction = Direction.up;
                            break;
                        case Direction.down:
                            direction = Direction.right;
                            break;
                        case Direction.left:
                            direction = Direction.down;
                            break;
                    }
                    weakened.Add(position);
                }

                switch(direction)
                {
                    case Direction.up:
                        position = new Tuple<int, int>(position.Item1, position.Item2 + 1);
                        break;
                    case Direction.right:
                        position = new Tuple<int, int>(position.Item1 + 1, position.Item2);
                        break;
                    case Direction.down:
                        position = new Tuple<int, int>(position.Item1, position.Item2 - 1);
                        break;
                    case Direction.left:
                        position = new Tuple<int, int>(position.Item1 - 1, position.Item2);
                        break;
                }

                if (i % 10000 == 0)
                {
                    Console.WriteLine(DateTime.Now);
                    Console.WriteLine(i);
                }
            }

            return infections;
        }
    }
}