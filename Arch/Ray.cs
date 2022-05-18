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

        public Ray(Vector3 origin, Vector3 direction)
        {
            this.Origin = origin;
            this.Direction = Vector3.Normalize(direction);
        }

    }
}
