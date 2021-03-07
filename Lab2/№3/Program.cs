using System;

namespace Lab2
{
  class Program
  {
    static void Main(string[] args)
    {
      string region;
      while (true)
      {
        Console.Write("Write region(ENTER to exit) : ");
        region = Console.ReadLine();
        if (region != "")
        {
          System.Globalization.CultureInfo Culture = new System.Globalization.CultureInfo("RU");
          try
          {
            Culture = new System.Globalization.CultureInfo(region);
          }
          catch (Exception ex)
          {
            Console.WriteLine($"Error: {ex.Message}");
            continue;
          }
          DateTime date = new DateTime(2021, 1, 1, 00, 00, 00);
          for (int i = 0; i < 12; i++)
          {
            Console.WriteLine(date.ToString("MMMM", Culture.DateTimeFormat));
            date = date.AddMonths(1);
          }
          Console.WriteLine();
        }
        else
        {
          break;
        }
      }      
    }
  }
}
