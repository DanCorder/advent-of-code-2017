namespace advent_of_code_2017
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day03
    {
        private const int Problem1Input = 325489;

        public static int SolveProblem1()
        {
            // Console.WriteLine(SolveProblem1_2(2));
            // Console.WriteLine(SolveProblem1_2(3));
            // Console.WriteLine(SolveProblem1_2(4));
            // Console.WriteLine(SolveProblem1_2(5));
            // Console.WriteLine(SolveProblem1_2(6));
            // Console.WriteLine(SolveProblem1_2(7));
            // Console.WriteLine(SolveProblem1_2(8));
            // Console.WriteLine(SolveProblem1_2(9));
            // Console.WriteLine(SolveProblem1_2(10));
            // Console.WriteLine(SolveProblem1_2(11));
            // Console.WriteLine(SolveProblem1_2(12));
            // Console.WriteLine(SolveProblem1_2(13));
            // Console.WriteLine(SolveProblem1_2(14));
            // Console.WriteLine(SolveProblem1_2(15));
            // Console.WriteLine(SolveProblem1_2(16));
            // Console.WriteLine(SolveProblem1_2(17));
            // Console.WriteLine(SolveProblem1_2(18));
            // Console.WriteLine(SolveProblem1_2(19));
            // Console.WriteLine(SolveProblem1_2(20));
            // Console.WriteLine(SolveProblem1_2(21));
            // Console.WriteLine(SolveProblem1_2(22));
            // Console.WriteLine(SolveProblem1_2(23));
            // Console.WriteLine(SolveProblem1_2(24));
            // Console.WriteLine(SolveProblem1_2(25));

            return SolveProblem1_2(325489);
        }

        public static int SolveProblem1_2(int value)
        {
            var minSquare = Math.Sqrt(value);
            var minWholeSquare = (int)Math.Ceiling(minSquare);
            if (minWholeSquare % 2 == 0) {
                minWholeSquare++;
            }

            var highestInSquare = minWholeSquare * minWholeSquare;
            var sideLength = minWholeSquare;
            var difference = highestInSquare - value;

            var distanceFromCorner = difference;
            while (distanceFromCorner >= (sideLength - 1)) {
                distanceFromCorner = distanceFromCorner - sideLength + 1;
            }
            if (distanceFromCorner > ((sideLength - 1) / 2))
            {
                distanceFromCorner = sideLength - 1 - distanceFromCorner;
            }

            var distanceFromCornerToCentre = minWholeSquare - 1;

            return distanceFromCornerToCentre - distanceFromCorner;
        }

        public static int SolveProblem2()
        {
            return 0;
        }
    }
}