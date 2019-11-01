using System;
using System.Collections.Generic;
using System.Linq;

namespace MyExercises
{
    class ArrayQueue
    {
        int[] items;
        int Front, Rear, Capacity = 0;

        public ArrayQueue(int capacity)
        {
            items = new int[capacity];
            this.Capacity = capacity;
        }

        public void Enqueue(int item)
        {
            if (IsFull())
                throw new System.Exception("Queue is Full.");

            Capacity--;
            items[Rear] = item;
            Rear = (Rear + 1) % 5;
        }

        public int Dequeue()
        {
            int temp = items[Front];
            items[Front] = 0;
            Capacity++;
            Front = (Front + 1) % 5;
            return items[Front];
        }

        public int Peek()
        {
            return items[Front];
        }

        public bool IsEmpty()
        {
            return Front == Rear;
        }

        public bool IsFull()
        {
            return Capacity == 0;
        }

        public void Print()
        {
            Console.Write('[');
            for (int x= 0; x < items.Length - 1; x++)
            {
                Console.Write(items[x] + ", ");
            }
            Console.Write(items[items.Length - 1]);
            Console.Write(']');
            Console.WriteLine("");
        }


        public static void Reverse(Queue<int> queue)
        {
            int count = queue.Count();
            int[] arr = new int[count];

            for (int x = queue.Count; x > 0; x--)
                arr[x - 1] = queue.Dequeue();

            for (int x = 0; x < count; x++)
                queue.Enqueue(arr[x]);

        }

    }
}
