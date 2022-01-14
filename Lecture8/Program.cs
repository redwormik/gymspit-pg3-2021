using System;


namespace Lecture8
{
	class Program
	{
		static int POPULATION = 10_701_777;


		static string FormatRange(int min = int.MinValue, int max = int.MaxValue)
		{
			string minLabel = min > int.MinValue ? min.ToString() : "";
			string maxLabel = max < int.MaxValue ? max.ToString() : "";
			return minLabel != "" || maxLabel != "" ?
				string.Format(" ({0} - {1})", minLabel, maxLabel) :
				"";
		}


		static char ReadAction()
		{
			Console.WriteLine("a) (A)dd a day value");
			Console.WriteLine("b) add values until a (B)lank line");
			Console.WriteLine("p) (P)rint all data");
			Console.WriteLine("r) print (R)ange of data");
			Console.WriteLine("u) (U)pdate a day value");
			Console.WriteLine("c) (C)lear data");
			Console.WriteLine("f) (F)orecast next data");
			Console.WriteLine("x) e(X)it");
			Console.Write("Please choose an action: ");

			char result = Console.ReadKey().KeyChar;
			Console.WriteLine();
			return char.ToLower(result);
		}


		static bool ParseInt(string input, int min, int max, string rangeLabel, out int result)
		{
			bool success = int.TryParse(input, out result) && result >= min && result <= max;
			if (!success) {
				Console.WriteLine("\"{0}\" is not a number{1}!", input, rangeLabel);
			}
			return success;
		}


		static int ReadInt(string label, int min = int.MinValue, int max = int.MaxValue)
		{
			int result;
			bool success;
			string rangeLabel = FormatRange(min, max);

			do {
				Console.Write("Please input {0}{1}: ", label, rangeLabel);
				string input = Console.ReadLine();
				success = ParseInt(input, min, max, rangeLabel, out result);
			} while (!success);

			return result;
		}


		static void AddValueStatic(int value, int[] data, ref int count)
		{
			data[count] = value;
			count += 1;
		}


		static void AddValueDynamic(int value, ref int[] data, ref int count)
		{
			if (count >= data.Length) {
				Array.Resize(ref data, data.Length * 2);
			}

			data[count] = value;
			count += 1;
		}


		static void AddValue(ref int[] data, ref int count, bool dynamic = true)
		{
			if (!dynamic && count >= data.Length) {
				Console.WriteLine("I'm afraid I can't do that.");
				return;
			}

			int value = ReadInt("a day value", 0);
			if (dynamic) {
				AddValueDynamic(value, ref data, ref count);
			} else {
				AddValueStatic(value, data, ref count);
			}
		}


		static void AddMultipleValues(ref int[] data, ref int count, bool dynamic = true)
		{
			if (!dynamic && count >= data.Length) {
				Console.WriteLine("I'm afraid I can't do that.");
				return;
			}

			string rangeLabel = FormatRange(0);
			string input;

			while (dynamic || count < data.Length) {
				Console.Write("Please input a day value{0} or empty line to end: ", rangeLabel);
				input = Console.ReadLine();
				if (input == "") {
					break;
				}

				int value;
				if (!ParseInt(input, 0, int.MaxValue, rangeLabel, out value)) {
					continue;
				}

				if (dynamic) {
					AddValueDynamic(value, ref data, ref count);
				} else {
					AddValueStatic(value, data, ref count);
				}
			}
		}


		static int SumValues(int[] data, int from, int to)
		{
			int total = 0;
			for (int i = from >= 0 ? from : 0; i <= to; i += 1) {
				total += data[i];
			}
			return total;
		}


