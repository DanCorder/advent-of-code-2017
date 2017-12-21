namespace advent_of_code_2017
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day21
    {
        private const string Problem1Input = @"../.. => #.#/##./..#
#./.. => ###/.##/..#
##/.. => ..#/.#./##.
.#/#. => ###/.##/###
##/#. => ###/#.#/.##
##/## => #.#/..#/.#.
.../.../... => ..../.#../##.#/#.#.
#../.../... => .##./#.../.##./#..#
.#./.../... => ...#/.#.#/###./##.#
##./.../... => #.##/..#./.#.#/..##
#.#/.../... => ..#./.#../.#.#/###.
###/.../... => #.#./.#../.#../....
.#./#../... => ..#./##../.###/###.
##./#../... => ..#./###./#.#./#.#.
..#/#../... => ..##/###./.#.#/#...
#.#/#../... => #.../...#/.#.#/#...
.##/#../... => ###./####/.###/#.##
###/#../... => #.../#.##/#.../.#.#
.../.#./... => .##./#.#./#..#/..#.
#../.#./... => #.../##.#/#.#./.##.
.#./.#./... => ##../.###/####/....
##./.#./... => #.#./..../###./.#.#
#.#/.#./... => ..../..../#.##/.##.
###/.#./... => ####/#.##/.###/#.#.
.#./##./... => ####/#..#/#.##/.##.
##./##./... => .#.#/#.##/####/.###
..#/##./... => .##./...#/.#.#/..#.
#.#/##./... => #..#/...#/.#../.##.
.##/##./... => ##../#..#/##../..##
###/##./... => ..##/..../#.../..##
.../#.#/... => ###./#.../##.#/.#.#
#../#.#/... => ..#./...#/#..#/#.##
.#./#.#/... => ##../..#./##../###.
##./#.#/... => .#.#/#.#./####/.##.
#.#/#.#/... => .##./.##./#.##/#..#
###/#.#/... => #..#/.##./..#./##..
.../###/... => ###./#..#/.###/#.##
#../###/... => #.../#..#/####/##..
.#./###/... => ###./.##./#..#/.###
##./###/... => #..#/##../.##./#.#.
#.#/###/... => ..#./...#/#.../...#
###/###/... => ...#/##../...#/#.##
..#/.../#.. => ##.#/.#.#/.##./###.
#.#/.../#.. => ###./#..#/.#.#/#.##
.##/.../#.. => ...#/.#.#/.###/###.
###/.../#.. => .#../...#/..#./.#..
.##/#../#.. => .#../...#/.##./..#.
###/#../#.. => .###/##.#/#.##/.###
..#/.#./#.. => ##.#/##../##../#...
#.#/.#./#.. => #.../.###/#.#./#...
.##/.#./#.. => ###./#.##/###./####
###/.#./#.. => .#../..##/##.#/##.#
.##/##./#.. => ##.#/##../.##./...#
###/##./#.. => .#.#/.#../####/.##.
#../..#/#.. => ..##/###./...#/##..
.#./..#/#.. => .#../...#/.#../..##
##./..#/#.. => ###./..##/###./.##.
#.#/..#/#.. => ####/.#.#/...#/..##
.##/..#/#.. => #..#/.#../#.##/####
###/..#/#.. => .#../#.##/#.##/.#..
#../#.#/#.. => ..#./#.##/.#../.##.
.#./#.#/#.. => ##../#.../#.#./###.
##./#.#/#.. => #..#/.##./####/.#..
..#/#.#/#.. => ##.#/..#./..#./.#.#
#.#/#.#/#.. => .#../..#./..#./..##
.##/#.#/#.. => ##../#.##/#.#./#.##
###/#.#/#.. => ##.#/..##/##../##.#
#../.##/#.. => .###/####/#.##/..##
.#./.##/#.. => #.#./.##./###./#.##
##./.##/#.. => ..#./#..#/####/...#
#.#/.##/#.. => ####/.#.#/##../##.#
.##/.##/#.. => #.#./#..#/.#.#/.##.
###/.##/#.. => .#../.##./.##./.###
#../###/#.. => #..#/###./##.#/##..
.#./###/#.. => #.#./#..#/..#./#..#
##./###/#.. => ..../##.#/####/...#
..#/###/#.. => ..../#.../##../#..#
#.#/###/#.. => ..#./.#../..../##.#
.##/###/#.. => #..#/###./##.#/.###
###/###/#.. => #.../.##./#.##/.##.
.#./#.#/.#. => ...#/#.../.#../##.#
##./#.#/.#. => .#.#/#.#./.#../#.##
#.#/#.#/.#. => #.##/.##./###./....
###/#.#/.#. => ##../#..#/#.../.###
.#./###/.#. => ###./#.../.#../#..#
##./###/.#. => ##../##../#.../#...
#.#/###/.#. => ##../.#.#/#.##/#.#.
###/###/.#. => #.##/##.#/#.#./#...
#.#/..#/##. => ..../..#./####/..##
###/..#/##. => #.../...#/#.#./#.#.
.##/#.#/##. => ..##/###./.##./#...
###/#.#/##. => .#../###./##.#/...#
#.#/.##/##. => .###/##../.###/..#.
###/.##/##. => .#.#/##.#/.##./.###
.##/###/##. => ..#./.#.#/.#../#..#
###/###/##. => ###./#..#/####/...#
#.#/.../#.# => .#.#/.#../.#.#/#...
###/.../#.# => #..#/##../.#../...#
###/#../#.# => ..../.#../#.../..##
#.#/.#./#.# => #.#./####/.#.#/.##.
###/.#./#.# => ..#./####/#..#/..##
###/##./#.# => .##./.#../#.##/.#.#
#.#/#.#/#.# => ##../..##/##.#/#.#.
###/#.#/#.# => .##./#..#/#..#/.#.#
#.#/###/#.# => ..#./.###/#.##/#.##
###/###/#.# => ###./###./.#.#/###.
###/#.#/### => #.##/..##/#..#/...#
###/###/### => ...#/.#../##.#/.##.";
// private const string Problem1Input = @"../.# => ##./#../...
// .#./..#/### => #..#/..../..../#..#";

        static bool[,] start = { { false, false, true }, { true, false, true}, {false, true, true } };
        public static int SolveProblem1()
        {
            var rules = Utils.SplitToLines(Problem1Input).Select(s => new Rule(s)).ToArray();
            var image = (bool[,])start.Clone();

            for (int i=0; i < 5; i++)
            {
                image = ApplyRules(image, rules);
            }

            return image.Cast<bool>().Sum(b => b ? 1 : 0);
        }

        private static bool[,] ApplyRules(bool[,] image, Rule[] rules)
        {
            var imageSize = image.GetLength(0);
            if (imageSize % 2 == 0)
            {
                var ret = new bool[(imageSize/2)*3,(imageSize/2)*3];
                for (int x = 0; x<imageSize/2; x++)
                {
                    for (int y = 0; y<imageSize/2; y++)
                    {
                        var section = new bool[2,2];
                        copySection(image, section, 2, x*2, y*2, 0, 0);
                        var sa = section.Cast<bool>().ToArray();
                        var rule = rules.Single(r => r.isMatch(sa));
                        copySection(rule.Output, ret, 3, 0, 0, x*3, y*3);
                    }
                }
                return ret;
            }
            else
            {
                var ret = new bool[(imageSize/3)*4,(imageSize/3)*4];
                for (int x = 0; x<imageSize/3; x++)
                {
                    for (int y = 0; y<imageSize/3; y++)
                    {
                        var section = new bool[3,3];
                        copySection(image, section, 3, x*3, y*3, 0, 0);
                        var sa = section.Cast<bool>().ToArray();
                        var rule = rules.Single(r => r.isMatch(sa));
                        copySection(rule.Output, ret, 4, 0, 0, x*4, y*4);
                    }
                }
                return ret;
            }
        }

        private static void copySection(bool[,] source, bool[,] target, int size, int sourcex, int sourcey, int targetx, int targety)
        {
            for (int x = 0; x<size; x++)
            {
                for (int y = 0; y<size; y++)
                {
                    target[targetx + x, targety+y] = source[sourcex+x,sourcey+y];
                }
            }
        }

        public static int SolveProblem2()
        {
            var rules = Utils.SplitToLines(Problem1Input).Select(s => new Rule(s)).ToArray();
            var image = (bool[,])start.Clone();

            for (int i=0; i < 18; i++)
            {
                image = ApplyRules(image, rules);
            }

            return image.Cast<bool>().Sum(b => b ? 1 : 0);
        }

        private class Rule
        {
            public string RuleText {get;}

            public Rule(string rule)
            {
                RuleText = rule;
                var parts = rule.Split(" => ");
                var rows = parts[0].Split('/').Count();
                parseInput(parts[0]);
                Output = parse(parts[1]);
            }

            public bool isMatch(bool[] toMatch)
            {
                if (toMatch.Length != Matches[0].Length)
                {
                    return false;
                }

                return Matches.Any(m => m.SequenceEqual(toMatch));
            }

            private bool[,] parse(string gridString)
            {
                var rows = gridString.Split('/').ToArray();
                var ret = new bool[rows.Length, rows.Length];

                for (int y=0; y< rows.Length; y++)
                {
                    var row = rows[y];
                    for (int x=0; x< rows.Length; x++)
                    {
                        ret[x,y] = row[x] == '#';
                    }
                }

                return ret;
            }

            private void parseInput(string gridString)
            {
                var rows = gridString.Split('/').ToArray();
                var matches = new List<bool[,]>();

                if (rows.Length == 2)
                {
                    var grid = new bool[2,2];
                    grid[0,0] = rows[0][0] == '#';
                    grid[1,0] = rows[0][1] == '#';
                    grid[0,1] = rows[1][0] == '#';
                    grid[1,1] = rows[1][1] == '#';

                    matches.Add(grid);
                    matches.Add(rotate2x2(grid));
                    matches.Add(rotate2x2(rotate2x2(grid)));
                    matches.Add(rotate2x2(rotate2x2(rotate2x2(grid))));

                    var gridHorizontal = new bool[2,2];
                    gridHorizontal[0,0] = grid[0,1];
                    gridHorizontal[0,1] = grid[0,0];
                    gridHorizontal[1,0] = grid[1,1];
                    gridHorizontal[1,1] = grid[1,0];

                    matches.Add(gridHorizontal);
                    matches.Add(rotate2x2(gridHorizontal));
                    matches.Add(rotate2x2(rotate2x2(gridHorizontal)));
                    matches.Add(rotate2x2(rotate2x2(rotate2x2(gridHorizontal))));
                }
                else
                {
                    var grid = new bool[3,3];
                    grid[0,0] = rows[0][0] == '#';
                    grid[1,0] = rows[0][1] == '#';
                    grid[2,0] = rows[0][2] == '#';
                    grid[0,1] = rows[1][0] == '#';
                    grid[1,1] = rows[1][1] == '#';
                    grid[2,1] = rows[1][2] == '#';
                    grid[0,2] = rows[2][0] == '#';
                    grid[1,2] = rows[2][1] == '#';
                    grid[2,2] = rows[2][2] == '#';

                    matches.Add(grid);
                    matches.Add(rotate3x3(grid));
                    matches.Add(rotate3x3(rotate3x3(grid)));
                    matches.Add(rotate3x3(rotate3x3(rotate3x3(grid))));

                    var gridHorizontal = new bool[3,3];
                    gridHorizontal[0,0] = grid[0,2];
                    gridHorizontal[0,1] = grid[0,1];
                    gridHorizontal[0,2] = grid[0,0];
                    gridHorizontal[1,0] = grid[1,2];
                    gridHorizontal[1,1] = grid[1,1];
                    gridHorizontal[1,2] = grid[1,0];
                    gridHorizontal[2,0] = grid[2,2];
                    gridHorizontal[2,1] = grid[2,1];
                    gridHorizontal[2,2] = grid[2,0];

                    matches.Add(gridHorizontal);
                    matches.Add(rotate3x3(gridHorizontal));
                    matches.Add(rotate3x3(rotate3x3(gridHorizontal)));
                    matches.Add(rotate3x3(rotate3x3(rotate3x3(gridHorizontal))));
                }
                this.Matches = matches.Select(g => g.Cast<bool>().ToArray()).ToArray();
            }

            private bool[,] rotate3x3(bool[,] input)
            {
                var ret = new bool[3,3];

                ret[0,0] = input[0,2];
                ret[0,1] = input[1,2];
                ret[0,2] = input[2,2];
                ret[1,0] = input[0,1];
                ret[1,1] = input[1,1];
                ret[1,2] = input[2,1];
                ret[2,0] = input[0,0];
                ret[2,1] = input[1,0];
                ret[2,2] = input[2,0];

                return ret;
            }

            private bool[,] rotate2x2(bool[,] input)
            {
                var ret = new bool[2,2];

                ret[0,0] = input[0,1];
                ret[0,1] = input[1,1];
                ret[1,0] = input[0,0];
                ret[1,1] = input[1,0];

                return ret;
            }

            private bool[][] Matches {get;set;}
            public bool[,] Output {get;}
        }
    }
}