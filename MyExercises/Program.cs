using Lucene.Net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MyExercises
{
    static class Program
    {
        static Queue<int> keysPressed = new Queue<int>(5);

        static void Main(string[] args)
         {

            keysPressed.Enqueue(1);
            keysPressed.Enqueue(2);
            keysPressed.Enqueue(3);
            keysPressed.Enqueue(4);
            keysPressed.Enqueue(5);

            int num;
            Int32.TryParse(string.Join("", keysPressed), out num);

            Console.WriteLine("");
            Console.WriteLine(num/2);
            Console.ReadLine();

        }


        static string[] GetColors()
        {
            return new string[] { "Red", "Green", "Blue", "Orange", "Yellow", "White" };
        }




    }

    public class other
    {
        List<int> myList = new List<int>();

        public List<int> MyList { get => myList;}

        public void AddToList(int x)
        {
            MyList.Add(x);
        }

    }
}

