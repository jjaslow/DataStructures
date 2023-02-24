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

            GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });







            Console.WriteLine("a");
            Console.ReadLine();
        }


        //public static int isPrime(long n)
        //{

        //}


        public static int getMin(string s)
        {
            Stack<char> myStack = new Stack<char>();
            int result = 0;

            char left = '(';
            char right = ')';

            for (int x = 0; x < s.Length; x++)
            {
                char newChar = s[x];
                if (newChar == left)
                    myStack.Push(newChar);
                else if (myStack.Count == 0)
                {
                    result++;
                }
                else
                {
                    myStack.Pop();
                }
            }

            result += myStack.Count;

            return result;
        }



        public static int stockPairs(List<int> stocksProfit, long target)
        {
            int remainder;
            int result = 0;

            //profit, count
            Dictionary<int, int> stocks = new Dictionary<int, int>();

            foreach (var profit in stocksProfit)
            {
                if (!stocks.ContainsKey(profit))
                    stocks.Add(profit, 1);
                else
                    stocks[profit]++;
            }

            foreach (var profit in stocksProfit)
            {
                int price = profit;
                remainder = (int)(target - price);

                if (stocks.ContainsKey(remainder) && stocks[remainder] > 0)
                {
                    Console.WriteLine(price + "/ " + stocks[price] + " :: " + remainder + "/ " + stocks[remainder]);
                    if (remainder == price)
                    {
                        int tempResult = stocks[price] / 2;
                        result += tempResult;
                        stocks[remainder] -= 2;
                    }
                    else
                    {
                        int temp = Math.Min(stocks[price], stocks[remainder]);
                        Console.WriteLine(temp);
                        //result += temp;
                        result++;

                        //stocks[price]--;
                        //if (stocks[price] == 0)
                        stocks.Remove(price);

                        //stocks[remainder]--;
                        //if (stocks[remainder] == 0)
                        stocks.Remove(remainder);
                    }

                }

            }


            return result;
        }


        public static int isPrime(long n)
        {
            var top = Math.Floor(Math.Sqrt(n));


            for (int x = 2; x <= top; x++)
            {
                if (n % x == 0)
                    return x;
            }


            return 1;
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

            foreach (var q in queries)
            {
                int startingNode = q.num;
                char query = q.ch;

                int resultForThisRound = 0;

                nodesToVisit.Enqueue(startingNode);

                while (nodesToVisit.Count > 0)
                {
                    int val = nodesToVisit.Dequeue();
                    val--;
                    if (s[val] == query)
                        resultForThisRound++;

                    val++;
                    if (val * 2 < stringLength)
                        nodesToVisit.Enqueue(val * 2);
                    if ((val * 2) + 1 < stringLength + 1)
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

            if (middle + 1 < s.Length)
            {
                String s2 = s.Substring(middle + 1, s.Length - (middle + 1));
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
            foreach (var kvpS in misMatchS)
            {
                if (misMatchT.ContainsKey(kvpS.Key))
                    misMatchPairs++;

                if (misMatchPairs == 2)
                    break;
            }

            bool sDuplicates = false;
            foreach (var kvpS in duplicatesS)
            {
                if (kvpS.Value >= 2)
                {
                    sDuplicates = true;
                    break;
                }
            }

            if (misMatchPairs == 0)
            {
                if (sDuplicates)
                    return preMatchingPairs;
                else if (misMatchS.Count == 1)
                {
                    return preMatchingPairs - 1;
                }
                else if (misMatchS.Count == 2)
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

            for (int x = 0; x < P.Length - 1; x++)
            {
                long toAdd = P[x + 1] - P[x] - 1;
                holes += toAdd;
            }

            holes += N - P[F - 1] - 1;
            holes += F;

            return holes;
        }


        public static long getMinCodeEntryTime(int N, int M, int[] C)
        {
            long results = 0;
            int currentValue = 1;

            foreach (int nextnumber in C)
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

                if (minA <= minB)
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


            numOfSeats = N - S[M - 1];
            spaceNeeded = 1 + K;
            possibleDiners = numOfSeats / spaceNeeded;
            newDiners += possibleDiners;

            for (int x = 0; x < S.Length - 1; x++)
            {

                numOfSeats = (S[x + 1]) - (S[x] + K + 1);
                if (numOfSeats < 0)
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

            while (currentNumber <= B)
            {

                currentNumber = CreateNumberFromScale(digitLoop, powerLoop);

                if (currentNumber >= A && currentNumber <= B)
                    result++;

                if (digitLoop < 9)
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
            while (loop < power)
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

            for (int x = R.Length - 1; x >= 1; x--)
            {
                if (R[x] < x + 1)
                    return -1;

                if (R[x - 1] >= R[x])
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

            foreach (int quiz in S)
            {
                int totalTotal = onesTotal + (twosTotal * 2);
                if (quiz > totalTotal)
                {

                    twosTotal += ((quiz - twosTotal * 2) / 2);
                }
                //if (quiz > (onesTotal + (twosTotal * 2)))
                //    onesTotal++;
                if (quiz % 2 == 1)
                    onesTotal = 1;

            }


            return onesTotal + twosTotal;

        }

        public static int getMaximumEatenDishCount(int N, int[] D, int K)
        {
            int result = 0;

            HashSet<int> eaten = new HashSet<int>();

            for (int x = 1; x <= D.Length; x++)
            {
                if (!eaten.Contains(D[x - 1]))
                {
                    if (x > K)
                        eaten.Remove(D[x - 1 - K]);
                    eaten.Add(D[x - 1]);
                    result++;
                }
            }
            return result;
        }


        public static int getMaxVisitableWebpages(int N, int[] L)
        {
            Dictionary<int, HashSet<int>> pageOne = new Dictionary<int, HashSet<int>>();

            for (int x = 0; x < L.Length; x++)
            {
                HashSet<int> pagesVisited = new HashSet<int>();
                int currentPage = x;
                bool foundPriorConnection = false;

                while (!pagesVisited.Contains(currentPage))
                {
                    if (pageOne.ContainsKey(currentPage))
                    {
                        foundPriorConnection = true;
                        break;
                    }

                    pagesVisited.Add(currentPage);
                    currentPage = L[currentPage] - 1;
                }


                if (!foundPriorConnection)
                    pageOne.Add(x, pagesVisited);
                else
                {
                    //priorResult = pageOne[currentPage];
                    pagesVisited.UnionWith(pageOne[currentPage]);
                    //if (pageOne[currentPage] == L[x])
                    //    priorResult--;
                    pageOne.Add(x, pagesVisited);
                }
                Console.WriteLine("round: " + x + ": " + (pagesVisited.Count));
            }

            return pageOne.Max(t => t.Value.Count);
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

            int sides = int.Parse(input1.Substring(d + 1, input1.Length - d - 1));
            int totalRolls;
            double expected = 1 / sides;

            if (star != -1)
            {
                int people = int.Parse(input1.Substring(0, star));
                int rolls = int.Parse(input1.Substring(star + 1, d - star - 1));
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
            Dictionary<string, int> decks = new Dictionary<string, int>();

            for (int x = 0; x < cards.Length; x++)
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

            for (int x = 0; x < letters.Length; x++)
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




        public class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
            }
        }

        //1 4 7  9
        //2 5
        //

        static SinglyLinkedListNode MergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            SinglyLinkedListNode resultHead = new SinglyLinkedListNode(0);
            SinglyLinkedListNode current = resultHead;

            SinglyLinkedListNode crawl1 = head1;
            SinglyLinkedListNode crawl2 = head2;

            while (true)
            {
                if (crawl1 == null)
                {
                    current.data = crawl2.data;
                    crawl2 = crawl2.next;
                }
                else if (crawl2 == null)
                {
                    current.data = crawl1.data;
                    crawl1 = crawl1.next;
                }
                else if (crawl1.data < crawl2.data)
                {
                    current.data = crawl1.data;
                    crawl1 = crawl1.next;
                }
                else
                {
                    current.data = crawl2.data;
                    crawl2 = crawl2.next;
                }

                if (crawl1 == null && crawl2 == null)
                    return resultHead;

                SinglyLinkedListNode next = new SinglyLinkedListNode(0);
                current.next = next;
                current = next;
            }
        }


        public static int getNode(SinglyLinkedListNode llist, int positionFromTail)
        {



                SinglyLinkedListNode A = new SinglyLinkedListNode(llist.data)
                {
                    next = llist.next
                };
                SinglyLinkedListNode B = new SinglyLinkedListNode(llist.data)
                {
                    next = llist.next
                };

                for (int x = 0; x < positionFromTail; x++)
                    B = B.next;

            while(B.next !=null)
            {
                A = A.next;
                B = B.next;
            }

            return A.data;
        }


        ///



        public class NotesStore
        {
            public NotesStore() { }
            public List<Note> myNotes = new List<Note>();

            public void AddNote(String _state, String _name)
            {
                if (string.IsNullOrEmpty(_name))
                    throw new Exception("Name cannot be empty");

                string tempState;
                if (_state.ToLower() == "complete")
                    tempState = "complete";
                else if (_state.ToLower() == "active")
                    tempState = "active";
                else if (_state.ToLower() == "others")
                    tempState = "others";
                else
                    throw new Exception($"Invalid state {_state}");

                Note newNote = new Note(_state.ToLower(), _name);
                myNotes.Add(newNote);
            }

            public List<String> GetNotes(String _state)
            {
                string tempState;
                if (_state.ToLower() == "complete")
                    tempState = "complete";
                else if (_state.ToLower() == "active")
                    tempState = "active";
                else if (_state.ToLower() == "others")
                    tempState = "others";
                else
                    throw new Exception($"Invalid state {_state}");

                List<String> foundNotes = new List<string>();

                foreach (Note n in myNotes)
                {
                    if (n.State == _state.ToLower())
                        foundNotes.Add((n.Name));
                }
                return foundNotes;
            }


            public class Note
            {
                public string Name;
                public string State;

                public Note(String _state, String _name)
                {
                    Name = _name;
                    State = _state;
                }
            }
        }




        public static SortedDictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
        {
            HashSet<string> companies = new HashSet<string>();
            SortedDictionary<string, Employee> results = new SortedDictionary<string, Employee>();

            foreach (Employee e in employees)
            {
                companies.Add((e.Company));
            }

            foreach (string company in companies)
            {
                Employee ep = employees.Where(e => e.Company == company).OrderByDescending(e => e.Age).First();

                results.Add(company, ep);
            }

            return results;
        }

        public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Company { get; set; }
        }



        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> foundNumbers = new Dictionary<int, int>();

            for (int x=0; x<nums.Length; x++)
            {
                int balance = target - nums[x];

                if (foundNumbers.ContainsKey(balance))
                    return new int[] { x, foundNumbers[balance] };

                if(!foundNumbers.ContainsKey(nums[x]))
                    foundNumbers.Add(nums[x], x);
            }

            return new int[] { 0, 0 };

        }




        public class ListNode
        {
            public int val;
            public ListNode next;

        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            Stack<int> number = new System.Collections.Generic.Stack<int>();
            string tempNumber = "";
            BigInteger result;



            while(l1!=null)
            {
                number.Push(l1.val);
                l1 = l1.next;
            }

            while (number.Count > 0)
                tempNumber += number.Pop().ToString();

            result = BigInteger.Parse(tempNumber);




            tempNumber = "";

            while (l2 != null)
            {
                number.Push(l2.val);
                l2 = l2.next;
            }

            while (number.Count > 0)
                tempNumber += number.Pop().ToString();

            BigInteger b = BigInteger.Parse(tempNumber);
            result += b;





            string resultAsString = result.ToString();

            ListNode root = new ListNode { val = int.Parse(resultAsString[resultAsString.Length-1].ToString()), next = null };
            ListNode pointer = root;

            for (int i = resultAsString.Length - 2; i>=0; i--)
            {
                ListNode next = new ListNode();
                next.val = int.Parse(resultAsString[i].ToString());
                next.next = null;

                pointer.next = next;
                pointer = next;
            }

            return root;
        }



        public static int StrStr(string haystack, string needle)
        {
            int haystackLength = haystack.Length;
            int needleLength = needle.Length;

            if (haystackLength < needleLength)
                return -1;

            for(int index = 0; index< haystackLength; index++)
            {
                if (haystackLength - index < needleLength)
                    return -1;

                if(haystack.Substring(index, needleLength) == needle)
                {
                    return index;
                }
            }
            return -1;
        }





        public static int Reverse(int x)
        {
            bool isNegative = x < 0;

            string initialNumber = x.ToString();
            if (isNegative)
                initialNumber = initialNumber.Substring(1);

            string newNumber = "";

            for(int i = initialNumber.Length-1; i>=0; i--)
            {
                newNumber += initialNumber[i];
            }

            int result;
            if (!int.TryParse(newNumber, out result))
            {
                return 0;
            }

            if (isNegative)
                return result * -1;
            else
                return result;


        }



        public static int MyAtoi(string s)
        {
            s = s.ToLower();
            char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] letters = new char[]{ 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '.' };
            int index = 0;
            bool isNegative = false;

            for (index = 0; index < s.Length; index++)
            {
                if (numbers.Contains(s[index]))
                {
                    break;
                }
                else if(letters.Contains(s[index]))
                {
                    return 0;
                }
                else if (s[index] == '+')
                {
                    isNegative = false;
                    index++;
                    break;
                }
                else if (s[index] == '-')
                {
                    isNegative = true;
                    index++;
                    break;
                }
            }

            string resultString = "";
            for (int index2 = index; index2 < s.Length; index2++)
            {
                if (!numbers.Contains(s[index2]))
                {
                    break;
                }
                else
                {
                    resultString += s[index2];
                }
            }


            int finalNumber = 0;

            int power = 1;
            for(int x = resultString.Length-1; x>=0; x--)
            {
                int digit = (resultString[x]-48) * power;
                long digtitL = (long)(((long)resultString[x] - 48) * (long)power);

                if (!isNegative &&  digit < digtitL)
                    return int.MaxValue;
                if (isNegative && digit < digtitL)
                    return int.MinValue;


                finalNumber += digit;
                power *= 10;
            }


            if (isNegative)
                finalNumber *= -1;

            return finalNumber;
        }




        public static int Divide(int dividend, int divisor)
        {
            long result = 0;
            bool doNegate = true;

            if (dividend < 0 && divisor < 0)
                doNegate = false;
            if (dividend > 0 && divisor > 0)
                doNegate = false;

            if ((long)dividend == 2147483648)
            {
                if (doNegate)
                    return -2147483648;
                else
                    return 2147483647;
            }
                    

            long runningTotal = 0;

            long dividend2 = Math.Abs((long)dividend);
            long divisor2 = Math.Abs((long)divisor);

            while(runningTotal<dividend2)
            {
                result++;
                runningTotal += divisor2;
            }
            if(runningTotal>dividend2)
                result--;



            if (doNegate)
                result *= -1;

            return (int)result;
        }



    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;

                  public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
                     }
        }



        public static IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> list = new List<int>();

            InorderTraversal(root, list);

            return list;
        }


        static void InorderTraversal(TreeNode node, IList<int> list)
        {
            if (node == null)
                return;

            if (node.left != null)
                InorderTraversal(node.left, list);

            list.Add(node.val);

            if (node.right != null)
                InorderTraversal(node.right, list);

        }

        static void PostorderTraversal(TreeNode node, IList<int> list)
        {
            if (node == null)
                return;

            if (node.right != null)
                InorderTraversal(node.right, list);

            list.Add(node.val);

            if (node.left != null)
                InorderTraversal(node.left, list);

        }














        public static TreeNode SortedArrayToBST(int[] nums)
        {
            return CreateNode(nums, 0, nums.Length - 1);
        }


        static TreeNode CreateNode(int[] nums, int left, int right)
        {
            if (left > right)
            {
                return null;
            }
            int mid = left + (right - left) / 2;
            return new TreeNode(nums[mid], CreateNode(nums, left, mid - 1), CreateNode(nums, mid + 1, right));
        }





        public static int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            return CrawlTree(root, 0);
        }

        static int CrawlTree(TreeNode root, int amount)
        {
            if (root == null)
                return amount;

            return Math.Max(CrawlTree(root.left, amount+1), CrawlTree(root.right, amount+1));
        }





        public static int MajorityElement(int[] nums)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            foreach (int x in nums)
            {
                if (result.ContainsKey(x))
                    result[x]++;
                else
                    result.Add(x, 1);
            }
            return result.OrderByDescending(x => x.Value).First().Key;
            
        }


        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            HashSet<ListNode> nodes = new HashSet<ListNode>();

            while(headA!=null)
            {
                nodes.Add(headA);
                headA = headA.next;
            }

            while (headB != null)
            {
                if (nodes.Contains(headB))
                    return headB;
                headB = headB.next;
            }
            return null;
        }




        public static bool WordBreak(string s, IList<string> wordDict)
        {
            foreach(var word in wordDict)
            {
                if (!s.Contains(word))
                    return false;

                int start = s.IndexOf(word);

                s = s.Substring(0, start) + s.Substring(start + word.Length);

            }
            return true;
        }

        ///


        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }

            public override string ToString()
            {
                return "Key: " + val;
            }
        }



        public static Node CopyRandomList(Node head)
        {
            if (head == null)
                return null;

            Node newHead = new Node(head.val);

            Node pointer1 = head;
            Node pointer2 = newHead;

            Dictionary<Node, Node> visitedAB = new Dictionary<Node, Node>();
            visitedAB.Add(pointer1, pointer2);

            while (pointer1 != null)
            {
                if (pointer1.next == null)
                {

                }
                else if (visitedAB.ContainsKey(pointer1.next))
                {
                    pointer2.next = visitedAB[pointer1.next];
                }
                else
                {
                    pointer2.next = new Node(pointer1.next.val);
                    visitedAB.Add(pointer1.next, pointer2.next);
                }


                if (pointer1.random == null)
                {

                }
                else if(visitedAB.ContainsKey(pointer1.random))
                {
                    pointer2.random = visitedAB[pointer1.random];
                }
                else
                {
                    pointer2.random = new Node(pointer1.random.val);
                    visitedAB.Add(pointer1.random, pointer2.random);
                }


                pointer1 = pointer1.next;
                pointer2 = pointer2.next;
            }

            return newHead;
        }





        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next == null)
                return null;


            ListNode pointerA = head;
            ListNode pointerB = head;


            int index = 0;
            while(pointerA.next!=null)
            {
                if (index == n)
                    break;

                pointerA = pointerA.next;
                index++;
            }

            if (index == n-1)
                return head.next;


            while(pointerA.next != null)
            {
                pointerA = pointerA.next;
                pointerB = pointerB.next;
            }

            if(pointerA==head)
            {
                head.val = pointerA.val;
            }
                
            pointerB.next = pointerB.next.next;

            return head;

        }



        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

            foreach(string s in strs)
            {
                string sortedString = String.Concat(s.OrderBy(c => c));

                if (words.ContainsKey(sortedString))
                    words[sortedString].Add(s);
                else
                {
                    words.Add(sortedString, new List<string> { s });
                }
            }



            IList<IList<string>> results = new List<IList<string>>();

            foreach(var wordArray in words)
            {
                results.Add(wordArray.Value);
            }



            return results;
        }



        public static void SetZeroes(int[][] matrix)
        {
            HashSet<int> rows = new HashSet<int>();
            HashSet<int> cols = new HashSet<int>();


            for(int x=0; x<matrix.Length; x++)
            {
                for(int y = 0; y<matrix[x].Length; y++)
                {
                    if (matrix[x][y] == 0)
                    { 
                        rows.Add(x);
                        cols.Add(y);
                    }
                }

            }

            foreach(var row in rows)
            {
                matrix[row] = new int[matrix[0].Length];
            }

            foreach(var col in cols)
            {
                for(int x = 0; x < matrix.Length; x++)
                    matrix[x][col] = 0;
            }
        }




        public static bool IsValidBST(TreeNode root)
        {
            return CrawlValidBST(root, int.MinValue, int.MaxValue);
        }

        static bool CrawlValidBST(TreeNode node, long min, long max)
        {
            if (node == null)
                return true;

            if (node.val < min || node.val > max)
                return false;


            return CrawlValidBST(node.left, min, (long)node.val-1) && CrawlValidBST(node.right, (long)node.val+1, max);
        }




        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> results = new List<IList<int>>();

            if (root == null)
                return results;

            Queue<TreeNode> nodes = new Queue<TreeNode>();
            int counter = 1;
            nodes.Enqueue(root);



            while (nodes.Count>0)
            {
                int nodesThisLevel = counter;
                counter = 0;

                IList<int> resutsB = new List<int>();
                
                for(int x = 0; x< nodesThisLevel; x++)
                {
                    TreeNode currentNode = nodes.Dequeue();
                    resutsB.Add(currentNode.val);


                    if(currentNode.left!=null)
                    {
                        nodes.Enqueue(currentNode.left);
                        counter++;
                    }
                    if (currentNode.right != null)
                    {
                        nodes.Enqueue(currentNode.right);
                        counter++;
                    }
                }

                results.Add(resutsB);
            }

            return results;

        }
















    }

}

