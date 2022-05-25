using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;

namespace INFOGR2022Template
{
    public class Ray
    {
        public Vector3 Origin { get; }
        public Vector3 Direction { get; }
        public Vector3 Normal { get; set; }
        public int ID { get; set; }
        //IPrimitive InterPrim { get; set; }
        public float t { get; set; }

        public Ray(Vector3 origin, Vector3 direction, int ID)
        {
            this.ID = ID;
            this.Origin = origin;
            this.Direction = direction.Normalized();
            t = float.PositiveInfinity;
        }

        public void Draw()
        {

             OpenTKApp.app.debugscreen.Line((int)Origin.X, (int)Origin.Z, (int)(Origin.X + Direction.X * Math.Min(t, 1000)), (int)(Origin.Z + Direction.Z * Math.Min(t, 1000)), 0xFFFF00);
        }

        public void DrawS()
        {
            OpenTKApp.app.debugscreen.Line((int)Origin.X, (int)Origin.Z, (int)(Origin.X + Direction.X * t), (int)(Origin.Z + Direction.Z * t), 0xFFFFFF);
        }
        
    }
}
