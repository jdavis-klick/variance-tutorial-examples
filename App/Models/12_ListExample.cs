using System;
using System.Collections.Generic;
using Variance.Models;

namespace Variance.Examples {

	public class ListExamples {

		public void Run() {

			// List

			IList<Base> baseList = new List<Base>();
			IList<Derived> derivedList = new List<Derived>();

			// covariant parameter okay
			baseList.Add(new Derived());
			baseList.Add(new OtherDerived());

			derivedList.Add(new Derived());
			// can't add supertype to List
			//derivedList.Add(new Base());

			// List<T> is invariant
			// can't assign List<Derived> to List<Base>!
			//baseList = derivedList;
			// or the other way around
			//derivedList = baseList;


			// Enumerable<T> is covariant

			IEnumerable<Base> bases = new List<Base>();
			IEnumerable<Derived> derived = new List<Derived>();

			// covariant assignment to IEnumerable<Base>
			bases = derived;

		}

	}
}