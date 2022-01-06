// https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/
// https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/objects
// https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/classes
// https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/tutorials/oop
// https://docs.microsoft.com/en-us/dotnet/csharp/properties
using System;


namespace Lecture15
{
	class Program
	{
		static void Main(string[] args)
		{
			Animal joe = new Animal("dog", "Joe");
			Animal bob = new Animal("cat", "Bob", "Garfield");
			Animal alfred = new Animal("hedgehog", "Alfred");
			// Animal unknown = new Animal("", "Alfred");
			// joe.Species = "catdog";

			Console.WriteLine(joe.Speak());
			Console.WriteLine(bob.Speak());
			Console.WriteLine(alfred.Speak());

			Console.WriteLine(joe.Call("Joe") ? "Comes over" : "Does nothing");
			Console.WriteLine(bob.Call("Joe") ? "Comes over" : "Does nothing");

			Console.WriteLine(alfred.Species);
			// alfred.Species = "mole";

			Console.WriteLine(bob.Nickname);
			bob.Nickname = "Bobby";
			Console.WriteLine(bob.Nickname);

			Console.WriteLine("Skoda:");
			Car skoda = new Car(new Engine(90, 10.0 / 100), new GasTank(25));
			skoda.Tank(15);
			skoda.Go(25);
			skoda.Tank(15);
			skoda.Go(275);

			Console.WriteLine("Felicie:");
			Car felicie = new Car(new Engine(130, 7.0 / 100), new GasTank(40));
			felicie.Tank(20);
			felicie.Go(200);
			felicie.Tank(20);
			felicie.Go(300);
			felicie.Go(300);

			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
