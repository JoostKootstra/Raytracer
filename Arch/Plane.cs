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
        public Vector3 u { get; set; }
        public Vector3 v { get; set; }
        public float Distance { get; }
        public int Material { get; }
        

        public Plane(Vector3 Position, Vector3 u, Vector3 v, Vector3 Color, int material)
        {
            this.Position = Position;
            this.u = u.Normalized();
            this.v = v.Normalized();
            this.Normal = Vector3.Cross(u,v).Normalized();
            this.Distance = Vector3.Dot(this.Normal, this.Position);
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

        // calculate color for textured plane
        public Vector3 CalcColor(Vector3 p, Vector3 c1, Vector3 c2)
        {
            p -= this.Position;
            Vector3 c = c1;
            Vector2 uv = new Vector2(Vector3.Dot(u, p), Vector3.Dot(v, p));

            if (((int)uv.X / 60) % 2 == 0) c = c2;
            if (((int)uv.Y / 60) % 2 == 0) c = c2 - c;

            return c;
        }

    }
}