		static void PrintData(int[] data, int from, int to)
		{
			if (from > to) {
				Console.WriteLine("I'm afraid I can't do that.");
				return;
			}

			int total = 0;
			int total7 = SumValues(data, from - 6, from - 1);
			int total14 = total7 + SumValues(data, from - 13, from - 7);
			int total7D5 = SumValues(data, from - 11, from - 6);
			int min = from;
			int max = from;

			Console.WriteLine("{0,6} | {1,15} | {2,19} | {3,19} | {4,19}", "Day", "Value", "Simple R", "7-day incidence", "14-day incidence");
			Console.WriteLine(new string('-', 90));

			for (int i = from; i <= to; i += 1) {
				int value = data[i];

				total += value;
				total7 += value;
				total14 += value;
				total7D5 += i >= 5 ? data[i - 5] : 0;
				if (value < data[min]) {
					min = i;
				}
				if (value > data[max]) {
					max = i;
				}

				string simpleR = i >= 11 && total7D5 != 0 ? string.Format("{0,19:N3}", (double) total7 / total7D5) : "N/A";
				string total7Value = i >= 6 ? string.Format("{0,19:N3}", (double) total7 * 100_000 / POPULATION) : "N/A";
				string total14Value = i >= 13 ? string.Format("{0,19:N3}", (double) total14 * 100_000 / POPULATION) : "N/A";
				Console.WriteLine("{0,6} | {1,15:N0} | {2,19} | {3,19} | {4,19}", i + 1, value, simpleR, total7Value, total14Value);

				// "cycle" old values
				total7 -= i >= 6 ? data[i - 6] : 0;
				total14 -= i >= 13 ? data[i - 13] : 0;
				total7D5 -= i >= 11 ? data[i - 11] : 0;
			}

			Console.WriteLine(new string('-', 90));
			Console.WriteLine("{0,6} | {1,15:N0}", "Total", total);
			Console.WriteLine("{0,6} | {1,19:N3}", "Avg", (double) total / (to - from + 1));
			Console.WriteLine("{0,6} | {1,19:N3}", "N/100k", (double) total * 100_000 / POPULATION);
			Console.WriteLine("{0,6} | {1,15:N0} on day {2}", "Min", data[min], min + 1);
			Console.WriteLine("{0,6} | {1,15:N0} on day {2}", "Max", data[max], max + 1);
			Console.WriteLine();
		}


		static void PrintDataRange(int[] data, int count)
		{
			if (count <= 0) {
				Console.WriteLine("I'm afraid I can't do that.");
				return;
			}

			int from = ReadInt("a min day", 1, count);
			int to = ReadInt("a max day", from, count);
			PrintData(data, from - 1, to - 1);
		}


		static void UpdateValue(int[] data, int count)
		{
			if (count <= 0) {
				Console.WriteLine("I'm afraid I can't do that.");
				return;
			}

			int day = ReadInt("a day", 1, count) - 1;
			data[day] = ReadInt(string.Format("a new day value (old is {0})", data[day]), 0);
		}


		static void ClearData(int[] data, ref int count)
		{
			int input = ReadInt("+N to clear last N values, -N to clear first N values or 0 to clear all records", -count, count);

			if (input < 0) {
				for (int i = -input; i < count; i += 1) {
					data[i + input] = data[i];
				}
				count += input;
			} else if (input > 0) {
				count -= input;
			} else {
				count = 0;
			}
		}


		static int[] ForecastSimpleR(int[] data, int count)
		{
			int total7D5 = SumValues(data, count - 12, count - 6);
			if (count < 12 || total7D5 == 0) {
				Console.WriteLine("I'm afraid I can't do that.");
				return new int[0];
			}

			int length = ReadInt("a forecast length", 1);
			int[] forecast = new int[length];
			int total6 = SumValues(data, count - 6, count - 1);
			double simpleR = (double) (data[count - 7] + total6) / total7D5;

			for (int i = 0; i < length; i += 1) {
				total7D5 -= i < 12 ? data[count + i - 12] : forecast[i - 12];
				total7D5 += i < 5 ? data[count + i - 5] : forecast[i - 5];
				forecast[i] = (int) Math.Round(simpleR * total7D5 - total6);
				total6 -= i < 6 ? data[count + i - 6] : forecast[i - 6];
				total6 += forecast[i];
			}
			
			return forecast;
		}


