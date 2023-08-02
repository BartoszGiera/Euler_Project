using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            { 6, () => P6.Run() },
            { 7, () => P7.Run() },
            { 8, () => P8.Run() },
            { 9, () => P9.Run() },
            { 10, () => P10.Run() },
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

#region 1 - 10

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
        Console.WriteLine($"\nCalculated in {Stopwatch.GetElapsedTime(timer).ToString(@"mm\:ss\.fff")}");
    }
}
#endregion

#region #4
class P4
{
    public static void Run()
    {
        int digits = 0, max = 1, min = 0;
        long result = 0;

        Console.Write("Largest palindrome made from the product of two X-digit numbers, where X = ");
        Int32.TryParse(Console.ReadLine(), out digits);

        long timer = Stopwatch.GetTimestamp();

        max = (int)Math.Pow(10, digits);
        min = max / 10;

        for (int i = max - 1; i >= min; i--)
        {
            for (int j = i; j >= min; j--)
            {
                if (IsPalindrome(i * j) && i * j > result)
                {
                    result = i * j;
                }
            }
        }

        if (result != 0)
            Console.WriteLine($"\nLargest found palindrome = {result}");
        else
            Console.WriteLine("\nDid not find any palindromes");

        Console.WriteLine($"Calculated in {Stopwatch.GetElapsedTime(timer).ToString(@"mm\:ss\.fff")}");
    }

    private static bool IsPalindrome(long num)
    {
        if (num < 0)
            return false;

        string palindrome = num.ToString();
        int n = palindrome.Length;

        for (int i = 0; i < n / 2; i++)
        {
            if (palindrome.ElementAt(i) != palindrome.ElementAt(n - 1 - i))
                return false;
        }
        return true;
    }
}
#endregion

#region #5
class P5
{
    private static long _result = 0;
    public static void Run()
    {
        int input = 0;

        Console.Write("Least common multiple of numbers 1 to ");
        Int32.TryParse(Console.ReadLine(), out input);
        long timer = Stopwatch.GetTimestamp();

        LCM(input - 1, input);
        
        Console.WriteLine($"\n\nLCM(1, 2, 3... ,{input}) = {_result}");
        Console.WriteLine($"Calculated in {Stopwatch.GetElapsedTime(timer).ToString(@"mm\:ss\.fff")}");
    }

    private static void LCM(int a, long b)
    {
        long result = a * b / GCD(a, b);

        while (a != 1)
        {
            LCM(a - 1, result);
            return;
        }

        _result = result;
    }

    private static long GCD(long a, long b)
    {
        long temp = 0, result = 0;

        if (b > a)
        {
            temp = a;
            a = b;
            b = temp;
        }

        if (a % b == 0)
            return b;

        for (long i = b - 1; i >= 1; i--)
        {
            if (a % i == 0 && b % i == 0)
            {
                result = i;
                break;
            }
        }

        return result;
    }
}
#endregion

#region #6
class P6
{
    public static void Run()
    {
        Console.WriteLine("Empty");
    }
}
#endregion

#region #7
class P7
{
    public static void Run()
    {
        Console.WriteLine("Empty");
    }
}
#endregion

#region #8
class P8
{
    public static void Run()
    {
        Console.WriteLine("Empty");
    }
}
#endregion

#region #9
class P9
{
    public static void Run()
    {
        Console.WriteLine("Empty");
    }
}
#endregion

#region #10
class P10
{
    public static void Run()
    {
        Console.WriteLine("Empty");
    }
}
#endregion

#endregion