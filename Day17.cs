namespace advent_of_code_2017
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day17
    {
        private const int Problem1Input = 382;
        // private const int Problem1Input = 3;

        public static int SolveProblem1()
        {
            var buffer = new List<int> { 0 };
            var currentPos = 0;

            for (var insert=1; insert<2018; insert++)
            {
                var step = Problem1Input % buffer.Count;
                currentPos += step;
                currentPos = currentPos % buffer.Count;

                buffer.Insert(currentPos+1, insert);
                currentPos++;
            }

            return buffer[currentPos+1];
        }

        public static int SolveProblem2()
        {
            var currentPos = 0;
            var valueAfterZero = 0;
            var bufferLength = 1;

            for (var insert=1; insert<=50000000; insert++)
            {
                var step = Problem1Input % bufferLength;
                currentPos += step;
                currentPos = currentPos % bufferLength;

                if (currentPos == 0)
                {
                    valueAfterZero = insert;
                }
                bufferLength++;
                currentPos++;
            }

            return valueAfterZero;
        }
    }
}