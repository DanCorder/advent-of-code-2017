namespace advent_of_code_2017
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day25
    {
        private const string Problem1Input = @"";

        enum State
        {
            A,
            B,
            C,
            D,
            E,
            F
        }

        public static int SolveProblem1()
        {
            var state = new Tuple<int, State>(0, State.A);
            var onePositions = new HashSet<int>();
            var checksumLimit = 12586542;

            for (int i = 0; i<checksumLimit; i++)
            {
                state = DoStep(state, onePositions);
            }

            return onePositions.Count();
        }

        private static Tuple<int, State> DoStep(Tuple<int, State> state, HashSet<int> onePositions)
        {
            switch (state.Item2)
            {
                case State.A:
                    if (!onePositions.Contains(state.Item1))
                    {
                        onePositions.Add(state.Item1);
                        return new Tuple<int, State>(state.Item1 + 1, State.B);
                    }
                    else
                    {
                        onePositions.Remove(state.Item1);
                        return new Tuple<int, State>(state.Item1 - 1, State.B);
                    }
                case State.B:
                    if (!onePositions.Contains(state.Item1))
                    {
                        return new Tuple<int, State>(state.Item1 + 1, State.C);
                    }
                    else
                    {
                        return new Tuple<int, State>(state.Item1 - 1, State.B);
                    }
                case State.C:
                    if (!onePositions.Contains(state.Item1))
                    {
                        onePositions.Add(state.Item1);
                        return new Tuple<int, State>(state.Item1 + 1, State.D);
                    }
                    else
                    {
                        onePositions.Remove(state.Item1);
                        return new Tuple<int, State>(state.Item1 - 1, State.A);
                    }
                case State.D:
                    if (!onePositions.Contains(state.Item1))
                    {
                        onePositions.Add(state.Item1);
                        return new Tuple<int, State>(state.Item1 - 1, State.E);
                    }
                    else
                    {
                        return new Tuple<int, State>(state.Item1 - 1, State.F);
                    }
                case State.E:
                    if (!onePositions.Contains(state.Item1))
                    {
                        onePositions.Add(state.Item1);
                        return new Tuple<int, State>(state.Item1 - 1, State.A);
                    }
                    else
                    {
                        onePositions.Remove(state.Item1);
                        return new Tuple<int, State>(state.Item1 - 1, State.D);
                    }
                case State.F:
                    if (!onePositions.Contains(state.Item1))
                    {
                        onePositions.Add(state.Item1);
                        return new Tuple<int, State>(state.Item1 + 1, State.A);
                    }
                    else
                    {
                        return new Tuple<int, State>(state.Item1 - 1, State.E);
                    }
                default:
                    throw new Exception();
            }
        }

        public static int SolveProblem2()
        {
            return 0;
        }
    }
}