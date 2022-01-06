using System;


namespace Lecture15
{
	class Animal
	{
		private string species;

		// auto-implemented via property
		// private string name;


		public Animal(string species, string name, string nickname = "")
		{
			Species = species;
			Name = name;
			Nickname = nickname;
		}


		public string Species
		{
			// read-only from the outside
			get {
				return species;
			}
			private set {
				if (value == "" || value == null) {
					throw new ArgumentException();
				}
				species = value;
			}
		}


		public string Name
		{
			// read-only from the outside
			get;
			private set; // cannot have validation here
		}


		public string Nickname
		{
			// read-write from the outside
			get;
			set;
		}


		public string Speak()
		{
			switch (Species) {
				case "dog":
					return "Bark, bark!";
				case "cat":
					return "Meow, meow.";
				default:
					return "What does the " + Species + " say?";
			}
		}


		public bool Call(string name)
		{
			return Name == name;
		}
	}
}
