using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Variance.Models {

	// In the true Linnaean system, the taxonometic hierarchy is
	// Kingdom, Phylum, Class, (subclass), Order, Family, Genus, Species
	// the "Lifeform" class is not the 
	public class Lifeform {
		public string Genus { get; set; }
		public string Species { get; set; }
		public string CommonName {get ; set;}
	}

	// Oddly enough, in the Linneaan system of taxonomy, Amphibian really is a Class (within subphylum Chordata)
	// It has only one subclass with non-extinct members, Lissamphibia
	public class Amphibian: Lifeform {
		public bool HasLegs { get; set; } // there are legless amphibians
		public virtual void Hatch() {
			Console.WriteLine("Hatching: " + this.CommonName);
		}
	}

	// Order Anura.  frogs and toads
	public class Frog : Amphibian {
		public bool IsPoisonous { get; set; }

		public void Croak () {
			Console.WriteLine("Ribbit");
		}

		public void Jump() { }

		public Frog () {
			IsPoisonous = false;
			HasLegs = true;
		}

		public override  void Hatch() {
			Console.WriteLine("Hatching " + (IsPoisonous ? "poison" : "normal") + " Frog: " + this.CommonName);
		}

	}

	// Order Caudata, also includes the newts
	public class Salamander : Amphibian { }



}