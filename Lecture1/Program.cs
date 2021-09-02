using System;


namespace Lecture1
{
	class Program
	{
		static void Main(string[] args)
		{
			// Vypiš text do konzole
			Console.WriteLine("Hello, World!");


			Console.WriteLine("What is your name?");

			// deklarace proměnné, načtení vstupu
			string name = Console.ReadLine();
			// To samé jako:
			// string name;
			// name = Console.ReadLine();

			Console.WriteLine("Hello, {0}!", name);
			// To samé jako:
			// Console.WriteLine("Hello, " + name + "!");

			// Když chci složenou závorku, tak ji zdvojím:
			Console.WriteLine("{{0}} {0}", name);
			Console.WriteLine();


			// Typy proměnných

			// int - celé číslo
			int answer = 42;
			int number = 24;

			Console.WriteLine("{0} + {1} = {2}", answer, number, answer + number);
			Console.WriteLine("{0} - {1} = {2}", answer, number, answer - number);
			Console.WriteLine("{0} * {1} = {2}", answer, number, answer * number);
			Console.WriteLine("{0} / {1} = {2}", answer, number, answer / number);

			// float a double - desetinná čísla
			// podobně jako:
			// 3.124 * 10^10 = 31 240 000 000
			// 3.124 * 10^-5 = 0.000 031 24
			float pi = 3.1413f;
			double sqrt2 = 1.415;

			// převod typu:
			// pi = (float) 3.1413;
			// sqrt2 = 1.415f; // implicitní

			Console.WriteLine("{0} * {1} = {2}", sqrt2, sqrt2, sqrt2 * sqrt2);
			// desetinné dělení
			Console.WriteLine("{0} / {1} = {2}", 2, sqrt2, 2 / sqrt2);
			Console.WriteLine("{0} / {1} = {2}", answer, number, (double)answer / number);
			Console.WriteLine();


			// bool - pravda nebo nepravda
			bool isItTrue = true;
			bool isItFalse = false;

			Console.WriteLine("{0}", isItTrue);
			Console.WriteLine("{0}", isItFalse);
			Console.WriteLine();


			// operátory porovnání
			isItTrue = answer == 42;
			Console.WriteLine("{0}", isItTrue);
			Console.WriteLine("{0} == {1}: {2}", answer, number, answer == number);
			Console.WriteLine("{0} != {1}: {2}", answer, number, answer != number);
			Console.WriteLine("{0} < {1}: {2}", answer, number, answer < number);
			Console.WriteLine("{0} > {1}: {2}", answer, number, answer > number);
			Console.WriteLine("{0} <= {1}: {2}", answer, number, answer <= number);
			Console.WriteLine("{0} >= {1}: {2}", answer, number, answer >= number); // => je něco jiného

			Console.WriteLine("{0} < {1}: {2}", answer, 42, answer < 42);
			Console.WriteLine("{0} > {1}: {2}", answer, 42, answer > 42);
			Console.WriteLine("{0} <= {1}: {2}", answer, 42, answer <= 42);
			Console.WriteLine("{0} >= {1}: {2}", answer, 42, answer >= 42);

			Console.WriteLine();

			Console.WriteLine("\"{0}\" == \"{1}\": {2}", name, "", name == "");
			Console.WriteLine("\"{0}\" != \"{1}\": {2}", name, "", name != "");

			Console.WriteLine();


			// logické operátory
			Console.WriteLine("!{0}: {1}", true, !true);
			Console.WriteLine("!{0}: {1}", false, !false);

			Console.WriteLine("{0} && {1}: {2}", true, true, true && true);
			Console.WriteLine("{0} && {1}: {2}", true, false, true && false);
			Console.WriteLine("{0} && {1}: {2}", false, true, false && true);
			Console.WriteLine("{0} && {1}: {2}", false, false, false && false);

			Console.WriteLine("{0} || {1}: {2}", true, true, true || true);
			Console.WriteLine("{0} || {1}: {2}", true, false, true || false);
			Console.WriteLine("{0} || {1}: {2}", false, true, false || true);
			Console.WriteLine("{0} || {1}: {2}", false, false, false || false);


			Console.WriteLine("!({0} || {1}): {2}", true, false, !(true || false));
			Console.WriteLine("!{0} && !{1}: {2}", true, false, !true && !false);

			Console.WriteLine("3 * 2 - 6 == 0 && 3 + 6 / 6 != 1: {0}", 3 * 2 - 6 == 0 && 3 + 6 / 6 != 1);
			Console.WriteLine("3 * (2 - 6) == 0 && (3 + 6) / 6 != 1: {0}", 3 * (2 - 6) == 0 && (3 + 6) / 6 != 1);

			Console.WriteLine();


			Console.Write("Enter a number: ");
			string input = Console.ReadLine();
			int inputInt = int.Parse(input);
			Console.WriteLine("{0} * {1} = {2}", answer, inputInt, answer * inputInt);

			Console.Write("Enter another number: ");
			int inputInt2;
			input = Console.ReadLine();
			// výstupní parametr
			bool success = int.TryParse(input, out inputInt2);

			// podmínka
			if (success) {
				Console.WriteLine("{0} * {1} = {2}", inputInt, inputInt2, inputInt * inputInt2);
			} else {
				Console.WriteLine("That is not a number!");
			}

			// nebo:
			// int inputInt2;
			// if (int.TryParse(Console.ReadLine(), out inputInt2)) {


			// Jinak se program ukončí a nic neuvidíme
			Console.Write("Press any key...");
			Console.ReadKey();
		}
	}
}
