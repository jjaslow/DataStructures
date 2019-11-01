using System;

namespace MyExercises
{
    class Heap
    {

        int[] heap;
        public int HeapSize { get; private set; }

        public Heap(int maxSize)
        {
            heap = new int[maxSize];
            HeapSize = 0;
        }


        public void Insert(int value)
        {
            if (HeapSize == heap.Length)
                throw new Exception("out of space.");

            heap[HeapSize++] = value;
            BubbleUp(HeapSize - 1);
        }

        public int Remove()
        {
            if (HeapSize == 0)
                return 0;

            int ret = heap[0];
            heap[0] = heap[--HeapSize];
            heap[HeapSize] = 0;
            BubbleDown(0);
            return ret;
        }

        private void BubbleUp(int index)
        {
            if (index == 0)
                return;
       
             var parentIndex = (index - 1) / 2;
             if (heap[index] > heap[parentIndex])
             {
                var temp = heap[parentIndex];
                heap[parentIndex] = heap[index];
                heap[index] = temp;
                BubbleUp(parentIndex);
             }
        }

        private void BubbleDown(int index)
        {
            var leftChildIndex = (index * 2) + 1;
            var rightChildIndex = leftChildIndex + 1;

            if (rightChildIndex < HeapSize && heap[index] < heap[rightChildIndex] && heap[rightChildIndex] > heap[leftChildIndex])
            {   //bubble right
                var temp = heap[rightChildIndex];
                heap[rightChildIndex] = heap[index];
                heap[index] = temp;
                BubbleDown(rightChildIndex);
            }
                    
            if (leftChildIndex < HeapSize && heap[index] < heap[leftChildIndex])
            {   //bubble left
                var temp = heap[leftChildIndex];
                heap[leftChildIndex] = heap[index];
                heap[index] = temp;
                BubbleDown(leftChildIndex);
            }
        }



        public static void Heapify(int[] array)
        {
            for(int index=0; index < array.Length; index++)
            {
                Heapify(array, index);
            }
        }


        private static void Heapify(int[] array, int index)
        {
            var leftChildIndex = (index * 2) + 1;
            var rightChildIndex = leftChildIndex + 1;

            if (rightChildIndex < array.Length && array[index] < array[rightChildIndex] && array[rightChildIndex] > array[leftChildIndex])
            {   //bubble right
                var temp = array[rightChildIndex];
                array[rightChildIndex] = array[index];
                array[index] = temp;
                Heapify(array, index + 1);
                Heapify(array, index);
            }

            if (leftChildIndex < array.Length && array[index] < array[leftChildIndex])
            {   //bubble left
                var temp = array[leftChildIndex];
                array[leftChildIndex] = array[index];
                array[index] = temp;
                Heapify(array, index + 1);
                Heapify(array, index);
            }
        }


        public static bool isMaxHeap(int[] array)
        {
            if (array.Length == 0)
                throw new Exception("empty array exception.");

            return isMaxHeap(array, 0);
        }

        private static bool isMaxHeap(int[] array, int index)
        {
            int leftChild = (index * 2) + 1;
            int rightChild = leftChild + 1;

            if (rightChild >= array.Length && leftChild >= array.Length)
                return true;
            else if (rightChild >= array.Length && leftChild < array.Length)
                return isMaxHeap(array, leftChild);


            if (array[index] < array[leftChild] || array[index] < array[rightChild])
                return false;
            else
                return isMaxHeap(array, leftChild) && isMaxHeap(array, rightChild);




        }



    }

}
