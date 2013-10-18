using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Variance.Models;

namespace Variance.Examples {
	public class FunctionExamples {
		public void Run() {
			Action<Amphibian> changeName = (a) => a.CommonName = "Modified by Action!";

			// An Action can modify the object passed to it
			changeName(Zoo.gen);
			Console.WriteLine(Zoo.gen.CommonName);

			changeName(Zoo.blue_spotted);
			Console.WriteLine(Zoo.blue_spotted);

			Action<Frog> fa = changeName;

			// Can't assign Action<Derived> to Action<Base>
			// and this makes sense, as the Action<Derived> might refer to members of Derived not present in Base.
			//Action<Amphibian> aa = fa;

		}
	}
}