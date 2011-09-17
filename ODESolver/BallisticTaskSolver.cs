using System;

namespace ODESolver
{
	public class BallisticTaskSolver
	{
		private RungeKuttaSolver solver = new RungeKuttaSolver();
		
		public double f(double[] arguments)
		{
			return 4 * Math.Pow(arguments[0], 3); 
		}
		
		public void solve()
		{
			
			Function []funcs = new Function[1];
			funcs[0] = f;
			solver.Functions = funcs;
			solver.Start = 0;
			solver.End = 10;
			double [] conds = new double[1];
			conds[0] = 0;
			solver.InitialConditions = conds;
			solver.Steps = 10;
			solver.solve();
			
			for(int i =0 ; i <= 10; i++)
			{
				System.Console.WriteLine("{0}\t{1}", solver.Results[0, i],
				                         solver.Results[1,i]);
			}
			
			
		}
		
		public BallisticTaskSolver ()
		{
			
		}
	}
}

