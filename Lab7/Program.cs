using System;

namespace Lab7
{
  class Program
  {
    static void Main(string[] args)
    {
      RationalNum a = new RationalNum("0.(3)");
      RationalNum b = new RationalNum("1/3");
      RationalNum res = a / b;

      float x = a;
      int y = (int)a;

      Console.WriteLine(a);
      Console.WriteLine(x);
      Console.WriteLine(res.ToString());

    }
  }
}
