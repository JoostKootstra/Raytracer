using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace INFOGR2022Template
{
    public class Raytracer
    {
        public List<Sphere> _spheres { get; set; }
		public List<Plane> _planes { get; set; }
        public List<Light> _lights { get; set; }
		public List<Ray> _rays { get; set; }
		public List<Ray> _shadowrays { get; set; }
		public List<Intersection> _intersections { get; set; }
		public List<IPrimitive> primitives { get; set; }

		public Vector3 Eye = new Vector3(new Vector3(256, 256, 480));
		public Camera cam = new Camera(new Vector3(256, 256, 400), new Vector3(0, 0, -480), new Vector3(0, 256, 0));
		public Light light = new Light(new Vector3(512, 300, 256), 1);

		Sphere sphere1 = new Sphere(new Vector3(256, 256, 100), 50, new Vector3(0, 0, 1));
		Sphere sphere2 = new Sphere(new Vector3(128, 256, 100), 70, new Vector3(1, 0, 0));
		Sphere sphere3 = new Sphere(new Vector3(384, 256, 100), 40, new Vector3(0, 1, 0));
		Plane plane1 = new Plane(new Vector3(0, 1, 0), -300, new Vector3(1, 1, 1));

		public Raytracer()
        {
			primitives = new List<IPrimitive>();
			_spheres = new List<Sphere>();
			_planes = new List<Plane>();
			_lights = new List<Light>();
			_rays = new List<Ray>();
			_intersections = new List<Intersection>();
			_shadowrays = new List<Ray>();
			
			primitives.Add(sphere1);
			primitives.Add(sphere2);
			primitives.Add(sphere3);
			//primitives.Add(plane1);
			/*
			_spheres.Add(sphere1);
			_spheres.Add(sphere2);
			_spheres.Add(sphere3);
			*/
			//_planes.Add(plane1);
		}



		public void Shoot()
        {
			_rays.Clear();
			
			int id = 0;
			for (int i = 0; i < 512; i++)
				for (float j = 0; j < 512; j++)
				{
					//calculate direction of ray
					Vector3 dir = (cam.p0 + (j / 512f) * cam.u + (i / 512f) * cam.v) - Eye;
					Ray ray = new Ray(Eye, dir, id);
					Intersection temp = null;
					foreach (IPrimitive p in primitives) temp = p.Intersect(ray) ?? temp;
					if (temp != null) _intersections.Add(temp);
					if (i == 256 && id % 10 == 0) ray.Draw();
					id++;
				}
		}

		public void DrawDebug()
		{
			foreach (IPrimitive s in primitives) (s as Sphere)?.Draw();

			//draw eye and screen on debug
			OpenTKApp.app.debugscreen.Line((int)cam.Position.X - 80, 400, (int)cam.Position.X + 80, 400, 0xFFFFFF);
			OpenTKApp.app.debugscreen.Plot((int)Eye.X, (int)Eye.Z, 0xFFFFFF);

			foreach (Intersection i in _intersections)
            {
				
				Vector3 Origin = new Vector3(i.ray.Origin.X + i.ray.Direction.X * i.ray.t, i.ray.Origin.Y + i.ray.Direction.Y * i.ray.t, i.ray.Origin.Z + i.ray.Direction.Z * i.ray.t);
				Ray shadowray = new Ray(light.Position, Origin - light.Position, i.ray.ID);
				shadowray.t = Vector3.Distance(light.Position, Origin);
				foreach (IPrimitive p in primitives) p.Intersect(shadowray);
				if (i.ray.Origin.Y + i.ray.Direction.Y * i.ray.t == 256 && i.ray.ID % 33 == 0)
				{
					shadowray.DrawS();
				}
				
            }
		}
		
		public void Render()
        {
			foreach (Intersection i in _intersections)
            {
				foreach (Light l in _lights)
                {
					Vector3 Origin = new Vector3(i.ray.Origin.X + i.ray.Direction.X * i.ray.t, i.ray.Origin.Y + i.ray.Direction.Y * i.ray.t, i.ray.Origin.Z + i.ray.Direction.Z * i.ray.t);
					Ray shadowray = new Ray(Origin, l.Position - Origin, i.ray.ID);
					foreach (IPrimitive p in primitives) p.Intersect(shadowray);
				}

				OpenTKApp.app.tracerscreen.pixels[i.ray.ID] = i.prim.Color.ToInt();
            }

        }

	}
}
