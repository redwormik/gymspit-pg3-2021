using System;


namespace Lecture11
{
	class Program
	{
		static int Factorial(int n)
		{
			if (n <= 1) { // ukončující podmínka
				return 1;
			}
			return n * Factorial( // volá sám sebe
				n - 1 // s parametrem blíž ukončující podmínce
			);
		}


		static int FactorialIterative(int n)
		{
			int result;
			for (result = 1; n > 1; n -= 1) {
				result *= n;
			}
			return result;
		}


		static int FactorialTail(int n, int acc = 1)
		{
			if (n <= 1) { // ukončující podmínka
				return acc;
			}
			// tail pozice - rovnou vracím, nepotřebuju paměť navíc pro volání
			return FactorialTail( // volá sám sebe
				n - 1, // s parametrem blíž ukončující podmínce
				n * acc
			);
		}


		static int Fibonacci(int n, ref int count)
		{
			count += 1;
			// int id = count;
			// Console.WriteLine("[{1}] Fibonacci({0}):", n, id);
			if (n <= 0) {
				// Console.WriteLine("[{2}] Fibonacci({0}) = {1}", n, 0, id);
				return 0;
			}
			if (n == 1) {
				// Console.WriteLine("[{2}] Fibonacci({0}) = {1}", n, 1, id);
				return 1;
			}
			int result = Fibonacci(n - 1, ref count) + Fibonacci(n - 2, ref count);
			// Console.WriteLine("[{2}] Fibonacci({0}) = {1}", n, result, id);
			return result;
		}


		static int FindMax(int[] array, int left, int right)
		{
			if (left > right) {
				return int.MinValue;
			}
			if (left == right) {
				return array[left];
			}

			int leftMax = FindMax(array, left, (left + right) / 2);
			int rightMax = FindMax(array, (left + right) / 2 + 1, right);
			return rightMax > leftMax ? rightMax : leftMax;
		}


		static int FibonacciIterative(int n)
		{
			int result = 0;
			int next = 1;
			for (int i = 1; i <= n; i += 1) {
				int tmp = result + next;
				result = next;
				next = tmp;
			}
			return result;
		}


		static bool TryEvaluate(out int result)
		{
			string line = Console.ReadLine();
			switch (line) {
				case "+":
				case "-":
				case "*":
				case "/":
					int left, right;
					if (!TryEvaluate(out left) || !TryEvaluate(out right)) {
						result = 0;
						return false;
					}

					switch (line) {
						case "+":
							result = left + right;
							return true;
						case "-":
							result = left - right;
							return true;
						case "*":
							result = left * right;
							return true;
						case "/":
							result = left / right;
							return true;
						default:
							result = 0;
							return false;
					}
				default:
					bool success = int.TryParse(line, out result);
					if (!success) {
						Console.WriteLine("Error reading line \"{0}\"!", line);
					}
					return success;
			}
		}


		static void Main(string[] args)
		{
			Console.WriteLine("Factorial({0}) = {1}", 5, Factorial(5));
			Console.WriteLine("FactorialIterative({0}) = {1}", 5, FactorialIterative(5));
			Console.WriteLine("FactorialTail({0}) = {1}", 5, FactorialTail(5));
			Console.WriteLine();

			int count = 0;
			Console.WriteLine("Fibonacci({0}) = {1}", 10, Fibonacci(10, ref count));
			Console.WriteLine("count = {0}", count);
			Console.WriteLine("FibonacciIterative({0}) = {1}", 10, FibonacciIterative(10));

			int[] array = new int[] { 15, -52, 84, 18, 16, 42, 0, 75, -17, -24 };
			Console.WriteLine("FindMax(array) = {0}", FindMax(array, 0, array.Length - 1));

			int result;
			TryEvaluate(out result);
			Console.WriteLine(result);

			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
