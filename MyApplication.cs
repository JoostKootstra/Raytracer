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
		int lselect = 0;


		// initialize
		public void Init()
		{
			
		}
		// tick: renders one frame
		public void Tick()
		{
			
			tracer.cam.Update();
			input = Keyboard.GetState();
			
			if (input.IsKeyDown(Key.Q)) lselect++;
			if (lselect > tracer._lights.Count) lselect = 0;
			
			if (input.IsKeyDown(Key.A)) tracer.Eye -= new Vector3(10, 0, 0);
			if (input.IsKeyDown(Key.D)) tracer.Eye += new Vector3(10, 0, 0);
			if (input.IsKeyDown(Key.S)) tracer.Eye += new Vector3(0, 0, 10);
			if (input.IsKeyDown(Key.W)) tracer.Eye -= new Vector3(0, 0, 10);
			if (input.IsKeyDown(Key.Z)) tracer.Eye += new Vector3(0, 10, 0);
			if (input.IsKeyDown(Key.X)) tracer.Eye -= new Vector3(0, 10, 0);

			if (input.IsKeyDown(Key.Right)) tracer._lights[lselect].Position += new Vector3(10, 0, 0);
			if (input.IsKeyDown(Key.Left)) tracer._lights[lselect].Position -= new Vector3(10, 0, 0);
			if (input.IsKeyDown(Key.Up)) tracer._lights[lselect].Position -= new Vector3(0, 0, 10);
			if (input.IsKeyDown(Key.Down)) tracer._lights[lselect].Position += new Vector3(0, 0, 10);
			if (input.IsKeyDown(Key.Space)) tracer._lights[lselect].Position += new Vector3(0, 10, 0);
			if (input.IsKeyDown(Key.ShiftLeft)) tracer._lights[lselect].Position -= new Vector3(0, 10, 0);

			debugscreen.Clear(0);
			tracerscreen.Clear(0xFFFFFF);
			tracer.Shoot();
			tracer.Render();
			tracer._intersections.Clear();
		}
	}
}