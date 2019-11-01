using System;

namespace MyExercises
{
    class PriorityQueue
    {
        int[] Queue;
        int Length=0;
        int Capacity;

        public PriorityQueue(int Capacity)
        {
            this.Capacity = Capacity;
            Queue = new int[Capacity];
        }

        public void Add(int value)
        {
            if (Length == Capacity)
                DoubleArray();

            for (int x = Length-1; x >= -1; x--)
            {
                if (x == -1)
                {
                    Queue[0] = value;
                    Length++;
                    return;
                }

                if (value > Queue[x])
                {
                    Queue[x + 1] = value;
                    Length++;
                    return;
                }
                Queue[x + 1] = Queue[x];
                
            }
        }

        public int Remove()
        {
            if (Length == 0)
                return -1;

            return Queue[--Length];
        }

        public void Print()
        {
            for (int x=0; x<Length; x++)
                Console.Write(Queue[x] + ", ");
            Console.WriteLine("");
        }

        private void DoubleArray()
        {
            int[] Queue2 = new int[Capacity * 2];

            for (int x = 0; x < Capacity; x++)
                Queue2[x] = Queue[x];

            Capacity *= 2;

            Queue = Queue2;
        }
    }
}
