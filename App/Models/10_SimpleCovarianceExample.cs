using System;
using Variance.Models;

namespace Variance.Examples {

	public class SimpleCovarianceExamples {

		Base foo() {
			return new Derived();
		}

		void bar(Base b) {
			// note that even though b is mutable and the object b is bound to is mutable
			// assignment just changes b, not the object b was bound too.
			b = new OtherDerived();
		}

		public void Run() {

			// simple assignment is covariant
			Base _base = new Derived();

			// as is function return
			_base = foo();

			// and value passed to function
			bar(new Derived());

		}

	}
}