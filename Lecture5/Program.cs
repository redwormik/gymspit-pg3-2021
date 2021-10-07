using System;


namespace Lecture5
{
	class Program
	{
		static void Main(string[] args)
		{
			int length = 10;
			// https://docs.microsoft.com/cs-cz/dotnet/api/system.array?view=netframework-4.8
			int[] array = new int[length];
			Random rnd = new Random(1004084313);

			for (int i = 0; i < array.Length; i += 1) {
				array[i] = rnd.Next(-1000, 1001);
			}

			foreach (int item in array) {
				Console.WriteLine(item);
			}
			Console.WriteLine();


			int[] copy = new int[length];
			int mid = length / 2;
			// https://docs.microsoft.com/cs-cz/dotnet/api/system.array.copy?view=netframework-4.8#System_Array_Copy_System_Array_System_Int32_System_Array_System_Int32_System_Int32_
			Array.Copy(array, mid, copy, 0, length - mid);
			Array.Copy(array, 0, copy, length - mid, mid);

			for (int i = 0; i < length; i += 1) {
				Console.WriteLine("{0} {1}", array[i], copy[i]);
			}
			Console.WriteLine();


			// https://docs.microsoft.com/cs-cz/dotnet/api/system.array.sort?view=netframework-4.8#System_Array_Sort_System_Array_
			Array.Sort(copy);
			foreach (int item in copy) {
				Console.WriteLine(item);
			}
			Console.WriteLine();


			https://docs.microsoft.com/cs-cz/dotnet/api/system.array.reverse?view=netframework-4.8#System_Array_Reverse_System_Array_
			Array.Reverse(copy);
			foreach (int item in copy) {
				Console.WriteLine(item);
			}
			Console.WriteLine();


			// https://docs.microsoft.com/cs-cz/dotnet/api/system.array.clear?view=netframework-4.8#System_Array_Clear_System_Array_System_Int32_System_Int32_
			Array.Clear(copy, 4, 2);
			foreach (int item in copy) {
				Console.WriteLine(item);
			}
			Console.WriteLine();


			// https://docs.microsoft.com/cs-cz/dotnet/api/system.array.indexof?view=netframework-4.8#System_Array_IndexOf_System_Array_System_Object_
			Console.WriteLine("Array.IndexOf(copy, 0) = {0}", Array.IndexOf(copy, 0));
			Console.WriteLine("Array.IndexOf(copy, 964) = {0}", Array.IndexOf(copy, 964));
			Console.WriteLine("Array.IndexOf(copy, 760) = {0}", Array.IndexOf(copy, 760));
			Console.WriteLine("Array.IndexOf(copy, 666) = {0}", Array.IndexOf(copy, 666));
			Console.WriteLine();

			// https://docs.microsoft.com/cs-cz/dotnet/api/system.array.lastindexof?view=netframework-4.8#System_Array_LastIndexOf_System_Array_System_Object_
			Console.WriteLine("Array.LastIndexOf(copy, 0) = {0}", Array.LastIndexOf(copy, 0));
			Console.WriteLine("Array.LastIndexOf(copy, 964) = {0}", Array.LastIndexOf(copy, 964));
			Console.WriteLine("Array.LastIndexOf(copy, 760) = {0}", Array.LastIndexOf(copy, 760));
			Console.WriteLine("Array.LastIndexOf(copy, 666) = {0}", Array.LastIndexOf(copy, 666));
			Console.WriteLine();


			// https://docs.microsoft.com/cs-cz/dotnet/api/system.array.resize?view=netframework-4.8#System_Array_Resize__1___0____System_Int32_
			Array.Resize(ref copy, length * 2);
			Console.WriteLine(copy.Length);
			foreach (int item in copy) {
				Console.WriteLine(item);
			}
			Console.WriteLine();

			Array.Resize(ref copy, length / 2);
			Console.WriteLine(copy.Length);
			foreach (int item in copy) {
				Console.WriteLine(item);
			}
			Console.WriteLine();

			// dynamicky rozšiřuju pole podle potřeby
			int initialLength = 1;
			int count = 0;
			string[] list = new string[initialLength];
			string line;

			line = Console.ReadLine();
			while (line != "") {
				if (count == list.Length) {
					Console.WriteLine("Resizing from {0} to {1}!", list.Length, list.Length * 2);
					Array.Resize(ref list, list.Length * 2);
				}

				list[count] = line;
				count += 1;

				line = Console.ReadLine();
			};

			Array.Resize(ref list, count); // zkrátím, abych měl jen "platné" položky
			Array.Sort(list);
			foreach (string item in list) {
				Console.WriteLine(item);
			}
			Console.WriteLine();


			// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays
			// vícerozměrné pole - víc indexů, prvek typu int

			int width = 6;
			int height = 4;
			int[,] matrixA = new int[width, height];
			int[,] matrixB = new int[width, height];
			int[,] matrixSum = new int[width, height];

			for (int y = 0; y < matrixA.GetLength(1); y += 1) {
				for (int x = 0; x < matrixA.GetLength(0); x += 1) {
					matrixA[x, y] = rnd.Next(-9, 10);
				}
			}

			for (int y = 0; y < matrixB.GetLength(1); y += 1) {
				for (int x = 0; x < matrixB.GetLength(0); x += 1) {
					matrixB[x, y] = rnd.Next(-9, 10);
				}
			}

			foreach (int item in matrixA) {
				Console.Write("{0} ", item);
			}
			Console.WriteLine();

			for (int y = 0; y < matrixA.GetLength(1); y += 1) {
				for (int x = 0; x < matrixA.GetLength(0); x += 1) {
					Console.Write("{0} ", matrixA[x, y]);
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			for (int y = 0; y < matrixB.GetLength(1); y += 1) {
				for (int x = 0; x < matrixB.GetLength(0); x += 1) {
					Console.Write("{0} ", matrixB[x, y]);
				}
				Console.WriteLine();
			}
			Console.WriteLine();


			for (int y = 0; y < matrixSum.GetLength(1); y += 1) {
				for (int x = 0; x < matrixSum.GetLength(0); x += 1) {
					matrixSum[x, y] = matrixA[x, y] + matrixB[x, y];
				}
			}

			for (int y = 0; y < matrixSum.GetLength(1); y += 1) {
				for (int x = 0; x < matrixSum.GetLength(0); x += 1) {
					Console.Write("{0} ", matrixSum[x, y]);
				}
				Console.WriteLine();
			}
			Console.WriteLine();


			// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/jagged-arrays
			// pole polí - jednorozměrné pole typu int[]

			int[][] jaggedArray = new int[5][];
			for (int i = 0; i < jaggedArray.Length; i += 1) {
				jaggedArray[i] = new int[4];
				for (int j = 0; j < jaggedArray[i].Length; j += 1) {
					jaggedArray[i][j] = rnd.Next(0, 10);
				}
			}

			for (int i = 0; i < jaggedArray.Length; i += 1) {
				for (int j = 0; j < jaggedArray[i].Length; j += 1) {
					Console.Write("{0} ", jaggedArray[i][j]);
				}
				Console.WriteLine();
			}
			Console.WriteLine();


			for (int i = 0; i < jaggedArray.Length; i += 1) {
				jaggedArray[i] = new int[i + 1];
				for (int j = 0; j < jaggedArray[i].Length; j += 1) {
					jaggedArray[i][j] = rnd.Next(0, 10);
				}
			}

			for (int i = 0; i < jaggedArray.Length; i += 1) {
				for (int j = 0; j < jaggedArray[i].Length; j += 1) {
					Console.Write("{0} ", jaggedArray[i][j]);
				}
				Console.WriteLine();
			}
			Console.WriteLine();


			Console.Write("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
