namespace advent_of_code_2017
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day24
    {
        private const string Problem1Input = @"24/14
30/24
29/44
47/37
6/14
20/37
14/45
5/5
26/44
2/31
19/40
47/11
0/45
36/31
3/32
30/35
32/41
39/30
46/50
33/33
0/39
44/30
49/4
41/50
50/36
5/31
49/41
20/24
38/23
4/30
40/44
44/5
0/43
38/20
20/16
34/38
5/37
40/24
22/17
17/3
9/11
41/35
42/7
22/48
47/45
6/28
23/40
15/15
29/12
45/11
21/31
27/8
18/44
2/17
46/17
29/29
45/50";

        public static int SolveProblem1()
        {
            var parts = Utils.SplitToLines(Problem1Input)
                .Select(l => new Tuple<int,int>(Int32.Parse(l.Split("/")[0]), Int32.Parse(l.Split("/")[1])))
                .ToList();

            return findHighestTotal(0, 0, parts);
        }

        private static int findHighestTotal(int totalSoFar, int currentPort, List<Tuple<int, int>> parts)
        {
            var matchingParts = parts.Where(p => p.Item1 == currentPort || p.Item2 == currentPort).ToArray();
            var highestTotal = totalSoFar;
            foreach (var matchingPart in matchingParts)
            {
                var nextPort = matchingPart.Item1 == currentPort ? matchingPart.Item2 : matchingPart.Item1;
                parts.Remove(matchingPart);
                var total = findHighestTotal(totalSoFar + matchingPart.Item1 + matchingPart.Item2, nextPort, parts);
                highestTotal = Math.Max(total, highestTotal);
                parts.Add(matchingPart);
            }

            return highestTotal;
        }

        public static int SolveProblem2()
        {
            var parts = Utils.SplitToLines(Problem1Input)
                .Select(l => new Tuple<int,int>(Int32.Parse(l.Split("/")[0]), Int32.Parse(l.Split("/")[1])))
                .ToList();

            return findLongestBridge(0, 0, 0, parts).Item2;
        }

        private static Tuple<int, int> findLongestBridge(int length, int strengthSoFar, int currentPort, List<Tuple<int, int>> parts)
        {
            var matchingParts = parts.Where(p => p.Item1 == currentPort || p.Item2 == currentPort).ToArray();
            var bestBridge = new Tuple<int,int>(length, strengthSoFar);
            foreach (var matchingPart in matchingParts)
            {
                var nextPort = matchingPart.Item1 == currentPort ? matchingPart.Item2 : matchingPart.Item1;
                parts.Remove(matchingPart);
                var longestBridge = findLongestBridge(length + 1, strengthSoFar + matchingPart.Item1 + matchingPart.Item2, nextPort, parts);

                if (longestBridge.Item1 > bestBridge.Item1)
                {
                    bestBridge = longestBridge;
                }
                else if (longestBridge.Item1 == bestBridge.Item1 && longestBridge.Item2 > bestBridge.Item2)
                {
                    bestBridge = longestBridge;
                }

                parts.Add(matchingPart);
            }

            return bestBridge;
        }
    }
}