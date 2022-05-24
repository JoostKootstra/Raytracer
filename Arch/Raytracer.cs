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

		public Camera cam = new Camera(new Vector3(256, 256, 480), new Vector3(0, 0, -480), new Vector3(0, 256, 0));
		public Light light = new Light(new Vector3(512, 600, 256), 1);

		Sphere sphere1 = new Sphere(new Vector3(256, 256, 100), 50, new Vector3(0, 0, 1));
		Sphere sphere2 = new Sphere(new Vector3(128, 256, 100), 70, new Vector3(1, 0, 0));
		Sphere sphere3 = new Sphere(new Vector3(384, 256, 100), 40, new Vector3(0, 1, 0));
		Plane plane1 = new Plane(new Vector3(1, 0, 1), -300, new Vector3(0, 0, 1));

		public Raytracer()
        {
			_spheres = new List<Sphere>();
			_planes = new List<Plane>();
			_lights = new List<Light>();
			_rays = new List<Ray>();
			_intersections = new List<Intersection>();
			_shadowrays = new List<Ray>();
			

			_spheres.Add(sphere1);
			_spheres.Add(sphere2);
			_spheres.Add(sphere3);
			//_planes.Add(plane1);
		}

		public void Shoot()
        {
			_rays.Clear();
			for (int i = 0; i < 512; i++)
				for (float j = 0; j < 512; j++)
				{
					//calculate direction of ray
					Vector3 dir = (cam.p0 + (j / 512f) * cam.u + (i / 512f) * cam.v) - cam.Position;
					_rays.Add(new Ray(cam.Position, dir));
				}
		}

		public void DrawDebug()
		{
			//draw the rays of the middle of the screen
			for (int i = 130560; i < 131072; i += 10)
			{
				foreach (Sphere s in _spheres)
				{
					IntersectS(s, _rays[i]);
					s.Draw();
				}
				foreach (Plane p in _planes)
                {
					IntersectP(p, _rays[i]);
                }
				_rays[i].Draw();
			}

			//draw eye and screen on debug
			OpenTKApp.app.debugscreen.Line((int)cam.Position.X - 80, 400, (int)cam.Position.X + 80, 400, 0xFFFFFF);
			OpenTKApp.app.debugscreen.Plot((int)cam.Position.X, (int)cam.Position.Z, 0xFFFFFF);
		}

		public void IntersectS(Sphere sphere, Ray ray)
		{
			Vector3 c = sphere.Center - ray.Origin;
			float t = Vector3.Dot(c, ray.Direction);
			Vector3 q = c - t * ray.Direction;
			float p2 = q.LengthSquared;

			if (p2 > sphere.Radius * sphere.Radius) return;
			t -= (float)Math.Sqrt((sphere.Radius * sphere.Radius) - p2);
			if ((t < ray.t) && (t > 0))
			{
				ray.t = t;
				sphere.Normal = (ray.Origin + ray.Direction * ray.t) - sphere.Position;
				if (_rays.Contains(ray)) _intersections.Add(new Intersection(sphere, ray));
			}
		}

		public void IntersectP(Plane plane, Ray ray)
		{
			float f = Vector3.Dot(ray.Direction, plane.Normal);
			if (Math.Abs(f) < 0.0001) return;
			float t = (plane.Distance - Vector3.Dot(plane.Position, plane.Normal)) / f;
			if ((t < ray.t) && (t > 0))
			{
				ray.t = t;
				if (_rays.Contains(ray)) _intersections.Add(new Intersection(plane, ray));
			}
		}

		public void Render()
        {
			foreach (Intersection i in _intersections)
            {
				foreach (Light l in _lights)
                {
					Vector3 Origin = new Vector3(i.ray.Origin.X + i.ray.Direction.X * i.ray.t, i.ray.Origin.Y + i.ray.Direction.Y * i.ray.t, i.ray.Origin.Z + i.ray.Direction.Z * i.ray.t);
					_shadowrays.Add(new Ray(Origin, l.Position - Origin));
				}
            }

			foreach (Ray sr in _shadowrays)
            {
				foreach (Plane p in _planes) IntersectP(p, sr);
				foreach (Sphere s in _spheres) IntersectS(s, sr);
			}
        }

	}
}
