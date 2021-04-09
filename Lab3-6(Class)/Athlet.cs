using System;
using System.Collections.Generic;

namespace Lab3_Class_
{
  class Athlet : Sportsman
  {
    public Athlet() : base()
    {
      WhatSport = Sports.Athletics;
      BestResult = 0;
      results = new List<double>();
    }

    public Athlet(Athlet obj) : base(obj)
    {
      this.WhatSport = obj.WhatSport;
      this.BestResult = obj.BestResult;
      this.results = obj.results;
    }

    public Athlet(string name, string second, int age, Sex sex, int exp, int golds, int silvers, int bronzes) 
           : base(name, second, age, sex, exp, golds, silvers, bronzes)
    {
      WhatSport = Sports.Athletics;
      BestResult = 0;
      results = new List<double>();
    }
    
    public Sports WhatSport { get; private set; }

    public override void DoExercise()
    {
      Console.WriteLine("Please enter the result of the 100 meter race (sec): ");
      try
      {
        double res = Convert.ToDouble(Console.ReadLine());
        results.Add(res);
        BestResult = res > BestResult ? res : BestResult;
      }
      catch
      {
        Console.WriteLine("Uncorrect result");
      }
    }

    public double BestResult { get; private set; }

    private List<double> results;

    public override void ShowInfo()
    {
      base.ShowInfo();
      Console.WriteLine($"The best result of the 100 meter race: {BestResult}");
    }
  }
}
