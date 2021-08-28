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

            int[] xx = { 1, 2,1,3};            //
            int x = getMaximumEatenDishCount(0, xx, 0);

            Console.WriteLine(x);
            Console.ReadLine();
        }


        //FB IV Prep
        private static string rotationalCipher(String input, int rotationFactor)
        {
            string result = "";

            for (int x = 0; x < input.Length; x++)
            {
                int ch = (int)input[x];

                if (ch >= 48 && ch <= 57)
                {
                    int increment = rotationFactor % 10;
                    int baseCh = ch - 48;
                    ch = (baseCh + increment) % 10;
                    ch += 48;
                }
                else if (ch >= 65 && ch <= 90)
                {
                    int increment = rotationFactor % 26;
                    int baseCh = ch - 65;
                    ch = (baseCh + increment) % 26;
                    ch += 65;
                }
                else if (ch >= 97 && ch <= 122)
                {
                    int increment = rotationFactor % 26;
                    int baseCh = ch - 97;
                    ch = (baseCh + increment) % 26;
                    ch += 97;
                }

                result += (char)ch;
            }
            return result;
        }


        private static int[] countSubarrays(int[] arr)
        {
            int[] result = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                //self is 1
                int count = 1;
                int j = i - 1;
                //down
                while (j >= 0)
                {
                    if (arr[j] < arr[i])
                        count++;
                    else if (arr[j] >= arr[i])
                        j = -1;


                    j--;
                }


                //up
                j = i + 1;
                while (j < arr.Length)
                {
                    if (arr[j] < arr[i])
                        count++;
                    else if (arr[j] >= arr[i])
                        j = arr.Length + 1;

                    j++;
                }



                result[i] = count;
            }


            return result;
        }


        private static int numberOfWays(int[] arr, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int x in arr)
            {
                if (dict.ContainsKey(x))
                    dict[x]++;
                else
                    dict.Add(x, 1);
            }

            int count = 0;

            foreach (int x in arr)
            {
                if (dict[x] == 0)
                    continue;

                int pairInt = k - x;

                if (x == pairInt)
                {
                    count += dict[x] - 1;
                }
                else if (dict.ContainsKey(pairInt))
                    count += dict[x] * dict[pairInt];

                dict[x] -= 1;
            }



            return count;
        }

        private static int[] findPositions(int[] arr, int x)
        {
            List<int> position = new List<int>();
            List<int> arr2 = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                position.Add(i + 1);
                arr2.Add(arr[i]);
            }

            List<int> results = new List<int>();

            int iteration = x;
            while (iteration > 0)
            {
                int j;
                if (x < arr2.Count)
                    j = x;
                else
                    j = arr2.Count;

                int max = 0;
                int maxIndex = 0;
                List<int> popped = new List<int>();
                for (int i = 0; i < j; i++)
                {
                    popped.Add(arr2[i]);

                    if (arr2[i] > max)
                    {
                        max = arr2[i];
                        maxIndex = i;
                    }
                }

                results.Add(position[maxIndex]);

                position.RemoveAt(maxIndex);
                popped.RemoveAt(maxIndex);

                arr2.RemoveRange(0, j);
                for (int i = 0; i < popped.Count; i++)
                {
                    int newVal = Math.Max(0, popped[i] - 1);
                    arr2.Add(newVal);

                    int posVal = position[i];
                    position.Add(posVal);
                }

                position.RemoveRange(0, popped.Count);

                iteration--;
            }
            return results.ToArray();
        }


        private static int[] Reverse(int[] data)
        {
            List<int> result = new List<int>();
            Stack<int> stack = new Stack<int>();


            for (int x = 0; x < data.Length; x++)
            {
                if (data[x] % 2 == 1)
                {
                    while (stack.Count > 0)
                        result.Add(stack.Pop());

                    result.Add(data[x]);
                }
                else
                {
                    stack.Push(data[x]);
                }
            }

            while (stack.Count > 0)
                result.Add(stack.Pop());
            return result.ToArray();
        }


        private static int VisibleNodes(BinaryTreeNode root)
        {
            if (root == null)
                return 0;

            int count = 1;
            Queue<BinaryTreeNode> queue = new Queue<BinaryTreeNode>();

            if (root.Left != null)
                queue.Enqueue(root.Left);
            if (root.Right != null)
                queue.Enqueue(root.Right);

            while (queue.Count > 0)
            {
                int len = queue.Count;
                for (int x = 0; x < len; x++)
                {
                    var node = queue.Dequeue();

                    if (node.Left != null)
                        queue.Enqueue(node.Left);
                    if (node.Right != null)
                        queue.Enqueue(node.Right);

                }
                count++;
            }


            return count;
        }


        struct Query
        {
            public int num;
            public char ch;
        }


        private static int[] NodesInSubTree(List<Query> queries, String s)
        {
            int stringLength = s.Length;
            List<int> result = new List<int>();
            Queue<int> nodesToVisit = new Queue<int>();

            foreach(var q in queries)
            {
                int startingNode = q.num;
                char query = q.ch;

                int resultForThisRound = 0;

                nodesToVisit.Enqueue(startingNode);

                while(nodesToVisit.Count>0)
                {
                    int val = nodesToVisit.Dequeue();
                    val--;
                    if (s[val] == query)
                        resultForThisRound++;

                    val++;
                    if (val * 2 < stringLength)
                        nodesToVisit.Enqueue(val * 2);
                    if ((val * 2) + 1 < stringLength+1)
                        nodesToVisit.Enqueue((val * 2) + 1);
                }

                result.Add(resultForThisRound);
            }

            return result.ToArray();
        }


        private static String findEncryptedWord(String s)
        {
            string result = "";
         
            if (s.Length == 0)
                return result;

            int middle = GetMiddle(s);

            result = findEncryptedWord(s, middle);
            return result;
        }


        public static String findEncryptedWord(String s, int middle)
        {
            String result = "";

            if (middle == -1)
                return "";


            result += s[middle];

            String s1 = s.Substring(0, middle);
            result += findEncryptedWord(s1, GetMiddle(s1));

            if(middle+1<s.Length)
            {
                String s2 = s.Substring(middle+1, s.Length-(middle + 1));
                result += findEncryptedWord(s2, GetMiddle(s2));
            }

            return result;
        }

        public static int GetMiddle(String s)
        {
            if (s.Length == 0)
                return -1;
            else if (s.Length % 2 == 1)
                return s.Length / 2;
            else
                return (s.Length / 2) - 1;
        }

        private static int matchingPairs(string s, string t)
        {
            int preMatchingPairs = 0;
            Dictionary<char, int> duplicatesS = new Dictionary<char, int>();
            Dictionary<char, int> misMatchS = new Dictionary<char, int>();
            Dictionary<char, int> misMatchT = new Dictionary<char, int>();

            for (int x = 0; x < s.Length; x++)
            {
                if (s[x] == t[x])
                {
                    preMatchingPairs++;
                    if (duplicatesS.ContainsKey(s[x]))
                        duplicatesS[s[x]]++;
                    else
                        duplicatesS.Add(s[x], 1);
                }
                else
                {
                    if (!misMatchS.ContainsKey(s[x]))
                        misMatchS.Add(s[x], 1);

                    if (!misMatchT.ContainsKey(t[x]))
                        misMatchT.Add(t[x], 1);
                }
            }

            int misMatchPairs = 0;
            foreach(var kvpS in misMatchS)
            {
                if (misMatchT.ContainsKey(kvpS.Key))
                    misMatchPairs++;

                if (misMatchPairs == 2)
                    break;
            }

            bool sDuplicates = false;
            foreach (var kvpS in duplicatesS)
            {
                if(kvpS.Value>=2)
                {
                    sDuplicates = true;
                    break;
                }
            }

            if (misMatchPairs == 0)
            {
                if (sDuplicates)
                    return preMatchingPairs;
                else if(misMatchS.Count==1)
                {
                    return preMatchingPairs-1;
                }
                else if(misMatchS.Count==2)
                {
                    return preMatchingPairs;
                }
                else
                    return preMatchingPairs - 2;
            }
            else if (misMatchPairs == 1)
            {
                if (sDuplicates)
                    return preMatchingPairs;
                else
                    return preMatchingPairs - 1;
            }
            else
            {
                return preMatchingPairs + 2;
            }
        }


        public static long getSecondsRequired(long N, int F, long[] P)
        {
            Array.Sort(P);
            long holes = 0;

            for(int x = 0; x<P.Length-1; x++)
            {
                long toAdd = P[x + 1] - P[x] - 1;
                holes += toAdd;
            }

            holes += N - P[F - 1]-1;
            holes += F;

            return holes;
        }


        public static long getMinCodeEntryTime(int N, int M, int[] C)
        {
            long results = 0;
            int currentValue = 1;

            foreach(int nextnumber in C)
            {
                int up = Math.Abs(nextnumber - currentValue);
                int down = N - up;

                results += Math.Min(up, down);
                currentValue = nextnumber;
            }


            return results;
        }

        public static long getMinCodeEntryTimeDouble(int N, int M, int[] C)
        {
            long results = 0;
            int currentValueA = 1;
            int currentValueB = 1;

            foreach (int nextnumber in C)
            {
                int upA = Math.Abs(nextnumber - currentValueA);
                int downA = N - upA;
                int minA = Math.Min(upA, downA);

                int upB = Math.Abs(nextnumber - currentValueB);
                int downB = N - upB;
                int minB = Math.Min(upB, downB);

                if(minA<=minB)
                {
                    results += (long)minA;
                    currentValueA = nextnumber;
                }
                else
                {
                    results += (long)minB;
                    currentValueB = nextnumber;
                }
            }
            return results;
        }

        public static long getMaxAdditionalDinersCount(long N, long K, int M, long[] S)
        {
            long newDiners = 0;

            Array.Sort(S);

            long numOfSeats;
            long spaceNeeded;
            long possibleDiners;

            numOfSeats = S[0] - 1;
            spaceNeeded = 1 + K;
            possibleDiners = numOfSeats / spaceNeeded;
            newDiners += possibleDiners;


            numOfSeats = N - S[M-1];
            spaceNeeded = 1 + K;
            possibleDiners = numOfSeats / spaceNeeded;
            newDiners += possibleDiners;

            for(int x=0; x<S.Length-1; x++)
            {

                numOfSeats = (S[x + 1]) - (S[x]+K+1);
                if(numOfSeats<0)
                        continue;

                spaceNeeded = 1 + K;
                possibleDiners = numOfSeats / spaceNeeded;
                newDiners += possibleDiners;
            }

            return newDiners;
        }


        public static int getUniformIntegerCountInInterval(long A, long B)
        {
            int result = 0;

            //get first digit
            int firstDigit = int.Parse(A.ToString().Substring(0, 1));


            int digitLoop = firstDigit;
            int powerLoop = 1;
            long currentNumber = 0;

            while (currentNumber<=B)
            {
                
                currentNumber = CreateNumberFromScale(digitLoop, powerLoop);

                if (currentNumber >= A && currentNumber <= B)
                    result++;

                if(digitLoop < 9)
                {
                    digitLoop++;
                }
                else
                {
                    digitLoop = 1;
                    powerLoop++;
                }
            }

            return result;
        }

        static long CreateNumberFromScale(int digit, int power)
        {
            long result = digit;

            int loop = 1;
            while(loop<power)
            {
                result *= 10;
                result += digit;
                loop++;
            }
            return result;
        }

        public static int getMinimumDeflatedDiscCount(int N, int[] R)
        {

            int deflations = 0;

            for(int x=R.Length-1; x>=1; x--)
            {
                if (R[x] < x + 1)
                    return -1;

                if (R[x-1]>=R[x])
                {
                    R[x - 1] = R[x] - 1;
                    deflations++;
                }
            }
            return deflations;
        }


        public static int getMinProblemCount(int N, int[] S)
        {
            int onesTotal = 0;
            int twosTotal = 0;

            foreach(int quiz in S)
            {
                int totalTotal = onesTotal + (twosTotal * 2);
                if(quiz > totalTotal)
                {

                    twosTotal += ((quiz - twosTotal*2) / 2);
                }
                //if (quiz > (onesTotal + (twosTotal * 2)))
                //    onesTotal++;
                if (quiz % 2 == 1)
                    onesTotal=1;

            }


            return onesTotal + twosTotal;

        }

        public static int getMaximumEatenDishCount(int N, int[] D, int K)
        {
            int result = 0;

            HashSet<int> eaten = new HashSet<int>();
      
            for(int x=1; x<=D.Length; x++)
            {
                if (!eaten.Contains(D[x-1]))
                {
                    if (x > K)
                       eaten.Remove(D[x - 1 - K]);
                    eaten.Add(D[x-1]);
                    result++;
                }
            }
            return result;
        }




        /////////////////



        public static int clrd(int input1, int input2)
        {
            float lossRate = 1 - ((float)input1 / 100);
            float years = input2;
            float inversePower = 1 / years;

            double result = Math.Pow(lossRate, inversePower);
            double xxx = (1 - result) * 100;
            
            return (int)xxx;
        }



        static int aaa(string input1)
        {
            string[] individuals = input1.Split('+');

            double result = 0;
            foreach (string i in individuals)
                result += separated(i);

            return (int)Math.Floor(result);
        }


        static double separated(string input1)
        {
            int star = input1.IndexOf('*');
            int d = input1.IndexOf('d');

            int sides = int.Parse(input1.Substring(d + 1, input1.Length - d-1));
            int totalRolls;
            double expected = 1 / sides;

            if (star != -1)
            {
                int people = int.Parse(input1.Substring(0, star));
                int rolls = int.Parse(input1.Substring(star+1, d - star-1));
                totalRolls = people * rolls;
            }
            else
            {
                totalRolls = int.Parse(input1.Substring(0, d));
            }


            double average = (sides + Math.Pow(sides, 2)) / 2 / sides;
            double result = average * totalRolls;


            return result;
        }



        //TopTal
        static int cards(string[] cards)
        {
            Dictionary<string, int> decks =  new Dictionary<string, int>();

            for (int x=0; x<cards.Length; x++)
            {
                string thisCard = cards[x];

                if (decks.ContainsKey(thisCard))
                    decks[thisCard]++;
                else
                    decks.Add(thisCard, 1);
            }

            if (decks.Count < 52)
                return 0;

            return decks.Min(kvp => kvp.Value);
            
        }



        static string words(string[] letters)
        {
            List<string> myLetters = new List<string>();

            for(int x=0; x<letters.Length; x++)
            {
                string thisLetter = letters[x].Substring(0, 1);
                string nextLeter = letters[x].Substring(2, 1);

                if (myLetters.Contains(nextLeter))
                {
                    int index = myLetters.IndexOf(nextLeter);
                    myLetters.Insert(index - 1, thisLetter);

                }
                else
                {
                    myLetters.Add(thisLetter);
                    myLetters.Add(nextLeter);

                }
            }

            string myWord = String.Join("", myLetters);

            return myWord;

        }







    }

}

