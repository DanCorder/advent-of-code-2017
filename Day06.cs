namespace advent_of_code_2017
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day06
    {
        // private const string Problem1Input = @"0	2	7	0";
        private const string Problem1Input = @"0	5	10	0	11	14	13	4	11	8	8	7	1	4	12	11";

        public static int SolveProblem1()
        {
            var previouslySeen = new HashSet<string>();
            var memory = Problem1Input.Split('\t').Select(Int32.Parse).ToArray();

            var steps = 0;

            while (true)
            {
                var memoryAsString = String.Join(' ', memory.Select(x => x.ToString()));
                Console.WriteLine(memoryAsString);

                if (previouslySeen.Contains(memoryAsString)) {
                    break;
                }
                previouslySeen.Add(memoryAsString);
                memory = Redistribute(memory);

                steps++;
            }


            return steps;
        }

        private static int[] Redistribute(int[] memory)
        {
            var maxValue = memory.Max();
            var indexToRedistribute = 0;

            for (; indexToRedistribute < memory.Length; indexToRedistribute++)
            {
                if (memory[indexToRedistribute] == maxValue)
                {
                    break;
                }
            }

            memory[indexToRedistribute] = 0;
            for (int i = 0; i < maxValue; i++)
            {
                var nextIndex = (indexToRedistribute + i + 1) % memory.Length;
                memory[nextIndex] = memory[nextIndex] + 1;
            }

            return memory;
        }

        public static int SolveProblem2()
        {
            var previouslySeen = new Dictionary<string, int>();
            var memory = Problem1Input.Split('\t').Select(Int32.Parse).ToArray();

            var steps = 0;

            while (true)
            {
                var memoryAsString = String.Join(' ', memory.Select(x => x.ToString()));
                Console.WriteLine(memoryAsString);

                if (previouslySeen.ContainsKey(memoryAsString)) {
                    return steps - previouslySeen[memoryAsString];
                }
                previouslySeen.Add(memoryAsString, steps);
                memory = Redistribute(memory);

                steps++;
            }
        }
    }
}