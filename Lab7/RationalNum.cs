using System;
using System.Globalization;

namespace Lab7
{
  class RationalNum : IFormattable
  {
    public RationalNum()
    {
      n = 0;
      m = 0;
      negative = false;
    }
    public RationalNum(string str)
    {
      RationalNum temp = StringToRationalNum(str);
      n = temp.n;
      m = temp.m;
      negative = temp.negative;
    }
    public RationalNum(RationalNum obj)
    {
      n = obj.n;
      m = obj.m;
      negative = obj.negative;
    }

    private int n;
    private int m;
    private bool negative;

    //======================================================== Format functions
    public override string ToString()
    {
      if (n == 0) return "0";
      if (m == 1) return negative ? ("-" + n.ToString()) : n.ToString();
      if (negative) return ("-" + n + "/" + m);
      else return (n + "/" + m);
    }

    public string ToStirng(string format)
    {
      double res = (double)n / m;
      res = negative ? -res : res;
      return String.Format(CultureInfo.CurrentCulture, format, res);
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
      if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;
      double res = (double)n / m;
      res = negative ? -res : res;
      return res.ToString(format, formatProvider);
    }

    public static RationalNum StringToRationalNum(string str)
    {
      RationalNum num = new RationalNum();
      num.negative = false;
      str.Replace(" ", "");
      if (str.Contains("."))
      {
        str = str.Replace('.', ' ');
        str = str.Replace('(', ' ');
        str = str.Replace(')', ' ');
        string[] arr = str.Split(' ');

        if (arr.Length == 2)
        {
          int integerPart = 0;
          int fractionalPart = 0;
          try
          {
            integerPart = Convert.ToInt32(arr[0]);
            if (arr[0][0] == '-')
            {
              integerPart = integerPart >= 0 ? integerPart : -integerPart;
              num.negative = true;
            }
            fractionalPart = Convert.ToInt32(arr[1]);
            if (fractionalPart < 0) throw new Exception("Unkorrect input");
          }
          catch
          {
            throw new Exception("Unkorrect input");
          }
          int tempN = fractionalPart;
          int tempM = (int)Math.Pow(10, arr[1].Length);
          tempN = tempM * integerPart + tempN;
          int commonD = GCD(tempN, tempM);
          tempM /= commonD;
          tempN /= commonD;
          num.n = tempN;
          num.m = tempM;
        }
        else if (arr.Length == 4 && arr[3] == "")
        {
          int integerPart = 0;
          int fractionalPart = 0;
          int periodicPart = 0;
          try
          {
            integerPart = Convert.ToInt32(arr[0]);
            if (arr[0][0] == '-')
            {
              integerPart = integerPart >= 0 ? integerPart : -integerPart;
              num.negative = true;
            }
            if (arr[1].Length != 0) fractionalPart = Convert.ToInt32(arr[1]);
            else fractionalPart = 0;
            periodicPart = Convert.ToInt32(arr[2]);
          }
          catch
          {
            throw new Exception("Unkorrect input");
          }
          int tempN = (fractionalPart * (int)Math.Pow(10, arr[2].Length) + periodicPart) -
                       fractionalPart;
          int tempM = NinesByCount(arr[2].Length) * (int)Math.Pow(10, arr[1].Length);
          tempN = integerPart * tempM + tempN;
          int commonD = GCD(tempN, tempM);
          tempM /= commonD;
          tempN /= commonD;
          num.n = tempN;
          num.m = tempM;
        }
      }
      else if (str.Contains("/"))
      {
        string[] arr = str.Split('/');
        int tempN = 0;
        int tempM = 0;
        try
        {
          tempN = Convert.ToInt32(arr[0]);
          if (arr[0][0] == '-')
          {
            tempN = tempN >= 0 ? tempN : -tempN;
            num.negative = true;
          }
          tempM = Convert.ToInt32(arr[1]);
          if (tempM == 0) throw new Exception("Unkorrect input");
        }
        catch
        {
          throw new Exception("Unkorrect input");
        }
        num.n = tempN;
        num.m = tempM;
      }
      else throw new Exception("Unkorrect input");
      return num;
    }

    // ================================================== Operators overloading
    public static RationalNum operator +(RationalNum num1, RationalNum num2)
    {
      RationalNum temp = new RationalNum();

      int tempN1 = num1.negative ? -num1.n : num1.n;
      int tempN2 = num2.negative ? -num2.n : num2.n;

      int commonM = LCM(num1.m, num2.m);
      temp.m = commonM;

      tempN1 = tempN1 * commonM / num1.m;
      tempN2 = tempN2 * commonM / num2.m;

      temp.n = tempN1 + tempN2;
      if (temp.n < 0)
      {
        temp.negative = true;
        temp.n = -temp.n;
      }

      int commonD = GCD(temp.n, temp.m);
      temp.n /= commonD;
      temp.m /= commonD;

      return temp;
    }

