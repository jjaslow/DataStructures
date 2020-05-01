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
        static void Main(string[] args)
         {

            //List<int> a = new List<int> { 9,5,8};
            //int x = HackerRank.sortedSum(a);


            List<long> freq = new List<long> {3,5,4,3 };
            long cc = HackerRank.taskOfPairing(freq);

            Console.WriteLine("");
            Console.WriteLine("xx");
            Console.ReadLine();
            
        }


        static string[] GetColors()
        {
            return new string[] { "Red", "Green", "Blue", "Orange", "Yellow", "White" };
        }

















    }
}

