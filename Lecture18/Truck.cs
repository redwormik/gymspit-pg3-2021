using System;


namespace Lecture18
{
	class Truck : Car
	{
		private double loadAmount = 0;
		private double capacity;


		public Truck(Engine engine, GasTank gasTank, double capacity) :
			base(engine, gasTank)
		{
			this.capacity = capacity;
		}


		public double LoadAmount
		{
			get {
				return loadAmount;
			}
		}


		public override double LitersPerKm
		{
			get {
				return 3.0 / 100 + loadAmount / 1000;
			}
		}


		public override void Go(double distance)
		{
			base.Go(distance);
			Console.WriteLine("Transported {0} stuff.", loadAmount);
		}


		public void Load(double amount)
		{
			if (amount + loadAmount > capacity) {
				throw new ArgumentException();
			}
			loadAmount += amount;
		}


		public void Unload(double amount)
		{
			if (amount > loadAmount) {
				throw new ArgumentException();
			}
			loadAmount -= amount;
		}
	}
}