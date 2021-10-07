using System;


namespace Lecture4Sieve
{
	class Program
	{
		static void Main(string[] args)
		{
			// Eratosthenovo síto
			
			// 1) načtu maximum, kam až chci počítat
			int max;
			bool success;

			do {
				Console.WriteLine("Please enter a maximum number:");
				success = int.TryParse(Console.ReadLine(), out max) && max > 0;
				if (!success) {
					Console.WriteLine("That's not a number!");
				}
			} while (!success);


			// 2) vytvořím tak velké pole typu bool[], nastavím všechny hodnoty na true
			bool[] isPrime = new bool[max - 1];
			for (int i = 0; i < isPrime.Length; i += 1) {
				isPrime[i] = true;
			}

			// 3) pro každé i >= 2, i * i <= maximum,
			//        pokud je hodnota v poli true,
			//            nastavím pro všechny násobky hodnotu v poli na false
			for (int i = 2; i * i <= max; i += 1) {
				if (isPrime[i - 2]) {
					for (int j = i * i; j <= max; j += i) {
						isPrime[j - 2] = false;
					}
				}
			}

			// 4) vypíšu čísla, pro která v poli zůstalo true
			for (int i = 2; i <= max; i += 1) {
				if (isPrime[i - 2]) {
					Console.WriteLine(i);
				}
			}


			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
