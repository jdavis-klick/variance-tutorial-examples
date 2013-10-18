using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Variance.Models;

namespace Variance.Examples {

	public class ActionExamples {

		static void Hatch(Amphibian a) {
			a.Hatch();
		}

		static void Hatch(Frog f) {
			f.Hatch();
			f.Croak();
		}

		static void HatchFrog(Frog f) {
			f.Hatch();
			f.Croak();
		}

		static void Jump(Frog f) {
			f.Jump();
		}

		static void HatchMany(IEnumerable<Amphibian> bios) {
			foreach (var b in bios) {
				b.Hatch();
			}
		}

		public void Run() {
			Console.WriteLine("\nAction Examples");

			Action<Frog> ff1 = null;
			Action<Amphibian> fa1 = null;

			Action<Frog> printFrog = (f) => Console.WriteLine("Frog Action " + f.Species + " " + f.IsPoisonous.ToString());

			ff1 = printFrog;

			ff1(Zoo.leopard_frog);

			// naturally this is not allowed.  Salamander is not Frog
			//ff1(Zoo.blue_spotted);

			// This also is not allowed, for same reason
			//ff1(Zoo.gen);

			// you can assign an anonymous lambda to a typed variable
			fa1 = (a) => Console.WriteLine("Amphibian Action: " + a.CommonName);

			fa1(Zoo.leopard_frog);
			fa1(Zoo.gen);

			// you can assign an Action<T> to Action<S> when S is subtype of T
			// this is contravariance.
			ff1 = fa1;

			ff1(Zoo.leopard_frog);

			// Can't assign Action<S> to Action<T>
			//fa1 = printFrog;

			// you can cast, but the result is null.
			fa1 = printFrog as Action<Amphibian>;
			if (fa1 == null) {
				Console.WriteLine("After assignment, fa1 is null");
			} else {
				fa1(Zoo.blue_spotted);
			}


			// this is the easy case, since Hatch is defined on Amphibian
			Action<Amphibian> aa1 = Hatch;

			//HatchFrog is defined on Frog, so this does not work, even though Frog is a subtype of Amphibian
			// 
			//Action<Amphibian> aa2 = HatchFrog;

			Action<Frog> aa3 = HatchFrog;

			// Frog has to be substitutable for Amphibian, so Frog must implement Hatch
			Action<Frog> aa4 = Hatch;

			Console.WriteLine("\n---");

			Hatch(Zoo.blue_spotted);

			// THIS call uses the more-specific Hatch<Frog>
			Hatch(Zoo.leopard_frog);

			// Since this action is defined on Amphibian, it uses the Hatch<Amphibian> method.
			aa1(Zoo.poison_frog);

			// This call uses the more specific method
			aa4(Zoo.leopard_frog);

			// this call isn't allowed, because Salamander is not Frog
			//aa4(blue_spotted);


		}
	}
}