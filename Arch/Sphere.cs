using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;


namespace INFOGR2022Template
{
    public class Sphere : IPrimitive
    {
        public Vector3 Color { get; }
        public Vector3 Position { get; }
        public Vector3 Center { get; }
        public float Radius { get; }
        public int Material { get; }

        public Sphere(Vector3 position, float radius, Vector3 color, int material)
        {
            this.Position = position;
            this.Radius = radius;
            this.Center = position;
            this.Color = color;
            this.Material = material;
        }

        // calculate intersection between ray and sphere
        public Intersection Intersect(Ray ray)
        {
            // code was taken from slides

            Vector3 c = Center - ray.Origin;
            float t = Vector3.Dot(c, ray.Direction);
            Vector3 q = c - t * ray.Direction;
            float p2 = q.LengthSquared;

            if (p2 > Radius * Radius) return null;
            t -= (float)Math.Sqrt((Radius * Radius) - p2);
            if ((t < ray.t) && (t > 0))
            {
                ray.t = t;
                // calculate normal 
                Vector3 Normal = (ray.Origin + ray.Direction * ray.t) - Position;
                Intersection temp = new Intersection(this, ray, Normal);
                return temp;
            }
            return null;
        }

        // draw circle on debugscreen as a 100-sided polygon
        public void Draw()
        {
            int c = Color.ToInt();
            for (int i = 0; i < 100; i++)
            {
                OpenTKApp.app.debugscreen.Line((int)(Position.X + Radius * Math.Cos((float)i / 100 * 2 * Math.PI)), (int)(Position.Z + Radius * Math.Sin((float)i / 100 * 2 * Math.PI)),
                                          (int)(Position.X + Radius * Math.Cos(((float)i + 1) / 100 * 2 * Math.PI)), (int)(Position.Z + Radius * Math.Sin(((float)i + 1) / 100 * 2 * Math.PI)),c);
            }
        }
    }
}