		static int[] ForecastWeeklyRatio(int[] data, int count)
		{
			if (count < 14) {
				Console.WriteLine("I'm afraid I can't do that.");
				return new int[0];
			}

			int length = ReadInt("a forecast length", 1);
			int[] forecast = new int[length];
			for (int i = 0; i < length; i += 1) {
				int weekAgo = i < 7 ? data[count + i - 7] : forecast[i - 7];
				int twoWeeksAgo = i < 14 ? data[count + i - 14] : forecast[i - 14];
				forecast[i] = weekAgo >= 0 && twoWeeksAgo > 0 ?
					(int) Math.Round((float) weekAgo * weekAgo / twoWeeksAgo) :
					-1;
			}

			return forecast;
		}


		static void Forecast(int[] data, int count)
		{
			bool success = false;
			char type;

			do {
				Console.WriteLine("r) forecast by simple (R)");
				Console.WriteLine("w) forecast by (W)eekly ratio");
				Console.Write("Please choose a forecast type: ");

				char result = Console.ReadKey().KeyChar;
				Console.WriteLine();
				type = char.ToLower(result);
				success = type == 'r' || type == 'w';

				if (!success) {
					Console.WriteLine("I'm afraid I can't do that.");
				}
			} while (!success);

			int[] forecast;
			switch (type) {
				case 'r':
					forecast = ForecastSimpleR(data, count);
					break;
				case 'w':
					forecast = ForecastWeeklyRatio(data, count);
					break;
				default:
					return;
			}

			if (forecast.Length == 0) {
				return;
			}

			Console.WriteLine("{0,6} | {1,15}", "Day", "Value");
			Console.WriteLine(new string('-', 24));

			for (int i = 0; i < forecast.Length; i += 1) {
				string value = type == 'w' && forecast[i] < 0 ? "N/A" : string.Format("{0,15:N0}", forecast[i]);
				Console.WriteLine("{0,6} | {1,15}", count + i + 1, value);
			}
			Console.WriteLine();
		}


		static void Main(string[] args)
		{
			int initialLength = 30;
			int count = 0;
			int[] data = new int[initialLength];

			AddValueStatic(16_703, data, ref count);
			AddValueStatic(11_617, data, ref count);
			AddValueStatic(9_496, data, ref count);
			AddValueStatic(8_962, data, ref count);
			AddValueStatic(5_984, data, ref count);
			AddValueStatic(3_741, data, ref count);
			AddValueStatic(8_599, data, ref count);
			AddValueStatic(11_840, data, ref count);
			AddValueStatic(7_692, data, ref count);
			AddValueStatic(7_359, data, ref count);
			AddValueStatic(2_045, data, ref count);
			AddValueStatic(1_089, data, ref count);
			AddValueStatic(2_014, data, ref count);
			AddValueStatic(6_855, data, ref count);
			AddValueStatic(9_078, data, ref count);
			AddValueStatic(6_151, data, ref count);
			AddValueStatic(5_752, data, ref count);
			AddValueStatic(4_995, data, ref count);
			AddValueStatic(1_088, data, ref count);
			AddValueStatic(1_925, data, ref count);
			AddValueStatic(9_339, data, ref count);
			AddValueStatic(10_174, data, ref count);
			AddValueStatic(7_381, data, ref count);
			AddValueStatic(6_636, data, ref count);
			AddValueStatic(6_666, data, ref count);
			AddValueStatic(3_959, data, ref count);
			AddValueStatic(2_763, data, ref count);
			AddValueStatic(7_342, data, ref count);
			AddValueStatic(12_377, data, ref count);
			AddValueStatic(11_452, data, ref count);

			char action = ReadAction();
			while (action != 'x') {
				switch (action) {
					case 'a':
						AddValue(ref data, ref count);
						break;
					case 'b':
						AddMultipleValues(ref data, ref count);
						break;
					case 'p':
						PrintData(data, 0, count - 1);
						break;
					case 'r':
						PrintDataRange(data, count);
						break;
					case 'u':
						UpdateValue(data, count);
						break;
					case 'c':
						ClearData(data, ref count);
						break;
					case 'f':
						Forecast(data, count);
						break;
					default:
						Console.WriteLine("I'm afraid I can't do that.");
						break;
				}
				action = ReadAction();
			}

			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
