using System;


namespace Lecture18
{
	class Car
	{
		// protected je viditelné i v podtřídě
		protected Engine engine;

		protected GasTank gasTank;


		public Car(Engine engine, GasTank gasTank)
		{
			this.engine = engine;
			this.gasTank = gasTank;
		}


		virtual public double LitersPerKm
		{
			get {
				return 2.0 / 100;
			}
		}


		public void Tank(double amount)
		{
			gasTank.Add(amount);
		}


		public virtual void Go(double distance)
		{
			double realDistance = engine.Run(this, distance, gasTank);
			double time = engine.Time(realDistance);
			Console.WriteLine("Went {0} km in {1} hours. {2} liters of gas left.", realDistance, time, gasTank.Amount);
		}
	}
}