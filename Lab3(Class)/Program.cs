using System;

namespace Human
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
    }
  }
}
