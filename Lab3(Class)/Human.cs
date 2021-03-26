using System;
using System.Collections.Generic;

namespace Human
{
  enum Sex
  {
    Udefined,
    Man,
    Women
  }

  class Human
  {
    public Human()
    {
      this.Name = "";
      this.SecondName = "";
      this.Age = 0;
      this.Sex = Sex.Udefined;
      CountOfHumans++;
    }

    public Human(string name, string second, int age, Sex sex)
    {
      this.Name = name;
      this.SecondName = second;
      this.Age = age;
      this.Sex = sex;
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

    private int age;
    public int Age
    {
      get
      {
        return age;
      }
      set
      {
        if (value < 0 || value > 250)
        {
          age = 0;
          return;
        }
        age = value;
      }
    }

    public Sex Sex { get; set; }

    public void ShowInfo()
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
