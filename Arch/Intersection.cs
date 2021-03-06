using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace INFOGR2022Template
{
    public class Intersection
    {
        public Vector3 Normal { get; set; }
        public Ray ray { get; set; }
        float d { get; set; }
        public IPrimitive prim { get; set; }
        public Vector3 Color { get; set; }

        public Intersection(IPrimitive primitive, Ray r, Vector3 normal)
        {
            prim = primitive;
            ray = r;
            Normal = normal.Normalized();

            // set color of object at intersection, if color is null, color is set to black
            Color = prim?.Color?? Vector3.Zero;
        }
    }
}
