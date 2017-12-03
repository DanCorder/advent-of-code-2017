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
            var coords = positionToXY(value);

            return Math.Abs(coords.Item1) + Math.Abs(coords.Item2);
        }

        public static int SolveProblem2()
        {
            // Console.WriteLine(positionToXY(2));
            // Console.WriteLine(positionToXY(3));
            // Console.WriteLine(positionToXY(4));
            // Console.WriteLine(positionToXY(5));
            // Console.WriteLine(positionToXY(6));
            // Console.WriteLine(positionToXY(7));
            // Console.WriteLine(positionToXY(8));
            // Console.WriteLine(positionToXY(9));
            // Console.WriteLine(positionToXY(10));
            // Console.WriteLine(positionToXY(11));
            // Console.WriteLine(positionToXY(12));

            // Console.WriteLine(XYToPosition(new Tuple<int, int>(1, 0)));
            // Console.WriteLine(XYToPosition(new Tuple<int, int>(1, 1)));
            // Console.WriteLine(XYToPosition(new Tuple<int, int>(0, 1)));
            // Console.WriteLine(XYToPosition(new Tuple<int, int>(-1, 1)));
            // Console.WriteLine(XYToPosition(new Tuple<int, int>(-1, 0)));
            // Console.WriteLine(XYToPosition(new Tuple<int, int>(-1, -1)));
            // Console.WriteLine(XYToPosition(new Tuple<int, int>(0, -1)));
            // Console.WriteLine(XYToPosition(new Tuple<int, int>(1, -1)));
            // Console.WriteLine(XYToPosition(new Tuple<int, int>(2, -1)));
            // Console.WriteLine(XYToPosition(new Tuple<int, int>(2, 0)));
            // Console.WriteLine(XYToPosition(new Tuple<int, int>(2, 1)));

            var limit = 325489;
            var valuesByPosition = new Dictionary<int, int>();
            valuesByPosition[1] = 1;

            var position = 2;
            while(true) {
                var value = calculateValue(position, valuesByPosition);
                //Console.WriteLine(value);

                if (value > limit) {
                    //343767 too high
                    return value;
                }

                valuesByPosition[position] = value;

                position++;
            }
        }

        private static int calculateValue(int position, Dictionary<int, int> valuesByPosition)
        {
            var coords = positionToXY(position);
            var value = 0;

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    value += getValueAt(new Tuple<int, int>(coords.Item1 + x, coords.Item2 + y), valuesByPosition);
                }
            }
            return value;
        }

        private static Tuple<int, int> positionToXY(int position)
        {
            var minSquare = Math.Sqrt(position);
            var minWholeSquare = (int)Math.Ceiling(minSquare);
            if (minWholeSquare % 2 == 0) {
                minWholeSquare++;
            }

            var highestInSquare = minWholeSquare * minWholeSquare;
            var sideLength = minWholeSquare;
            var difference = highestInSquare - position;

            var sideIndex = difference / (sideLength - 1); // 0 = bottom, 1 = left, 2 = top, 3 = right
            var sideDistanceFromCorner = difference % (sideLength - 1);

            int corner4X = (sideLength - 1) / 2;
            int corner4Y = -corner4X;
            int x;
            int y;

            switch(sideIndex)
            {
                case 0:
                    x = corner4X - sideDistanceFromCorner;
                    y = corner4Y;
                break;
                case 1:
                    x = corner4X - sideLength + 1;
                    y = corner4Y + sideDistanceFromCorner;
                break;
                case 2:
                    x = corner4X - sideLength + 1 + sideDistanceFromCorner;
                    y = corner4Y + sideLength - 1;
                break;
                case 3:
                    x = corner4X;
                    y = corner4Y + sideLength - 1 - sideDistanceFromCorner;
                break;
                default:
                    throw new Exception("impossible");
            }

            return new Tuple<int, int>(x,y);
        }

        private static int XYToPosition(Tuple<int, int> coords)
        {
            var x = coords.Item1;
            var y = coords.Item2;
            var sideLength = (Math.Max(Math.Abs(x), Math.Abs(y)) * 2) + 1;

            int corner4X = (sideLength - 1) / 2;
            int corner4Y = -corner4X;

            var sideIndex = 0; // 0 = bottom, 1 = left, 2 = top, 3 = right
            var sideDistanceFromCorner = 0;
            if (x == corner4X && y != corner4Y) {
                sideIndex = 3;
                sideDistanceFromCorner = corner4Y + sideLength - 1 - y;
            } else if (y == (corner4Y + sideLength - 1)) {
                sideIndex = 2;
                sideDistanceFromCorner = x - (corner4X - sideLength + 1);
            } else if (x == (corner4X - sideLength + 1)) {
                sideIndex = 1;
                sideDistanceFromCorner = y - corner4Y;
            } else {
                sideIndex = 0;
                sideDistanceFromCorner = corner4X - x;
            }

            var highestInSquare = sideLength * sideLength;

            return highestInSquare - sideDistanceFromCorner - (sideIndex * (sideLength - 1));
        }

        private static int getValueAt(Tuple<int, int> coords, Dictionary<int, int> valuesByPosition)
        {
            var position = XYToPosition(coords);
            if (valuesByPosition.ContainsKey(position))
            {
                return valuesByPosition[position];
            }
            return 0;
        }
    }
}