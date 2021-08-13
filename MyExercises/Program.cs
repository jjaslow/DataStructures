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
            //int[] arr = new int[] { 1, 2, 8, 9, 12, 16 };

            //BinaryTreeNode a = new BinaryTreeNode(8);
            //BinaryTreeNode b = new BinaryTreeNode(3);
            //BinaryTreeNode c = new BinaryTreeNode(10);
            //BinaryTreeNode d = new BinaryTreeNode(1);
            //BinaryTreeNode e = new BinaryTreeNode(6);
            //BinaryTreeNode f = new BinaryTreeNode(14);
            //BinaryTreeNode g = new BinaryTreeNode(4);
            //BinaryTreeNode h = new BinaryTreeNode(7);
            //BinaryTreeNode i = new BinaryTreeNode(13);
            //a.Left = b;
            //a.Right = c;

            //b.Left = d;
            //b.Right = e;

            //c.Right = f;

            //e.Left = g;
            //e.Right = h;

            //f.Left = i;


            //Query q1 = new Query { num = 1, ch = 'a' };
            //List<Query> q = new List<Query>();
            //q.Add(q1);
            //Console.WriteLine(NodesInSubTree(q, "aba"));

            string r = findEncryptedWord("facebook");
            Console.WriteLine(r);
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

