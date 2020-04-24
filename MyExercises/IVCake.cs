using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
using System.Globalization;

namespace MyExercises
{
    public static class IVCake
    {
        /*ARRAYS

            We started off trying to solve the problem in one pass, and we noticed that it wouldn't work. try sorting

            Solve a simpler version of the problem (in this case, reversing the characters instead of the words), 
            and see if that gets us closer to a solution for the original problem.
        */
        public class Meeting
        {
            public int StartTime { get; set; }
            public int EndTime { get; set; }

            public Meeting(int startTime, int endTime)
            {
                // Number of 30 min blocks past 9:00 am
                StartTime = startTime;
                EndTime = endTime;
            }

            public override string ToString()
            {
                return $"({StartTime}, {EndTime})";
            }
        }


        public static void Reverse(char[] arrayOfChars)
        {
            int len = arrayOfChars.Length;
            for(int x=0; x< len; x++)
            {
                if (x > len - x-1)
                    return;
                char temp = arrayOfChars[x];
                arrayOfChars[x] = arrayOfChars[len - x-1];
                arrayOfChars[len - x-1] = temp;
            }
        }


        public static void ReverseSubset(char[] arrayOfChars, int start, int end)
        {
            while(start<end)
            {
                char temp = arrayOfChars[start];
                arrayOfChars[start] = arrayOfChars[end];
                arrayOfChars[end ] = temp;
                start++;
                end--;
            }
        }


        public static void ReverseWords(char[] message)
        {
            Reverse(message);
            int start = 0;
            int end = 0;

            for(int index=0; index<message.Length; index++)
            {
                if(message[index]==' ')
                {
                    end = index-1;

                    ReverseSubset(message, start, end);

                    start = end + 2;
                }
            }
            //reverse last word
            ReverseSubset(message, start, message.Length-1);
        }


        public static int[] MergeArrays(int[] myArray, int[] alicesArray)
        {
            int size = myArray.Length + alicesArray.Length;
            int[] results = new int[size];

            int index1 = 0;
            int index2 = 0;

            for(int x=0; x< size; x++)
            {
                if(index2==alicesArray.Length || (index1 < myArray.Length && myArray[index1]<alicesArray[index2]))
                {
                    results[x] = myArray[index1++];
                }
                else
                {
                    results[x] = alicesArray[index2++];
                }
            }
            return results;
        }


        public static bool IsFirstComeFirstServed(int[] takeOutOrders, int[] dineInOrders, int[] servedOrders)
        {
            int[] placedOrders  = MergeArrays(takeOutOrders, dineInOrders);

            if (servedOrders.Length != placedOrders.Length)
                return false;

            for(int i = 0; i<servedOrders.Length; i++)
            {
                if (placedOrders[i] != servedOrders[i])
                    return false;
            }
            return true;
        }


        /*DICT & HASH

            Using hash-based data structures, like dictionaries or hash sets, is so common in coding challenge solutions, it should always be your first thought. 
            If hash, can we do the testing AS we build the hash instead of building a full hash and then testing on it later?

            Start with a brute force solution, look for repeat work in that solution, and modify it to only do that work once.
        */
        public static bool CanTwoMoviesFillFlight(int[] movieLengths, int flightLength)
        {
            var movieDict = new Dictionary<int, int>();

            foreach(int i in movieLengths)
            {
                if (movieDict.ContainsKey(i))
                    movieDict[i]++;
                else
                    movieDict.Add(i, 1);
            }

            foreach(int i in movieLengths)
            {
                int secondMovie = flightLength - i;                

                if(movieDict.ContainsKey(secondMovie))
                {
                    if (i == secondMovie && movieDict[i] > 1)
                        return true;
                    else if(i!=secondMovie)
                        return true;
                }
            }

            return false;
        }


        public static bool HasPalindromePermutation(string theString)
        {
            var charDict = new Dictionary<char, int>();

            foreach (char c in theString)
            {
                if (charDict.ContainsKey(c))
                    charDict.Remove(c);
                else
                    charDict.Add(c, 1);
            }

            return charDict.Count <= 1;
        }


