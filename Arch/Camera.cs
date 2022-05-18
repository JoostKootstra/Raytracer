using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace INFOGR2022Template
{
    internal class Camera
    {
        Vector3 Position { get; set; }
        Vector3 LookAt { get; set; }
        Vector3 Up { get; set; }
        Vector3 Right { get; set; }
        Vector3 p0 { get; set; }
        Vector3 p1 { get; set; }
        Vector3 p2 { get; set; }
        Vector3 p3 { get; set; }
        
        public Camera(Vector3 Position, Vector3 LookAt, Vector3 UpDir)
        {
            this.Position = Vector3.Normalize(Position);
            this.LookAt = Vector3.Normalize(LookAt);
            this.Up = Vector3.Normalize(UpDir);
            Right = Vector3.Cross(LookAt, UpDir);

            p0 = Position + Up + Right;
            p1 = Position - Up + Right;
            p2 = Position - Up - Right;
            p3 = Position + Up - Right;
        }

    }
}
