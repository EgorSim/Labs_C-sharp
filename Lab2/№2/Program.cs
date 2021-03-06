using System;

namespace Lab2
{
  class Program
  {
    static void Main(string[] args)
    {
      ulong result = 0;
      ulong a = (ulong)Convert.ToUInt64(Console.ReadLine());
      ulong b = (ulong)Convert.ToUInt64(Console.ReadLine());
      ulong p = 2;
      while (p <= b && p != 0)
      {
        result += b / p;
        p *= 2;
      }
      p = 2;
      while (p <= a && p != 0)
      {
        result -= a / p;
        p *= 2;
      }
      Console.WriteLine(result);
    }
  }
}
