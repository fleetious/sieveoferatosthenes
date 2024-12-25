using System.Diagnostics;

namespace PrimeSolvers;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch t = new Stopwatch();
        int toNum = 90000000;
        HashSet<int> nonprimes = new HashSet<int>();
        t.Start();
        double lengthSqrt = Math.Sqrt(toNum);
        nonprimes.Add(0);
        nonprimes.Add(1);

        for(int i = 2; i <= lengthSqrt; i++)
        {
            if (nonprimes.Contains(i)) continue;
            for(int j = i*i; j < toNum; j += i)
            {
                nonprimes.Add(j);
            }
        }
        
        t.Stop();

        /*for(int i = 0; i < toNum; i++)
        {
            if (!nonprimes.Contains(i)) Console.WriteLine(i);
        }*/
        string secondIncrement = "ns";
        double seconds = t.Elapsed.TotalNanoseconds;
        if (t.Elapsed.TotalNanoseconds >= 1000)
        {
            seconds = t.Elapsed.TotalMilliseconds;
            secondIncrement = "ps";
        }
        if (t.Elapsed.TotalMicroseconds >= 1000)
        {
            seconds = t.Elapsed.TotalMilliseconds;
            secondIncrement = "ms";
        }
        if (t.Elapsed.TotalMilliseconds >= 1000)
        {
            seconds = t.Elapsed.TotalSeconds;
            secondIncrement = "s";
        }
        Console.WriteLine($"Total time: {seconds} {secondIncrement} ({Math.Round(toNum/seconds)}/{secondIncrement})");
    }
}
