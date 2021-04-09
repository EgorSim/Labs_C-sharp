using System;


namespace Lab3_Class_
{
  enum Sports
  {
    Athletics,
    Weightlifting,
    ShotPut
  }

  abstract class Sportsman : Human, ILife, ILife2, IComparable<Mammals>
  {
    public Sportsman() : base()
    {
      awards = new Awards();
    }

    public Sportsman(Sportsman obj) : base(obj)
    {
      this.Gold = obj.Gold;
      this.Silver = obj.Silver;
      this.Bronze = obj.Bronze;
      this.Experience = obj.Experience;
    }

    public Sportsman(string name, string second, int age, Sex sex, int exp, int golds, int silvers, int bronzes)
              : base(name, second, age, sex)
    {
      awards = new Awards(golds, silvers, bronzes);
      Experience = exp;
    }

    private struct Awards
    {
      public Awards(int x, int y, int z)
      {
        this.gold = x;
        this.silver = y;
        this.bronze = z;
      }

      public int gold;
      public int silver;
      public int bronze;
    }

    private Awards awards;

    public int Gold
    {
      get
      {
        return awards.gold;
      }
      set
      {
        if (value < 0) throw new Exception("Inpossible amount");
        else
        {
          awards.gold = value;
        }
      }
    }

    public int Silver
    {
      get
      {
        return awards.silver;
      }
      set
      {
        if (value < 0) throw new Exception("Inpossible amount");
        else
        {
          awards.silver = value;
        }
      }
    }

    public int Bronze
    {
      get
      {
        return awards.bronze;
      }
      set
      {
        if (value < 0) throw new Exception("Inpossible amount");
        else
        {
          awards.bronze = value;
        }
      }
    }

    public int Experience { get; set; }

    public abstract void DoExercise();

    public override void ShowInfo()
    {
      base.ShowInfo();
      Console.WriteLine($"Experience {Experience}\nHe has {Gold} gold, {Silver} silver and {Bronze} bronze medals");
    }

    int ILife.EarnMoney()
    {
      Console.WriteLine($"{Name} going to the competition...");
      Console.WriteLine("What is prize fund ($)? ");
      int fund = 0;
      try
      {
        fund = Convert.ToInt32(Console.ReadLine());
      }
      catch
      {
        Console.WriteLine("Unkorrect fund");
      }
      DoExercise();
      Console.WriteLine("What place did you take?");
      int place = 0;
      try
      {
        place = Convert.ToInt32(Console.ReadLine());
      }
      catch
      {
        Console.WriteLine("Unkorrect fund");
      }
      if (place == 1)
      {
        Console.WriteLine($"Congratulations!!! You earned {fund} $");
        return fund;
      }
      else if (place == 2)
      {
        Console.WriteLine($"Congratulations!!! You earned {fund * 3 / 5} $");
        return fund * 3 / 5;
      }
      else if (place == 3)
      {
        Console.WriteLine($"Congratulations!!! You earned {fund * 3 / 10} $");
        return fund * 3 / 10;
      }
      throw new Exception("Uncorrect place");
    }

    int ILife2.EarnMoney()
    {
      return 3;
    }

    public void F()
    {
      ILife oj = this;
      oj.EarnMoney();
    }

    public new void Relax()
    {
      Console.WriteLine($"{Name} going to the park...");
    }

    /// <param name="obj"></param>
    /// <returns>Compare by golden medals</returns>
    public int CompareTo(Sportsman obj)
    {
      if (this.Gold == obj.Gold) return 0;
      else if (this.Gold > obj.Gold) return 1;
      else return -1;
    }
  }
}
