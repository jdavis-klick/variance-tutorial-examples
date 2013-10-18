using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Variance.Models;

namespace Variance.Examples {

	interface ITerrarium<T> where T:Lifeform {
		T remove();
		void add(T a);
	}

	class Amphiborium : ITerrarium<Amphibian> {
		public Amphibian remove() {
			return _amphibian;
		}

		public void add(Amphibian a) {
			_amphibian = a;
		}

		Amphibian _amphibian = null;
	}

	class Frogorium : ITerrarium<Frog> {
		public Frog remove() {
			return _amphibian;
		}

		public void add(Frog a) {
			_amphibian = a;
		}

		Frog _amphibian = null;
	}

	class Example {

		Frog poison_frog = new Frog {
			Genus = "Dendrobates",
			Species = "azureus",
			CommonName = "Blue poison dart frog",
			IsPoisonous = true
		};

		Salamander blue_spotted = new Salamander {
			Genus = "Ambystoma",
			Species = "laterale",
			CommonName = "Blue-spotted salamander"
		};

		public void Foo() {
			var glassbox = new Amphiborium();
			var wetbox = new Frogorium();

			glassbox.add(poison_frog);
			glassbox.add(blue_spotted);

			// not allowed, of course
			//wetbox.add(blue_spotted);

			ITerrarium<Frog> t1 = wetbox;
			t1.add(poison_frog);

			// can not implicitly convert to ITerrarium<Amphibian>.  An explicit conversion exists
			ITerrarium<Amphibian> t2 = wetbox as ITerrarium<Amphibian>;

			t2.add(poison_frog);

			t2.add(blue_spotted); // this compiles, but I bet it fails at run time

		}
	}



}
