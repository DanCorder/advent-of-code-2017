namespace advent_of_code_2017
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day10
    {
        private const string Problem1Input = @"120,93,0,90,5,80,129,74,1,165,204,255,254,2,50,113";

        public static int SolveProblem1()
        {
            var lengths = Problem1Input.Split(',').Select(Int32.Parse);

            var list = Enumerable.Range(0, 256).ToArray();
            var currentPosition = 0;
            var skipSize = 0;

            performHashRound(list, lengths, ref currentPosition, ref skipSize);

            return list[0] * list[1];
        }

        private static void performHashRound(int[] list, IEnumerable<int> lengths, ref int currentPosition, ref int skipSize)
        {
            var listLength = list.Length;

            foreach (var length in lengths)
            {
                if (length > list.Length)
                {
                    continue;
                }

                if (length > 1)
                {
                    var swapStart = currentPosition;
                    var swapEnd = (currentPosition + length - 1) % listLength;

                    do
                    {
                        var temp = list[swapStart];
                        list[swapStart] = list[swapEnd];
                        list[swapEnd] = temp;

                        swapStart = (swapStart + 1) % listLength;
                        swapEnd = swapEnd == 0 ? swapEnd = listLength - 1 : swapEnd - 1;

                    } while ((swapEnd != swapStart) && ((swapEnd + 1) % listLength) != swapStart);
                }

                currentPosition = (currentPosition + length + skipSize) % listLength;
                skipSize++;
            }
        }

        public static string SolveProblem2()
        {
            return KnotHash(Problem1Input);
        }

        public static string KnotHash(string input)
        {
            var standardSuffix = new int[17, 31, 73, 47, 23];
            var lengths = generateLengths(input);

            var list = Enumerable.Range(0, 256).ToArray();
            var currentPosition = 0;
            var skipSize = 0;

            for (int i = 0; i < 64; i++)
            {
                performHashRound(list, lengths, ref currentPosition, ref skipSize);
            }

            var denseHash = GetDenseHash(list);

            return string.Join("", denseHash.Select(ToHexString));
        }

        private static int[] generateLengths(string input)
        {
            var standardSuffix = new []{17, 31, 73, 47, 23};
            return System.Text.ASCIIEncoding.ASCII.GetBytes(input)
                .Select(x => (int)x)
                .Concat(standardSuffix)
                .ToArray();
        }

        private static int[] GetDenseHash(int[] sparseHash)
        {
            var ret = new List<int>();
            for (int i = 0; i < 16; i++)
            {
                var value = 0;
                for (int j = 0; j < 16; j++)
                {
                    value = value ^ sparseHash[(i*16)+j];
                }
                ret.Add(value);
            }

            return ret.ToArray();
        }

        private static string ToHexString(int value)
        {
            return value.ToString("X2");
        }
    }
}