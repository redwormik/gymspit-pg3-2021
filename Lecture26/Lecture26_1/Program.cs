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


	class MyStack<T>
	{
		private MyNode<T> head = null;


		public bool Empty
		{
			get { return head == null; }
		}


		public T Top
		{
			get { return head.value; }
		}


		public void Push(T value)
		{
			head = new MyNode<T>(value, head);
		}


		public T Pop()
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
			MyStack<int> hanoiTower = new MyStack<int>();

			Console.WriteLine(hanoiTower.Empty);
			// Console.WriteLine(hanoiTower.Top);

			hanoiTower.Push(5);
			Console.WriteLine("Top after Push(5): {0}", hanoiTower.Top);

			hanoiTower.Push(4);
			Console.WriteLine("Top after Push(4): {0}", hanoiTower.Top);

			hanoiTower.Push(3);
			Console.WriteLine("Top after Push(3): {0}", hanoiTower.Top);

			hanoiTower.Push(2);
			Console.WriteLine("Top after Push(2): {0}", hanoiTower.Top);

			hanoiTower.Push(1);
			Console.WriteLine("Top after Push(1): {0}", hanoiTower.Top);

			Console.WriteLine(hanoiTower.Empty);

			Console.WriteLine("Pop: {0}", hanoiTower.Pop());
			Console.WriteLine("Top after Pop(): {0}", hanoiTower.Top);

			Console.WriteLine("Pop: {0}", hanoiTower.Pop());
			Console.WriteLine("Top after Pop(): {0}", hanoiTower.Top);

			Console.WriteLine("Pop: {0}", hanoiTower.Pop());
			Console.WriteLine("Top after Pop(): {0}", hanoiTower.Top);

			hanoiTower.Push(1);
			Console.WriteLine("Top after Push(1): {0}", hanoiTower.Top);

			while (!hanoiTower.Empty) {
				Console.WriteLine("Pop: {0}", hanoiTower.Pop());
				if (!hanoiTower.Empty) {
					Console.WriteLine("Top after Pop(): {0}", hanoiTower.Top);
				}
				else {
					Console.WriteLine("Empty after Pop()!");
				}
			}

			Console.WriteLine(hanoiTower.Empty);
			// Console.WriteLine(hanoiTower.Top);

			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
