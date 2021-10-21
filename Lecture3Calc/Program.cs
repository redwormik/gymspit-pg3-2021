using System;


namespace Lecture3Calc
{
	class Program
	{
		static void Main(string[] args)
		{
			bool exit = false;

			do {
				double operand1, operand2, result;
				char operation;
				bool success, nonZero = false;

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
				operation = Console.ReadKey().KeyChar;
				Console.WriteLine();

				switch (operation) {
					case '+':
					case 'a':
					case 'A':
						operation = '+';
						break;
					case '-':
					case 's':
					case 'S':
						operation = '-';
						break;
					case '*':
					case 'm':
					case 'M':
						operation = '*';
						break;
					case '/':
					case 'd':
					case 'D':
						operation = '/';
						nonZero = true;
						break;
					case '%':
					case 'r':
					case 'R':
						operation = '%';
						nonZero = true;
						break;
					case '^':
					case 'e':
					case 'E':
						operation = '^';
						break;
					case 'q':
					case 'Q':
					case 'x':
					case 'X':
						operation = '\0';
						exit = true;
						break;
					default:
						operation = '\0';
						Console.WriteLine("Invalid operation!");
						break;
				}

				if (operation == '\0') {
					continue;
				}

				do {
					Console.Write("Please input a number: ");
					string input = Console.ReadLine();
					success = double.TryParse(input, out operand1);
					if (!success) {
						Console.WriteLine("\"{0}\" is not a number!", input);
					}
				} while (!success);

				do {
					Console.Write("Please input a {0}number: ", nonZero ? "non-zero " : "");
					string input = Console.ReadLine();
					success = double.TryParse(input, out operand2) && !(nonZero && operand2 == 0.0);
					if (!success) {
						Console.WriteLine("\"{0}\" is not a {1}number!", input, nonZero ? "non-zero " : "");
					}
				} while (!success);


				switch (operation) {
					case '+':
						result = operand1 + operand2;
						break;
					case '-':
						result = operand1 - operand2;
						break;
					case '*':
						result = operand1 * operand2;
						break;
					case '/':
						result = operand1 / operand2;
						break;
					case '%':
						result = operand1 % operand2;
						break;
					case '^':
						result = Math.Pow(operand1, operand2);		
						break;
					default:
						// should not happen
						result = 0.0;
						break;
				}

				Console.WriteLine("{1} {0} {2} = {3}", operation, operand1, operand2, result);
				Console.WriteLine();
			} while (!exit);

			Console.WriteLine("Press any key...");
			Console.ReadKey();
		}
	}
}
