#region Main
class ProgramRunner
{
    static void Main(string[] args)
    {
        #region Problems mapping

        Dictionary<int, Action> problemsMap = new Dictionary<int, Action>
        {
            { 1, () => P1.Run() },
            { 2, () => P2.Run() },
        };
        #endregion

        int problemNumber = 0;

        Console.WriteLine("I want to see the answer to problem number:\n");
        Int32.TryParse(Console.ReadLine(), out problemNumber);

        Console.WriteLine($"\n\nStarting solution to problem no.{problemNumber}...\n");
        Thread.Sleep(2 * 1000);

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

        Console.WriteLine(result);
    }
}
#endregion

#region #2
class P2
{
    public static void Run()
    {
        Console.Write("2");
    }
}
#endregion