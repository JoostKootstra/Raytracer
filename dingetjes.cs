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
            int x = (int)Math.Round(c.X);
            int y = (int)Math.Round(c.Y);
            int z = (int)Math.Round(c.Z);
            return (x << 16) + (y << 8) + z;
        }

        public static float ToP(this float f)
        {
            return f * (OpenTKApp.app.debugscreen.width) + (OpenTKApp.app.debugscreen.width / 2);
        }
    }
}
