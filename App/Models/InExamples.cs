using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Variance.Models;

namespace Variance.Examples {
	public class InExamples {

		// generic interface that does not use in
		interface Stylist<T> {
			void Examine(T animal);
		}

		// generic interface using in
		interface Veterinarian<in T> {
			void Examine(T animal);
		}


		public void Run() {

			Veterinarian<Frog> vf = null;
			Veterinarian<Lifeform> va = null;

			vf.Examine(new Frog());
			// not allowed, method has a right to expect T=Frog
			//vf.Examine(new Amphibian());

			// covariance for parameters
			va.Examine(new Frog());

			// variable assignment is contravariant
			vf = va;

			// not allowed
			//va = vf;


			Stylist<Frog> sf = null;
			Stylist<Lifeform> sa = null;

			sf.Examine(new Frog());
			// not allowed, method has a right to expect T=Frog
			//sf.Examine(new Amphibian());

			// covariance for parameters
			sa.Examine(new Frog());

			// NOT allowed
			//sf = sa;

			// not allowed
			//sa = sf;

		}

	}
}