using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace INFOGR2022Template
{
    public interface IPrimitive
    {
        Vector3 Color { get; }
        int Material { get; }

        Intersection Intersect(Ray ray);


    }
}
