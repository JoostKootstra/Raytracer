using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace INFOGR2022Template
{
    internal class Ray
    {
        Vector3 Origin { get; }
        Vector3 Direction { get; }
        Vector3 Normal { get; set; }
        IPrimitive InterPrim { get; set; }
        float t { get; set; }
        float o;

        public Ray(Vector3 origin, Vector3 direction)
        {
            this.Origin = origin;
            this.Direction = direction.Normalized();
        }

        public void IntersectP(Plane plane)
        {
            
        }

        /*
        public void IntersectS(Sphere sphere)
        {
            Vector3 c = sphere.Center - Origin;
            float t = Vector3.Dot(c, Direction);
            Vector3 q = c - t * Direction;
            float p2 = q.LengthSquared;
            if (p2 > sphere.Radius * sphere.Radius) return;
            t -= (float)Math.Sqrt(sphere.Radius * sphere.Radius - p2);
            if ((t < this.t) && (t > 0)) { this.t = t; o = sphere.Radius; }
        }
        */

        public void Draw()
        {
            OpenTKApp.app.debugscreen.Line((int)Origin.X, (int)Origin.Z, (int)(Origin.X + Direction.X * ), 0, 0xFFFF00);
        }
        
    }
}