    public static RationalNum operator -(RationalNum num1, RationalNum num2)
    {
      RationalNum temp = new RationalNum();

      int tempN1 = num1.negative ? -num1.n : num1.n;
      int tempN2 = num2.negative ? -num2.n : num2.n;

      int commonM = LCM(num1.m, num2.m);
      temp.m = commonM;

      tempN1 = tempN1 * commonM / num1.m;
      tempN2 = tempN2 * commonM / num2.m;

      temp.n = tempN1 - tempN2;
      if (temp.n < 0)
      {
        temp.negative = true;
        temp.n = -temp.n;
      }

      int commonD = GCD(temp.n, temp.m);
      temp.n /= commonD;
      temp.m /= commonD;

      return temp;
    }

    public static RationalNum operator *(RationalNum num1, RationalNum num2)
    {
      RationalNum temp = new RationalNum();
      if ((num1.negative && num2.negative) || (!num1.negative && !num2.negative)) temp.negative = false;
      else temp.negative = true;

      temp.n = num1.n * num2.n;
      temp.m = num1.m * num2.m;

      int commonD = GCD(temp.n, temp.m);

      temp.n /= commonD;
      temp.m /= commonD;

      return temp;
    }

    public static RationalNum operator /(RationalNum num1, RationalNum num2)
    {
      if (num2.n == 0) throw new Exception("Division by zero");
      RationalNum temp = new RationalNum();
      temp.negative = num2.negative;
      temp.n = num2.m;
      temp.m = num2.n;

      return (num1 * temp);
    }

    public static bool operator >(RationalNum num1, RationalNum num2)
    {
      double n1 = (double)num1.n / num1.m;
      n1 = num1.negative ? -n1 : n1;

      double n2 = num2.n / num2.m;
      n2 = num2.negative ? -n2 : n2;

      return (n1 > n2);
    }

    public static bool operator <(RationalNum num1, RationalNum num2)
    {
      double n1 = (double)num1.n / num1.m;
      n1 = num1.negative ? -n1 : n1;

      double n2 = num2.n / num2.m;
      n2 = num2.negative ? -n2 : n2;

      return (n1 < n2);
    }

    public static bool operator >=(RationalNum num1, RationalNum num2)
    {
      double n1 = (double)num1.n / num1.m;
      n1 = num1.negative ? -n1 : n1;

      double n2 = num2.n / num2.m;
      n2 = num2.negative ? -n2 : n2;

      return (n1 >= n2);
    }

    public static bool operator <=(RationalNum num1, RationalNum num2)
    {
      double n1 = (double)num1.n / num1.m;
      n1 = num1.negative ? -n1 : n1;

      double n2 = num2.n / num2.m;
      n2 = num2.negative ? -n2 : n2;

      return (n1 <= n2);
    }

    public static bool operator ==(RationalNum num1, RationalNum num2)
    {
      return ReferenceEquals(num1, num2);
    }

    public static bool operator !=(RationalNum num1, RationalNum num2)
    {
      return !ReferenceEquals(num1, num2);
    }

    public override bool Equals(object obj)
    {
      if (obj == null || GetType() != obj.GetType())
      {
        return false;
      }

      if (obj is RationalNum objectType)
      {
        double n1 = (double)this.n / this.m;
        n1 = this.negative ? -n1 : n1;

        double n2 = (double)objectType.n / objectType.m;
        n2 = objectType.negative ? -n2 : n2;
        return (n1 == n2);
      }
      return false;
    }

    public override int GetHashCode()
    {
      double res = (double)n / m;
      res = negative ? -res : res;
      return res.GetHashCode();
    }

    public static implicit operator double(RationalNum num)
    {
      double res = (double)num.n / num.m;
      res = num.negative ? -res : res;
      return res;
    }

    public static implicit operator float(RationalNum num)
    {
      float res = (float)num.n / num.m;
      res = num.negative ? -res : res;
      return res;
    }

    public static explicit operator int(RationalNum num)
    {
      double res = (double)num.n / num.m;
      res = num.negative ? -res : res;
      return (int)res;
    }

    public static explicit operator long(RationalNum num)
    {
      long res = (long)num.n / num.m;
      res = num.negative ? -res : res;
      return res;
    }

    //============================================= Private auxiliary functions
    private static int GCD(int x, int y)
    {
      int temp;
      while (y != 0)
      {
        x = x % y;
        temp = y;
        y = x;
        x = temp;
      }
      return x;
    }

    private static int LCM(int x, int y)
    {
      return (x / GCD(x, y) * y);
    }

    private static int NinesByCount(int count)
    {
      int res = 0;
      for (int i = 0; i < count; i++)
      {
        res += 9 * (int)Math.Pow(10, i);
      }
      return res;
    }
  }
}
