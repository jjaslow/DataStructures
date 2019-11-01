namespace MyExercises
{
    class Sort 
    {

        public static void BubbleSort(int[] array)
        {
            bool loop = true;

            while(loop)
            {
                loop = false;
                for (int x = 0; x < array.Length - 1; x++)
                {
                    if (array[x] > array[x + 1])
                    {
                        Swap(array, x, x+1);
                        loop = true;
                    }
                }
            }
        }

        public static void SelectionSort(int[] array)
        {
            for (int x = 0; x < array.Length; x++)
            {
                int minIndex = FindMinIndex(array, x, array.Length);
                Swap(array, x, minIndex);
            }
        }

        public static void InsertionSort(int[] array)
        {
            for(int x=0; x<array.Length; x++)
            {
                int temp = array[x];
                int y=x;

                for(y=x; y>0; y--)
                {
                    if(temp<array[y-1])
                        array[y]=array[y-1];
                    else
                        break;
                }

                array[y]=temp;
            }

        }




        private static void Swap(int[] array, int x, int y)
        {
            int temp = array[y];
            array[y] = array[x];
            array[x] = temp;
        }

    
        private static int FindMinIndex(int[] array, int start, int end)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for(int x=start; x<end; x++)
            {
                if (array[x] < min)
                {
                    min = array[x];
                    minIndex = x;
                }
                
            }

            return minIndex;
        }
    
    
    
    }




}

