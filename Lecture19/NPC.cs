using System;


namespace Lecture19
{
	class NPC : Character
	{
		private Random random;


		public NPC(string name, int maxHp, int attack, int defense, Random random):
			base(name, maxHp, attack, defense)
		{
			this.random = random;
		}


		protected override string ChooseAction()
		{
			string[] choices = new string[] {
				TURN_CHOICE_ATTACK,
				TURN_CHOICE_ATTACK,
				TURN_CHOICE_WAIT,
			};

			return choices[this.random.Next(choices.Length)];
		}
	}
}
