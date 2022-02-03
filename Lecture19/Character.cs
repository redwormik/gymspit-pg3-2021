using System;
using System.IO;


namespace Lecture19
{
	abstract class Character
	{
		protected const string TURN_CHOICE_ATTACK = "attack";
		protected const string TURN_CHOICE_WAIT = "wait";

		private string name;

		private int hp;
		private int maxHp;

		private int attack;
		private int defense;


		public string Name
		{
			get {
				return name;
			}
		}


		public int Hp
		{
			get {
				return hp;
			}
		}


		public int MaxHp
		{
			get {
				return maxHp;
			}
		}


		public bool Alive
		{
			get {
				return hp > 0;
			}
		}


		protected int Attack
		{
			get {
				return attack;
			}
		}


		protected int Defense
		{
			get {
				return defense;
			}
		}


		protected Character(string name, int maxHp, int attack, int defense)
		{
			this.name = name;
			this.maxHp = maxHp;
			this.attack = attack;
			this.defense = defense;

			Reset();
		}


		public void TakeTurn(TextWriter output, Character enemy, Die die)
		{
			string action = ChooseAction();

			switch (action) {
				case TURN_CHOICE_ATTACK:
					AttackEnemy(output, enemy, die);
					break;

				case TURN_CHOICE_WAIT:
					Wait(output, die);
					break;

				default:
					output.WriteLine("{0} does nothing...", name);
					break;
			}
		}


		public void Reset()
		{
			hp = maxHp;
		}


		protected abstract string ChooseAction();


		private void AttackEnemy(TextWriter output, Character enemy, Die die)
		{
			output.WriteLine("{0} attacks {1}!", name, enemy.Name);
			int attackRoll = attack + die.Roll();
			enemy.ReceiveAttack(output, attackRoll, die);
		}


		private void ReceiveAttack(TextWriter output, int attackRoll, Die die)
		{
			int defenseRoll = defense + die.Roll();
			int damage = attackRoll - defenseRoll;

			if (damage > 0) {
				hp -= damage;
				output.WriteLine("{0} takes {1} damage!", name, damage);
			} else {
				output.WriteLine("{0} takes no damage!", name);
			}
		}


		private void Wait(TextWriter output, Die die)
		{
			output.WriteLine("{0} waits and rolls a die...", name);
			output.WriteLine("They rolled a {0}!", die.Roll());
		}
	}
}
