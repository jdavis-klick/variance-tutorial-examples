using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Variance.Models;

namespace Variance.Examples {

	class ArrayExamples {

		void populate(Base[] bases) {
			bases[0] = new OtherDerived();
		}

		void Run() {
			// Array Covariance
			// http://msdn.microsoft.com/en-us/library/aa664572(v=vs.71).aspx
			/*
			 * For any two reference-types A and B, if an implicit reference conversion (Section 6.1.4) or explicit reference conversion (Section 6.2.3)
			 * exists from A to B, then the same reference conversion also exists from the array type A[R] to the array type B[R], 
			 * where R is any given rank-specifier (but the same for both array types). 
			 * This relationship is known as array covariance. 
			 * Array covariance in particular means that a value of an array type A[R] may actually be a reference to an instance of an array type B[R],
			 * provided an implicit reference conversion exists from B to A.
			 * 
			 * Because of array covariance, assignments to elements of reference type arrays include a run-time check that ensures that the value 
			 * being assigned to the array element is actually of a permitted type (Section 7.13.1).
			 * */

			Base[] baseArray = new Base[1];
			Derived[] derivedArray = new Derived[] { new Derived() };

			// array element assignment is covariant
			baseArray[0] = new Derived();
			baseArray[0] = new OtherDerived();

			// This assignment is not type safe but it is allowed
			baseArray = derivedArray;
			baseArray[0] = new Derived();
			// ArrayTypeMismatchException at RUNTIME
			baseArray[0] = new OtherDerived();

			populate(derivedArray);


		}


	}
}