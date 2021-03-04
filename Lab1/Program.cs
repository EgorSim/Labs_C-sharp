using System;
using System.Collections.Generic;


namespace Lab1
{
  static class Game
  {
    public static bool IsWin()
    {
      if (userRow == 29 && userCol == 50) return true;
      return false;
    }

    private static char[,] field = new char[31, 51];

    static int userRow;
    static int userCol;

    public static void PrintField(bool visible)
    {
      for (int i = 0; i < 31; i++)
      {
        for (int j = 0; j < 51; j++)
        {
          if (!visible)
          {
            if (Math.Abs(userRow - i) < 4 && Math.Abs(userCol - j) < 4)
            {
              if (i == userRow && j == userCol)
              {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write("  ");
                Console.ResetColor();
              }
              else if (field[i, j] == 'x')
              {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write("  ");
                Console.ResetColor();
              }
              else
              {
                Console.Write("  ");
              }
              continue;
            }
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write("  ");
            Console.ResetColor();
          }
          else
          {
            if (i == userRow && j == userCol)
            {
              Console.BackgroundColor = ConsoleColor.DarkRed;
              Console.Write("  ");
              Console.ResetColor();
            }
            else if (field[i, j] == 'x')
            {
              Console.BackgroundColor = ConsoleColor.Gray;
              Console.Write("  ");
              Console.ResetColor();
            }
            else
            {
              Console.Write("  ");
            }
            continue;
          }
          
        }
        Console.WriteLine();
      }
    }

    private static bool HaveNoVisitedNeighbour(int row, int col, bool[,] visited)
    {
      if ((row - 2 < 0 || visited[row - 2, col] == true) &&
          (row + 2 > 30 || visited[row + 2, col] == true) &&
          (col - 2 < 0 || visited[row, col - 2] == true) &&
          (col + 2 > 50 || visited[row, col + 2] == true)) return false;

      return true;
    }

    private static void DeleteWall(int row1, int col1, int row2, int col2)
    {
      if (row1 == row2)
      {
        field[row1, Math.Min(col1, col2) + 1] = '.';
      }
      else
      {
        field[Math.Min(row1, row2) + 1, col1] = '.';
      }
    }

    private static readonly int seed = Environment.TickCount;

    private static readonly Random rnd = new Random(seed);

    private static void Dfs(int row, int col, bool[,] visited)
    {
      visited[row, col] = true;

      while (HaveNoVisitedNeighbour(row, col, visited))
      {
        int temp = rnd.Next(0, 4);

        switch (temp)
        {
          case 0:
            if (!(row - 2 < 0) && visited[row - 2, col] == false)
            {
              DeleteWall(row, col, row - 2, col);
              Dfs(row - 2, col, visited);
            }
            break;
          case 1:
            if (!(row + 2 > 30) && visited[row + 2, col] == false)
            {
              DeleteWall(row, col, row + 2, col);
              Dfs(row + 2, col, visited);
            }
            break;
          case 2:
            if (!(col - 2 < 0) && visited[row, col - 2] == false)
            {
              DeleteWall(row, col, row, col - 2);
              Dfs(row, col - 2, visited);
            }
            break;
          case 3:
            if (!(col + 2 > 50) && visited[row, col + 2] == false)
            {
              DeleteWall(row, col, row, col + 2);
              Dfs(row, col + 2, visited);
            }
            break;
        }
      }
    }

    public static void CreateField()
    {
      bool[,] visited = new bool[31, 51];
      userRow = userCol = 1;

      for (int i = 0; i < 31; i++)
      {
        for (int j = 0; j < 51; j++)
        {
          if ((i % 2 != 0 && j % 2 != 0) && (i < 30 && j < 50)) field[i, j] = '.';
          else field[i, j] = 'x';
        }
      }
      field[1, 0] = '.';
      field[29, 50] = '.';

      Dfs(1, 1, visited);
    }

    public static void Up()
    {
      if (field[userRow - 1, userCol] == 'x') return;
      userRow--;
    }
    public static void Down()
    {
      if (field[userRow + 1, userCol] == 'x') return;
      userRow++;
    }
    public static void Left()
    {
      if (userCol == 0 || field[userRow, userCol - 1] == 'x') return;
      userCol--;
    }
    public static void Right()
    {
      if (userCol == 50 || field[userRow, userCol + 1] == 'x') return;
      userCol++;
    }
  }


