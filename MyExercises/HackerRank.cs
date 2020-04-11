using Lucene.Net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace MyExercises
{

    public static class HackerRank
    {

        class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                this.head = null;
                this.tail = null;
            }

            public void InsertNode(int nodeData)
            {
                SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

                if (this.head == null)
                {
                    this.head = node;
                }
                else
                {
                    this.tail.next = node;
                }

                this.tail = node;
            }
        }

        public static string findSubstring(string s, int k)
        {
            var vowels = new List<char> { 'a', 'e', 'i', 'o', 'u' };

            int stringLen = s.Length;

            int maxCount = 0;
            int maxIndex = 0;

            if (k > stringLen)
                return "Not found!";
            else if (k == stringLen)
                return s;


            for (int x = 0; x <= (stringLen - k - 1); x++)
            {
                int currCount = 0;
                String subStr = s.Substring(x, k);
                currCount = subStr.Count(ch => vowels.Contains(ch));     //

                if (currCount > maxCount)
                {
                    maxCount = currCount;
                    maxIndex = x;
                }
                if (maxCount == k)
                    return subStr;
            }

            if (maxCount == 0)
                return "Not found!";

            return s.Substring(maxIndex, k);
        }


        public static string kangaroo(int x1, int v1, int x2, int v2)
        {
            if ((x1 > x2 && v1 > v2) || (x1 < x2 && v1 < v2))
                return "NO";

            if (x1 > x2)
            {
                while (x1 > x2)
                {
                    x1 += v1;
                    x2 += v2;
                }
            }
            else
            {
                while (x1 < x2)
                {
                    x1 += v1;
                    x2 += v2;
                }
            }

            if (x1 == x2)
                return "YES";
            else
                return "NO";


        }


        public static int birthday(List<int> s, int d, int m)
        {
            int count = 0;

            for (int x = 0; x <= s.Count() - m; x++)
            {
                var subList = s.Skip(x).Take(m);
                int mySum = subList.Sum();
                if (mySum == d)
                    count++;


            }
            return count;

        }

        public static int divisibleSumPairs(int n, int k, int[] ar)
        {

            int count = 0;

            for (int a = 0; a < n - 1; a++)
            {
                for (int b = a + 1; b < n; b++)
                {
                    if ((ar[a] + ar[b]) % k == 0)
                        count++;
                }

            }

            return count;
        }


        public static int migratoryBirds(List<int> arr)
        {
            var dict = new Dictionary<int, int>();

            for (int x = 0; x < arr.Count(); x++)
            {
                if (dict.ContainsKey(arr[x]))
                    dict[arr[x]]++;
                else
                    dict.Add(arr[x], 1);
            }

            int result = 1;
            int resultIndex = 1;
            for (int x = 1; x <= 5; x++)
            {
                if (dict.ContainsKey(x) && dict[x] > result)
                {
                    result = dict[x];
                    resultIndex = x;
                }


            }

            return resultIndex;
        }


        public static string dayOfProgrammer(int year)
        {
            var days = new Dictionary<int, int>
            {
                { 1,31},
                { 2,28},
                { 3,31},
                { 4,30},
                { 5,31},
                { 6,30},
                { 7,31},
                { 8,31},
                { 9,30},
                { 10,31},
                { 11,30},
                { 12,31}
            };

            int daysOut = 256;
            int dayCount = 0;

            if (year == 1918)
                days[2] = 15;
            else if (year < 1918)
            {
                if (year % 4 == 0)
                    days[2] = 29;
            }
            else
            {
                if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
                    days[2] = 29;
            }

            int monthCount = 1;

            while (dayCount < daysOut)
            {
                dayCount += days[monthCount];
                monthCount++;
            }
            dayCount -= days[monthCount];
            int finalDate = daysOut - dayCount;


            return (finalDate - 1).ToString() + "." + (monthCount - 1).ToString("00") + "." + year.ToString();

        }



        public static void bonAppetit(List<int> bill, int k, int b)
        {
            bill.RemoveAt(k);
            int fair = bill.Sum() / 2;

            if (fair == b)
                Console.WriteLine("Bon Appetit");
            else
                Console.WriteLine(b - fair);

        }


        public static int sockMerchant(int n, int[] ar)
        {
            var dict = new Dictionary<int, int>();

            foreach (int s in ar)
            {
                if (dict.ContainsKey(s))
                    dict[s]++;
                else
                    dict.Add(s, 1);
            }

            int count = 0;

            foreach (var x in dict)
            {
                count += x.Value / 2;
            }

            return count;

        }


        public static int formingMagicSquare(int[][] s)
        {
            int[,] goodSquares = new int[,] {
            {8, 1, 6, 3, 5, 7, 4, 9, 2},
            {6, 1, 8, 7, 5, 3, 2, 9, 4},
            {4, 9, 2, 3, 5, 7, 8, 1, 6},
            {2, 9, 4, 7, 5, 3, 6, 1, 8},
            {8, 3, 4, 1, 5, 9, 6, 7, 2},
            {4, 3, 8, 9, 5, 1, 2, 7, 6},
            {6, 7, 2, 1, 5, 9, 8, 3, 4},
            {2, 7, 6, 9, 5, 1, 4, 3, 8},
            };

            int[] mySquare = new int[9];        //{ 1, 2, 3 }, new int[3] { 4, 5, 6 }, new int[3] { 7, 8, 9 }
            int i = 0;                          //{8, 1, 6,                3, 5, 7,                4, 9, 2},
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                {
                    mySquare[i] = s[x][y];
                    i++;
                }

            i = 0;
            var dict = new Dictionary<int, int>();

            for (int x = 0; x < 8; x++)
            {
                int result = 0;
                for (int y = 0; y < 9; y++)
                {
                    result += Math.Abs(mySquare[y] - goodSquares[x, y]);
                }
                dict.Add(x, result);
            }


            return dict.Min(k => k.Value);

        }


        public static int pickingNumbers(List<int> a)
        {
            a.Sort();
            int finalCount = 0;

            for (int i = 0; i < a.Count - 1; i++)        //1 3 3 4 5 6
            {
                int baseNum = a[i];
                int tempCount = 1;
                int j = i + 1;
                while (j < a.Count && Math.Abs(a[j] - baseNum) <= 1)
                {
                    tempCount++;
                    j++;
                }

                if (tempCount > finalCount)
                    finalCount = tempCount;
            }

            return finalCount;

        }


        public static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            var results = new int[alice.Length];
            var scores2 = scores.Distinct().ToArray();    //.Select((value, index) => new { value, index }).ToDictionary(pair => pair.value, pair => pair.index);
            int cap = scores2.Count() - 1;

            for (int scoreNumber = 0; scoreNumber < alice.Length; scoreNumber++)
            {
                int aliceScore = alice[scoreNumber];
                int y = 0;

                while (y <= cap && scores2[y] > aliceScore)
                    y++;

                cap = y;
                results[scoreNumber] = y + 1;
            }
            return results;
        }


        public static int BinarySearchIterative(int[] list, int value)
        {
            int left = 0;
            int right = list.Length - 1;
            int index = (left + right) / 2;

            while (value != list[(left + right) / 2])
            {
                index = (left + right) / 2;

                if (value > list[index])
                {
                    right = index;
                }
                else if (value < list[index])
                {
                    left = index;
                }


            }
            return index;
        }


        public static int countingValleys(int n, string s)
        {
            int valleys = 0;
            int height = 0;

            for (int x = 0; x < s.Length; x++)
            {
                int priorHeight = height;
                height += s[x] == 'U' ? 1 : -1;

                if (height == -1 && priorHeight == 0)
                    valleys++;
            }
            return valleys;
        }


        public static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            int spend = -1;
            var keyboardsSorted = keyboards.OrderBy(x => x).ToArray();
            var drivesSorted = drives.OrderBy(x => x).ToArray();

            for (int x = keyboardsSorted.Length - 1; x >= 0; x--)
            {
                for (int y = drivesSorted.Length - 1; y >= 0; y--)
                {
                    bool found = false;
                    int price = keyboardsSorted[x] + drivesSorted[y];
                    if (price <= b)
                    {
                        found = true;
                        if (spend == b)
                            return spend;
                        else if (price > spend)
                            spend = price;
                    }
                }
            }
            return spend;
        }



        public static string catAndMouse(int x, int y, int z)
        {
            int A = Math.Abs(x - z);
            int B = Math.Abs(y - z);

            if (A == B)
                return "Mouse C";
            else if (A < B)
                return "Cat A";
            else
                return "Cat B";

        }


        public static int findDigits(int n)
        {
            string numberString = n.ToString();
            int[] numbers = new int[numberString.Length];

            for (int i = 0; i < numberString.Length; i++)
                numbers[i] = int.Parse(numberString[i].ToString());

            int sum = 0;

            for (int i = 0; i < numberString.Length; i++)
            {
                if (numbers[i] == 0)
                    continue;
                else if (n % numbers[i] == 0)
                    sum++;

            }


            return sum;
        }



        public static int designerPdfViewer(int[] h, string word)
        {

            int height = word.Max(ch => h[(int)(ch - 97)]);

            return height * word.Length;

        }


        public static int utopianTree(int n)
        {
            int height = 1;

            for (int x = 1; x <= n; x++)
            {
                if (x % 2 == 1)
                    height *= 2;
                else
                    height++;

            }

            return height;
        }

        public static string angryProfessor(int k, int[] a)
        {
            int onTimeStudents = a.Where(i => i <= 0).Count();
            if (onTimeStudents >= k)
                return "NO";
            else
                return "YES";

        }


        public static int beautifulDays(int i, int j, int k)
        {
            int beautifulDays = 0;

            for (int x = i; x <= j; x++)
            {
                int y = ReverseNumber(x);
                if (Math.Abs(x - y) % k == 0)
                    beautifulDays++;
            }
            return beautifulDays;

        }

        public static int ReverseNumber(int x)
        {
            var y = x.ToString().Reverse().ToArray(); //.Reverse().ToString()
            String reversed = new String(y);
            return int.Parse(reversed);
        }


        public static int viralAdvertising(int n)
        {
            int currentDay = 1;
            int totalLikes = 0;
            int shares = 5;

            while (currentDay <= n)
            {
                int newLikes = (int)(shares / 2);
                totalLikes += newLikes;
                shares = newLikes * 3;

                Console.WriteLine("day " + currentDay + ": total likes:" + totalLikes);
                currentDay++;
            }
            return totalLikes;
        }


        public static int saveThePrisoner(int n, int m, int s)
        {
            int prisonerNumber = m % n;
            if (prisonerNumber == 0)
                prisonerNumber = n;
            int seatNumber = (prisonerNumber + s - 1) % n;
            if (seatNumber == 0)
                seatNumber = n;

            Console.WriteLine(seatNumber);
            return seatNumber;
        }


        public static int[] circularArrayRotation(int[] a, int k, int[] queries)
        {
            int[] results = new int[queries.Length];

            int shiftRight = k % (a.Length);
            Console.WriteLine("Shift: " + shiftRight + "\n");

            for (int x = 0; x < queries.Length; x++)
            {
                int index = ((queries[x] - shiftRight) % a.Length);
                if (index < 0)
                    index += a.Length;

                Console.WriteLine("index: " + x + " now at: " + index);
                results[x] = a[index];
                Console.WriteLine("result: " + results[x] + "\n");
            }
            return results;
        }


        public static int[] permutationEquation(int[] p)
        {
            int[] result = new int[p.Length];

            for (int x = 0; x <= p.Length - 1; x++)
            {
                int numToFind = x + 1;
                int found = Array.FindIndex(p, q => q == numToFind);
                int found2 = Array.FindIndex(p, q => q == found + 1);

                result[x] = found2 + 1;
            }
            return result;
        }


        public static int jumpingOnClouds(int[] c, int k)
        {
            int jumpDistance = k;
            int energyLevel = 100;
            int currentCloud = 0;

            do
            {
                currentCloud = (currentCloud + k) % c.Length;
                energyLevel -= 1;
                if (c[currentCloud] == 1)
                    energyLevel -= 2;

            }
            while (currentCloud != 0);

            return energyLevel;

        }

        public static void extraLongFactorials(int n)
        {
            Int64 factorial = 1;
            int currentCount = 2;
            if (n == 1)
            {
                Console.WriteLine("1");
                return;
            }

            while (currentCount <= 20)
            {
                factorial *= currentCount;
                currentCount++;
                if (currentCount > n)
                    break;
            }

            if (n <= 20)
            {
                Console.WriteLine(factorial);
                return;
            }

            BigInteger bigIntFromInt64 = new BigInteger(factorial);

            while (currentCount <= n)
            {
                bigIntFromInt64 = bigIntFromInt64 * currentCount;
                currentCount++;
                if (currentCount > n)
                    break;

            }

            Console.WriteLine(bigIntFromInt64);

        }


        public static string appendAndDelete(string s, string t, int k)
        {
            int lastCommonCharIndex = s.TakeWhile((v, i) => (i < t.Length && v == t[i])).Count();
            //-1 nothing in common
            String sStub = s.Substring(0, lastCommonCharIndex);

            //5
            //11, 10  => 5,4

            int sExtraChar = s.Length - lastCommonCharIndex;
            int tExtraChar = t.Length - lastCommonCharIndex;

            if (sExtraChar + tExtraChar > k) //dont have enough steps to remove and then add
                return "No";
            else if (sExtraChar + tExtraChar == k)
                return "Yes";

            else if (s.Length + tExtraChar <= k)
                return "Yes";


            int sStubLength = sStub.Length;
            int difference = (k - s.Length + sStubLength);

            String newString = sStub.Substring(0, sStubLength - difference) + t.Substring(t.Length - difference, difference);
            if (newString == t)
                return "Yes";


            return "No";
        }

        //returned                  //due
        public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            DateTime returned = new DateTime(y1, m1, d1);
            DateTime due = new DateTime(y2, m2, d2);

            if (returned < due)
                return 0;

            if (y1 > y2)
                return 10000;
            if (m1 > m2)
                return (500 * (m1 - m2));
            else
                return (15 * (d1 - d2));


        }


        public static int[] cutTheSticks(int[] arr)
        {
            var startList = new List<int>();
            startList = arr.ToList();
            startList.Sort();

            var results = new List<int>();
            results.Add(startList.Count);

            while (startList.Count > 0)
            {
                int remove = startList[0];
                for (int x = 0; x < startList.Count; x++)
                    startList[x] -= remove;

                startList = startList.Where(i => i > 0).ToList();
                results.Add(startList.Count);
            }

            results.RemoveAt(results.Count - 1);


            return results.ToArray();
        }


        public static int nonDivisibleSubset(int k, List<int> s)
        {
            var pairs = new Dictionary<int, List<int>>();

            for (int x = 0; x < s.Count; x++)
            {
                if (!pairs.ContainsKey(s[x]))
                {
                    for (int y = x + 1; y < s.Count; y++)
                    {
                        if ((s[x] + s[y]) % k != 0)
                        {
                            if (!pairs.ContainsKey(s[x]))
                            {
                                pairs.Add(s[x], new List<int>() { s[y] });
                            }
                            else if (!pairs[s[x]].Contains(s[y]))
                            {
                                pairs[s[x]].Add(s[y]);
                            }

                        }
                    }
                }
            }   //create valid pair hash

            return 4;
        }


        public static int squares(int a, int b)
        {
            int count = 0;
            double start = Math.Sqrt(a);
            int startInt = (int)start;


            if (start == startInt)
                count++;

            startInt++;

            while (startInt * startInt <= b)
            {
                count++;
                startInt++;
            }

            return count;

        }


        public static int jumpingOnClouds(int[] c)
        {

            int jumps = 0;
            int currentCloud = 0;
            int lastCloud = c.Length - 1;

            while (currentCloud < lastCloud)
            {
                if (currentCloud + 2 <= lastCloud && c[currentCloud + 2] != 1)
                    currentCloud += 2;
                else
                    currentCloud++;

                jumps++;
            }


            return jumps;
        }


        public static int equalizeArray(int[] arr)
        {
            var dict = new Dictionary<int, int>();

            for (int x = 0; x < arr.Length; x++)
            {
                if (dict.ContainsKey(arr[x]))
                    dict[arr[x]]++;
                else
                    dict.Add(arr[x], 1);
            }

            var k = dict.Where(x => x.Value == dict.Max((kvp => kvp.Value))).ToList();      //Max(kvp=>kvp.Value)

            int z = k[0].Key;

            dict.Remove(z);

            int lesserNumbers = dict.Sum(i => i.Value);

            return lesserNumbers;
        }


        //r&c    //#obs    q_r     q_c      obstacles
        public static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            int count = 0;
            int obstaclesFound = 0;

            //up
            int queenRow = r_q;
            int queenCol = c_q;
            bool continueTest = true;
            queenRow++;
            while (queenRow <= n && continueTest)
            {
                if (obstacles.Any(i => i[0] == queenRow && i[1] == queenCol))
                {
                    continueTest = false;
                    obstaclesFound++;
                    if (obstaclesFound == k) return count;
                }
                else
                {
                    count++;
                }
                queenRow++;
            }
            //down
            queenRow = r_q;
            queenCol = c_q;
            continueTest = true;
            queenRow--;
            while (queenRow >= 1 && continueTest)
            {
                if (obstacles.Any(i => i[0] == queenRow && i[1] == queenCol))
                {
                    continueTest = false;
                    obstaclesFound++;
                    if (obstaclesFound == k) return count;
                }
                else
                {
                    count++;
                }
                queenRow--;
            }
            //right
            queenRow = r_q;
            queenCol = c_q;
            continueTest = true;
            queenCol++;
            while (queenCol <= n && continueTest)
            {
                if (obstacles.Any(i => i[0] == queenRow && i[1] == queenCol))
                {
                    continueTest = false;
                    obstaclesFound++;
                    if (obstaclesFound == k) return count;
                }
                else
                {
                    count++;
                }
                queenCol++;
            }
            //left
            queenRow = r_q;
            queenCol = c_q;
            continueTest = true;
            queenCol--;
            while (queenCol >= 1 && continueTest)
            {
                if (obstacles.Any(i => i[0] == queenRow && i[1] == queenCol))
                {
                    continueTest = false;
                    obstaclesFound++;
                    if (obstaclesFound == k) return count;
                }
                else
                {
                    count++;
                }
                queenCol--;
            }
            //up right
            queenRow = r_q;
            queenCol = c_q;
            continueTest = true;
            queenRow++;
            queenCol++;
            while (queenRow <= n && queenCol <= n && continueTest)
            {
                if (obstacles.Any(i => i[0] == queenRow && i[1] == queenCol))
                {
                    continueTest = false;
                    obstaclesFound++;
                    if (obstaclesFound == k) return count;
                }
                else
                {
                    count++;
                }
                queenRow++;
                queenCol++;
            }
            //down right
            queenRow = r_q;
            queenCol = c_q;
            continueTest = true;
            queenRow--;
            queenCol++;
            while (queenRow >= 1 & queenCol <= n && continueTest)
            {
                if (obstacles.Any(i => i[0] == queenRow && i[1] == queenCol))
                {
                    continueTest = false;
                    obstaclesFound++;
                    if (obstaclesFound == k) return count;
                }
                else
                {
                    count++;
                }
                queenRow--;
                queenCol++;
            }
            //down left
            queenRow = r_q;
            queenCol = c_q;
            continueTest = true;
            queenRow--;
            queenCol--;
            while (queenRow >= 1 && queenCol >= 1 && continueTest)
            {
                if (obstacles.Any(i => i[0] == queenRow && i[1] == queenCol))
                {
                    continueTest = false;
                    obstaclesFound++;
                    if (obstaclesFound == k) return count;
                }
                else
                {
                    count++;
                }
                queenRow--;
                queenCol--;
            }
            //up left
            queenRow = r_q;
            queenCol = c_q;
            continueTest = true;
            queenRow++;
            queenCol--;
            while (queenRow <= n && queenCol >= 1 && continueTest)
            {
                if (obstacles.Any(i => i[0] == queenRow && i[1] == queenCol))
                {
                    continueTest = false;
                    obstaclesFound++;
                    if (obstaclesFound == k) return count;
                }
                else
                {
                    count++;
                }
                queenRow++;
                queenCol--;
            }
            return count;
        }


        public static long repeatedString(string s, long n)
        {
            long result = 0;

            int numofA = s.Where(i => i == 'a').Count();
            int lenofString = s.Length;

            result += ((long)n / lenofString) * numofA;

            int balance = (int)(n % lenofString);

            result += s.Substring(0, balance).Where(i => i == 'a').Count();

            return result;
        }


        public static int[] acmTeam(string[] topic)
        {
            //         topics, # of teams
            Dictionary<int, int> topicCount = new Dictionary<int, int>();
            int numOfAttendees = topic.Length;
            int numOfTopics = topic[0].Length;

            for (int x = 0; x < numOfAttendees - 1; x++)  //length of array -> # of attendees
                for (int y = x + 1; y < numOfAttendees; y++)
                {
                    //get # of topics for this pair
                    int count = 0;
                    for (int z = 0; z < numOfTopics; z++)
                    {
                        if (topic[x][z] == '1' || topic[y][z] == '1')
                            count++;
                    }
                    Console.WriteLine(count);

                    //add to dict
                    if (topicCount.ContainsKey(count))
                        topicCount[count]++;
                    else
                        topicCount.Add(count, 1);
                }

            int maxTopics = topicCount.Max(kvp => kvp.Key);
            int maxteams = topicCount[maxTopics];
            int[] result = new int[] { maxTopics, maxteams };
            return result;
        }


        public static long taumBday(int b, int w, int bc, int wc, int z)
        {
            long xbc = wc + z;
            long xwc = bc + z;

            long bestBC = xbc < bc ? xbc : bc;
            long bestWC = xwc < wc ? xwc : wc;

            long result = (b * bestBC) + (w * bestWC);
            return result;

        }


        public static void kaprekarNumbers(int p, int q)
        {
            bool foundOne = false;

            for (int n = p; n <= q; n++)
            {
                int digits = n.ToString().Length;
                Int64 squared = (Int64)n * (Int64)n;

                string stringified = squared.ToString();
                int length = stringified.Length;

                Int64 left = 0;
                Int64 right = Int64.Parse(stringified);
                if (length > 1)
                {
                    left = Int64.Parse(stringified.Substring(0, length - digits));
                    right = Int64.Parse(stringified.Substring(length - digits, digits));
                }


                if (left + right == n)
                {
                    Console.Write(n + " ");
                    foundOne = true;
                }
            }
            if (!foundOne)
                Console.WriteLine("INVALID RANGE");
        }


        public static int beautifulTriplets(int d, int[] arr)
        {
            int count = 0;

            foreach (int x in arr)
            {
                if (arr.Contains(x + d) && arr.Contains(x + d + d))
                    count++;
            }

            return count;
        }


        public static int minimumDistances(int[] a)
        {
            var numberDict = new Dictionary<int, List<int>>();
            int minDistance = int.MaxValue;

            for (int x = 0; x < a.Length; x++)
            {
                if (!numberDict.ContainsKey(a[x]))
                {
                    numberDict.Add(a[x], new List<int> { x });
                }
                else
                {
                    int currDist = numberDict[a[x]].Min(i => Math.Abs(i - x));
                    if (currDist == 1)
                        return 1;
                    else if (currDist < minDistance)
                        minDistance = currDist;
                }
            }
            if (minDistance == int.MaxValue)
                return -1;
            else
                return minDistance;
        }



        public static string timeInWords(int h, int m)
        {
            string adverb;
            string hour;

            var hourDict = new Dictionary<int, string>()
            {
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
                { 4, "four" },
                { 5, "five" },
                { 6, "six" },
                { 7, "seven" },
                { 8, "eight" },
                { 9, "nine" },
                { 10, "ten" },
                { 11, "eleven" },
                { 12, "twelve" }
            };

            var minuteDict = new Dictionary<int, string>()
            {
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
                { 4, "four" },
                { 5, "five" },
                { 6, "six" },
                { 7, "seven" },
                { 8, "eight" },
                { 9, "nine" },
                { 10, "ten" },
                { 11, "eleven" },
                { 12, "twelve" },
                { 13, "thirteen" },
                { 14, "fourteen" },
                { 15, "fifteen" },
                { 16, "sixteen" },
                { 17, "seventeen" },
                { 18, "eighteen" },
                { 19, "nineteen" },
                { 20, "twenty" },
                { 21, "twenty one" },
                { 22, "twenty two" },
                { 23, "twenty three" },
                { 24, "twenty four" },
                { 25, "twenty five" },
                { 26, "twenty six" },
                { 27, "twenty seven" },
                { 28, "twenty eight" },
                { 29, "twenty nine" },
                { 30, "half" }
            };

            string minString = m == 1 ? "minute" : "minutes";

            if (m == 0)
            {
                hour = hourDict[h];
                adverb = "o' clock";
                return hour + " " + adverb;
            }
            else if (m == 30)
            {
                hour = hourDict[h];
                adverb = "past";
                return minuteDict[m] + " " + adverb + " " + hour;
            }
            else if (m < 30)
            {
                hour = hourDict[h];
                adverb = "past";

                if (m == 15)
                    return "quarter " + adverb + " " + hour;
                else
                    return minuteDict[m] + " " + minString + " " + adverb + " " + hour;
            }
            else
            {
                hour = hourDict[(h + 1) % 12];
                adverb = "to";

                if (m == 45)
                    return "quarter " + adverb + " " + hour;
                else
                    return minuteDict[60 - m] + " " + minString + " " + adverb + " " + hour;
            }
        }


        public static int howManyGames(int p, int d, int m, int s)
        {
            int currentDollars = s;
            int currentPrice = p;
            int gamesBought = 0;

            while (currentDollars >= currentPrice)
            {
                currentDollars -= currentPrice;
                gamesBought++;

                currentPrice -= d;
                if (currentPrice < m)
                    currentPrice = m;
            }

            return gamesBought;
        }


        public static int chocolateFeast(int n, int c, int m)
        {
            int wrappers = n / c;
            int chocolatesEaten = n / c;

            int wrapperCost = m;

            while (wrappers >= wrapperCost)
            {
                int newRound = wrappers / wrapperCost;
                chocolatesEaten += newRound;
                wrappers = wrappers - (newRound * wrapperCost) + newRound;
            }

            return chocolatesEaten;
        }



        public static string biggerIsGreater(string w)
        {
            //initialize base array
            char[] values = new char[w.Length];
            for (int i = 0; i < w.Length; i++)
                values[i] = w[i];

            for (int a = w.Length - 1; a >= 0 + 1; a--)
            {
                for (int b = a - 1; b >= 0; b--)
                {
                    if (values[a] >= values[b])
                    {
                        //swap and return
                        char temp = values[a];
                        values[a] = values[b];
                        values[b] = temp;

                        //from [b+1] to end, sort ascending
                        char[] subSet = new char[values.Length - (b + 1)];
                        for (int i = 0; i < subSet.Length; i++)      //b+1
                            subSet[i] = values[i + b + 1];

                        subSet = subSet.OrderBy(z => z).ToArray();

                        for (int i = 0; i < subSet.Length; i++)
                            values[i + b + 1] = subSet[i];


                        //rebuild string and return
                        String result = new string(values);
                        if (result == w)
                            return "no answer";
                        else
                            return result;
                    }
                }
            }


            //iterate over array
            //for (int a = 1; a < values.Length - 1; a++)  //distances apart
            //{
            //    for (int b = w.Length - 1; b > w.Length - a; b--)  //start at end
            //    {
            //        if (values[b] > values[b - a])
            //        {
            //            //swap and return
            //            char temp = values[b - a];
            //            values[b - a] = values[b];
            //            values[b] = temp;

            //            //from [b-a+1] to end, sort ascending
            //            char[] subSet = new char[values.Length - (b - a + 1)];
            //            for (int i = 0; i < subSet.Length; i++)      //b+1  TO  b - a + 1
            //                subSet[i] = values[i + b - a + 1];

            //            subSet = subSet.OrderBy(z => z).ToArray();

            //            for (int i = 0; i < subSet.Length; i++)
            //                values[i + b - a + 1] = subSet[i];


            //            //rebuild string and return
            //            String result = new string(values);
            //            return result;
            //        }
            //    }
            //}

            return "no answer";
        }


        //// Data Structures ///////


        public static int hourglassSum(int[][] arr)
        {
            var results = new int[16];
            int i = 0;

            for (int a = 0; a <= arr.Length - 3; a++)
            {
                for (int b = 0; b <= arr.Length - 3; b++)
                {
                    int tempSum = 0;
                    tempSum += arr[a].Where((value, index) => index >= b && index <= (b + 2)).Sum(value => value);
                    tempSum += arr[a + 1][b + 1];
                    tempSum += arr[a + 2].Where((value, index) => index >= b && index <= (b + 2)).Sum(value => value);
                    results[i++] = tempSum;
                }
            }


            return results.Max();
        }


        public static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            var queryList = new List<List<int>>();   //list of lists
            for (int a = 0; a < n; a++)
                queryList.Add(new List<int>());

            int lastAnswer = 0;
            var resultList = new List<int>();

            for (int a = 0; a < queries.Count; a++)
            {
                int qNumber = queries[a][0];

                int index = (queries[a][1] ^ lastAnswer) % n;

                if (qNumber == 1)
                {
                    queryList[index].Add(queries[a][2]);
                }
                else
                {
                    int value = queries[a][2] % queryList[index].Count();
                    lastAnswer = queryList[index][value];
                    resultList.Add(lastAnswer);
                    Console.WriteLine(lastAnswer);
                }
            }
            return resultList;
        }



        public static void leftRotations()
        {
            string[] nd = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nd[0]);
            int d = Convert.ToInt32(nd[1]);
            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));

            //jj
            int shift = d;

            for (int x = 0; x < n; x++)
            {
                int index = (x + d) % n;
                Console.Write(a[index] + " ");
            }
        }


        public static int[] matchingStrings(string[] strings, string[] queries)
        {
            var results = new int[queries.Length];

            var stringsDict = new Dictionary<char, List<string>>();
            foreach (string s in strings)
            {
                char firstLetter = Char.Parse(s.Substring(0, 1));
                if (stringsDict.ContainsKey(firstLetter))
                {
                    stringsDict[firstLetter].Add(s);
                }
                else
                {
                    stringsDict.Add(firstLetter, new List<string> { s });
                }
            }

            for (int x = 0; x < queries.Length; x++)
            {
                int count = 0;
                char firstLetter = Char.Parse(queries[x].Substring(0, 1));
                if (stringsDict.ContainsKey(firstLetter))
                {
                    count = stringsDict[firstLetter].Count(i => i == queries[x]);
                }
                results[x] = count;
            }
            return results;
        }


        public class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int v)
            {
                data = v;
                next = null;
            }
        }

        public static void printLinkedList(SinglyLinkedListNode head)
        {
            if (head == null)
                return;

            SinglyLinkedListNode pointer = head;

            do
            {
                Console.WriteLine(pointer.data);
                pointer = pointer.next;
            }
            while (pointer != null);

        }



        public static SinglyLinkedListNode insertNodeAtTail(SinglyLinkedListNode head, int data)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

            if (head == null)
            {
                return newNode;
            }

            SinglyLinkedListNode pointer = head.next;
            SinglyLinkedListNode lastPointer = head;

            while (pointer != null)
            {
                lastPointer = pointer;
                pointer = pointer.next;
            }

            lastPointer.next = newNode;

            return head;

        }


        public static SinglyLinkedListNode insertNodeAtHead(SinglyLinkedListNode llist, int data)
        {

            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

            if (llist == null)
            {
                return newNode;
            }
            else
            {
                newNode.next = llist;
                return newNode;
            }
        }


        public static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position)   //0==head ; else # after position
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

            if (head == null)
                return newNode;


            SinglyLinkedListNode pointer = head.next;
            SinglyLinkedListNode lastPointer = head;

            for (int x = 1; x < position; x++)
            {
                lastPointer = pointer;
                pointer = pointer.next;
            }

            lastPointer.next = newNode;
            newNode.next = pointer;

            return head;
        }


        public static SinglyLinkedListNode deleteNode(SinglyLinkedListNode head, int position)  //0==head ; else # after position
        {
            if (head.next == null)
                return null;
            else if (position == 0)
            {
                return head.next;
            }

            SinglyLinkedListNode pointer = head.next;
            SinglyLinkedListNode lastPointer = head;

            for (int x = 1; x < position; x++)
            {
                lastPointer = pointer;
                pointer = pointer.next;
            }

            lastPointer.next = pointer.next;
            pointer.next = null;

            return head;
        }


        public static void reversePrint(SinglyLinkedListNode head)
        {
            if (head == null)
                return;

            var results = new Stack<int>();

            SinglyLinkedListNode pointer = head;

            while (pointer != null)
            {
                results.Push(pointer.data);
                pointer = pointer.next;
            }

            int stopAt = results.Count();
            for (int x = 0; x < stopAt; x++)
                Console.WriteLine(results.Pop());

        }

        public static SinglyLinkedListNode reverse(SinglyLinkedListNode head)
        {
            if (head == null)
                return null;

            SinglyLinkedListNode A = head;
            SinglyLinkedListNode B = head.next;
            SinglyLinkedListNode C;



            while (B.next != null)
            {
                //A.next = null;
                C = B.next;
                B.next = A;

                A = B;
                B = C;
            }


            //A.next = null;
            B.next = A;
            head.next = null;
            return B;

        }


        public static bool CompareLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {

            if (head1 == null && head2 == null)
            {
                Console.WriteLine(1);
                return true;
            }
            else if (head1 == null || head2 == null)
            {
                Console.WriteLine(0);
                return false;
            }

            SinglyLinkedListNode A = head1;
            SinglyLinkedListNode B = head2;

            while (A != null || B != null)
            {
                if (A == null && B == null)
                {
                    Console.WriteLine(1);
                    return true;
                }
                else if (A == null || B == null)
                {
                    Console.WriteLine(0);
                    return false;
                }
                else if (A.data != B.data)
                {
                    Console.WriteLine(0);
                    return false;
                }

                else
                {
                    A = A.next;
                    B = B.next;
                }
            }

            if (A == null && B == null)
            {
                Console.WriteLine(1);
                return true;
            }
            else
            {
                Console.WriteLine(0);
                return false;
            }
        }


        public static SinglyLinkedListNode removeDuplicates(SinglyLinkedListNode head)
        {
            if (head == null)
                return head;

            SinglyLinkedListNode pointer = head;
            SinglyLinkedListNode pointerTwo = head;

            while (pointer.next != null)
            {
                pointerTwo = pointer.next;
                while (pointerTwo != null && pointer.data == pointerTwo.data)
                {
                    pointer.next = pointerTwo.next;

                    pointerTwo.next = null;
                    pointerTwo = pointer.next;
                }

                if (pointerTwo == null)
                    return head;

                pointer = pointer.next;
            }

            return head;

        }


        public static bool hasCycle(SinglyLinkedListNode head)
        {
            var myHash = new HashSet<SinglyLinkedListNode>();
            SinglyLinkedListNode pointer = head;

            while (pointer != null)
            {
                if (myHash.Contains(pointer))
                    return true;
                else
                {
                    myHash.Add(pointer);
                    pointer = pointer.next;
                }
            }
            return false;
        }


        public static int findMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            var myDict = new HashSet<SinglyLinkedListNode>();
            SinglyLinkedListNode P1 = head1;
            SinglyLinkedListNode P2 = head2;

            while (P1 != null)
            {
                myDict.Add(P1);
                P1 = P1.next;
            }

            while (!myDict.Contains(P2))
            {
                P2 = P2.next;
            }

            return P2.data;

        }


        public class DoublyLinkedListNode
        {
            public int data;
            public DoublyLinkedListNode next;
            public DoublyLinkedListNode prev;

            public DoublyLinkedListNode(int nodeData)
            {
                this.data = nodeData;
                this.next = null;
                this.prev = null;
            }
        }

        public static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode head, int data)   //next, prev
        {
            DoublyLinkedListNode newNode = new DoublyLinkedListNode(data);

            if (head == null)
                return newNode;
            else if (data < head.data)
            {
                newNode.next = head;
                head = newNode;
                return head;
            }

            DoublyLinkedListNode pointer = head;

            while (pointer.next != null && data > pointer.next.data)
            {
                pointer = pointer.next;
            }

            newNode.next = pointer.next;
            pointer.next = newNode;

            if (newNode.next != null)
            {
                newNode.next.prev = newNode;
            }
            return head;
        }


        public static DoublyLinkedListNode reverse(DoublyLinkedListNode head)  //next prev
        {

            if (head == null || head.next == null)   //empty or just 1 node
                return head;

            DoublyLinkedListNode P = head.next;
            DoublyLinkedListNode N = P.next;
            head.next = null;
            head.prev = P;

            while (N != null)
            {
                P.next = P.prev;
                P.prev = N;

                P = N;
                N = N.next;
            }

            P.next = P.prev;
            P.prev = null;

            return P;
        }


        public static int equalStacks(int[] h1, int[] h2, int[] h3)
        {
            var myDict = new Dictionary<int[], int>();
            myDict.Add(h1, h1.Length);
            myDict.Add(h2, h2.Length);
            myDict.Add(h3, h3.Length);

            int minArrSize = myDict.Min(i => i.Value);
            int[] minArr = myDict.First(i => i.Value == minArrSize).Key;
            myDict.Remove(myDict.First(i => i.Value == minArrSize).Key);

            int midArrSize = myDict.Min(i => i.Value);
            int[] midArr = myDict.First(i => i.Value == midArrSize).Key;
            myDict.Remove(myDict.First(i => i.Value == midArrSize).Key);

            int maxArrSize = myDict.Min(i => i.Value);
            int[] maxArr = myDict.First(i => i.Value == maxArrSize).Key;
            myDict.Remove(myDict.First(i => i.Value == maxArrSize).Key);

            var stack1 = new Stack<int>();
            stack1.Push(0);
            int lastSum = 0;
            for (int x = maxArr.Length - 1; x >= 0; x--)
            {
                int mySum = maxArr[x] + lastSum;
                lastSum = mySum;
                stack1.Push(mySum);
            }


            var stack2 = new Stack<int>();
            stack2.Push(0);
            lastSum = 0;
            for (int x = minArr.Length - 1; x >= 0; x--)
            {
                int mySum = minArr[x] + lastSum;
                lastSum = mySum;
                if (stack1.Contains(mySum))
                    stack2.Push(mySum);
                if (mySum > stack1.Peek())
                    x = 0;
            }

            if (stack2.Count == 2)
                return stack2.Pop();

            var stack3 = new Stack<int>();
            stack3.Push(0);
            lastSum = 0;
            for (int x = midArr.Length - 1; x >= 0; x--)
            {
                int mySum = midArr[x] + lastSum;
                lastSum = mySum;
                if (stack2.Contains(mySum))
                    stack3.Push(mySum);
                if (mySum > stack2.Peek())
                    x = 0;
            }
            Console.WriteLine("a");
            return stack3.Pop();
        }


        public static void MaxInStack(int n)
        {
            var myStack = new Stack<long>();
            var maxStack = new Stack<long>();
            long y;
            maxStack.Push(0);

            for (int a = 0; a < n; a++)
            {
                string myString = Console.ReadLine();
                string[] x = myString.Split(' ');

                if (x[0] == "1")
                {
                    y = long.Parse(x[1]);
                    myStack.Push(y);

                    if (y >= maxStack.Peek())
                        maxStack.Push(y);
                }
                else if (x[0] == "2")
                {
                    y = myStack.Pop();
                    if (y == maxStack.Peek())
                        maxStack.Pop();
                }
                else if (x[0] == "3")
                {
                    Console.WriteLine(maxStack.Peek());
                }

            }

        }


        public static string isBalanced(string s)
        {
            var bracketsLeft = new Dictionary<int, char>()
            {  { 0, '(' }, { 1, '{' }, { 2, '[' }  };
            var bracketsRight = new Dictionary<char, int>()
            {  { ')', 0 }, { '}', 1 }, { ']', 2 }  };

            int index;
            var myStack = new Stack<char>();

            for (int x = 0; x < s.Length; x++)
            {
                if (bracketsLeft.ContainsValue(s[x]))
                    myStack.Push(s[x]);

                if (bracketsRight.ContainsKey(s[x]))
                {
                    if (myStack.Count == 0)
                        return "NO";

                    index = bracketsRight[s[x]];
                    if (myStack.Peek() == bracketsLeft[index])  //myStack.Peek() == bracketsLeft.First(i=>i.Key==index).Value
                        myStack.Pop();
                    else
                        return "NO";
                }
            }

            if (myStack.Count == 0)
                return "YES";
            else
                return "NO";
        }


        public static int cookies(int k, int[] A)
        {
            int rounds = 0;
            int targetIndex = 0;
            Array.Sort(A);

            if (A[targetIndex] >= k)
                return rounds;

            while (targetIndex < A.Length - 1)
            {
                int cookieMix = A[targetIndex] + (2 * A[targetIndex + 1]);
                targetIndex++;
                A[targetIndex] = cookieMix;
                arrBubbleSort(A, targetIndex);
                rounds++;


                if (A[targetIndex] >= k)
                    return rounds;
            }
            return -1;

        }

        public static void arrBubbleSort(int[] A, int index)
        {
            while (index < A.Length - 1 && A[index] > A[index + 1])
            {
                int temp = A[index];
                A[index] = A[index + 1];
                A[index + 1] = temp;
                index++;
            }
        }


        public static void SimpleTextEditor(int q)
        {
            String mainText = null;
            var functionStack = new Stack<EditorFunctions>();
            int stringLength = 0;


            for (int a = 0; a < q; a++)
            {
                string myString = Console.ReadLine();
                string[] x = myString.Split(' ');

                int chosenFunction = int.Parse(x[0]);

                if (chosenFunction == 1)
                {
                    //append x[1] to mainText and add step to stack
                    mainText += x[1];
                    stringLength += x[1].Length;
                    functionStack.Push(new EditorFunctions(chosenFunction, x[1]));
                }
                else if (chosenFunction == 2)
                {
                    //delete last x[1] chars & add step to stack
                    string deletedText = mainText.Substring(stringLength - int.Parse(x[1]));
                    mainText = mainText.Substring(0, stringLength - int.Parse(x[1]));
                    stringLength -= int.Parse(x[1]);
                    functionStack.Push(new EditorFunctions(chosenFunction, deletedText));
                }
                else if (chosenFunction == 3)
                {
                    //print kth character
                    string toPrint = mainText.Substring(int.Parse(x[1]) - 1, 1);
                    Console.WriteLine(toPrint);
                }
                else if (chosenFunction == 4)
                {
                    //undo last step and remove step from stack
                    EditorFunctions undoFunction = functionStack.Pop();
                    if (undoFunction.Type == 1)
                    {
                        //undo an append (ie delete)
                        mainText = mainText.Substring(0, stringLength - undoFunction.Words.Length);
                        stringLength -= undoFunction.Words.Length;
                    }
                    else
                    {
                        //undo a delete (ie add)
                        mainText += undoFunction.Words;
                        stringLength += undoFunction.Words.Length;
                    }
                }

            }

        }

        class EditorFunctions
        {
            public int Type { get; private set; }
            public String Words { get; private set; }

            public EditorFunctions(int T, string S)
            {
                Type = T;
                Words = S;
            }
        }


        public static int poisonousPlants(int[] p)
        {
            var mainList = new List<Queue<int>>();
            var endOfQueueValue = new List<int>();

            int days = 0;

            //fill initial lists
            int subListNumber = 0;
            int index = 0;
            while (index < p.Length)
            {
                mainList.Add(new Queue<int>());
                do
                {
                    mainList[subListNumber].Enqueue(p[index]);
                    index++;
                }
                while (index < p.Length && p[index] < p[index - 1]);
                endOfQueueValue.Add(p[index - 1]);
                subListNumber++;
            }

            //pop lists
            bool keepGoing = true;
            while (keepGoing)
            {
                keepGoing = false;
                int numOfLists = mainList.Count();
                for (int x = 1; x < numOfLists; x++)
                {
                    if (mainList[x].Peek() > endOfQueueValue[x - 1])
                    {
                        mainList[x].Dequeue();
                        keepGoing = true;
                    }

                }

                //remove empty queues from list
                var removeList = new List<int>();
                for (int x = 0; x < numOfLists; x++)
                {
                    if (mainList[x].Count == 0)
                        removeList.Add(x);
                }
                for (int x = removeList.Count - 1; x >= 0; x--)
                {
                    mainList.RemoveAt(removeList[x]);
                    endOfQueueValue.RemoveAt(removeList[x]);
                }

                if (keepGoing)
                    days++;
            }

            return days;
        }



        public static int[] rotLeft(int[] a, int d)
        {
            int[] results = new int[a.Length];

            for (int x = 0; x < a.Length; x++)
            {
                int index = (x + d) % a.Length;
                results[x] = a[index];
            }

            return results;

        }


        public static void minimumBribes(int[] q)
        {
            int bribes = 0;
            int maxEncountered = 0;

            for (int i = 1; i <= q.Length; i++)  //1 indexed
            {
                int value = q[i - 1];
                maxEncountered = Math.Max(value, maxEncountered);
                if (value > i + 2)    //if # is more than 2 spaces ahead or original position => Too chaotic
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }
                else if (value < maxEncountered) //if any number has a larger # in front of it then it was bribed
                                                 //use bribee because bribor is limited to 2, but a bribee can be bribed unlimited times.
                {
                    for (int j = i - 1; j >= Math.Max(0, value - 1 - 2); j--)       //Math.Max(0, value-1-2)
                    {
                        if (q[j] > value)
                            bribes++;
                    }
                }
            }

            Console.WriteLine(bribes);
        }



        public static int minimumSwaps(int[] arr)
        {
            var myDict = new Dictionary<int, int>();
            for (int x = 1; x <= arr.Length; x++)
                myDict.Add(arr[x - 1], x);         //number, place in array

            var swappedDict = new Dictionary<int, int>();   //place in array, number

            int swaps = 0;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                //compare against swapDict if its been swapped (ie in the swapDict) or otherwise look in original array
                int currentCompareValue = swappedDict.ContainsKey(i + 1) ? swappedDict[i + 1] : arr[myDict.Count() - 1];

                if (currentCompareValue == myDict.Count())  //comparekey is what I see, need to compare with what should be there (myDict.count)
                {
                    //correct spot
                    myDict.Remove(i + 1);

                }
                else
                {
                    //wrong spot so swap with the correct value that should be here
                    int swapSpace = myDict[i + 1];  //where is the number I want to swap with
                    myDict[currentCompareValue] = swapSpace; //then move it to the place we are swapping with
                    myDict.Remove(i + 1);

                    //add current value to swapped dict so we know where it is
                    if (swappedDict.ContainsKey(swapSpace))
                        swappedDict[swapSpace] = currentCompareValue;
                    else
                        swappedDict.Add(swapSpace, currentCompareValue);

                    swaps++;
                }
            }
            return swaps;
        }



        public static long arrayManipulation(int n, int[][] queries)
        {
            long[] results = new long[n];
            int numQueries = queries.Length;

            for (int x = 0; x < numQueries; x++)
            {
                int a = queries[x][0];
                int b = queries[x][1];
                int k = queries[x][2];

                results[a - 1] += k;

                if (b < n)
                    results[b] -= k;
            }

            long[] resultsSummed = new long[n];
            resultsSummed[0] = results[0];

            for (int x = 1; x < n; x++)
            {
                resultsSummed[x] = resultsSummed[x - 1] + results[x];
            }

            return resultsSummed.Max();
        }


        public static void checkMagazine(string[] magazine, string[] note)
        {
            var myDict = new Dictionary<string, int>();

            foreach (string s in magazine)
            {
                if (myDict.ContainsKey(s))
                    myDict[s]++;
                else
                    myDict.Add(s, 1);
            }

            foreach (string s in note)
            {
                if (myDict.ContainsKey(s) && myDict[s] > 0)
                {
                    myDict[s]--;
                }
                else
                {
                    Console.WriteLine("No");
                    return;
                }
            }
            Console.WriteLine("Yes");
        }


        public static string twoStrings(string s1, string s2)
        {
            var myHash = new HashSet<Char>();
            int count = 0;

            //find one letter matches
            foreach (char c in s1)
            {
                if (!myHash.Contains(c))
                    myHash.Add(c);
            }

            foreach (char c in s2)
            {
                if (myHash.Contains(c))
                    count++;
            }

            if (count == 0)
                return "NO";
            else
                return "YES";
        }


        public static long countTripletsxxx(List<long> arr, long r)
        {
            long count = 0;
            long maxNumInArray = 0;

            var positionDict = new Dictionary<long, List<long>>();   //list of positions for each number

            for (int x = 0; x < arr.Count; x++)
            {
                if (positionDict.ContainsKey(arr[x]))
                {
                    positionDict[arr[x]].Add(x);
                }
                else
                {
                    positionDict.Add(arr[x], new List<long> { x });
                    if (arr[x] > maxNumInArray)
                        maxNumInArray = arr[x];
                }
            }

            long maxStartNumber = maxNumInArray / r / r;

            for (int x = 0; x < arr.Count; x++)
            {
                long a = arr[x];
                long b = a * r;
                long c = b * r;

                if (a <= maxStartNumber && positionDict.ContainsKey(b) && positionDict.ContainsKey(c) && positionDict[b].Any(y => y > x) && positionDict[c].Any(y => y > x))
                {
                    var bAfterAPositionList = positionDict[b].Where(i => i > x && i < arr.Count - 1).ToList();   //list of B positions where position is after A (excluding last 2 places)

                    long cAfterB = 0;
                    for (int y = 0; y < bAfterAPositionList.Count; y++)
                    {
                        cAfterB += positionDict[c].Count(j => j > bAfterAPositionList[y]);
                    }

                    count += cAfterB;
                }
            }
            return count;
        }



        public static long countTriplets(List<long> arr, long r)
        {
            Dictionary<long, long> As = new Dictionary<long, long>();    //step1 A's
            Dictionary<long, long> Bs = new Dictionary<long, long>();      //step2 AB's
            long count = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                long X = arr[i];
                long key = X / r;

                if (Bs.ContainsKey(key) && X % r == 0)          //if this is a C, look for AB's
                {
                    count += Bs[key];
                }

                if (As.ContainsKey(key) && X % r == 0)       //if this is a B, how many A's are waiting
                {
                    long c = As[key];
                    if (Bs.ContainsKey(X))
                        Bs[X] += c;
                    else
                        Bs.Add(X, c);
                }

                if (As.ContainsKey(X))                       //add to As
                    As[X]++;
                else
                    As.Add(X, 1);

            }
            return count;
        }


        public static int stringConstruction(string s)
        {
            int cost = 0;
            var myHash = new HashSet<char>();

            foreach (char c in s)
            {
                if (!myHash.Contains(c))
                {
                    cost++;
                    myHash.Add(c)
;
                }
            }
            return cost;
        }


        public static List<int> freqQuery(List<List<int>> queries)
        {
            List<int> results = new List<int>();
            Dictionary<int, int> data = new Dictionary<int, int>();
            Dictionary<int, int> counts = new Dictionary<int, int>();
            int count;

            for (int x = 0; x < queries.Count; x++)
            {
                int value = queries[x][1];

                switch (queries[x][0])
                {
                    case 1:
                        if (data.ContainsKey(value))
                            data[value]++;
                        else
                            data.Add(value, 1);

                        count = data[value];
                        if (counts.ContainsKey(count))
                            counts[count]++;
                        else
                        {
                            counts.Add(count, 1);
                        }

                        if (count - 1 != 0 && counts.ContainsKey(count - 1) && counts[count - 1] > 0)
                            counts[count - 1]--;

                        break;
                    case 2:
                        count = -1;
                        if (data.ContainsKey(value) && data[value] > 0)
                        {
                            data[value]--;
                            count = data[value];
                            counts[count + 1]--;
                        }

                        if (counts.ContainsKey(count))
                            counts[count]++;
                        else if (count != 0)
                            counts.Add(count, 1);





                        break;
                    case 3:
                        bool yesNo = (counts.ContainsKey(value) && counts[value] > 0);
                        if (yesNo)
                            results.Add(1);
                        else
                            results.Add(0);
                        break;
                }
            }

            return results;
        }


        public static void TaleOfTwoStacks(int n)
        {
            Queue<int> myQueue = new Queue<int>();

            for (int a = 0; a < n; a++)
            {
                string myString = Console.ReadLine();
                string[] x = myString.Split(' ');

                if (x[0] == "1")
                {
                    myQueue.Enqueue(int.Parse(x[1]));
                }
                else if (x[0] == "2")
                {
                    myQueue.Dequeue();
                }
                else if (x[0] == "3")
                {
                    Console.WriteLine(myQueue.Peek());
                }
            }
        }






















    }
}

