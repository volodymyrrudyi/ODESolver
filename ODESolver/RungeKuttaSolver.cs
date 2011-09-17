using System;
namespace ODESolver
{
	// Delegate that rpresents function of ODE
	// arguments[0] - independent variable 't' should always be present 
	public delegate double Function(double[] arguments);
	
	public class RungeKuttaSolver
	{
		#region Fields
		private Function[] functions;
		private double[] initialConditions;
		private double[,] results;
		private bool solved;
		private double start;
		private double end;
		private int steps;
		#endregion
		#region Propertiess
		public int Steps
		{
			get
			{
				return steps;
			}
			
			set
			{
				steps = value;
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
		
		public double Start
		{
			get
			{
				return start;
			}
			
			set
			{
				start = value;
			}
		}
		
		public double End
		{
			get
			{
				return end;
			}
			
			set
			{
				end = value;
			}
		}

		
		#endregion
		
		public bool solve()
		{
			double [] vars_1;
			double [] vars_2;
			double [] vars_3;
			double [] vars_4;
			
			double [] coeff_1;
			double [] coeff_2;
			double [] coeff_3;
			double [] coeff_4;
			
			if ( this.Functions.Length != this.InitialConditions.Length)
			{
				throw new ArgumentException("Number of initial conditions" +
				 	"and equations must be equal");
			}
			
			this.results = new double[this.functions.Length + 1, this.steps + 1];
			double delta = (end - start) / steps;
			vars_1 = new double[this.Functions.Length + 1];
			vars_2 = new double[this.Functions.Length + 1];
			vars_3 = new double[this.Functions.Length + 1];
			vars_4 = new double[this.Functions.Length + 1];
			
			coeff_1 = new double[this.Functions.Length];
			coeff_2 = new double[this.Functions.Length];
			coeff_3 = new double[this.Functions.Length];
			coeff_4 = new double[this.Functions.Length];
			
			vars_1[0] = start;
			
			for(int k = 0; k < this.Functions.Length - 1; k++)
				vars_1[k+1] = this.InitialConditions[k];
			
			for(int j = 0; j <= this.Functions.Length; j++)
				results[j,0] = vars_1[j];
			
			for(int i = 0; i < steps; i++)
			{
				// First coefficient calculation
				for( int j = 0; j < Functions.Length; j++)
					coeff_1[j] = functions[j](vars_1) * delta;
	
				// Second coefficient calculation
				vars_2[0] = vars_1[0] + delta/2;
				for(int k = 1; k <= this.Functions.Length; k++)
					vars_2[k] = vars_1[k] + coeff_1[k -1]/2;
				for(int j = 0; j < Functions.Length; j++)
					coeff_2[j] = functions[j](vars_2) * delta;
				
				// Third coefficient calculation
				vars_3[0] = vars_1[0] + delta/2;
				for(int k = 1; k <= this.Functions.Length; k++)
					vars_3[k] = vars_1[k] + coeff_2[k -1]/2;
				for(int j = 0; j < Functions.Length; j++)
					coeff_3[j] = functions[j](vars_3) * delta;
				
				// Fourth coefficient calculation
				vars_4[0] = vars_1[0] + delta/2;
				for(int k = 1; k <= this.Functions.Length; k++)
					vars_3[k] = vars_1[k] + coeff_3[k -1]/2;
				for(int j = 0; j < Functions.Length ; j++)
					coeff_4[j] = functions[j](vars_4) * delta;
				
				vars_1[0] = vars_1[0] + delta;
				for (int k = 1; k <= this.Functions.Length; k++)
				{
					vars_1[k] = vars_1[k] + (1/6) * 
						(coeff_1[k-1] + 2*(coeff_2[k-1] + coeff_3[k-1]) + coeff_4[k-1]);
				}
				
				for(int j = 0; j <= this.Functions.Length; j++)
					results[j, i + 1] = vars_1[j];
			}
		
			this.solved = true;
			return true;			
		}
			
		public RungeKuttaSolver ()
		{
		}
	}
}

