using System;
using System.IO;


namespace Lecture13
{
	class CustomException : Exception
	{
		public CustomException(string message) : base(message)
		{
		}
	}


	// https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/
	// https://docs.microsoft.com/en-us/dotnet/api/system.exception?view=net-6.0
	class Program
	{
		static void Input(out int a, out int b)
		{
			while (true) {
				string input = "";

				try {
					Console.Write("Enter a: ");
					a = int.Parse(input = Console.ReadLine());
					Console.Write("Enter b: ");
					b = int.Parse(input = Console.ReadLine());

					// pokud se program dostane sem, tak se čtení podařilo
					break;
				} catch (FormatException) {
					Console.WriteLine("Invalid input: {0}", input);
				}
			}
		}


		static int Div(int a, int b)
		{
			if (b == 1) {
				throw new ArgumentException("Why do you divide by one?");
			}
			return a / b;
		}


		static void Compute(int a, int b)
		{
			try {
				int result = Div(a, b);
				Console.WriteLine("{0} / {1} = {2}", a, b, result);
			} catch (DivideByZeroException e) {
				Console.WriteLine("Cannot divide by zero!");
				Console.WriteLine(e.StackTrace);
			} catch (Exception) {
				Console.WriteLine("Another exception happened!");
				throw;
			} finally {
				Console.WriteLine("Finally, it's over!");
			}
		}


		static int D6(int last, Random rnd)
		{
			int result = rnd.Next(1, 7);
			if (result == last) {
				throw new CustomException("Go to jail!");
			}
			return result;
		}


		static int CastDice(int num, Random rnd)
		{
			int sum = 0;
			int last = 0;

			try {
				for (int i = 0; i < num; i += 1) {
					last = D6(last, rnd);
					sum += last;

					if (sum > 21) {
						Console.WriteLine("Bust!");
						return -1;
					}
				}
			} finally {
				Console.WriteLine("Good luck next time!");
			}

			return sum;
		}


		static void Game(int a, Random rnd)
		{
			try {
				int result = CastDice(a, rnd);
				Console.WriteLine("Your result: {0}", result);
			} catch (CustomException e) {
				Console.WriteLine(e.Message);
			}
		}


		static string[] ReadLines(TextReader reader)
		{
			string[] lines = new string[10];
			int count = 0;
			string line;

			while ((line = reader.ReadLine()) != null) {
				if (count >= lines.Length) {
					Array.Resize(ref lines, lines.Length * 2);
				}
				lines[count] = line;
				count += 1;
			}

			Array.Resize(ref lines, count);
			return lines;
		}


		private static void ReadFile(string baseDir)
		{
			Console.Write("Enter a file name: ");
			string fileName = Console.ReadLine();
			string[] lines;

			try {
				using (TextReader reader = new StreamReader(baseDir + fileName)) {
					lines = ReadLines(reader);
				}
			} catch (FileNotFoundException) {
				Console.WriteLine("File not found!");
				return;
			}

			Console.WriteLine("{0} lines successfully read", lines.Length);

			int line = -1;
			while (line != 0) {
				Console.Write("Enter a line number (0 to quit): ");
				string input = "";
				try {
					line = int.Parse(input = Console.ReadLine());
				} catch (FormatException) {
					Console.WriteLine("Invalid input: {0}", input);
					continue;
				}

				if (line != 0) {
					try {
						Console.WriteLine(lines[line - 1]);
					} catch (IndexOutOfRangeException) {
						Console.WriteLine("{0} is out of range!", line);
					}
				}
			}
		}


		static void Main(string[] args)
		{
			int a, b;

			Input(out a, out b);
			Compute(a, b);

			Game(a, new Random());

			ReadFile(@"..\..\");

			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
