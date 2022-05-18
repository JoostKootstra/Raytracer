using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace INFOGR2022Template
{
    internal class Light
    {
        Vector3 Position { get; }
        float Intensity { get; }
        public Light(Vector3 position, float intensity)
        {
            this.Position = position;
            this.Intensity = intensity;
        }

    }
}
