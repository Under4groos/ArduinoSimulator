
using System.Runtime.InteropServices;


namespace Stuctures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public Size GetSize()
        {
            return new Size(Right - Left, Bottom - Top);
        }
        public Size GetSize(double w, double h)
        {
            return new Size((Right - Left) * w, (Bottom - Top) * h);
        }
        public override string ToString()
        {
            return $"x:{Left} y: {Top} / {GetSize()}";
        }
    }
}
