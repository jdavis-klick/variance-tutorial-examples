using System;
using Variance.Models;

namespace Variance.Examples {
	public class DelegateExamples {
		delegate int Foo(Base b);
		delegate int FooDerived(Derived d);

		delegate Base BaseMaker();
		delegate Derived DerivedMaker();

		public void Run() {
			Foo fb;
			FooDerived fd;
			
			// lambda assignment
			fb = (b) => 0;

			fb = foo_base;
			//fb = foo_derived;

			// contravariant read
			fd = (b) => 0;
			fd = foo_derived;
			fd = foo_base;

			// covariant write
			BaseMaker bm;
			DerivedMaker dm;

			bm = () => new Base();
			dm = () => new Derived();


			bm = () => new OtherDerived();
			//dm = () => new Base();


		}

		

		int foo_base(Base b) {
			return 0;
		}

		int foo_derived(Derived d) {
			return 0;
		}
	}
}