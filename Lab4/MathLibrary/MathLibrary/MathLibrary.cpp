#include "MathLibrary.h"
#include "pch.h"
#include <math.h>

int _stdcall Sum(int a, int b) {
    return a + b;
}

int _stdcall Subtract(int a, int b) {
    return a - b;
}

int _stdcall Multiply(int a, int b) {
    return a * b;
}

int _stdcall Divide(int a, int b) {
    return a / b;
}

int _stdcall Mod(int a, int b) {
    return a % b;
}

int _stdcall Abs(int a) {
    int modifier = a < 0 ? -1 : 1;
    return a * modifier;
}

int _stdcall Gcd(int a, int b) {
    a = Abs(a);
    b = Abs(b);
    while (a > 0 && b > 0) {
        if (a > b) {
            a %= b;
        }
        else {
            b %= a;
        }
    }
    return a + b;
}

int __cdecl Min(int a, int b) {
    return a < b ? a : b;
}

int __cdecl Max(int a, int b) {
    return a > b ? a : b;
}

int __cdecl Pow(int a, int power) {
    int value = 1;
    while (power--) {
        value *= a;
    }
    return value;
}