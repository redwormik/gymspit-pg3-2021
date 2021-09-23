using System;


namespace Lecture3
{
	class Program
	{
		static void Main(string[] args)
		{
			string input;
			do {
				Console.WriteLine("Enter a text line: ");
				input = Console.ReadLine();
			} while (input.Length < 3);

			// proměnná typu char pro jeden znak
			char literalChar = '@'; // literály se zapisují do apostrofů (')
			char firstChar = input[0]; // můžu číst jeden znak z řetězce, číslují se od nuly
			char thirdChar = input[2];
			char lastChar = input[input.Length - 1];

			Console.WriteLine("'{0}' '{1}' '{2}' '{3}'", literalChar, firstChar, thirdChar, lastChar);

			char inputKey;
			do {
				Console.Write("Press any key: ");
				// ReadKey vrací typ ConsoleKeyInfo,to má vlastnost KeyChar
				// https://docs.microsoft.com/en-us/dotnet/api/system.consolekeyinfo.keychar?view=net-5.0
				inputKey = Console.ReadKey().KeyChar;
				Console.WriteLine();

				// klávesy, co nemají svůj znak, vrací "nulový" znak
				if (inputKey == '\u0000') { // '\u0000' je znak s Unicode číslem 0
					Console.WriteLine("You pressed a special key!");
				} else {
					Console.WriteLine("You pressed: '{0}'", inputKey);
				}

				// dá se použít i ConsoleKeyInfo.Key
				// https://docs.microsoft.com/en-us/dotnet/api/system.consolekeyinfo.key?view=net-5.0
			} while (inputKey != 'x' && inputKey != 'X');


			// break přeruší cyklus
			int result = 0;			// musím proměnné inicializovat
			bool success = false;	// protože kvůli break nemusí dostat hodnotu v cyklu

			do {
				Console.Write("Please input a number: ");
				string numberInput = Console.ReadLine();
				if (numberInput.ToLower() == "exit") {
					break;
				}

				success = int.TryParse(numberInput, out result);
				if (!success) {
					Console.WriteLine("\"{0}\" is not a number!", numberInput);
				}
			} while (!success);
			// break skočí sem

			Console.WriteLine("success = {0}, result = {1}", success, result);


			// continue přeruší iteraci cyklu
			int sum = 0;
			for (int i = 1; i <= 20; i++) {
				if (i % 3 == 0) {
					Console.WriteLine("FIZZ!");
					continue;
				}

				Console.WriteLine(i);
				sum += i;

				// continue skočí sem
			}
			Console.WriteLine("sum = {0}", sum);


			// switch vybere první hodnotu, co odpovídá
			// podobně jako řada if-else
			Console.Write("Choose a color (R/G/B): ");
			char color = Console.ReadKey().KeyChar;
			Console.WriteLine();

			switch (color) {
				case 'R':
					Console.WriteLine("Red");
					break; // každá větev musí končit breakem
				case 'r':
					Console.WriteLine("Red");
					break;

				case 'G': // můžu mít prázdnou větev - propadne do první neprázdné
				case 'g': // chová se podobně jako || v if-u
					Console.WriteLine("Green");
					break;

				case 'B':
				case 'b':
					Console.WriteLine("Blue");
					break;

				default:
					Console.WriteLine("Unknown color!");
					break; // i default musí končit breakem
			}

			Console.Write("Press any key...");
			Console.ReadKey();
		}
	}
}
