using System;
using Variance.Models;

namespace Variance.Examples {
	public class OutExamples {

		void Factory(out Base b) {
			// covariant assignment
			if (DateTime.Now.Year > 2013) {
				b = new Derived();
			} else {
				b = new OtherDerived();
			}
		}

		void FactoryDerived(out Derived d) {
			d = new Derived();
		}

		public void Run() {
			Base b = null;
			Derived d = null;

			Factory(out b);
			//Factory(out d);

			FactoryDerived(out d);
			//FactoryDerived(out b);
	
		}

	}
}