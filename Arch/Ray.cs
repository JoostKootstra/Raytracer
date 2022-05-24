﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;

namespace INFOGR2022Template
{
    public class Ray
    {
        public Vector3 Origin { get; }
        public Vector3 Direction { get; }
        public Vector3 Normal { get; set; }
        IPrimitive InterPrim { get; set; }
        public float t { get; set; }

        public Ray(Vector3 origin, Vector3 direction)
        {
            this.Origin = origin;
            this.Direction = direction.Normalized();
            t = 1000;
        }

        public void Draw()
        {
            if (!OpenTKApp.app.input.IsKeyDown(Key.A) && !OpenTKApp.app.input.IsKeyDown(Key.D))
            {
                OpenTKApp.app.debugscreen.Line((int)Origin.X, (int)Origin.Z, (int)(Origin.X + Direction.X * t), (int)(Origin.Z + Direction.Z * t), 0xFFFF00);
            }
        }
        
    }
}
