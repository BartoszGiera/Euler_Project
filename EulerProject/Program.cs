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
            { 11, () => P11.Run() },
            { 12, () => P12.Run() },
            { 13, () => P13.Run() },
            { 14, () => P14.Run() },
            { 15, () => P15.Run() },
            { 16, () => P16.Run() },
            { 17, () => P17.Run() },
            { 18, () => P18.Run() },
            { 19, () => P19.Run() },
            { 20, () => P20.Run() },
            { 21, () => P21.Run() },
            { 22, () => P22.Run() },
            { 23, () => P23.Run() },
            { 24, () => P24.Run() },
            { 25, () => P25.Run() },
            { 26, () => P26.Run() },
            { 27, () => P27.Run() },
            { 28, () => P28.Run() },
            { 29, () => P29.Run() },
            { 30, () => P30.Run() },
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
        int n = 0;

        Console.Write("Input what a + b + c equals to: ");
        Int32.TryParse(Console.ReadLine(), out n );

        long timer = Stopwatch.GetTimestamp();

        Console.WriteLine(BruteForce(n));

        Console.WriteLine($"Calculated (with brute force O(n^3)) in {Stopwatch.GetElapsedTime(timer).ToString(@"mm\:ss\.fff")}");



        timer = Stopwatch.GetTimestamp();

        Console.WriteLine(OptimizedBrute(n));

        Console.WriteLine($"Calculated (with optimized brute force ~O(n^2)) in {Stopwatch.GetElapsedTime(timer).ToString(@"mm\:ss\.fff")}");
    }

    private static long BruteForce(int n)
    {
        for (long a = 1; a < n / 2; a++)
        {
            for (long b = 1; b < n / 2; b++)
            {
                for (long c = 1; c < n / 2; c++)
                {
                    if (a + b + c == n && a * a + b * b == c * c)
                        return a * b * c;
                }
            }
        }

        return 0;
    }

    private static long OptimizedBrute(int n)
    {
        for (long a = 1; a < n / 2; a++)
        {
            for (long b = 1; b < n / 2; b++)
            {
                if (a * a + b * b == (n - a - b) * (n - a - b))
                    return a * b * (n - a - b);
            }
        }
        return 0;
    }
}
#endregion

#region #10
class P10
{
    public static void Run()
    {
        long result = 2 + 3 + 5 + 7;
        int input = 0;
        bool isPrime = false;

        Console.Write("Sum all primes below: ");
        Int32.TryParse(Console.ReadLine(), out input);

        long timer = Stopwatch.GetTimestamp();

        for (int i = 9; i < input; i++)
        {
            int max = (int)Math.Sqrt(i);
            isPrime = true;

            if (i % 2 == 0)
                isPrime = false;
            else
            {
                for (int j = 3; j <= max; j += 2)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            if (isPrime)
            {
                result += i;
                isPrime = false;
            }
        }

        Console.WriteLine($"Sum of all primes below {input} = {result}");
        Console.WriteLine($"Calculated in {Stopwatch.GetElapsedTime(timer).ToString(@"mm\:ss\.fff")}");
    }
}
#endregion

#endregion

#region 11 - 20

#region #11
class P11
{
    public static void Run()
    {
        string input = "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08\r\n49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00\r\n81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65\r\n52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91\r\n22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80\r\n24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50\r\n32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70\r\n67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21\r\n24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72\r\n21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95\r\n78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92\r\n16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57\r\n86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58\r\n19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40\r\n04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66\r\n88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69\r\n04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36\r\n20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16\r\n20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54\r\n01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";
        string[][] arr = input.Split("\r\n").Select(x => x.Split(" ")).ToArray();
        int[][] matrix = new int[arr.Length][];
        int result = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            matrix[i] = Array.ConvertAll(arr[i], Int32.Parse);
        }

        long timer = Stopwatch.GetTimestamp();

        //Vertical search
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length - 3; j++)
            {
                if (matrix[i][j] * matrix[i][j + 1] * matrix[i][j + 2] * matrix[i][j + 3] > result)
                    result = matrix[i][j] * matrix[i][j + 1] * matrix[i][j + 2] * matrix[i][j + 3];
            }
        }

        //Horizontal search
        for (int i = 0; i < matrix.Length - 3; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] * matrix[i + 1][j] * matrix[i + 2][j] * matrix[i + 3][j] > result)
                    result = matrix[i][j] * matrix[i + 1][j] * matrix[i + 2][j] * matrix[i + 3][j];
            }
        }

        //Diagonal search (top-left to bottom-right)
        for (int i = 0; i < matrix.Length - 3; i++)
        {
            for (int j= 0; j < matrix[i].Length - 3; j++)
            {
                if (matrix[i][j] * matrix[i + 1][j + 1] * matrix[i + 2][j + 2] * matrix[i + 3][j + 3] > result)
                    result = matrix[i][j] * matrix[i + 1][j + 1] * matrix[i + 2][j + 2] * matrix[i + 3][j + 3];
            }
        }

        //Diagonal search (bottom-left to top-right)
        for (int i = 3; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length - 3; j++)
            {
                if (matrix[i][j] * matrix[i - 1][j + 1] * matrix[i - 2][j + 2] * matrix[i - 3][j + 3] > result)
                    result = matrix[i][j] * matrix[i - 1][j + 1] * matrix[i - 2][j + 2] * matrix[i - 3][j + 3];
            }
        }

        Console.WriteLine($"Greatest product of four adjacent numbers in given matrix = {result}");
        Console.WriteLine($"Calculated in {Stopwatch.GetElapsedTime(timer).ToString(@"mm\:ss\.fff")}");
    }
}
#endregion

