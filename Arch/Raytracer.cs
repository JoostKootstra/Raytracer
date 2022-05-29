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
		public List<Intersection> _mirrorinters { get; set; }
		public List<IPrimitive> primitives { get; set; }
		public List<int> notShadow { get; set; }

		public Vector3 Eye = new Vector3(new Vector3(256, 256, 480));
		public Camera cam = new Camera(new Vector3(256, 256, 400), new Vector3(0, 0, -480), new Vector3(0, 256, 0));
		public Light light = new Light(new Vector3(330, 256, 180), new Vector3(1, 0, 0));
		public Light light2 = new Light(new Vector3(100, 256, 180), new Vector3(1, 1, 1));

		Sphere sphere1 = new Sphere(new Vector3(256, 256, 100), 50, new Vector3(0, 0, 1), 0);
		Sphere sphere2 = new Sphere(new Vector3(128, 256, 100), 70, new Vector3(1, 0, 0), 0);
		Sphere sphere3 = new Sphere(new Vector3(384, 256, 100), 40, new Vector3(0, 1, 0), 1);
		Plane plane1 = new Plane(new Vector3(0, 1, 0), 0, new Vector3(1, 1, 1), 0);

		public Raytracer()
        {
			primitives = new List<IPrimitive>();
			_spheres = new List<Sphere>();
			_planes = new List<Plane>();
			_lights = new List<Light>();
			_rays = new List<Ray>();
			_intersections = new List<Intersection>();
			_mirrorinters = new List<Intersection>();
			_shadowrays = new List<Ray>();
			notShadow = new List<int>();

			_lights.Add(light);
			_lights.Add(light2);
			
			primitives.Add(sphere1);
			primitives.Add(sphere2);
			primitives.Add(sphere3);
			primitives.Add(plane1);
		}

		public Intersection Trace(Ray r)
        {
			Intersection temp = null;
			foreach (IPrimitive p in primitives) temp = p.Intersect(r) ?? temp;
			if (temp != null && temp.prim.Material == 1 && r.MaxBounces > 0)
            {
				Vector3 dir = r.Direction - 2 * (Vector3.Dot(r.Direction, temp.Normal) * temp.Normal);
				Ray refl = new Ray(r.Origin + r.Direction * r.t + temp.Normal * 0.0001f, dir, r.ID, r.MaxBounces - 1);
				OpenTKApp.app.tracerscreen.pixels[r.ID] = (OpenTKApp.app.tracerscreen.pixels[r.ID].ToVector() * temp.prim.Color).ToInt();

				if (r.Origin.Y + r.Direction.Y * 100 == 256 && r.ID % 5 == 0) refl.DrawR();

				return Trace(refl);
            }
			return temp;
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
					Ray ray = new Ray(Eye, dir, id, 20);
					Intersection t = Trace(ray);
					
					if (t != null) _intersections.Add(t);
					if (i == 256 && id % 10 == 0) ray.Draw();
					id++;
				}
		}

		public void Render()
		{
			foreach (IPrimitive s in primitives) (s as Sphere)?.Draw();

			//draw eye and screen on debug
			OpenTKApp.app.debugscreen.Line((int)cam.Position.X - 80, 400, (int)cam.Position.X + 80, 400, 0xFFFFFF);
			OpenTKApp.app.debugscreen.Plot((int)Eye.X, (int)Eye.Z, 0xFFFFFF);


			foreach (Intersection i in _intersections)
            {
				if (i.prim.Material == 0)
                {
					Vector3 s = Vector3.Zero;
					foreach (Light l in _lights)
					{
						Vector3 c;
						Vector3 Origin = new Vector3(i.ray.Origin.X + i.ray.Direction.X * i.ray.t, i.ray.Origin.Y + i.ray.Direction.Y * i.ray.t, i.ray.Origin.Z + i.ray.Direction.Z * i.ray.t);
						Ray shadowray = new Ray(Origin + i.Normal.Normalized(), l.Position - Origin, i.ray.ID, 0);
						shadowray.t = Vector3.Distance(l.Position, Origin);
						c = (Math.Max(Vector3.Dot(i.Normal, shadowray.Direction), 0) * i.Color * l.Color);

						Intersection temp = null;
						foreach (IPrimitive p in primitives)
						{
							temp = p.Intersect(shadowray) ?? temp;
						}


						if (temp != null || Vector3.Dot(shadowray.Direction, i.Normal) < 0) c = Vector3.Zero;
						if (shadowray.Origin.Y + shadowray.Direction.Y * shadowray.t == 256 && shadowray.ID % 10 == 0) shadowray.DrawS();

						s += c;
					}
					OpenTKApp.app.tracerscreen.pixels[i.ray.ID] = (OpenTKApp.app.tracerscreen.pixels[i.ray.ID].ToVector() * s).ToInt();
                }

            }

			foreach (Intersection i in _mirrorinters) _intersections.Add(i);
		}
		


	}
}
