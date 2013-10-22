using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Variance.Examples;

public class CommandLine {


	public static void Main(string[] args) {

		Console.WriteLine("Simple Examples");
		new SimpleCovarianceExamples().Run();

		try {
			Console.WriteLine("\nArray Examples");
			new ArrayExamples().Run();
		} catch (Exception e) {
			Console.WriteLine(e);
		}

		Console.WriteLine("\nList Examples");
		new ListExamples().Run();

		Console.WriteLine("\nOut Examples");
		new OutExamples().Run();

		Console.WriteLine("\nGeneric Interface Examples");
		new GenericInterfaceExamples().Run();

		Console.WriteLine("\nFunction and Action Examples");
		new FunctionExamples().Run();
		
		Console.WriteLine("\nDelegate Examples");
		new DelegateExamples().Run();


	}





}

