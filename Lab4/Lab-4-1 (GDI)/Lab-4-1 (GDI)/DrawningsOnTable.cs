using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Lab_4_1__GDI_ {
    static class DrawningsOnTable {
        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        static extern int ReleaseDC(IntPtr hwnd);
        static public void FillEllips(Color color, int x, int y, int width, int height) {
            SolidBrush brush= new SolidBrush(color);
            IntPtr desktopDC = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopDC);
            g.FillEllipse(brush, x, y, width, height);
            g.Dispose();
            ReleaseDC(desktopDC);
        }
        static public void FillRectangle(Color color, int x, int y, int width, int height) {
            SolidBrush brush = new SolidBrush(color);
            IntPtr desktopDC = GetDC(IntPtr.Zero);
            Graphics g = Graphics.FromHdc(desktopDC);
            g.FillRectangle(brush, x, y, width, height);
            g.Dispose();
            ReleaseDC(desktopDC);
        }
    }

}
