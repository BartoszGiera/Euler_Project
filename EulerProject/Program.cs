using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
        long sumOfSquares = 0, squareOfSum = 0;
        int input = 0;

        Console.Write("Calculate the difference between sum of squares and square of sum od number form 1 to ");
        Int32.TryParse(Console.ReadLine(), out input);

        for (int i = 1; i <= input; i++)
        {
            sumOfSquares += i * i;
            squareOfSum += i;
        }

        squareOfSum *= squareOfSum;

        Console.WriteLine($"{squareOfSum} - {sumOfSquares} = {squareOfSum - sumOfSquares}");
    }
}
#endregion

#region #7
class P7
{
    public static void Run()
    {
        int primeCount = 4, n = 9, input = 0;
        bool isPrime = false;

        Console.WriteLine("Which prime number to calculate?");
        Int32.TryParse(Console.ReadLine(), out input);

        long timer = Stopwatch.GetTimestamp();

        while (primeCount < input)
        {
            n++;
            int max = (int)Math.Sqrt(n);
            isPrime = true;

            for (int i = 2; i <= max; i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                primeCount++;
                isPrime = false;
            }
        }

        Console.WriteLine($"Prime({input}) = {n}");
        Console.WriteLine($"Calculated in {Stopwatch.GetElapsedTime(timer).ToString(@"mm\:ss\.fff")}");
    }
}
#endregion

#region #8
class P8
{
    public static void Run()
    {
        string input = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
        string[] arr = input.Split('0');

        long maxFound = 0;
        long timer = Stopwatch.GetTimestamp();

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Length < 12)
                continue;

            for (int j = 0; j < arr[i].Length - 12; j++)
            {
                long temp = long.Parse(arr[i][j].ToString()) * long.Parse(arr[i][j + 1].ToString()) * long.Parse(arr[i][j + 2].ToString()) *
                            long.Parse(arr[i][j + 3].ToString()) * long.Parse(arr[i][j + 4].ToString()) * long.Parse(arr[i][j + 5].ToString()) *
                            long.Parse(arr[i][j + 6].ToString()) * long.Parse(arr[i][j + 7].ToString()) * long.Parse(arr[i][j + 8].ToString()) *
                            long.Parse(arr[i][j + 9].ToString()) * long.Parse(arr[i][j + 10].ToString()) * long.Parse(arr[i][j + 11].ToString()) *
                            long.Parse(arr[i][j + 12].ToString());

                if (temp > maxFound)
                    maxFound = temp;
            }
        }

        Console.WriteLine($"Greatest product of thirteen adjacent digits = {maxFound}");
        Console.WriteLine($"Calculated in {Stopwatch.GetElapsedTime(timer).ToString(@"mm\:ss\.fff")}");
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