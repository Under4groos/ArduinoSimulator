﻿using System.Runtime.InteropServices;

namespace Stuctures
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Size
    {

        public double Height;
        public double Width;

        public Size(double w, double h)
        {

            Height = h;
            Width = w;
        }

        public override string ToString()
        {
            return $"{Width}px/{Height}px";
        }
    }
}
