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
        float Intensity { get; }
        public Light(Vector3 position, float intensity)
        {
            this.Position = position;
            this.Intensity = intensity;
        }

    }
}
