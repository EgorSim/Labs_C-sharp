namespace Lab3_Class_
{
  enum Sex
  {
    Udefined,
    Man,
    Women
  }

  abstract class Mammals
  {
    public Mammals()
    {
      age = 0;
      Sex = Sex.Udefined;
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
  }
}
