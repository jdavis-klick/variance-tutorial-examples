using System;
using Variance.Models;

namespace Variance.Examples {
	public class FunctionExamples {
		Func<Base, bool> IsReady;

		Func<int, Base> baseMaker;

		Action<Base> baseAction;
		Action<Derived> derivedAction;

		public void Run() {
			Func<Base, bool> fBase = (b) => true;
			Func<Derived, bool> fDerived = (d) => true;

			IsReady = fBase;

			// Can't assign Func<Derived,...> to Func<Base,...>
			//IsReady = fDerived;

			// Contravariance
			fDerived = IsReady;

			Func<int, Base> f2Base = (x) => new OtherDerived();
			Func<int, Derived> f2Derived = (x) => new Derived();

			baseMaker = f2Base;

			baseMaker = f2Derived;

			//f2Derived = f2Base;

			//baseAction = derivedAction;
			derivedAction = baseAction;
	

		}
	}
}