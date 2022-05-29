using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace INFOGR2022Template
{
    static class dingetjes
    {
        public static int ToInt(this Vector3 c)
        {
            c *= 255;
            int x = (int)Math.Round(Math.Min(Math.Max(c.X, 0), 255));
            int y = (int)Math.Round(Math.Min(Math.Max(c.Y, 0), 255));
            int z = (int)Math.Round(Math.Min(Math.Max(c.Z, 0), 255));
            return (x << 16) + (y << 8) + z;
        }

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

        public static float ToP(this float f)
        {
            return f * (OpenTKApp.app.debugscreen.width) + (OpenTKApp.app.debugscreen.width / 2);
        }

        public static int CalcColor(this Ray sr, Vector3 inter, IPrimitive p)
        {
            int c = 0;
            if (sr.t == Vector3.Distance(sr.Origin, inter)) c = p.Color.ToInt();

            return c;
        }
    }
}
