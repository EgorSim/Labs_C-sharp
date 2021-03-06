using System;

namespace Lab2
{
  static class ReverseStr
  {
    public static void DisplayRevStr(string str, int index)
    {
      if (index >= str.Length) return;
      int i;
      for (i = index; i < str.Length && str[i] != ' '; i++) ;
      DisplayRevStr(str, i + 1);
      Console.Write(str.Substring(index, i - index) + " ");
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      string str = Console.ReadLine();
      Console.WriteLine();
      ReverseStr.DisplayRevStr(str, 0);
      Console.WriteLine();
    }
  }
}
