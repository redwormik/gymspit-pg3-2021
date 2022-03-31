using System;
using System.Collections.Generic;


namespace Lecture26
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


	class MyQueue<T>
	{
		private MyNode<T> head = null;
		private MyNode<T> tail = null;


		public bool Empty
		{
			get { return head == null; }
		}


		public T First
		{
			get { return head.value; }
		}


		public T Last
		{
			get { return tail.value; }
		}


		public void Enqueue(T value)
		{
			MyNode <T> node = new MyNode<T>(value);

			if (tail != null) {
				tail.next = node;
			}

			tail = node;

			if (head == null) {
				head = tail;
			}
		}


		public T Dequeue()
		{
			T value = head.value;
			head = head.next;
			return value;
		}
	}


	class Program
	{
		static void Main(string[] args)
		{
			MyQueue<string> playList = new MyQueue<string>();

			Console.WriteLine(playList.Empty);
			// Console.WriteLine(playList.First);
			// Console.WriteLine(playList.Last);

			playList.Enqueue("Bohemian Rhapsody");
			Console.WriteLine("First after Enqueue(\"Bohemian Rhapsody\"): {0}", playList.First);
			Console.WriteLine("Last after Enqueue(\"Bohemian Rhapsody\"): {0}", playList.Last);

			playList.Enqueue("Don't Stop Me Now");
			Console.WriteLine("First after Enqueue(\"Don't Stop Me Now\"): {0}", playList.First);
			Console.WriteLine("Last after Enqueue(\"Don't Stop Me Now\"): {0}", playList.Last);

			playList.Enqueue("Bicycle");
			Console.WriteLine("First after Enqueue(\"Bicycle\"): {0}", playList.First);
			Console.WriteLine("Last after Enqueue(\"Bicycle\"): {0}", playList.Last);

			playList.Enqueue("Under Pressure");
			Console.WriteLine("First after Enqueue(\"Under Pressure\"): {0}", playList.First);
			Console.WriteLine("Last after Enqueue(\"Under Pressure\"): {0}", playList.Last);

			playList.Enqueue("We Will Rock You");
			Console.WriteLine("First after Enqueue(\"We Will Rock You\"): {0}", playList.First);
			Console.WriteLine("Last after Enqueue(\"We Will Rock You\"): {0}", playList.Last);

			Console.WriteLine(playList.Empty);

			Console.WriteLine("Dequeue: {0}", playList.Dequeue());
			Console.WriteLine("First after Dequeue(): {0}", playList.First);
			Console.WriteLine("Last after Dequeue(): {0}", playList.Last);

			Console.WriteLine("Dequeue: {0}", playList.Dequeue());
			Console.WriteLine("First after Dequeue(): {0}", playList.First);
			Console.WriteLine("Last after Dequeue(): {0}", playList.Last);

			Console.WriteLine("Dequeue: {0}", playList.Dequeue());
			Console.WriteLine("First after Dequeue(): {0}", playList.First);
			Console.WriteLine("Last after Dequeue(): {0}", playList.Last);

			playList.Enqueue("We Will Rock You");
			Console.WriteLine("First after Enqueue(\"We Will Rock You\"): {0}", playList.First);
			Console.WriteLine("Last after Enqueue(\"We Will Rock You\"): {0}", playList.Last);

			while (!playList.Empty)
			{
				Console.WriteLine("Dequeue: {0}", playList.Dequeue());
				if (!playList.Empty)
				{
					Console.WriteLine("First after Dequeue(): {0}", playList.First);
					Console.WriteLine("Last after Dequeue(): {0}", playList.Last);
				}
				else
				{
					Console.WriteLine("Empty after Dequeue()!");
				}
			}

			Console.WriteLine(playList.Empty);
			// Console.WriteLine(playList.First);
			// Console.WriteLine(playList.Last);

			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
