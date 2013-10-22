using System;
using Variance.Models;

namespace Variance.Examples {
	public class GenericInterfaceExamples {

		// generic interface that does not use in
		interface IFoo<T> {
			void Frob(T obj);
		}

		// generic interface using in
		interface IBar<in T> {
			void Frob(T obj);
		}

		public void Run() {

			IFoo<Base> foo_base = new FooImpl();
			IFoo<Derived> foo_derived = new FooImplD();

			// types match, this is normal case
			foo_derived.Frob(new Derived());
			// not allowed, method has a right to expect T=Derived
			//foo_derived.Frob(new Base());

			// covariance for parameters
			foo_base.Frob(new Derived());

			// Generic Interface is invariant:
			// Neither of these is allowed
			//foo_derived = foo_base;
			//foo_base = foo_derived;

			IBar<Base> bar_base = new BarImpl();
			IBar<Derived> bar_derived = new BarImplD();
	
			bar_derived.Frob(new Derived());
			// not allowed, method has a right to expect T=Derived
			//bar_derived.Frob(new Amphibian());

			// covariance for parameters
			bar_base.Frob(new Derived());

			// variable assignment is contravariant
			bar_derived = bar_base;

			// not allowed
			//bar_base = bar_derived;

		}

		class FooImpl : IFoo<Base> {
			public void Frob (Base b) {
			}
		}

		class FooImplD : IFoo<Derived> {
			public void Frob(Derived b) {
			}
		}

		class BarImpl : IBar<Base> {
			public void Frob(Base b) {
			}
		}

		class BarImplD : IBar<Derived> {
			public void Frob(Derived b) {
			}
		}

	}
}