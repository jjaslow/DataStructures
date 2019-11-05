using Lucene.Net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExercises
{
    class Program
    {
        static void Main(string[] args)
        {    //                                 #         #     
            //            0 1 2 3 4 5 6  7  8
            int[] List = {1,2,3,5,6,7,8, 9, 10,120};

            Console.WriteLine(Search.JumpSearch(List, 100));
            
            

            Console.ReadLine();



        }

 
    
    }



}

