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


		public bool Exists(T value)
		{
			MyNode<T> node = head;

			while (node != null)
			{
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
			while (node != null)
			{
				yield return node.value;
				node = node.next;
			}
		}


		public void InsertFirst(T value)
		{
			head = new MyNode<T>(value, head);

			if (tail == null) {
				tail = head;
			}
		}


		public void InsertLast(T value)
		{
			MyNode <T> node = new MyNode<T>(value);

			if (tail != null)
			{
				tail.next = node;
			}

			tail = node;

			if (head == null)
			{
				head = tail;
			}
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
			MyList<int> numbers = new MyList<int>();

			numbers.InsertLast(1);
			numbers.InsertLast(2);
			numbers.InsertLast(3);

			foreach (int number in numbers.Items())
			{
				Console.WriteLine(number);
			}

			numbers.InsertFirst(0);

			Console.WriteLine(numbers.Exists(2));
			Console.WriteLine(numbers.Exists(4));

			foreach (int number in numbers.Items())
			{
				Console.WriteLine(number);
			}

			numbers.RemoveFirst();

			while (!numbers.Empty)
			{
				Console.WriteLine(numbers.First);
				numbers.RemoveFirst();
			}

			Console.WriteLine(numbers.Empty);
			// Console.WriteLine(numbers.First);

			Console.WriteLine("Press any key to quit...");
			Console.ReadKey();
		}
	}
}
