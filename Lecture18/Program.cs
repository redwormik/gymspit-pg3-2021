using System;


namespace Lecture18
{
	class Program
	{
		static void Main(string[] args)
		{
			Car car = new Car(new Engine(150, 5.0 / 100), new GasTank(40.0));
			car.Tank(40.0);
			car.Go(500);

			Truck truck = new Truck(
				new Engine(100, 10.0 / 100),
				new GasTank(100.0),
				20.0
			);
			truck.Load(20.0);
			truck.Tank(100.0);
			truck.Go(250);
			truck.Unload(10.0);
			truck.Go(250);
			truck.Unload(10.0);
			truck.Go(250);

			Car[] fleet = { car, truck };

			foreach (Car fleetCar in fleet) {
				// fleetCar.load(20);
				if (fleetCar is Truck fleetTruck) {
					fleetTruck.Load(20);
				}
				fleetCar.Tank(60.0);
				fleetCar.Go(250);
			}

			Console.ReadKey();
		}
	}
}
