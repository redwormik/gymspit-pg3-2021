using System;


namespace Lecture4
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] array = new int[10];

			// pole se indexuje od 0
			array[0] = 2;
			array[1] = 8;
			array[2] = 32;
			array[3] = 9;
			array[4] = 3;
			array[5] = 14;
			array[6] = 7;
			array[7] = 314;
			array[8] = 256;
			array[9] = 84;

			// prvek array[array.Length] neexistuje
			// při přístupu k neexistujícímu prvku dostanu IndexOutOfRangeException
			for (int i = 0; i < array.Length; i += 1) {
				Console.WriteLine(array[i]);
			}
			Console.WriteLine();


			int size;
			bool success;
			do {
				Console.Write("Please enter the length of the array: ");
				success = int.TryParse(Console.ReadLine(), out size) && size >= 0;
				if (!success) {
					Console.WriteLine("That is not a valid length!");
				}
			} while (!success);

			int[] variableArray = new int[size];

			Console.WriteLine("Length of the array is: {0}", variableArray.Length);

			for (int i = 0; i < variableArray.Length; i += 1) {
				variableArray[i] = (int) Math.Round(Math.Sin(i * Math.PI / 12) * 100);
			}

			for (int i = 0; i < variableArray.Length; i += 1) {
				Console.WriteLine("{0} {1}", i, variableArray[i]);
			}
			Console.WriteLine();

			// Objekt tzpu Random je generátor náhodných čísel
			// Zavolání metody Next vrátí "náhodné" číslo
			// Random generuje čísla pomocí vzorců, do kterých vstupují např. čas systému
			// https://docs.microsoft.com/en-us/dotnet/api/system.random?view=netframework-4.8
			Random rnd = new Random();

			// Random můžu inicializovat s tzv. seedem, pak vrací stejnou sekvenci hodnot
			// Random rnd = new Random(1024);

			Console.WriteLine(rnd.Next()); // 0 <= rnd.Next() < int.MaxValue
			Console.WriteLine(rnd.Next(1000)); // 0 <= rnd.Next(1000) < 1000
											   // rnd.Next(0) == 0
											   // rnd.Next(-1) vyhodí výjimku
			Console.WriteLine(rnd.Next(10, 25)); // 10 <= rnd.Next(10, 25) < 25
												 // rnd.Next(10, 10) == 10
												 // rnd.Next(10, 9) vyhodí výjimku
			Console.WriteLine();

			for (int i = 0; i < variableArray.Length; i += 1) {
				variableArray[i] = rnd.Next(-10000, 10000);
			}

			// nemůžu dát nulu, minimum (maximum) může být větší (menší)
			int min = int.MaxValue; // nebo variableArray[0]
			int max = int.MinValue; // nebo variableArray[0]

			int sum = 0;

			foreach (int item in variableArray) {
				if (item < min) { // každý prvek bude menší než int.MaxValue
					min = item;
				}

				if (item > max) { // každý prvek bude větší než int.MinValue
					max = item;
				}

				sum += item;
			}

			Console.WriteLine("Min: {0}", min);
			Console.WriteLine("Max: {0}", max);
			Console.WriteLine("Sum: {0}", sum);
			Console.WriteLine("Avg: {0}", (double) sum / variableArray.Length);
			Console.WriteLine();


			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
