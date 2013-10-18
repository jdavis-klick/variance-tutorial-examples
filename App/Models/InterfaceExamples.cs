using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Variance.Models;

namespace Variance.Examples {

	interface ITerrarium {
		Amphibian remove();
		void add(Amphibian a);
	}

	class Terrarium : ITerrarium {
		public Amphibian remove() {
			return _amphibian;
		}

		public void add(Amphibian a) {
			_amphibian = a;
		}

		Amphibian _amphibian = null;

	}

	class Frogarium : ITerrarium {

		// this does not count as an implementation of Amphibian remove(), event though Frog is a subtype
		// C# does not allow covariant return types
		/*
		public  Frog remove() {
			return _frog;
		}
		 */

		public Amphibian remove() {
			return _frog;
		}

		// this does not count as implementing add(Amphibian) because Frog  < Amphibian
		public void add(Frog a) {
			_frog = a;
		}

		public void add(Amphibian a) {
			if (a is Frog) {
				_frog = a as Frog;
			} else {
				throw new ArgumentException("I do not really implement ITerrarium.");
			}
		}


		Frog _frog = null;
	}



}