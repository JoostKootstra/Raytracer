using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace INFOGR2022Template
{
    public class Camera
    {
        public Vector3 Position { get; set; }
        public Vector3 LookAt { get; set; }
        public Vector3 Up { get; set; }
        public Vector3 Right { get; set; }
        public Vector3 p0 { get; set; }
        public Vector3 p1 { get; set; }
        public Vector3 p2 { get; set; }
        public Vector3 u { get; set; }
        public Vector3 v { get; set; }
        
        public Camera(Vector3 Position, Vector3 LookAt, Vector3 UpDir)
        {
            this.Position = Position;
            this.Up = UpDir;
            
            this.LookAt = LookAt.Normalized();
            this.Up = UpDir.Normalized();
            Right = Vector3.Cross(LookAt, UpDir);
            this.Right = 80*this.Right.Normalized();

            p0 = Position + Up - Right;
            p1 = Position + Up + Right;
            p2 = Position - Up - Right;
            u = p1 - p0;
            v = p2 - p0;
        }

        public void Update()
        {
            p0 = Position + Up - Right;
            p1 = Position + Up + Right;
            p2 = Position - Up - Right;
            u = p1 - p0;
            v = p2 - p0;
        }

    }
}
