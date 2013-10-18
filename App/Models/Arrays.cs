using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Variance.Models;

namespace Variance.Examples {

	class ArrayExamples {

		Amphibian[] amphibianArray = new Amphibian[1];
		Frog[] frogArray = new Frog[1];


		void Example1() {
			frogArray[0] = Zoo.leopard_frog;
			amphibianArray[0] = Zoo.leopard_frog;

			// of course this is not allowed
			//frogArray[0] = blue_spotted;
			amphibianArray[0] = Zoo.blue_spotted;

			// Amphibian[] can't be a subtype of Frog[] because it fails on READ if it did already have a Salamander
			// Frog[] can not be a subtype of Amphibian[] because it fails on WRITE if we assign a Salamander into it

			// so these arrays must be invariant

			// but a read-only array (an Enumerable) could be covariant
			// and a write-only array can be contravariant


		}


	}
}