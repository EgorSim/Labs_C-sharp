using System;

namespace Lab3_Class_
{
  enum Sex
  {
    Udefined,
    Man,
    Women
  }

  abstract class Mammals : IComparable<Mammals>
  {
    public Mammals()
    {
      age = 0;
      Sex = Sex.Udefined;
    }

    public Mammals(Mammals obj)
    {
      this.Age = obj.age;
      this.Sex = obj.Sex;
    }

    public Mammals(int age, Sex sex)
    {
      this.age = age;
      this.Sex = sex;
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

    public abstract void ShowInfo();

    /// <param name="other"></param>
    /// <returns>Compare by age</returns>
    public int CompareTo(Mammals other)
    {
      if (this.Age == other.Age) return 0;
      else if (this.Age > other.Age) return 1;
      else return -1;
    }
  }
}
