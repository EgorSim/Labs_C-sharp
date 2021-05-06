using System;

namespace Lab3_Class_
{
  class Program
  {
    static void Main()
    {
      Human egorchik = new Human();
      try
      {
        egorchik.Age = -26;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        egorchik.Age = 18;
      }
      egorchik.Name = "Egorchik";
      egorchik.SecondName = "Simakov";
      egorchik.Sex = Sex.Man;

      Human galya = new Human("Galya", "Pupkina", 18, Sex.Women);

      egorchik.AddFriend(galya);

      try
      {
        egorchik[23].ShowInfo();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }


      Console.WriteLine();
      egorchik.ShowInfo();

      Console.WriteLine();
      Human anon = new Human();
      anon.ShowInfo();

      Athlet john = new Athlet("John", "Alewan", 22, Sex.Man, exp: 8, golds: 5, silvers: 7, bronzes: 0);
      john.ShowInfo();

      Console.WriteLine();
      Console.WriteLine();

      john.CompititonResults += john.DoExercise1;
      john.CompititonResults += john.DoExercise3;
      john.CompititonResults += () =>
      {
        Console.WriteLine("Please enter the result of the disk throwing(meters): ");
        try
        {
          int res = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
          Console.WriteLine("Uncorrect result");
        }
      };
      john.CompititonResults += delegate()
      {
        Console.WriteLine("Please enter the result of the shoting put(meters): ");
        try
        {
          int res = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
          Console.WriteLine("Uncorrect result");
        }
      };

      john.EarnMoney();

      Console.WriteLine();

      egorchik.EarnMoney();


      Console.WriteLine(john.CompareTo(egorchik));

    }
  }
}
