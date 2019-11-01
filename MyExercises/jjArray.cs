using System;

namespace MyExercises
{
    public class jjArray
    {
        public int totalLength;
        public int currLength;
        private int[] items;

        public jjArray(int len)
        {
            totalLength = len;
            items = new int[len];
            currLength = 0;
        }


        public void insert(int a)
        {
            if (currLength >= totalLength)
            {
                int[] items2 = new int[currLength * 2];

                for (int x = 0; x < currLength; x++)
                    items2[x] = items[x];

                totalLength = currLength * 2;

                items = items2;
            }

            items[currLength++] = a;

        }

        public void print()
        {
            for (int x = 0; x < currLength; x++)
                Console.WriteLine(items[x]);
        }


        public void removeAt(int i)
        {
            if(i>=0 && i< currLength)
            {
                for(int x=i; x<currLength-1; x++)
                {
                    items[x] = items[x + 1];
                    
                }
                currLength--;

            }
            else
                Console.WriteLine("no no");

        }

        public int indexOf(int a)
        {

            for (int x=0; x<currLength; x++)
            {
                if (items[x] == a)
                    return x;
            }
            return -1;
            
        }


    }

}
