using System;
using Variance.Models;

namespace Variance.Examples {
	public class DelegateAssignmentExamples {
		delegate int Foo(Base b);
		delegate int FooDerived(Derived d);

		/*
		 * http://msdn.microsoft.com/en-us/library/aa664603(v=vs.71).aspx
		 * Delegate types in C# are name equivalent, not structurally equivalent. Specifically, two different delegate types that
		 * have the same parameter lists and return type are considered different delegate types.
		 * 
		 * As explained by Eric Lippert:
		 * The reason for non-structural typing is because the delegate definition might have semantics. You shouldn't be able to assign
		 * a "Func" to a "SecureFunc", or a "PureFunc" or a "NoSideEffectsFunc" or whatever. 
		 * In practice, no one actually does make delegate types that have semantics; if we had to do it all over again delegates
		 * would probably be more structurally typed. –  Eric Lippert Dec 17 '10 at 7:19
		 * */

		public void Run() {
			Foo fb;
			FooDerived fd;

			// direct Contravariant assign to fd works fine
			fd = foo_base;

			// but not via a member of type Foo
			fb = foo_base;
			//fd = fb;

		}

		int foo_base(Base b) {
			return 0;
		}

	}
}