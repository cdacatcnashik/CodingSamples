using Finance;
using System;

static class Program
{
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		Type t = args.Length > 1 ? Type.GetType($"Finance.{args[1]},bank") : typeof(PersonalLoan);
		ILoan loan = (ILoan)Activator.CreateInstance(t);
		int m = 10;

		for(int n = 1; n <= m; ++n)
		{
			float r = loan.GetInterestRate(n);
			float i = r / 1200;
			double emi = p * i / (1 - Math.Pow(1 + i, -12 * n));
			Console.WriteLine("{0, -6}{1, 12:0.00}", n, emi);
		}
	}
}
