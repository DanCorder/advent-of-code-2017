namespace advent_of_code_2017
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day18
    {
//         private const string Problem1Input = @"set a 1
// add a 2
// mul a a
// mod a 5
// snd a
// set a 0
// rcv a
// jgz a -1
// set a 1
// jgz a -2";
        private const string Problem1Input = @"set i 31
set a 1
mul p 17
jgz p p
mul a 2
add i -1
jgz i -2
add a -1
set i 127
set p 952
mul p 8505
mod p a
mul p 129749
add p 12345
mod p a
set b p
mod b 10000
snd b
add i -1
jgz i -9
jgz a 3
rcv b
jgz b -1
set f 0
set i 126
rcv a
rcv b
set p a
mul p -1
add p b
jgz p 4
snd a
set a b
jgz 1 3
snd b
set f 1
add i -1
jgz i -11
snd a
jgz f -16
jgz a -19";

        public static long SolveProblem1()
        {
            var registerValues = new Dictionary<char, long>();
            var instructions = Utils.SplitToLines(Problem1Input).ToList();
            long instructionIndex = 0;
            long lastFrequencyPlayed = 0;

            while (instructionIndex >= 0 && instructionIndex < instructions.Count)
            {
                var instruction = instructions[(int)instructionIndex];
                var instructionType = instruction.Substring(0, 3);

                switch (instructionType)
                {
                    case "snd":
                        lastFrequencyPlayed = GetValue(instruction.Substring(4,1), registerValues);
                        instructionIndex++;
                        break;
                    case "set":
                        SetValue(instruction[4], instruction.Substring(6), registerValues);
                        instructionIndex++;
                        break;
                    case "add":
                        Add(instruction[4], instruction.Substring(6), registerValues);
                        instructionIndex++;
                        break;
                    case "mul":
                        Multiply(instruction[4], instruction.Substring(6), registerValues);
                        instructionIndex++;
                        break;
                    case "mod":
                        Modulo(instruction[4], instruction.Substring(6), registerValues);
                        instructionIndex++;
                        break;
                    case "rcv":
                        if (GetValue(instruction.Substring(4,1), registerValues) != 0)
                        {
                            return lastFrequencyPlayed;
                        }
                        instructionIndex++;
                        break;
                    case "jgz":
                        if (GetValue(instruction.Substring(4,1), registerValues) > 0)
                        {
                            instructionIndex += GetValue(instruction.Substring(6), registerValues);
                        }
                        else
                        {
                            instructionIndex++;
                        }
                        break;
                    default:
                        throw new Exception(instructionType);
                }
            }

            return 0;
        }

        private static void Add(char register, string value, Dictionary<char, long> registerValues)
        {
            if (!registerValues.ContainsKey(register))
            {
                registerValues[register] = 0;
            }
            registerValues[register] = registerValues[register] + GetValue(value, registerValues);
        }

        private static void Multiply(char register, string value, Dictionary<char, long> registerValues)
        {
            if (!registerValues.ContainsKey(register))
            {
                registerValues[register] = 0;
            }
            registerValues[register] = registerValues[register] * GetValue(value, registerValues);
        }

        private static void Modulo(char register, string value, Dictionary<char, long> registerValues)
        {
            if (!registerValues.ContainsKey(register))
            {
                registerValues[register] = 0;
            }
            registerValues[register] = registerValues[register] % GetValue(value, registerValues);
        }

        private static long GetValue(string valueOrRegister, Dictionary<char, long> registerValues)
        {
            long value;
            if (Int64.TryParse(valueOrRegister, out value))
            {
                return value;
            }

            var register = valueOrRegister[0];
            if (!registerValues.ContainsKey(register))
            {
                registerValues[register] = 0;
            }
            return registerValues[register];
        }

        private static void SetValue(char register, string value, Dictionary<char, long> registerValues)
        {
            var numberValue = GetValue(value, registerValues);

            registerValues[register] = numberValue;
        }

        enum ProgState
        {
            ready,
            waitingForQueue,
            terminated
        }
        public static long SolveProblem2()
        {
            var zeroToOne = new Queue<long>();
            var oneToZero = new Queue<long>();

            var prog0 = new Prog(0, oneToZero, zeroToOne);
            var prog1 = new Prog(1, zeroToOne, oneToZero);

            var prog0State = ProgState.ready;
            var prog1State = ProgState.ready;

            while (true)
            {
                if (((prog0State == ProgState.waitingForQueue &&
                      oneToZero.Count() == 0) ||
                     prog0State == ProgState.terminated) &&
                    ((prog1State == ProgState.waitingForQueue &&
                      zeroToOne.Count() == 0) ||
                     prog1State == ProgState.terminated))
                {
                    return prog1.sendCount;
                }
                prog0State = prog0.Run();
                prog1State = prog1.Run();
            }
        }

        private class Prog
        {
            public Prog(long id, Queue<long> inQueue, Queue<long> outQueue)
            {
                registerValues['p'] = id;
                instructions = Utils.SplitToLines(Problem1Input).ToList();
                this.inQueue = inQueue;
                this.outQueue = outQueue;
            }

            Queue<long> inQueue;
            Queue<long> outQueue;
            Dictionary<char, long> registerValues = new Dictionary<char, long>();
            List<string> instructions;
            long instructionIndex = 0;
            public long sendCount = 0;

            public ProgState Run()
            {
                while (instructionIndex >= 0 && instructionIndex < instructions.Count)
                {
                    var instruction = instructions[(int)instructionIndex];
                    var instructionType = instruction.Substring(0, 3);

                    switch (instructionType)
                    {
                        case "snd":
                            outQueue.Enqueue(GetValue(instruction.Substring(4,1), registerValues));
                            instructionIndex++;
                            sendCount++;
                            break;
                        case "set":
                            SetValue(instruction[4], instruction.Substring(6), registerValues);
                            instructionIndex++;
                            break;
                        case "add":
                            Add(instruction[4], instruction.Substring(6), registerValues);
                            instructionIndex++;
                            break;
                        case "mul":
                            Multiply(instruction[4], instruction.Substring(6), registerValues);
                            instructionIndex++;
                            break;
                        case "mod":
                            Modulo(instruction[4], instruction.Substring(6), registerValues);
                            instructionIndex++;
                            break;
                        case "rcv":
                            if (inQueue.Count() == 0)
                            {
                                return ProgState.waitingForQueue;
                            }
                            SetValue(instruction[4], inQueue.Dequeue().ToString(), registerValues);
                            instructionIndex++;
                            break;
                        case "jgz":
                            if (GetValue(instruction.Substring(4,1), registerValues) > 0)
                            {
                                instructionIndex += GetValue(instruction.Substring(6), registerValues);
                            }
                            else
                            {
                                instructionIndex++;
                            }
                            break;
                        default:
                            throw new Exception(instructionType);
                    }
                }

                return ProgState.terminated;
            }
        }
    }
}