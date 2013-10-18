using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Variance.Models;

namespace Variance.Examples {
	public class OutExamples {
	
		void AnimalMutator(Lifeform a) {
			a.CommonName = a.CommonName + "!";
		}

		void FrogMutator(Frog f) {
		}

		void AnimalFactory(out Lifeform a) {
			// assigning a more specialized type is okay
			a = new Frog() {
				CommonName = "Enchanted Frog",
				Genus = "Lorem",
				Species = "ipsum"
			};
		}

		void FrogFactory(out Frog a) {
			a = new Frog() {
				CommonName = "Enchanted Frog",
				Genus = "Lorem",
				Species = "ipsum"
			};
			a.IsPoisonous = false;
		}

		Lifeform AnimalFactory (bool tailRequired) {
			// return type is covariant
			if (tailRequired) {
				// returning a more specialized type is okay
				return new Salamander();
			} else {
				return new Frog();
			}
		}


		public void Run() {
			Lifeform a = null;
			Frog f = null;

			AnimalMutator(Zoo.blue_spotted);
			AnimalMutator(new Lifeform());

			FrogMutator(Zoo.poison_frog);
			//FrogMutator(new Amphibian());

			AnimalFactory(out a);
			// can't pass a Derived to method expecting out Base
			// since AnimalFactory does not promise to make only Frogs, the arg might not accept a 
			//AnimalFactory(out f);

			FrogFactory(out f);

			// You can not pass Base to out Derived.  The method is entitled to set properties on Derived
			//FrogFactory(out a);

			// can't pass out Derived to Base, either
			// since AnimalFactory does not promise to make only Frogs
			//AnimalFactory(out f);



			
		}

	}
}