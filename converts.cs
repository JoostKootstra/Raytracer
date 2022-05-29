using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace INFOGR2022Template
{
    static class converts
    {
        // convert Vector3 color to integer color by shifting bits
        public static int ToInt(this Vector3 c)
        {
            c *= 255;
            int x = (int)Math.Round(Math.Min(Math.Max(c.X, 0), 255));
            int y = (int)Math.Round(Math.Min(Math.Max(c.Y, 0), 255));
            int z = (int)Math.Round(Math.Min(Math.Max(c.Z, 0), 255));
            return (x << 16) + (y << 8) + z;
        }

        // convert integer color to Vector3 color by 
        public static Vector3 ToVector(this int i)
        {
            byte r, g, b;
            unchecked
            {
                b = (byte)i;
                i >>= 8;
                g = (byte)i;
                i >>= 8;
                r = (byte)i;
            }
            return new Vector3(r / 255f, g / 255f, b / 255f);
        }
    }
}
