using System;
using System.IO;


namespace Lecture19Composition
{
	class Game
	{
		private Character characterOne;

		private Character characterTwo;

		private Die die;


		public Game(Character characterOne, Character characterTwo, Die die)
		{
			this.characterOne = characterOne;
			this.characterTwo = characterTwo;
			this.die = die;
		}


		public void Run(TextWriter output)
		{
			Console.WriteLine("Let the games begin!");

			characterOne.Reset();
			characterTwo.Reset();

			Character active = characterOne;
			Character nonActive = characterTwo;

			PrintStatus(output, characterOne);
			PrintStatus(output, characterTwo);
			Console.WriteLine();

			while (characterOne.Alive && characterTwo.Alive) {
				Console.WriteLine("{0}'s turn:", active.Name);
				active.TakeTurn(output, nonActive, die);
				Console.WriteLine();

				PrintStatus(output, characterOne);
				PrintStatus(output, characterTwo);
				Console.WriteLine();

				Character tmp = active;
				active = nonActive;
				nonActive = tmp;
			}

			Console.WriteLine("GAME OVER!");
			if (characterOne.Alive || characterTwo.Alive) {
				Character winner = characterOne.Alive ?
					characterOne :
					characterTwo;
				Console.WriteLine("The winner is {0}!", winner.Name);
			} else {
				Console.WriteLine("Let's call it a draw!");
			}
		}


		private void PrintStatus(TextWriter output, Character character)
		{
			output.WriteLine(
				"{0}: {1}, {2} / {3} HP",
				character.Name,
				character.Alive ? "alive" : "dead",
				character.Hp,
				character.MaxHp
			);
		}
	}
}
