using System;


namespace Lecture7
{
	// https://docs.microsoft.com/en-us/dotnet/csharp/methods

	class Program
	{
		// https://docs.microsoft.com/en-us/dotnet/csharp/methods#method-signatures
		// Deklarace funkce:
		// - viditelnost (zatím neřešíme)
		// - static (voláme ji samostatně, ne na objektu)
		// - návratový typ nebo void
		// - název (konvence je PascalCase)
		// - parametry (typ + název)
		// - tělo funkce

		// Out a ref parametry:
		// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out
		// https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/ref
		static char ReadOperation(out bool nonZero)
		{
			char input;
			nonZero = false;

			while (true) {
				Console.WriteLine("Choose an operation:");
				Console.WriteLine("+/a/A - addition");
				Console.WriteLine("-/s/S - subtraction");
				Console.WriteLine("*/m/M - multiplication");
				Console.WriteLine("//d/D - division");
				Console.WriteLine("%/r/R - remainder");
				Console.WriteLine("^/e/E - exponentiation");
				Console.WriteLine("q/Q/x/X - quit");
				Console.WriteLine();

				Console.Write("Your choice: ");
				input = Console.ReadKey().KeyChar;
				Console.WriteLine();

				switch (input) {
					case '+':
					case 'a':
					case 'A':
						return '+';
					case '-':
					case 's':
					case 'S':
						return '-';
					case '*':
					case 'm':
					case 'M':
						return '*';
					case '/':
					case 'd':
					case 'D':
						nonZero = true;
						return '/';
					case '%':
					case 'r':
					case 'R':
						nonZero = true;
						return '%';
					case '^':
					case 'e':
					case 'E':
						return '^';
					case 'q':
					case 'Q':
					case 'x':
					case 'X':
						return 'q';
					default:
						Console.WriteLine("Invalid operation!");
						break;
				}
			}
		}


		// Výchozí parametr
		// https://docs.microsoft.com/en-us/dotnet/csharp/methods#optional-parameters-and-arguments
		static double ReadDouble(bool nonZero = false)
		{
			double result;
			bool success;

			do {
				Console.Write("Please input a {0}number: ", nonZero ? "non-zero " : "");
				string input = Console.ReadLine();
				success = double.TryParse(input, out result) && !(nonZero && result == 0.0);
				if (!success) {
					Console.WriteLine("\"{0}\" is not a {1}number!", input, nonZero ? "non-zero " : "");
				}
			} while (!success);

			// Návratová hodnota funkce
			// https://docs.microsoft.com/en-us/dotnet/csharp/methods#return-values
			return result;
		}
		

		static double Compute(char operation, double operand1, double operand2)
		{
			switch (operation) {
				case '+':
					return operand1 + operand2;
				case '-':
					return operand1 - operand2;
				case '*':
					return operand1 * operand2;
				case '/':
					return operand1 / operand2;
				case '%':
					return operand1 % operand2;
				case '^':
					return Math.Pow(operand1, operand2);
				default:
					return Double.NaN;
			}
		}


		static void WriteResult(char operation, double operand1, double operand2, double result)
		{
			Console.WriteLine("{1} {0} {2} = {3}", operation, operand1, operand2, result);
			Console.WriteLine();
		}


		static void Main(string[] args)
		{
			char operation;
			bool nonZero;

			// Volání funkce
			// https://docs.microsoft.com/en-us/dotnet/csharp/methods#method-invocation

			// Proměnné a parametry ve funkci jsou normálně oddělené od zbytku programu
			// Změna hodnoty parametru ve funkci se mimo funkci neprojeví,
			// pokud nepoužiju out/ref (a je to hodnotový typ)
			// https://docs.microsoft.com/en-us/dotnet/csharp/methods#passing-parameters

			do {
				operation = ReadOperation(out nonZero);
				if (operation != 'q') {
					double operand1 = ReadDouble();
					double operand2 = ReadDouble(nonZero);
					double result = Compute(operation, operand1, operand2);
					WriteResult(operation, operand1, operand2, result);
				}
			} while (operation != 'q');

			Console.WriteLine("Press any key...");
			Console.ReadKey();
		}
	}
}
