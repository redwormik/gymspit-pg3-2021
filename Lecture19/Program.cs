using System;


namespace Lecture19
{
	class Program
	{
		static void Main(string[] args)
		{
			Random random = new Random();

			Character c3PO = new NPC("C-3PO", 15, 6, 4, random);
			Character r2D2 = new NPC("R2-D2", 10, 7, 5, random);
			Character luke = new Player("Luke", 20, 4, 4, Console.In, Console.Out);

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