       public static void PopulateWordsToCounts(string inputString)
       {
           Dictionary<string, int> _wordsToCounts = new Dictionary<string, int>();
           TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
   
           string[] splitChars = {" - ", ",", ".", ":", "!", "?", " ", "..." };
           
           string[] myWords = inputString.Split(splitChars, System.StringSplitOptions.RemoveEmptyEntries);
   
           foreach(string s in myWords)
           {
                if (_wordsToCounts.ContainsKey(s))
                    _wordsToCounts[s]++;
                else if (_wordsToCounts.ContainsKey(myTI.ToTitleCase(s)))
                {
                    _wordsToCounts[myTI.ToTitleCase(s)]++;
                }
                else
                {
                     _wordsToCounts.Add(s, 1);
                }
                    
           }
   
            Console.WriteLine();
       }


        public static int[] SortScores(int[] unorderedScores, int highestPossibleScore)
        {
            int[] orderedScores = new int[highestPossibleScore+1];

            foreach (int score in unorderedScores)
                orderedScores[score]++;

            int index = 0;
            for(int x= orderedScores.Length-1; x>=0;x--)
            {
                while(orderedScores[x]>0)
                {
                    unorderedScores[index++] = x;
                    orderedScores[x]--;
                }
                    
            }

            return unorderedScores;
        }


        /*GREEDY

            Greedy approaches are great because they're fast (usually just one pass through the input). But they don't work for every problem.

            Trying out a greedy approach should be one of the first ways you try to break down a new question. ASK YOURSELF: "Suppose we could come up with the answer in one pass through the input, by simply
            updating the 'best answer so far' as we went. What additional values would we need to keep updated as we looked at each item in our input, in order to be able to update the 'best answer so far' in
            constant time?"

            maybe cant solve in 1 pass, but maybe 2? start by coming up with a slow (but correct) brute force solution and trying to improve from there. We looked at what our solution actually calculated, step by
            step, and found some repeat work. 
        */
        public static int GetMaxProfit(int[] stockPrices)
        {
            if (stockPrices.Length <= 1)
                throw new System.ArgumentException();

            int minSeen = stockPrices[0];
            int bestProfit = int.MinValue;

            for(int x=1; x<stockPrices.Length;x++)
            {
                int currPrice = stockPrices[x];

                if (currPrice - minSeen > bestProfit)
                    bestProfit = currPrice - minSeen;

                if (currPrice < minSeen)
                    minSeen = currPrice;            
            }

            return bestProfit;
        }


        public static int HighestProductOf3(int[] arrayOfInts)
        {
            int largest = int.MinValue, secondLargest = int.MinValue, thridLargest = int.MinValue, smallest = int.MaxValue, secondSmallest = int.MaxValue, thirdSmallest = int.MaxValue,  a, b, c;

            if (arrayOfInts.Length < 3)
                throw new System.ArgumentException();

            if (arrayOfInts.Length == 3)
                return arrayOfInts[0] * arrayOfInts[1] * arrayOfInts[2];

            for(int x=0; x<arrayOfInts.Length; x++)
            {
                int currentInt = arrayOfInts[x];

                if (currentInt >= largest)
                {
                    thridLargest = secondLargest;
                    secondLargest = largest;
                    largest = currentInt;
                }
                else if(currentInt>=secondLargest)
                {
                    thridLargest = secondLargest;
                    secondLargest = currentInt;
                }
                else if(currentInt>=thridLargest)
                {
                    thridLargest = currentInt;
                }

                if(currentInt<=smallest)
                {
                    thirdSmallest = secondSmallest;
                    secondSmallest = smallest;
                    smallest = currentInt;
                }
                else if(currentInt<=secondSmallest)
                {
                    thirdSmallest = secondSmallest;
                    secondSmallest = currentInt;
                }
                else if(currentInt<=thirdSmallest)
                {
                    thirdSmallest = currentInt;
                }
            }

            a = largest * secondLargest * thridLargest;
            b = smallest * secondSmallest * largest;
            c = smallest * secondSmallest * thirdSmallest;
            return Math.Max(Math.Max(a,b),c);
        }


        public static int[] GetProductsOfAllIntsExceptAtIndex(int[] intArray)       //[2,3,4,   5,  6,   7    ,8]
        {                                                                           //[1,2,6,   24, 120, 720,  5040] befores

            if (intArray.Length < 2)
                throw new System.ArgumentException();
            
            int[] befores = new int[intArray.Length];
            befores[0] = 1;
            for(int x=1; x<intArray.Length;x++)
            {
                befores[x] = befores[x - 1] * intArray[x-1];
            }

            int afters = 1;

;           for(int x = intArray.Length-1; x>=0; x--)
            {
                befores[x] = afters * befores[x];
                afters *= intArray[x];
            }

            return befores;
        }












    }
}

