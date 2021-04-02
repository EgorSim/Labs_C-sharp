#pragma once

#ifdef MATHLIBRARY_EXPORTS
#define MATHLIBRARY_API __declspec(dllexport)
#else
#define MATHLIBRARY_API __declspec(dllimport)
#endif

extern "C" {
    MATHLIBRARY_API int _stdcall Subtract(int a, int b);
    MATHLIBRARY_API int _stdcall Sum(int a, int b);
    MATHLIBRARY_API int _stdcall Multiply(int a, int b);
    MATHLIBRARY_API int _stdcall Divide(int a, int b);
    MATHLIBRARY_API int _stdcall Mod(int a, int b);
    MATHLIBRARY_API int _stdcall Abs(int a);
    MATHLIBRARY_API int _stdcall Gcd(int a, int b);
    MATHLIBRARY_API int __cdecl Min(int a, int b);
    MATHLIBRARY_API int __cdecl Max(int a, int b);
    MATHLIBRARY_API int __cdecl Pow(int a, int power);
}


