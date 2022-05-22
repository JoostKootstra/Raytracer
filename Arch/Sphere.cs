using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;


namespace INFOGR2022Template
{
    internal class Sphere : IPrimitive
    {
        public Vector3 Color { get; }
        public Vector3 Normal { get; }
        public Vector3 Position { get; }
        public Vector3 Center { get; }
        public float Radius { get; }

        public Sphere(Vector3 position, float radius, Vector3 color)
        {
            this.Position = position;
            this.Radius = radius;
            this.Center = position;
            this.Color = color;
        }

        public bool Intersect(Ray ray)
        {
            return true;
        }

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
