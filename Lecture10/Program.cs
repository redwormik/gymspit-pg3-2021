using System;


namespace Lecture10
{
	class Program
	{
		static int[] GenerateIntArray(int length, int seed, int max)
		{
			Random rng = new Random(seed);
			int[] array = new int[length];
			for (int i = 0; i < array.Length; i++) {
				array[i] = rng.Next(max);
			}
			return array;
		}


		static void PrintIntArray(int[] array)
		{
			foreach (int item in array) {
				Console.WriteLine(item);
			}
			Console.WriteLine();
		}


		static void SelectionSortInt(int[] array)
		{
			for (int i = 0; i < array.Length - 1; i += 1) {
				int minIndex = i;
				int min = array[i];

				for (int j = i + 1; j < array.Length; j += 1) {
					if (array[j] < min) {
						minIndex = j;
						min = array[j];
					}
				}

				if (minIndex != i) {
					int tmp = array[i];
					array[i] = array[minIndex];
					array[minIndex] = tmp;
				}
			}
		}


		static void InsertionSortInt(int[] array)
		{
			for (int i = 1; i < array.Length; i += 1) {
				int key = array[i];
				int j;

				for (j = i; j > 0 && key < array[j - 1]; j -= 1) {
					array[j] = array[j - 1];
				}

				if (j != i) {
					array[j] = key;
				}
			}
		}


		static void BubbleSortInt(int[] array)
		{
			int last = array.Length - 1;
			bool swapped;

			do {
				swapped = false;
				for (int i = 0; i < last; i += 1) {
					if (array[i] > array[i + 1]) {
						int tmp = array[i];
						array[i] = array[i + 1];
						array[i + 1] = tmp;
						swapped = true;
					}
				}

				last -= 1;
			} while (swapped);
		}


		static void Main(string[] args)
		{
			int length = 12;
			int seed = 1811;
			int max = 100;
			int[] array;

			Console.WriteLine("SelectionSort");
			array = GenerateIntArray(length, seed, max);
			PrintIntArray(array);
			SelectionSortInt(array);
			PrintIntArray(array);

			Console.WriteLine("InsertionSort");
			array = GenerateIntArray(length, seed, max);
			PrintIntArray(array);
			InsertionSortInt(array);
			PrintIntArray(array);

			Console.WriteLine("BubbleSort");
			array = GenerateIntArray(length, seed, max);
			PrintIntArray(array);
			BubbleSortInt(array);
			PrintIntArray(array);

			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
