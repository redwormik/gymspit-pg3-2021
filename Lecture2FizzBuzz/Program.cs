using System;


namespace Lecture2FizzBuzz
{
	class Program
	{
		static void Main(string[] args)
		{
			int max;
			bool success;

			do {
				Console.Write("Please input a positive number: ");
				string input = Console.ReadLine();
				success = int.TryParse(input, out max) && max > 0;
				if (!success) {
					Console.WriteLine("\"{0}\" is not a positive number!", max);
				}
			} while (!success);


			for (int i = 1; i <= max; i += 1) {
				if (i % 3 == 0 && i % 5 == 0) {
					Console.WriteLine("FIZZBUZZ!");
				} else if (i % 3 == 0) {
					Console.WriteLine("Fizz!");
				} else if (i % 5 == 0) {
					Console.WriteLine("Buzz!");
				} else {
					Console.WriteLine(i);
				}
			}

			Console.WriteLine("Press any key...");
			Console.ReadKey();
		}
	}
}