  class Program
  {

    enum Menu
    {
      Play,
      Settings,
      Exit
    }

    static void Main(string[] args)
    {
      Console.SetWindowSize(102, 32);
      Console.CursorVisible = false;

      Menu menu = Menu.Play;
      bool visible = false;
      ConsoleKeyInfo key;
      while (true)
      {
        if (menu == Menu.Play)
        {
          Console.BackgroundColor = ConsoleColor.DarkYellow;
          Console.ForegroundColor = ConsoleColor.Black;
          Console.SetCursorPosition(46, 13);
          Console.WriteLine("   Play   ");
          Console.ResetColor();
          Console.SetCursorPosition(44, 17);
          Console.WriteLine("   Settings   ");
          Console.SetCursorPosition(46, 21);
          Console.WriteLine("   Exit   ");
        } 
        else if (menu == Menu.Exit)
        {
          Console.SetCursorPosition(46, 13);
          Console.WriteLine("   Play   ");
          Console.SetCursorPosition(44, 17);
          Console.WriteLine("   Settings   ");
          Console.BackgroundColor = ConsoleColor.DarkYellow;
          Console.ForegroundColor = ConsoleColor.Black;
          Console.SetCursorPosition(46, 21);
          Console.WriteLine("   Exit   ");
          Console.ResetColor();
        }
        else
        {
          Console.SetCursorPosition(46, 13);
          Console.WriteLine("   Play   ");
          Console.BackgroundColor = ConsoleColor.DarkYellow;
          Console.ForegroundColor = ConsoleColor.Black;
          Console.SetCursorPosition(44, 17);
          Console.WriteLine("   Settings   ");
          Console.ResetColor();
          Console.SetCursorPosition(46, 21);
          Console.WriteLine("   Exit   ");
        }

        key = Console.ReadKey(true);

        if (key.Key == ConsoleKey.Enter && menu == Menu.Exit) break;
        else if (key.Key == ConsoleKey.Enter && menu == Menu.Play)
        {
          Game.CreateField();
          while (!Game.IsWin())
          {
            Console.SetCursorPosition(0, 0);
            Game.PrintField(visible);
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape) goto label;
            else if (key.Key == ConsoleKey.UpArrow)
            {
              Game.Up();
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
              Game.Down();
            }
            else if (key.Key == ConsoleKey.LeftArrow)
            {
              Game.Left();
            }
            else
            {
              Game.Right();
            }
          }

          for (int i = 0; i < 30; i++)
          {
            Console.WriteLine();
          }
          Console.WriteLine("                                            Congratulations!!!");
          for (int i = 0; i < 14; i++)
          {
            Console.WriteLine();
          }
          Console.Read();
          label:
          Console.Clear();
        }
        else if (key.Key == ConsoleKey.Enter && menu == Menu.Settings)
        {
          Console.Clear();
          while (true)
          {
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("Visible:   ");
            if (visible)
            {
              Console.BackgroundColor = ConsoleColor.DarkYellow;
              Console.ForegroundColor = ConsoleColor.Black;
              Console.SetCursorPosition(50, 16);
              Console.WriteLine("   ON   ");
              Console.ResetColor();
              Console.SetCursorPosition(58, 16);
              Console.WriteLine("   OFF   ");
            }
            else
            {
              Console.SetCursorPosition(50, 16);
              Console.WriteLine("   ON   ");
              Console.BackgroundColor = ConsoleColor.DarkYellow;
              Console.ForegroundColor = ConsoleColor.Black;
              Console.SetCursorPosition(58, 16);
              Console.WriteLine("   OFF   ");
              Console.ResetColor();
            }
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.LeftArrow) visible = true;
            else if (key.Key == ConsoleKey.RightArrow) visible = false;
            else if (key.Key == ConsoleKey.Enter)
            {
              Console.Clear();
              break;
            }
          }
        }
        else if (key.Key == ConsoleKey.UpArrow)
        {
          menu = menu == Menu.Exit ? Menu.Settings : Menu.Play;
        }
        else
        {
          menu = menu == Menu.Play ? Menu.Settings : Menu.Exit;
        }
      }




      

      
      
    }
  }
}
