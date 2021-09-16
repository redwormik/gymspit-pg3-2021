using System;


namespace Lecture2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Speak, friend and Enter: ");
			string password = Console.ReadLine();

			if (password != "mellon") {
				Console.WriteLine("Wrong password!");
				Console.WriteLine("Press any key...");
				Console.ReadKey();

				// return; // return opustí funkci, v tompto případě Main, takže prokram skončí

				Environment.Exit(1); // ukončí program; 1 znamená, že program skončil chybou
									 // 0 znamená, že program skončil úspěšně
			}

			Console.WriteLine("You may now enter.");


			Console.Write("Please input a negative number: ");
			string input = Console.ReadLine();
			int result;
			bool success = int.TryParse(input, out result);

			// Cyklus while provádí příkazy, dokud podmínka platí
			// Pokud podmínka neplatí, neprovede se ani jednou
			while (!(success && result < 0)) {
			// while (!success || result >= 0) {
				// Pokud chci vypsat uvozovku ("), dám před ni zpětné lomítko (\)
				Console.WriteLine("\"{0}\" is not a negative number!", input);

				Console.Write("Please input a negative number: ");
				input = Console.ReadLine();
				// Musím měnit proměnné v podmínce, jinak se zacyklím!
				// int.TryParse(input, out result); (bez success) by skončil v nekonečné smyčce
				success = int.TryParse(input, out result);
			}

			Console.WriteLine("You entered: {0}", result);


			// Cyklus do while provádí příkazy, dokud podmínka platí,
			// ale vyhodnocuje ji až po provedení příkazů
			// Pokud podmínka neplatí, jednou se provede

			bool success2;
			int result2;

			do {
				Console.Write("Please input a positive number: ");
				// Nemůžu deklarovat novou proměnnou "input" - název už se používá
				string input2 = Console.ReadLine();
				// Název proměnné platí mezi nejbližšími složenými závorkami {}
				success2 = int.TryParse(input2, out result2) && result2 > 0;

				if (!success2) {
					Console.WriteLine("\"{0}\" is not a positive number!", input2);
				}
			} while (!success2); // input2 tady neexistuje

			Console.WriteLine("You entered: {0}", result2);


			// if - else if - else můžu "řetězit" za sebou
			if (-result < result2) {
				Console.WriteLine("{0} < {1}", -result, result2);
			} else if (-result > result2) {
				Console.WriteLine("{0} > {1}", -result, result2);
			} else {
				Console.WriteLine("{0} == {1}", -result, result2);
			}


			// for (incializece; podmínka; příkaz)
			//  - inicializace se provede na začátku
			//  - podmínka se kontroluje před každou iterací
			//  - příkaz se provede po každé iteraci (před dalším vyhodnocením podmínky)

			// a += b je to samé jako a = a + b
			// (podobně a -= b, a *= b, a /= b, ...)
			// a += 1 se dá zkrátit na a++, resp. ++a
			// a -= 1 se dá zkrátit na a--, resp. --a
			int sum = 0;
			for (int i = 1; i <= 10; i += 1) {
				sum += i;
				Console.WriteLine("i={0}, sum={1}", i, sum);
			}

			Console.WriteLine("Sum is: {0}", sum);

			// To samé pomocí while:
			int sum2 = 0;
			// nový blok, ohraničuje platnost i
			// jinak by i kolidovalo s i ve for-cyklu
			{
				int i = 1;
				while (i <= 10) {
					sum2 += i;
					Console.WriteLine("i={0}, sum={1}", i, sum2);
					i += 1;
				}
			}

			Console.WriteLine("Sum is: {0}", sum2);


			Console.WriteLine("Press any key...");
			Console.ReadKey();
		}
	}
}
