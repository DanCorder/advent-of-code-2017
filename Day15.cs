namespace advent_of_code_2017
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day15
    {
        private const string Problem1Input = @"";
        // Generator A starts with 783
        // Generator B starts with 325
        private const long GenAStart = 783;
        private const long GenBStart = 325;
        private const long GenAFactor = 16807;
        private const long GenBFactor = 48271;
        private const long Divisor = 2147483647;

        public static int SolveProblem1()
        {
            var GenAPrevious = GenAStart;
            var GenBPrevious = GenBStart;
            long GenANext = 0;
            long GenBNext = 0;
            var matches = 0;
            for (long i = 0; i < 40000000; i++)
            {
                GenANext = (GenAPrevious * GenAFactor) % Divisor;
                GenBNext = (GenBPrevious * GenBFactor) % Divisor;

                var hexA = GenANext.ToString("X");
                var hexB = GenBNext.ToString("X");
                hexA = hexA.PadLeft('0');
                hexB = hexB.PadLeft('0');
                hexA = hexA.Substring(hexA.Length - 4);
                hexB = hexB.Substring(hexB.Length - 4);

                if (hexA == hexB)
                {
                    matches++;
                }

                GenAPrevious = GenANext;
                GenBPrevious = GenBNext;
            }
            return matches;
        }

        public static int SolveProblem2()
        {
            var GenAPrevious = GenAStart;
            var GenBPrevious = GenBStart;
            long GenANext = 0;
            long GenBNext = 0;
            var matches = 0;
            var judging = 0;
            var generateA = true;
            var generateB = true;
            string hexA = "a";
                string hexB = "b";

            while(judging < 5000000)
            {


                if (generateA)
                {
                    GenANext = (GenAPrevious * GenAFactor) % Divisor;
                    if (GenANext % 4 == 0)
                    {
                        hexA = GenANext.ToString("X");
                        hexA = hexA.PadLeft('0');
                        hexA = hexA.Substring(hexA.Length - 4);
                        generateA = false;
                    }
                }

                if (generateB)
                {
                    GenBNext = (GenBPrevious * GenBFactor) % Divisor;
                    if (GenBNext % 8 == 0)
                    {
                        hexB = GenBNext.ToString("X");
                        hexB = hexB.PadLeft('0');
                        hexB = hexB.Substring(hexB.Length - 4);
                        generateB = false;
                    }
                }

                if (!generateA && !generateB)
                {
                    generateA = true;
                    generateB = true;
                    judging++;
                    if (hexA == hexB)
                    {
                        matches++;
                    }
                }

                GenAPrevious = GenANext;
                GenBPrevious = GenBNext;
            }
            return matches;
        }
    }
}