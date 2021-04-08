using System;

namespace Lab3_Class_
{
  enum Sports
  {
    Athletics,
    Weightlifting,
    ShotPut
  }

  abstract class Sportsman : Human
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
  }
}
