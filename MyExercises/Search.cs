using System;

namespace MyExercises
{
    class Search
    {
        public static int LinearSearch(int[] list, int value)
        {
            for (int x = 0; x < list.Length; x++)
                if (list[x] == value)
                    return x;

            return -1;

        }


        public static int BinarySearchRecursive(int[] list, int value)
        {
            if (list.Length <= 0)
                return -1;

            int left = 0;
            int right = list.Length - 1;
            return BinarySearchRecursive(list, value, left, right);
        }

        private static int BinarySearchRecursive(int[] list, int value, int left, int right)
        {
            int middle = (left + right) / 2;
            if (list[middle] == value)
                return middle;

            if (left == right)
                return -1;

            if (value < list[middle])
                return BinarySearchRecursive(list, value, left, middle - 1);
            else
                return BinarySearchRecursive(list, value, middle + 1, right);

        }


        public static int BinarySearchIterative(int[] list, int value)
        {
            int left = 0;
            int right = list.Length - 1;

            while (value!=list[(left + right) / 2])
            {
                int middle = (left + right) / 2;

                if (left == right)
                    return -1;

                if (value < list[middle])
                    right = middle - 1;
                else
                    left = middle + 1;

            }

            return (left + right) / 2;
        }


        public static int TernarySearch(int[] list, int value)
        {
            if (list.Length < 1)
                return -1;

            int left = 0;
            int right = list.Length - 1;
            return TernarySearch(list, value, left, right);

        }

        private static int TernarySearch(int[] list, int value, int left, int right)
        {
            int part = (right - left) / 3;
            int seg1 = left + part;
            int seg2 = right - part;

            if (right < left)
                return -1;

            if (list[seg1] == value)
                return seg1;
            if (list[seg2] == value)
                return seg2;


            if(value<list[seg1])
            {
                right = seg1 - 1;
                return TernarySearch(list, value, left, right);
            }
                
            if (value < list[seg2])
            {
                left = seg1+1;
                right = seg2 - 1;
                return TernarySearch(list, value, left, right);
            }

            left = seg2 + 1;
            return TernarySearch(list, value, left, right);

        }


        public static int JumpSearch(int[] list, int value)
        {
            if (list.Length < 1)
                return -1;

            int start = 0;
            int next = (int)Math.Sqrt(list.Length);

            return JumpSearch(list, value, start, next);
        }

        private static int JumpSearch(int[] list, int value, int start, int next)
        {
            if (start > list.Length)
                return -1;

            if (next > list.Length)
                next = list.Length;

            if (value <= list[next - 1])
            {
                for (int x = start; x < next; x++)
                {
                    if (list[x] == value)
                        return x;    
                }
                return -1;

            }


            int increment = next-start;
            start = next;
            next += increment;

            if (start == next)
                return -1;

            return JumpSearch(list, value, start, next);

        }


        public static int ExponentialSearch(int[] list, int value)
        {

            int b=1;

            while (b<list.Length &&  value > list[b])
            {
                b *= 2;
            }

            int right = Math.Min(b, list.Length-1);
            
            return BinarySearchRecursive(list, value, b/2, right);


        }
    }

}