#region #12
class P12
{
    private static List<int> primes = new List<int>();
    public static List<int> PrimesList { get => primes; set => primes = value; }

    public static void Run()
    {
        long num = 0;
        bool useBrute = false;

        Console.WriteLine("How many divisors for first triangle number to have?");
        Int32.TryParse(Console.ReadLine(), out int input);
        Console.WriteLine("Use BruteForce solution? Y/N");

        if (Console.ReadLine() == "Y")
            useBrute = true;

        long timer = Stopwatch.GetTimestamp();

        if (useBrute)
            num = BruteForce(input);
        else
            num = Optimized(input);

        Console.WriteLine($"First triangle number to have {input} divisors = {num}");
        Console.WriteLine($"Calculated in {Stopwatch.GetElapsedTime(timer).ToString(@"mm\:ss\.fff")}");
    }

    private static long BruteForce(int input)
    {
        long num = 0, temp = 1;
        int divisorCount = 2;

        while (true)
        {
            num += temp;

            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                    divisorCount++;
            }

            if (divisorCount >= input)
                return num;
            else
            {
                temp++;
                divisorCount = 2;
            }
        }
    }

    private static long Optimized(int input)
    {
        long num = 0, temp = 1;

        PrimesList = Primes();

        while (true)
        {
            num += temp;

            if (PrimeFactorization(num) >= input)
                return num;
            else
                temp++;
        }
    }

    /// <summary>
    /// Prime numbers generator
    /// </summary>
    /// <returns></returns>
    private static List<int> Primes()
    {
        List<int> result = new List<int>() { 2, 3, 5, 7 };

        int n = 10;
        bool isPrime = false;

        while (result.Count < 10000) //First 10000 primes should be sufficient
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
                result.Add(n);
                isPrime = false;
            }
        }

        return result;
    }

    /// <summary>
    /// Runs prime factorization for given number
    /// </summary>
    /// <param name="num"></param>
    /// <returns>Number of divisors from equation d(n) = (a+1)(b+1)(c+1)...</returns>
    private static int PrimeFactorization(long num)
    {
        int divisorCount = 1, temp = 1;

        for (int i = 0; i < PrimesList.Count; i++) 
        {
            if (num < PrimesList[i])
                break;

            if (num % PrimesList[i] == 0)
            {
                while (num % PrimesList[i] == 0)
                {
                    num /= PrimesList[i];
                    temp++;
                }

                divisorCount *= temp;
                temp = 1;
            }
        }

        return divisorCount;
    }
}
#endregion

