using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Variance.Models;

namespace Variance.Examples {
	public class EnumerableExamples {

		static void HatchMany(IEnumerable<Amphibian> bios) {
			Console.WriteLine("\nGotta hatch 'em all");
			foreach (var b in bios) {
				Console.Write(" ");
				b.Hatch();
			}
		}

		public void Run() {
			Console.WriteLine("\nEnumerable Examples");

			// nothing surprising here, the signatures match
			HatchMany(Zoo.amphibianEnumerable);

			// This assignment is allowed because IList<T> inherits from IEnumerable<T>, therefore frogList is also IEnumerable<Frog>
			// can assign IList<T> to IEnumerable<T>
			IEnumerable<Frog> frogEnumerable = Zoo.frogList;

			// IEnumerable is convariant, so IEnumerable<Frog> is a subtype of  IEnumerable<Amphibian>,
			// so this call is allowed, too
			HatchMany(Zoo.frogList);

			// and so is this assignment
			IEnumerable<Amphibian> a1 = Zoo.frogList;

			// but NOT this assignment
			// Cannot implicitly convert type 'System.Collection.Generic.List<Variance.Models.Frog>' to 'System.Collection.Generic.List<Variance.Models.Amphibian>'
			//List<Amphibian> al = frogList;

			// but you can use an explicit conversion
			List<Amphibian> a2 = Zoo.frogList.ToList<Amphibian>();

	
		}
	}
}