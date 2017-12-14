namespace advent_of_code_2017
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day13
    {
        private const string Problem1Input = @"0: 3
1: 2
2: 6
4: 4
6: 4
8: 8
10: 9
12: 8
14: 5
16: 6
18: 8
20: 6
22: 12
24: 6
26: 12
28: 8
30: 8
32: 10
34: 12
36: 12
38: 8
40: 12
42: 12
44: 14
46: 12
48: 14
50: 12
52: 12
54: 12
56: 10
58: 14
60: 14
62: 14
64: 14
66: 17
68: 14
72: 14
76: 14
80: 14
82: 14
88: 18
92: 14
98: 18";

        public static int SolveProblem1()
        {
            var rangeByDepth = Utils.SplitToLines(Problem1Input)
                .ToDictionary(l => Int32.Parse(l.Split(':')[0]), l => Int32.Parse(l.Split(": ")[1]));

            var severity = 0;

            foreach (var depth in rangeByDepth.Keys)
            {
                if (IsAtTop(rangeByDepth[depth], depth))
                {
                    severity += (rangeByDepth[depth] * depth);
                }
            }

            return severity;
        }

        private static bool IsAtTop(int range, int time)
        {
            return time % ((range - 1) * 2) == 0;
        }

        public static int SolveProblem2()
        {
            var rangeByDepth = Utils.SplitToLines(Problem1Input)
                .ToDictionary(l => Int32.Parse(l.Split(':')[0]), l => Int32.Parse(l.Split(": ")[1]));

            var delay = -1;
            var caught = true;

            while (caught)
            {
                delay++;
                caught = false;
                foreach (var depth in rangeByDepth.Keys)
                {
                    if (IsAtTop(rangeByDepth[depth], depth + delay))
                    {
                        caught = true;
                        break;
                    }
                }
            }

            return delay;
        }
    }
}