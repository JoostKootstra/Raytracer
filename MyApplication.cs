using OpenTK;
using System.Collections.Generic;

namespace INFOGR2022Template
{
	public class MyApplication
	{
		// member variables
		public Surface debugscreen;
		public Surface tracerscreen;
		public static Camera cam = new Camera(new Vector3(256, 256, 480), new Vector3(0, 0, -480), new Vector3(0, 256, 0));
		Sphere sphere = new Sphere(new Vector3(256, 256, 100), 50, new Vector3(0, 0, 1));
		Plane plane1 = new Plane(new Vector3(0 ,0 ,1), 480, new Vector3(0, 0, 1));
		List<Ray> rays = new List<Ray>();
		// initialize
		public void Init()
		{
			//shoots a ray for every pixel
			//for (int i = 0; i < 512; i++)
				for(float j = 0; j < 512; 
					j++)
                {
					//calculate direction of ray
					Vector3 dir = (cam.p0 + (j / 512f) * cam.u + cam.v) - cam.Position;
					rays.Add(new Ray(cam.Position, dir));
                }
		}
		// tick: renders one frame
		public void Tick()
		{
			debugscreen.Clear( 0 );
			tracerscreen.Clear( 0xFF0000 );

			for (int i = 0; i < rays.Count; i++)
            {
				//rays[i].IntersectS(sphere);
				rays[i].IntersectP(plane1);
				rays[i].Draw();
			}
				

			//draw eye and screen on debug
			debugscreen.Line(206, 400, 306, 400, 0xFFFFFF);
			debugscreen.Plot((int)cam.Position.X, (int)cam.Position.Z, 0xFFFFFF);
			sphere.Draw();
		}
	}
}