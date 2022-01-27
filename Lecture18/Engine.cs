using System;


namespace Lecture18
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


		public double Run(Car car, double distance, GasTank tank)
		{
			double litersPerKm = this.litersPerKm + car.LitersPerKm;
			double needed = distance * litersPerKm;
			double used = tank.Use(needed);
			return used / litersPerKm;
		}


		public double Time(double distance)
		{
			return distance / kmPerHour;
		}
	}
}