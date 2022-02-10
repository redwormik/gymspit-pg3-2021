using System;


namespace Lecture19Composition
{
	class Program
	{
		static void Main(string[] args)
		{
			Random random = new Random();

			Character c3PO = new Character(new AI(random), "C-3PO", 15, 6, 4);
			Character r2D2 = new Character(new AI(random), "R2-D2", 10, 7, 5);
			Character luke = new Character(new Player(Console.In, Console.Out), "Luke", 20, 4, 4);

			Game game = new Game(c3PO, r2D2, new Die(random, 6));
			game.Run(Console.Out);
			Console.WriteLine();

			Game game2 = new Game(c3PO, luke, new Die(random, 6));
			game2.Run(Console.Out);
			Console.WriteLine();

			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
