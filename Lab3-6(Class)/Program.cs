using System;

namespace Lab3_Class_
{
  class Program
  {
    static void Main(string[] args)
    {
      Human egorchik = new Human();
      egorchik.Age = 18;
      egorchik.Name = "Egorchik";
      egorchik.SecondName = "Simakov";
      egorchik.Sex = Sex.Man;


      Human dasha = new Human("Dasha", "Kolbaskina", 18, Sex.Women);

      egorchik.AddFriend(dasha);

      egorchik[0].ShowInfo();

      Console.WriteLine();
      egorchik.ShowInfo();


      Console.WriteLine();
      Human anon = new Human();
      anon.ShowInfo();

      Athlet john = new Athlet("John", "Alewan", 22, Sex.Man, exp: 8, golds: 5, silvers: 7, bronzes: 0);
      john.ShowInfo();

      Console.WriteLine();
      Console.WriteLine();

      john.EarnMoney();

      Console.WriteLine();

      egorchik.EarnMoney();



      Console.WriteLine(john.CompareTo(egorchik));

    }
  }
}
