using System;
namespace ODESolver
{
	// Delegate that rpresents function of ODE
	// arguments[0] - independent variable 't' should always be present 
	public delegate double Function(double[] arguments);
	
	public class RungeKuttaSolver
	{
		#region Fields
		private double step;
		private Function[] functions;
		private double[] initialConditions;
		private double[,] results;
		private bool solved;
		#endregion
		#region Propertiesg
		public double Step
		{
			get
			{
				return step;
			}
			
			set
			{
				step = value;
			}
		}
		
		public Function[] Functions
		{
			get
			{
				return functions;
			}
			
			set
			{
				functions = value;
			}
		}
		
		public double[] InitialConditions
		{
			get
			{
				return initialConditions;
			}
			
			set
			{
				initialConditions = value;
			}
		}
		
		public bool Solved
		{
			get
			{
				return solved;
			}
			
			set
			{
				solved = value;
			}	
		}
		
		public double[,] Results
		{
			get
			{
				if (solved)
				{
					return results;
				} else
				{
					throw new InvalidOperationException();
				}
			}
		}
		
		#endregion
		
		public bool solve()
		{
			
		}
			
		public RungeKuttaSolver ()
		{
		}
	}
}

