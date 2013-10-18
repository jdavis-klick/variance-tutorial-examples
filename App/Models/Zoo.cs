using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Variance.Models {
	public class Zoo {

		public static Frog leopard_frog = new Frog {
			Genus = "Rana",
			Species = "pipiens",
			CommonName = "Leopard Frog"
		};

		public static Frog poison_frog = new Frog {
			Genus = "Dendrobates",
			Species = "azureus",
			CommonName = "Blue poison dart frog",
			IsPoisonous = true
		};

		public static Salamander blue_spotted = new Salamander {
			Genus = "Ambystoma",
			Species = "laterale",
			CommonName = "Blue-spotted salamander"
		};

		public static Amphibian gen  = new Amphibian { Genus = "Amphibian", Species = "generic" , CommonName="Abstract Amphibian"};

		public static IList<Frog> frogList = new List<Frog> { leopard_frog, poison_frog };

		public static IEnumerable<Amphibian> amphibianEnumerable = new List<Amphibian> { leopard_frog, poison_frog, blue_spotted };
	}
}