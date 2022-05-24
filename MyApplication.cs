using OpenTK;
using System.Collections.Generic;
using System;
using OpenTK.Input;

namespace INFOGR2022Template
{
	public class MyApplication
	{
		// member variables
		public Surface debugscreen;
		public Surface tracerscreen;
		public Raytracer tracer = new Raytracer();
		public KeyboardState input;
		 

		// initialize
		public void Init()
		{	
			
		}
		// tick: renders one frame
		public void Tick()
		{
			
			tracer.cam.Update();
			input = Keyboard.GetState();
			if (!input.IsKeyDown(Key.A) && !input.IsKeyDown(Key.D))
            {
				//shoots a ray for every pixel
				tracer.Shoot();
			}
			if (input.IsKeyDown(Key.A)) tracer.cam.Position -= new Vector3(10, 0, 0);
			if (input.IsKeyDown(Key.D)) tracer.cam.Position += new Vector3(10, 0, 0);
			debugscreen.Clear(0);
			tracerscreen.Clear(0xFF);
			tracer.DrawDebug();

			
		}
	}
}