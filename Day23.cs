namespace advent_of_code_2017
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Day23
    {
        private const string Problem1Input = @"set b 84
set c b
jnz a 2
jnz 1 5
mul b 100
sub b -100000
set c b
sub c -17000
set f 1
set d 2
set e 2
set g d
mul g e
sub g b
jnz g 2
set f 0
sub e -1
set g e
sub g b
jnz g -8
sub d -1
set g d
sub g b
jnz g -13
jnz f 2
sub h -1
set g b
sub g c
jnz g 2
jnz 1 3
sub b -17
jnz 1 -23";

        public static int SolveProblem1()
        {
            var registerValues = new Dictionary<char, long>();
            var instructions = Utils.SplitToLines(Problem1Input).ToList();
            long instructionIndex = 0;
            var muls = 0;

            while (instructionIndex >= 0 && instructionIndex < instructions.Count)
            {
                var instruction = instructions[(int)instructionIndex];
                var instructionType = instruction.Substring(0, 3);

                switch (instructionType)
                {
                    case "set":
                        SetValue(instruction[4], instruction.Substring(6), registerValues);
                        instructionIndex++;
                        break;
                    case "mul":
                        Multiply(instruction[4], instruction.Substring(6), registerValues);
                        instructionIndex++;
                        muls++;
                        break;
                    case "sub":
                        Subtract(instruction[4], instruction.Substring(6), registerValues);
                        instructionIndex++;
                        break;
                    case "jnz":
                        if (GetValue(instruction.Substring(4,1), registerValues) != 0)
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

            return muls;
        }

        private static void Subtract(char register, string value, Dictionary<char, long> registerValues)
        {
            if (!registerValues.ContainsKey(register))
            {
                registerValues[register] = 0;
            }
            registerValues[register] = registerValues[register] - GetValue(value, registerValues);
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

        // public static long SolveProblem2()
        // {
        //     var registerValues = new Dictionary<char, long>();
        //     //registerValues['a'] = 1L;
        //     var instructions = Utils.SplitToLines(Problem1Input).ToList();
        //     long instructionIndex = 0;
        //     var muls = 0L;

        //     while (instructionIndex >= 0 && instructionIndex < instructions.Count)
        //     {
        //         if (instructionIndex == 10)
        //         {
        //             instructionIndex = DoLoopB(registerValues);
        //         }
        //         if (instructionIndex == 11)
        //         {
        //             var loopTarget = GetValue("b", registerValues);
        //             var loopStart = GetValue("e", registerValues);
        //             var d = GetValue("d", registerValues);

        //             // if d * loopValue = loopTarget f = 0
        //             var fSet = loopTarget / d;
        //             if (fSet >= loopStart && fSet <= loopTarget)
        //             {
        //                 SetValue('f', "0", registerValues);
        //             }

        //             muls += (loopTarget - loopStart);
        //             SetValue('e', loopTarget.ToString(), registerValues);
        //             SetValue('g', "0", registerValues);
        //             instructionIndex = 20;
        //         }
        //         else
        //         {
        //             var instruction = instructions[(int)instructionIndex];
        //             var instructionType = instruction.Substring(0, 3);

        //             switch (instructionType)
        //             {
        //                 case "set":
        //                     SetValue(instruction[4], instruction.Substring(6), registerValues);
        //                     instructionIndex++;
        //                     break;
        //                 case "mul":
        //                     Multiply(instruction[4], instruction.Substring(6), registerValues);
        //                     instructionIndex++;
        //                     muls++;
        //                     break;
        //                 case "sub":
        //                     Subtract(instruction[4], instruction.Substring(6), registerValues);
        //                     instructionIndex++;
        //                     break;
        //                 case "jnz":
        //                     if (GetValue(instruction.Substring(4,1), registerValues) != 0)
        //                     {
        //                         instructionIndex += GetValue(instruction.Substring(6), registerValues);
        //                     }
        //                     else
        //                     {
        //                         instructionIndex++;
        //                     }
        //                     break;
        //                 default:
        //                     throw new Exception(instructionType);
        //             }
        //         }
        //     }

        //     return muls;
        //     // return GetValue("h", registerValues);
        // }


        // 902 too low
        //903 correct
        public static int SolveProblem2()
        {
            var count = 0;
            var b = 108400;
            for (int i = 0; i <= 1000; i++)
            {
                if (!isPrime(b + (17*i)))
                {
                    count++;
                }
            }

            return count;
        }

        private static bool isPrime(int number)
        {
            if (number % 2 == 0)  return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i+=2)
            {
                if (number % i == 0)  return false;
            }

            return true;
        }

        private static long DoLoopB(Dictionary<char, long> registerValues)
        {
            SetValue('e', "2", registerValues);

            var loopTarget = GetValue("b", registerValues);
            // var loopStart = 2;

            // for b between 108400 and 125400
            // b += 17
            // for any value between 2 and "b", if  (b % value = 0 && b / value between 2 and b) then h++

            // if B is not prime h++;

            return 24;
        }

        private static int DoLoopA(Dictionary<char, long> registerValues)
        {
            var loopTarget = GetValue("b", registerValues);
            var loopStart = 2;
            var d = GetValue("d", registerValues);

            // if d * loopValue = loopTarget f = 0
            var fSet = loopTarget / d;
            if (fSet >= loopStart && fSet <= loopTarget)
            {
                SetValue('f', "0", registerValues);
            }

            //muls += (loopTarget - loopStart);
            SetValue('e', loopTarget.ToString(), registerValues);
            SetValue('g', "0", registerValues);
            return 20;
        }
    }
}

// set b 84
// set c b
// jnz a 2
// jnz 1 5
// mul b 100
// sub b -100000
// set c b
// sub c -17000
// set f 1            <== Loop c
// set d 2
// set e 2   << b
// set g d   << a (g = (d * e) - b
// mul g e
// sub g b
// jnz g 2
// set f 0  <== if (d * e) - b = 0 { f = 0 }
// sub e -1   e++
// set g e
// sub g b   <== exit when g = e = b = 108400
// jnz g -8   <== loop a
// sub d -1       < d++
// set g d
// sub g b  <== exit when g = d = b
// jnz g -13  <== loop b
// jnz f 2
// sub h -1  < h++
// set g b
// sub g c
// jnz g 2      <== if b = c exit program
// jnz 1 3
// sub b -17
// jnz 1 -23   <== loop c

// loop a start
// a = 1
// b = 108400
// c = 125400
// f = 1
// g = 2
// d = 2
// e = 2

// a = 1
// b = 108400
// c = 125400
// f = 1
// d = 2
// e = 3
// g = -108397