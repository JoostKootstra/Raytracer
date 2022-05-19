using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace INFOGR2022Template
{
    internal class Plane : IPrimitive
    {
        public Vector3 Color { get; }
        public Vector3 Normal { get; }
        float Distance { get; }
        

        public Plane(Vector3 normal, float distance, Vector3 Color)
        {
            this.Normal = Vector3.Normalize(normal);
            this.Distance = distance;
            this.Color = Color;
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
