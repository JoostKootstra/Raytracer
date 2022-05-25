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
			
			if (input.IsKeyDown(Key.A)) tracer.Eye -= new Vector3(10, 0, 0);
			if (input.IsKeyDown(Key.D)) tracer.Eye += new Vector3(10, 0, 0);
			if (input.IsKeyDown(Key.S)) tracer.Eye += new Vector3(0, 0, 10);
			if (input.IsKeyDown(Key.W)) tracer.Eye -= new Vector3(0, 0, 10);
			if (input.IsKeyDown(Key.Z)) tracer.Eye += new Vector3(0, 10, 0);
			if (input.IsKeyDown(Key.X)) tracer.Eye -= new Vector3(0, 10, 0);


			debugscreen.Clear(0);
			tracerscreen.Clear(0);
			tracer.Shoot();
			tracer.DrawDebug();
			tracer.Render();
			tracer._intersections.Clear();
			//tracer.Render();


		}
	}
}