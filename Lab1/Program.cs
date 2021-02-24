using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{





  static class Game
  {
    static Game()
    {
      readField();
    }

    public static bool isWin()
    {
      if (field[userRow, userCol] == 'e') return true;
      return false;
    }

    static char[,] field = new char[20, 30];

    static int userRow;
    static int userCol;

    private static void readField()
    {
      StreamReader fin = new StreamReader("GameField.txt");
      for (int i = 0; i < 20; i++)
      {
        for (int j = 0; j < 30; j++)
        {
          char ch = (char)fin.Read();
          if (!(ch == 'x' || ch == '.' || ch == 's' || ch == 'e'))
          {
            j--;
            continue;
          }
          if (ch == 's')
          {
            userRow = i;
            userCol = j;
          }
          field[i, j] = ch;
        }
      }
    }

    public static void printField()
    {
      for (int i = 0; i < 20; i++)
      {
        for (int j = 0; j < 30; j++)
        {
          if (i == userRow && j == userCol)
          {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write("  ");
            Console.ResetColor();
          }
          else if (field[i, j] == 'x')
          {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("  ");
            Console.ResetColor();
          }
          else
          {
            Console.Write("  ");
          }
        }
        Console.WriteLine();
      }
    }

    public static void up()
    {
      if (userRow == 0 || field[userRow - 1, userCol] == 'x') return;
      userRow--;
    }
    public static void down()
    {
      if (userRow == 19 || field[userRow + 1, userCol] == 'x') return;
      userRow++;
    }
    public static void left()
    {
      if (userCol == 0 || field[userRow, userCol - 1] == 'x') return;
      userCol--;
    }
    public static void right()
    {
      if (userRow == 0 || field[userRow, userCol + 1] == 'x') return;
      userCol++;
    }
  }


  class Program
  {
    static void Main(string[] args)
    {

      while (!Game.isWin())
      {
        Console.SetCursorPosition(0, 0);
        Game.printField();
        ConsoleKeyInfo key;
        key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.UpArrow)
        {
          Game.up();
        }
        else if (key.Key == ConsoleKey.DownArrow)
        {
          Game.down();
        }
        else if (key.Key == ConsoleKey.LeftArrow)
        {
          Game.left();
        }
        else
        {
          Game.right();
        }
      }

      for (int i = 0; i < 30; i++)
      {
        Console.WriteLine();
      }
      Console.WriteLine("                                                    Congratulations");
      for (int i = 0; i < 14; i++)
      {
        Console.WriteLine();
      }

    }
  }
}
