using System;

namespace Lab7
{
  class Program
  {
    static void Main(string[] args)
    {
      RationalNum a1 = new RationalNum("0.(3)");
      RationalNum b1 = new RationalNum("1/3");
      RationalNum res1 = a1 + b1;
      Console.WriteLine(res1);
      Console.WriteLine(a1);
      Console.WriteLine(b1);
      Console.WriteLine(a1.ToString());
      Console.WriteLine(b1.ToString());

      Console.WriteLine();


      RationalNum a2 = new RationalNum("0.654(32)");
      RationalNum b2 = new RationalNum("-36.987");
      RationalNum res2 = a2 - b2;
      Console.WriteLine(res2);
      Console.WriteLine(a2);
      Console.WriteLine(b2);
      Console.WriteLine(a2.ToString());
      Console.WriteLine(b2.ToString());






    }
  }
}
