using System;


namespace Lecture18
{
	class GasTank
	{
		private double amount = 0;
		private double capacity;


		public GasTank(double capacity)
		{
			this.capacity = capacity;
		}


		public double Amount
		{
			get {
				return amount;
			}
		}


		public void Add(double amount)
		{
			this.amount = Math.Min(this.amount + amount, capacity);
		}


		public double Use(double amount)
		{
			if (amount > this.amount) {
				double current = this.amount;
				this.amount = 0;
				return current;
			}
			this.amount = this.amount - amount;
			return amount;
		}
	}
}

