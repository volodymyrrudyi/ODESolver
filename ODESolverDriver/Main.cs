using System;
using ODESolver;

namespace ODESolverDriver
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			BallisticTaskSolver solver = new BallisticTaskSolver();
			solver.solve();
			Console.WriteLine ("Hello World!");
		}
	}
}

