using System;
using System.Collections.Generic;

namespace Lab3_Class_
{
  class Human : Mammals
  {
    public Human() : base()
    {
      this.Name = "";
      this.SecondName = "";
      CountOfHumans++;
    }

    public Human(string name, string second, int age, Sex sex) : base(age, sex)
    {
      this.Name = name;
      this.SecondName = second;
      CountOfHumans++;
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

    private List<Human> friends = new List<Human>();

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
  }
}
