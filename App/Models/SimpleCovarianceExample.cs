using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Variance.Models;


namespace Variance.Examples {
	public class SimpleCovarianceExamples {

		class Base { }
		class Derived : Base { }
		class OtherDerived : Base { }

		void populate(Base[] bases) {
			bases[0] = new OtherDerived();
		}

		public void Run() {

			// simple assignment is covariant
			Base _base = new Derived();

			Base[] baseArray = new Base[1];
			Derived[] derivedArray = new Derived[] { new Derived() };

			// array element assignment is covariant
			baseArray[0] = new Derived();
			baseArray[0] = new OtherDerived();

			// Good Lord.  Why does C# allow this?! It's not type-safe
			baseArray = derivedArray;
			baseArray[0] = new Derived();
			// ArrayTypeMismatchException
			baseArray[0] = new OtherDerived();

			// or this?!
			populate(derivedArray);

			// List

			IList<Base> baseList = new List<Base>();
			IList<Derived> derivedList = new List<Derived>();

			// covariant parameter okay
			baseList.Add(new Derived());
			baseList.Add(new OtherDerived());

			derivedList.Add(new Derived());
			// can't add supertype to List

			// can't assign List<Derived> to List<Base>!
			//baseList = derivedList;
			// or the other way around
			//derivedList = baseList;



			// Enumerable

			IEnumerable<Base> bases = new List<Base>();
			IEnumerable<Derived> derived = new List<Derived>();

			// covariant assignment to IEnumerable<Base>
			bases = derived;




		}

	}
}