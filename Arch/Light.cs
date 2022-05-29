using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace INFOGR2022Template
{
    public class Light
    {
        public Vector3 Position { get; set; }
        public Vector3 Color { get; }
        float t { get; set; }
        public Light(Vector3 position, Vector3 Color)
        {
            this.Position = position;
            this.Color = Color;
        }



    }
}