#region #13
class P13
{
    public static void Run()
    {
        string input = "37107287533902102798797998220837590246510135740250\r\n46376937677490009712648124896970078050417018260538\r\n74324986199524741059474233309513058123726617309629\r\n91942213363574161572522430563301811072406154908250\r\n23067588207539346171171980310421047513778063246676\r\n89261670696623633820136378418383684178734361726757\r\n28112879812849979408065481931592621691275889832738\r\n44274228917432520321923589422876796487670272189318\r\n47451445736001306439091167216856844588711603153276\r\n70386486105843025439939619828917593665686757934951\r\n62176457141856560629502157223196586755079324193331\r\n64906352462741904929101432445813822663347944758178\r\n92575867718337217661963751590579239728245598838407\r\n58203565325359399008402633568948830189458628227828\r\n80181199384826282014278194139940567587151170094390\r\n35398664372827112653829987240784473053190104293586\r\n86515506006295864861532075273371959191420517255829\r\n71693888707715466499115593487603532921714970056938\r\n54370070576826684624621495650076471787294438377604\r\n53282654108756828443191190634694037855217779295145\r\n36123272525000296071075082563815656710885258350721\r\n45876576172410976447339110607218265236877223636045\r\n17423706905851860660448207621209813287860733969412\r\n81142660418086830619328460811191061556940512689692\r\n51934325451728388641918047049293215058642563049483\r\n62467221648435076201727918039944693004732956340691\r\n15732444386908125794514089057706229429197107928209\r\n55037687525678773091862540744969844508330393682126\r\n18336384825330154686196124348767681297534375946515\r\n80386287592878490201521685554828717201219257766954\r\n78182833757993103614740356856449095527097864797581\r\n16726320100436897842553539920931837441497806860984\r\n48403098129077791799088218795327364475675590848030\r\n87086987551392711854517078544161852424320693150332\r\n59959406895756536782107074926966537676326235447210\r\n69793950679652694742597709739166693763042633987085\r\n41052684708299085211399427365734116182760315001271\r\n65378607361501080857009149939512557028198746004375\r\n35829035317434717326932123578154982629742552737307\r\n94953759765105305946966067683156574377167401875275\r\n88902802571733229619176668713819931811048770190271\r\n25267680276078003013678680992525463401061632866526\r\n36270218540497705585629946580636237993140746255962\r\n24074486908231174977792365466257246923322810917141\r\n91430288197103288597806669760892938638285025333403\r\n34413065578016127815921815005561868836468420090470\r\n23053081172816430487623791969842487255036638784583\r\n11487696932154902810424020138335124462181441773470\r\n63783299490636259666498587618221225225512486764533\r\n67720186971698544312419572409913959008952310058822\r\n95548255300263520781532296796249481641953868218774\r\n76085327132285723110424803456124867697064507995236\r\n37774242535411291684276865538926205024910326572967\r\n23701913275725675285653248258265463092207058596522\r\n29798860272258331913126375147341994889534765745501\r\n18495701454879288984856827726077713721403798879715\r\n38298203783031473527721580348144513491373226651381\r\n34829543829199918180278916522431027392251122869539\r\n40957953066405232632538044100059654939159879593635\r\n29746152185502371307642255121183693803580388584903\r\n41698116222072977186158236678424689157993532961922\r\n62467957194401269043877107275048102390895523597457\r\n23189706772547915061505504953922979530901129967519\r\n86188088225875314529584099251203829009407770775672\r\n11306739708304724483816533873502340845647058077308\r\n82959174767140363198008187129011875491310547126581\r\n97623331044818386269515456334926366572897563400500\r\n42846280183517070527831839425882145521227251250327\r\n55121603546981200581762165212827652751691296897789\r\n32238195734329339946437501907836945765883352399886\r\n75506164965184775180738168837861091527357929701337\r\n62177842752192623401942399639168044983993173312731\r\n32924185707147349566916674687634660915035914677504\r\n99518671430235219628894890102423325116913619626622\r\n73267460800591547471830798392868535206946944540724\r\n76841822524674417161514036427982273348055556214818\r\n97142617910342598647204516893989422179826088076852\r\n87783646182799346313767754307809363333018982642090\r\n10848802521674670883215120185883543223812876952786\r\n71329612474782464538636993009049310363619763878039\r\n62184073572399794223406235393808339651327408011116\r\n66627891981488087797941876876144230030984490851411\r\n60661826293682836764744779239180335110989069790714\r\n85786944089552990653640447425576083659976645795096\r\n66024396409905389607120198219976047599490197230297\r\n64913982680032973156037120041377903785566085089252\r\n16730939319872750275468906903707539413042652315011\r\n94809377245048795150954100921645863754710598436791\r\n78639167021187492431995700641917969777599028300699\r\n15368713711936614952811305876380278410754449733078\r\n40789923115535562561142322423255033685442488917353\r\n44889911501440648020369068063960672322193204149535\r\n41503128880339536053299340368006977710650566631954\r\n81234880673210146739058568557934581403627822703280\r\n82616570773948327592232845941706525094512325230608\r\n22918802058777319719839450180888072429661980811197\r\n77158542502016545090413245809786882778948721859617\r\n72107838435069186155435662884062257473692284509516\r\n20849603980134001723930671666823555245252804609722\r\n53503534226472524250874054075591789781264330331690";
        long[] arrayOfNums = Array.ConvertAll(input.Split("\r\n").Select(x => x.Substring(0, 11)).ToArray(), Int64.Parse);

        long sum = arrayOfNums.Sum();

        Console.WriteLine(sum.ToString().Substring(0, 10));
    }
}
#endregion

#region #14
class P14
{
    public static void Run()
    {

    }
}
#endregion

#region #15
class P15
{
    private static long _result = 0;
    public static void Run()
    {

    }
}
#endregion

#region #16
class P16
{
    public static void Run()
    {

    }
}
#endregion

#region #17
class P17
{
    public static void Run()
    {

    }
}
#endregion

#region #18
class P18
{
    public static void Run()
    {

    }
}
#endregion

#region #19
class P19
{
    public static void Run()
    {
        
    }
}
#endregion

#region #20
class P20
{
    public static void Run()
    {

    }
}
#endregion

#endregion

#region 21 - 30

#region #21
class P21
{
    public static void Run()
    {

    }
}
#endregion

#region #22
class P22
{
    public static void Run()
    {

    }
}
#endregion

#region #23
class P23
{
    public static void Run()
    {

    }
}
#endregion

#region #24
class P24
{
    public static void Run()
    {

    }
}
#endregion

#region #25
class P25
{
    private static long _result = 0;
    public static void Run()
    {

    }
}
#endregion

#region #26
class P26
{
    public static void Run()
    {

    }
}
#endregion

#region #27
class P27
{
    public static void Run()
    {

    }
}
#endregion

#region #28
class P28
{
    public static void Run()
    {

    }
}
#endregion

#region #29
class P29
{
    public static void Run()
    {

    }
}
#endregion

#region #30
class P30
{
    public static void Run()
    {

    }
}
#endregion

#endregion