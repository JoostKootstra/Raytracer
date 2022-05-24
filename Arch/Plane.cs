using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace INFOGR2022Template
{
    public class Plane : IPrimitive
    {
        public Vector3 Color { get; }
        public Vector3 Position { get; set; }
        public Vector3 Normal { get; set; }
        public Vector3 Up { get; set; }
        public Vector3 Right { get; set; }
        public Vector3 p0 { get; set; }
        public Vector3 p1 { get; set; }
        public Vector3 p2 { get; set; }
        public Vector3 p3 { get; set; }
        public float Distance { get; }
        

        public Plane(Vector3 normal, float distance, Vector3 Color)
        {
            this.Normal = normal.Normalized();
            this.Distance = distance;
            this.Color = Color;
        }

    }
}
