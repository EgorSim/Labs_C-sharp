using System;
using System.Collections.Generic;

namespace Lab3_Class_
{
  class Human : Mammals, ILife
  {
    public Human() : base()
    {
      this.Name = "";
      this.SecondName = "";
      friends = new List<Human>();
      CountOfHumans++;
    }

    public Human(string name, string second, int age, Sex sex) : base(age, sex)
    {
      this.Name = name;
      this.SecondName = second;
      friends = new List<Human>();
      CountOfHumans++;
    }

    public Human(Human obj) : base(obj)
    {
      this.Name = obj.Name;
      this.SecondName = obj.SecondName;
      this.CountOfFriends = obj.CountOfFriends;
      this.friends = obj.friends;
    }

    private static int countOfHumans;
    public static int CountOfHumans
    {
      get
      {
        return countOfHumans;
      }
      private set
      {
        countOfHumans = value;
      }
    }

    private string name;
    public string Name
    {
      get
      {
        return name;
      }
      set
      {
        name = value;
      }
    }

    private string secondName;
    public string SecondName
    {
      get
      {
        return secondName;
      }
      set
      {
        secondName = value;
      }
    }

    public override void ShowInfo()
    {
      Console.WriteLine("Person`s info:\n");
      Console.WriteLine($"Name: {Name}\nSecond name: {SecondName}\nAge: {Age}\nSex: {Sex}");
      if (Sex == Sex.Man || Sex == Sex.Udefined)
      {
        Console.Write($"He has {CountOfFriends} ");
        if (CountOfFriends > 1 || CountOfFriends == 0) Console.WriteLine("friends");
        else Console.WriteLine("friend");
      }

      else
      {
        Console.Write($"She has {CountOfFriends} ");
        if (CountOfFriends > 1 || CountOfFriends == 0) Console.WriteLine("friends");
        else Console.WriteLine("friend");
      }
    }

    private List<Human> friends;

    public void AddFriend(Human person)
    {
      friends.Add(person);
      CountOfFriends++;
    }
    private int CountOfFriends { get; set; }

    /// <param name="index"></param>
    /// <returns>Return friend by index</returns>
    public Human this[int index]
    {
      get
      {
        if (index < 0 || index > CountOfFriends - 1)
        {
          throw new Exception("Non-existent friend");
        }
        return friends[index];
      }
    }

    public int EarnMoney()
    {
      Console.WriteLine($"{Name} going to the work...");
      Console.WriteLine("How much money is paid for a full-day work (8h)?");
      int price = 0;
      try
      {
        price = Convert.ToInt32(Console.ReadLine());
        if (price < 0) throw new Exception("Uncorrect price");
      }
      catch
      {
        Console.WriteLine("Uncorrect price");
      }

      Console.WriteLine("How much time you have worked today?");
      double time = 0;
      try
      {
        time = Convert.ToDouble(Console.ReadLine());
        if (time < 0 || time > 8) throw new Exception("Uncorrect time");
      }
      catch
      {
        Console.WriteLine("Uncorrect time");
      }
      Console.WriteLine($"Congratulations!!! You earned {(int)((double)time / 8.0 * price)} $");
      return (int)((double)time / 8.0 * price);
    }

    public void Relax()
    {
      Console.WriteLine($"{Name} going to the club...");
      Random rnd = new Random();
      int index = rnd.Next(0, CountOfFriends);
      int count;
      for (count = 0; count <= 3 || count <= friends[index].CountOfFriends; count++)
      {
        this.AddFriend(this.friends[index].friends[count]);
      }
      Console.WriteLine($"{Name} fount {count} new friends");
    }
  }
}
