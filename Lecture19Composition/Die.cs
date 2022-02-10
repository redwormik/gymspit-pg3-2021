using System;


namespace Lecture19Composition
{
	class Die
	{
		Random random;

		int sides;


		public Die(Random random, int sides)
		{
			if (sides < 1) {
				throw new ArgumentOutOfRangeException();
			}

			this.random = random;
			this.sides = sides;
		}


		public int Roll()
		{
			return random.Next(sides) + 1;
		}


		public int RollMultiple(int count)
		{
			int sum = 0;

			for (int i = 0; i < count; i += 1) {
				sum += Roll();
			}

			return sum;
		}
	}
}
