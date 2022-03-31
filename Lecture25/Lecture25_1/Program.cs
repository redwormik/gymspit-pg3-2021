using System;
using System.Collections.Generic;


namespace Lecture25
{
	class MyNode<T>
	{
		public T value;

		public MyNode<T> next = null;


		public MyNode(T value, MyNode<T> next = null)
		{
			this.value = value;
			this.next = next;
		}
	}


	class MyList<T>
	{
		private MyNode<T> head = null;


		public bool Empty
		{
			get { return head == null; }
		}


		public T First
		{
			get { return head.value; }
		}


		public bool Exists(T value)
		{
			MyNode<T> node = head;

			while (node != null) {
				if (ValueEquals(node.value, value)) {
					return true;
				}

				node = node.next;
			}

			return false;
		}


		public IEnumerable<T> Items()
		{
			MyNode<T> node = head;

			while (node != null) {
				yield return node.value;
				node = node.next;
			}
		}


		public void InsertFirst(T value)
		{
			head = new MyNode<T>(value, head);
		}


		public void RemoveFirst()
		{
			head = head.next;
		}


		private bool ValueEquals(T left, T right)
		{
			return left == null ?
				right == null :
				left.Equals(right);
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			MyList<string> playlist = new MyList<string>();

			Console.WriteLine(playlist.Empty);
			// Console.WriteLine(playlist.First);

			playlist.InsertFirst("How much is the fish?");
			playlist.InsertFirst("Gangnam Style");
			playlist.InsertFirst("Despacito");

			Console.WriteLine(playlist.Empty);
			Console.WriteLine(playlist.First);

			Console.WriteLine(playlist.Exists("How much is the fish?"));
			Console.WriteLine(playlist.Exists("Stánky"));

			foreach (string song in playlist.Items())
			{
				Console.WriteLine(song);
			}

			playlist.RemoveFirst();

			while (!playlist.Empty)
			{
				Console.WriteLine(playlist.First);
				playlist.RemoveFirst();
			}

			Console.WriteLine(playlist.Empty);
			// Console.WriteLine(playlist.First);

			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
