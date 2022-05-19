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
        Vector3 Position { get; }
        Vector3 Center { get; }
        float Radius { get; }

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

        }

        public void DDraw()
        {

        }
    }
}
