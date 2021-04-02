using System;
using System.Runtime.InteropServices;

namespace MathClient {
    class Program {
        [DllImport("../../MathLibrary.dll", CallingConvention = CallingConvention.StdCall)]
        static extern int Sum(int a, int b);
        [DllImport("../../MathLibrary.dll", CallingConvention = CallingConvention.StdCall)]
        static extern int Subtract(int a, int b);
        [DllImport("../../MathLibrary.dll", CallingConvention = CallingConvention.StdCall)]
        static extern int Multiply(int a, int b);
        [DllImport("../../MathLibrary.dll", CallingConvention = CallingConvention.StdCall)]
        static extern int Divide(int a, int b);
        [DllImport("../../MathLibrary.dll", CallingConvention = CallingConvention.StdCall)]
        static extern int Mod(int a, int b);
        [DllImport("../../MathLibrary.dll", CallingConvention = CallingConvention.StdCall)]
        static extern int Abs(int a);
        [DllImport("../../MathLibrary.dll", CallingConvention = CallingConvention.StdCall)]
        static extern int Gcd(int a, int b);
        [DllImport("../../MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int Min(int a, int b);
        [DllImport("../../MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int Max(int a, int b);
        [DllImport("../../MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int Pow(int a, int power);
        static void Main(string[] args) {
            Console.WriteLine(Sum(5, 6));
            Console.WriteLine(Subtract(5, 6));
            Console.WriteLine(Multiply(5, 6));
            Console.WriteLine(Divide(5, 6));
            Console.WriteLine(Mod(5, 6));
            Console.WriteLine(Abs(-55));
            Console.WriteLine(Gcd(5, 6));
            Console.WriteLine(Min(5, 6));
            Console.WriteLine(Max(5, 6));
            Console.WriteLine(Pow(5, 6));
        }
    }
}
