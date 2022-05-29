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
        public int Material { get; }
        

        public Plane(Vector3 normal, float distance, Vector3 Color, int material)
        {
            Position = new Vector3(200, 256, 256);
            this.Normal = normal.Normalized();
            this.Distance = distance;
            this.Color = Color;
            Material = material;
        }


        // calculate intersection between ray and plane.
        public Intersection Intersect(Ray ray)
        {
            float f = Vector3.Dot(ray.Direction, Normal);

            // if angle between plane and direction of the ray is too small, we consider them parallel and thus no intersection
            if (Math.Abs(f) < 0.0000001) return null;

            // calculate distance to intersection and check if it's smaller than the distance set by a previous intersection
            // if the distance is smaller, update t and return intersection
            float distance_to_inter = (Distance - Vector3.Dot(ray.Origin, Normal)) / f;
            if ((distance_to_inter < ray.t) && (distance_to_inter > 0))
            {
                ray.t = distance_to_inter;
                Intersection temp = new Intersection(this, ray, Normal);
                return temp;   
            }
            return null;
        }

    }
}
