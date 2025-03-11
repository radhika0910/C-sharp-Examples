using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    
    public class GenericsPractice
    {
        // Problem 1: Swap Two Values
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        // Problem 2: Generic Stack Class
        public class MyStack<T>
        {
            private List<T> items = new List<T>();

            public void Push(T item)
            {
                items.Add(item);
            }

            public T Pop()
            {
                if (items.Count == 0)
                {
                    throw new InvalidOperationException("Stack is empty.");
                }
                T item = items[items.Count - 1];
                items.RemoveAt(items.Count - 1);
                return item;
            }

            public T Peek()
            {
                if (items.Count == 0)
                {
                    throw new InvalidOperationException("Stack is empty.");
                }
                return items[items.Count - 1];
            }
        }

        // Problem 3: Find Maximum in an Array
        public static T FindMax<T>(T[] array) where T : IComparable<T>
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Array is null or empty.");
            }

            T max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(max) > 0)
                {
                    max = array[i];
                }
            }
            return max;
        }

        // Problem 4: Key-Value Pair Class
        public class KeyValuePair<K, V>
        {
            public K Key { get; set; }
            public V Value { get; set; }

            public void Display()
            {
                Console.WriteLine($"Key: {Key}, Value: {Value}");
            }
        }

        // Problem 5: Generic Method for Sorting an Array
        public static void SortArray<T>(T[] array) where T : IComparable<T>
        {
            Array.Sort(array);
        }

        // Problem 6: Count Occurrences in a List
        public static int CountOccurrences<T>(List<T> list, T item)
        {
            int count = 0;
            foreach (T element in list)
            {
                if (EqualityComparer<T>.Default.Equals(element, item))
                {
                    count++;
                }
            }
            return count;
        }

        public static void Main(string[] args)
        {
            // Problem 1 Test
            int a = 5, b = 10;
            Swap(ref a, ref b);
            Console.WriteLine($"Swapped ints: a={a}, b={b}");

            double c = 1.5, d = 3.7;
            Swap(ref c, ref d);
            Console.WriteLine($"Swapped doubles: c={c}, d={d}");

            string e = "hello", f = "world";
            Swap(ref e, ref f);
            Console.WriteLine($"Swapped strings: e={e}, f={f}");

            // Problem 2 Test
            MyStack<int> intStack = new MyStack<int>();
            intStack.Push(1);
            intStack.Push(2);
            Console.WriteLine($"Popped int: {intStack.Pop()}");

            MyStack<string> stringStack = new MyStack<string>();
            stringStack.Push("apple");
            stringStack.Push("banana");
            Console.WriteLine($"Peeked string: {stringStack.Peek()}");

            // Problem 3 Test
            int[] intArray = { 3, 1, 4, 1, 5, 9 };
            Console.WriteLine($"Max int: {FindMax(intArray)}");

            double[] doubleArray = { 2.7, 1.6, 3.1, 1.4 };
            Console.WriteLine($"Max double: {FindMax(doubleArray)}");

            string[] stringArray2 = { "zebra", "apple", "banana" };
            Console.WriteLine($"Max string: {FindMax(stringArray2)}");

            // Problem 4 Test
            KeyValuePair<string, int> pair = new KeyValuePair<string, int> { Key = "age", Value = 30 };
            pair.Display();

            // Problem 5 Test
            int[] sortIntArray = { 5, 2, 8, 1, 9 };
            SortArray(sortIntArray);
            Console.WriteLine($"Sorted int array: {string.Join(", ", sortIntArray)}");

            string[] sortStringArray = { "zebra", "apple", "banana" };
            SortArray(sortStringArray);
            Console.WriteLine($"Sorted string array: {string.Join(", ", sortStringArray)}");

            // Problem 6 Test
            List<int> intList = new List<int> { 1, 2, 2, 3, 2, 4 };
            Console.WriteLine($"Occurrences of 2: {CountOccurrences(intList, 2)}");
        }
    }
}
