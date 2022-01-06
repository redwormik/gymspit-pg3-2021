using System;


namespace Lecture15
{
	class Engine
	{
		private double kmPerHour;
		private double litersPerKm;


		public Engine(double kmPerHour, double litersPerKm)
		{
			this.kmPerHour = kmPerHour;
			this.litersPerKm = litersPerKm;
		}


		public double Run(double distance, GasTank tank)
		{
			double needed = distance * litersPerKm;
			double used = tank.Use(needed);
			return used / litersPerKm;
		}


		public double Time(double distance)
		{
			return distance / kmPerHour;
		}
	}


	class GasTank
	{
		private double amount = 0;
		private double capacity;


		public GasTank(double capacity)
		{
			this.capacity = capacity;
		}


		public double Amount {
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


	class Car
	{
		private Engine engine;

		private GasTank gasTank;


		public Car(Engine engine, GasTank gasTank)
		{
			this.engine = engine;
			this.gasTank = gasTank;
		}


		public void Tank(double amount)
		{
			gasTank.Add(amount);
		}


		public void Go(double distance)
		{
			double realDistance = engine.Run(distance, gasTank);
			double time = engine.Time(realDistance);
			Console.WriteLine("Went {0} km in {1} hours. {2} liters of gas left.", realDistance, time, gasTank.Amount);
		}
	}
}
