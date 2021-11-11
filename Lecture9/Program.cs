using System;


namespace Lecture9
{
	class Program
	{
		static char[] CreateChars()
		{
			return new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
		}


		static char[] CreateCards()
		{
			char[] chars = CreateChars();
			char[] cards = new char[chars.Length * 2];
			int nextIndex = 0;

			foreach (char c in chars) {
				cards[nextIndex] = c;
				nextIndex += 1;
				cards[nextIndex] = c;
				nextIndex += 1;
			}

			return cards;
		}


		static void ShuffleCards(char[] cards)
		{
			Random rnd = new Random();

			for (int i = 0; i < cards.Length; i += 1) {
				int j = rnd.Next(0, i + 1);
				if (i != j) {
					char tmp = cards[i];
					cards[i] = cards[j];
					cards[j] = tmp;
				}
			}
		}


		static char[,] DealCards(char[] cards)
		{
			int size = (int) Math.Sqrt(cards.Length);
			char[,] board = new char[size, size];

			int row = 0;
			int col = 0;
			foreach (char card in cards) {
				board[row, col] = card;

				col += 1;
				if (col >= board.GetLength(1)) {
					row += 1;
					col = 0;
				}
			}

			return board;
		}


		static void PrintBoard(char[,] board, bool[,] shown)
		{
			for (int row = 0; row < board.GetLength(0); row += 1) {
				for (int col = 0; col < board.GetLength(1); col += 1) {
					Console.Write("{0} ", shown[row, col] ? board[row, col] : '#');
				}

				Console.WriteLine();
			}

			Console.WriteLine();
		}


		static bool AllShown(bool[,] shown)
		{
			foreach (bool b in shown) {
				if (!b) {
					return false;
				}
			}

			return true;
		}


		static int ChooseInt(string label, int min, int max)
		{
			int result;
			bool success;

			do {
				Console.Write("Please input a {0} number ({1} - {2}): ", label, min, max);
				string input = Console.ReadLine();
				success = int.TryParse(input, out result) && result >= min && result <= max;
				if (!success) {
					Console.WriteLine("\"{0}\" is not a number ({0} - {1})!", min, max);
				}
			} while (!success);

			return result;
		}


		static void ChooseCard(bool[,] shown, out int row, out int col)
		{
			bool success;

			do {
				row = ChooseInt("row", 1, shown.GetLength(0)) - 1;
				col = ChooseInt("col", 1, shown.GetLength(1)) - 1;
				success = !shown[row, col];
				if (!success) {
					Console.WriteLine("Card [{0}, {1}] is already shown!", row + 1, col + 1);
				}
			} while (!success);
		}


		static void Main(string[] args)
		{
			char [] cards = CreateCards();
			ShuffleCards(cards);
			char [,] board = DealCards(cards);
			bool [,] shown = new bool[board.GetLength(0), board.GetLength(1)];

			while (!AllShown(shown)) {
				int row1, col1, row2, col2;

				PrintBoard(board, shown);
				ChooseCard(shown, out row1, out col1);
				shown[row1, col1] = true;

				PrintBoard(board, shown);
				ChooseCard(shown, out row2, out col2);
				shown[row2, col2] = true;

				PrintBoard(board, shown);
				if (board[row1, col1] != board[row2, col2]) {
					shown[row1, col1] = false;
					shown[row2, col2] = false;
				}

				Console.Write("Press any key to continue...");
				Console.ReadKey();
				Console.Clear();
			}

			Console.WriteLine("Congratulations!");
			Console.Write("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
