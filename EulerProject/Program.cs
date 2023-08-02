﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

#region Main
class ProgramRunner
{
    public static void Main(string[] args)
    {
        #region Problems mapping

        Dictionary<int, Action> problemsMap = new Dictionary<int, Action>
        {
            { 1, () => P1.Run() },
            { 2, () => P2.Run() },
            { 3, () => P3.Run() },
            { 4, () => P4.Run() },
            { 5, () => P5.Run() },
        };
        #endregion

        int problemNumber = 0;

        Console.WriteLine("I want to see the answer to problem number:\n");
        Int32.TryParse(Console.ReadLine(), out problemNumber);

        Console.WriteLine($"\n\nStarting solution to problem no.{problemNumber}...\n");
        Thread.Sleep(500);

        if (problemsMap.TryGetValue(problemNumber, out var x))
            x();
    }
}
#endregion

#region #1
class P1
{
    public static void Run()
    {
        int result = 0, temp = 0;

        while (temp < 1000)
        {
            temp += 3;
            if (temp < 1000)
                result += temp;
        }

        temp = 0;
        while (temp < 1000)
        {
            temp += 5;
            if (temp < 1000 && temp % 3 != 0)
                result += temp;
        }

        Console.WriteLine("Result for sum under 1000: " + result);

        Console.WriteLine("\n\nType in new maxima");
        Int32.TryParse(Console.ReadLine(), out temp);

        result = 3 * (int)(temp / 3) * (1 + (int)(temp / 3)) / 2 + 5 * (int)(temp / 5) * (1 + (int)(temp / 5)) / 2 - 15 * (int)(temp / 15) * (1 + (int)(temp / 15)) / 2;
        Console.WriteLine(result);
    }
}
#endregion

#region #2
class P2
{
    public static void Run()
    {
        int x = 1, y = 1, maxima = 0;
        long result = 0;

        while (true)
        {
            maxima = x + y;

            if (maxima <= 4000000)
            {
                if (maxima % 2 == 0)
                    result += maxima;
            }
            else
                break;

            x = y;
            y = maxima;
        }

        Console.WriteLine(result);
    }
}
#endregion

#region #3
class P3
{
    public static void Run()
    {
        long result = 1, input = 0, temp = 2;

        Console.WriteLine("Use base problem number? Y/N");

        if (Console.ReadLine() == "Y")
            input = 600851475143;
        else
        {
            Console.WriteLine("\nInput number for prime factorization:");
            Int64.TryParse(Console.ReadLine(), out input);
        }

        long timer = Stopwatch.GetTimestamp();

        while (input > result)
        {
            if (input % temp == 0)
            {
                input = input / temp;
                result = temp;
            }
            temp++;
        }

        Console.WriteLine($"\nHighest prime factor is equal to {result}");
        Console.WriteLine($"\nCalculated in {Stopwatch.GetElapsedTime(timer).ToString(@"m\:ss\.fff")}");
    }
}
#endregion

#region #4
class P4
{
    public static void Run()
    {
        Console.WriteLine("Empty");
    }
}
#endregion

#region #5
class P5
{
    public static void Run()
    {
        Console.WriteLine("Empty");
    }
}
#endregion