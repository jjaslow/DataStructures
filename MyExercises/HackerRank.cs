using Lucene.Net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;

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

        //TaleOfTwoStacks is one of the STDIN STDOUT templates; also leftRotations, ArrayAndSimpleQueries

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
                    int price = keyboardsSorted[x] + drivesSorted[y];
                    if (price <= b)
                    {
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

        public static void countSwaps(int[] a)
        {
            int count = 0;

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        count++;
                    }
                }
            }
            Console.WriteLine("Array is sorted in " + count + " swaps.");
            Console.WriteLine("First Element: " + a[0]);
            Console.WriteLine("Last Element: " + a[a.Length-1]);

        }

        public static int maximumToys(int[] prices, int k)
        {
            Array.Sort(prices);

            int gifts = 0;
            int totalSpent = 0;

            for(gifts=0; gifts< prices.Length; gifts++ )
            {
                if (totalSpent + prices[gifts] > k)
                    return gifts;
                else
                {
                    totalSpent += prices[gifts];
                }
            }
            return gifts;
        }

        public static int makeAnagram(string a, string b)
        {
            var dictA = new Dictionary<char, int>();
            var dictB = new Dictionary<char, int>();

            int count = 0;

            foreach(char x in a)
            {
                if (dictA.ContainsKey(x))
                    dictA[x]++;
                else
                    dictA.Add(x, 1);
            }

            foreach (char x in b)
            {
                if (dictA.ContainsKey(x) && dictA[x] > 0)
                {
                    dictA[x]--;
                }
                else if (dictA.ContainsKey(x) && dictA[x] == 0)
                {
                    count++;
                }
                else
                    count++;
            }
            count += dictA.Where(i => i.Value > 0).Sum(i => i.Value);
            return count;
        }


        public static int alternatingCharacters(string s)
        {
            int count = 0;

            for (int i=0; i<s.Length-1; i++)
            {
                if (s[i] == s[i + 1])
                    count++;
            }
            return count;
        }


        public static string isValid(string s)
        {
            var letterDict = new Dictionary<char, int>();

            for (int c = 0; c < s.Length; c++)
            {
                if (letterDict.ContainsKey(s[c]))
                    letterDict[s[c]]++;
                else
                    letterDict.Add(s[c], 1);
            }

            var countDict = new Dictionary<int, int>();

            foreach (int x in letterDict.Values)
            {
                if (countDict.ContainsKey(x))
                    countDict[x]++;
                else
                    countDict.Add(x, 1);
            }

            if (countDict.Count == 1)
                return "YES";
            else if (countDict.Count > 2)
                return "NO";
            else if (countDict.Values.Where(i=>i==1).Count() ==1)  //AND diff between keys ==1
            {
                int[] keys = countDict.Keys.ToArray();
                if ((keys[0] == 1 && countDict[0]==1)|| (keys[1] == 1 && countDict[1] == 1))
                    return "YES";
                else if (Math.Abs(keys[0] - keys[1]) > 1)
                    return "NO";
                else
                    return "YES";
            }
            else
                return "NO";
        }


        public static string twoArrays(int k, int[] A, int[] B)
        {
            Array.Sort(A);
            Array.Sort(B);

            int x = 0;
            int size = A.Length;

            while(x<size)
            {
                if (A[x] + B[size - 1 - x] < k)
                    return "NO";
                x++;
            }
            return "YES";
        }


        public static long substrCount(int n, string s)
        {
            long count = n;

            Stack<string> myStack = new Stack<string>();
            myStack.Push(s[0].ToString());
            string lastChar = s[0].ToString();

            string twoBack = "-";
            string currentChar;

            int lastCharInt;

            for (int i=1; i<n; i++)
            {
                currentChar = s[i].ToString();

                if (currentChar == lastChar)    //same char, so replace letter with number of times
                {
                    string myPop = myStack.Pop();
                    if (int.TryParse(myPop, out lastCharInt))
                    {
                        myStack.Push((lastCharInt + 1).ToString());
                    }
                    else
                    {
                        myStack.Push("2");
                    }
                        
                }
                else                        //different char so check and update twoBack char
                {
                    //string myPeek = myStack.Peek();
                    
                    if (twoBack==currentChar)
                    {
                        count += 1;
                        lastChar = currentChar;

                    }
                    else
                    {
                        twoBack = lastChar;
                        

                    }
                    
                    myStack.Push(currentChar);



                }



            }
            if(myStack.Count>0 && int.TryParse(myStack.Pop(), out lastCharInt))
            {
                count += (lastCharInt * (lastCharInt + 1) / 2) - lastCharInt;
            }
            return count;
        }


        public static long flippingBits(long n)
        {
            string final = "00000000000000000000000000000000";
            string number = Convert.ToString(n,2);
            int addZeroes = 32 - number.Length;

            final = String.Concat(final.Substring(0, addZeroes), number);

            StringBuilder sb = new StringBuilder();
            foreach(char c in final)
            {
                if(c=='0')
                    sb.Append(1);
                else
                    sb.Append(0);
            }
            final = sb.ToString();

            long result = Convert.ToInt64(final,2);
                
            Console.WriteLine(final);
            return result;
        }

        public static long strangeCounter(long t)
        {
            long roundsPassed = 0;
            long counter = 3;
            long timePassed = 0;

            while(timePassed < t - counter)
            {
                roundsPassed++;
                timePassed += counter;
                counter *= 2;
            }

            long result = counter + (timePassed - t) + 1;
            Console.WriteLine(result);
            return result;
        }



        public static int[] stones(int n, int a, int b)
        {
            var myHash = new HashSet<int>();
            int stepsToTake = n - 1;
            
            for(int x=0;x<n;x++)
            {
                int q = a * x;
                int w = b * (stepsToTake - x);
                int e = q + w;

                if (!myHash.Contains(e))
                    myHash.Add(e);
            }
            int[] results = myHash.ToArray();

            Array.Sort(results);
            return results;
        }


        public static string happyLadybugs(string b)
        {
            var myDict = new Dictionary<char, int>();

            foreach(char c in b)
            {
                if (myDict.ContainsKey(c))
                    myDict[c]++;
                else
                    myDict.Add(c, 1);
            }

            if (myDict.Any(i => i.Value == 1 && i.Key!='_'))  //cant make singles happy
                return "NO";

            if (myDict.ContainsKey('_') && myDict['_'] >= 1)    //need X spaces to make happy (unless they are already happy)
                return "YES";

            //else see if they are stuck but already happy
            for(int x=1; x<b.Length-1; x++)
            {
                if (!(b[x] == b[x - 1] || b[x] == b[x + 1]))
                    return "NO";
            }
            if (b[0] != b[1] || b[b.Length - 1] != b[b.Length - 2])
                return "NO";
            else
                return "YES";

        }


        public static string[] cavityMap(string[] grid)
        {
            string[] resultGrid = new string[grid.Length];
            for (int x = 0; x < grid.Length; x++)
                resultGrid[x] = grid[x];

            int height = grid.Length;
            int width = grid[0].Length;

            StringBuilder sb = new StringBuilder();

            for(int q=1; q<grid.Length-1;q++)   //rows
            {
                sb.Append(grid[q][0].ToString());
                for(int w=1; w<grid[0].Length-1; w++)
                {
                    int thisCell = int.Parse(grid[q][w].ToString());

                    int up = int.Parse(grid[q-1][w].ToString());
                    int down = int.Parse(grid[q+1][w].ToString());
                    int right = int.Parse(grid[q][w+1].ToString());
                    int left = int.Parse(grid[q][w-1].ToString());

                    if (thisCell > up && thisCell > down && thisCell > right && thisCell > left)
                        sb.Append('X');
                    else
                        sb.Append(grid[q][w]);
                }

                sb.Append(grid[q][width-1].ToString());
                resultGrid[q] = sb.ToString();
                sb.Clear();
            }
            return resultGrid;
        }


        public static void almostSorted(int[] arr)
        {
            int leftIndex = 0; 
            int rightIndex = 0;
            bool startedDown = false;
            bool foundOneSwap = false;

            for(int x=0; x<arr.Length-1; x++)
            {
                if(arr[x+1]<arr[x] && !startedDown && !foundOneSwap)    //next index is smaller so we 'start down'
                {
                    leftIndex = x;
                    rightIndex = x+1;
                    startedDown = true;
                }
                else if (startedDown && arr[x + 1] > arr[x])  //if started down, look for back up
                {
                    if(arr[x + 1] < arr[leftIndex]) //goes up, but not enough for a reverse
                    {
                        Console.WriteLine("no");
                        return;
                    }
                    else                            //did one reverse
                    {
                        rightIndex = x;
                        foundOneSwap = true;
                        startedDown = false;
                    }
                }
                else if(arr[x + 1] < arr[x] && foundOneSwap)    //if found one and goes back up then NO
                {
                    Console.WriteLine("no");
                    return;
                }
            }
            
            if(startedDown && !foundOneSwap)
            {
                if(rightIndex==arr.Length-1 || arr[arr.Length - 1] > arr[leftIndex])
                {
                    foundOneSwap = true;
                    //leftIndex = arr.Length;
                }
                if (leftIndex > 0 && arr[arr.Length - 1] > arr[leftIndex - 1])
                {
                    foundOneSwap = true;
                    rightIndex = arr.Length - 1;
                }
                    
            }

            if (!foundOneSwap)                        //(rightIndex==arr.Length || arr[leftIndex+1]<arr[rightIndex])
            {
                Console.WriteLine("no");
                return;
            }

            Console.WriteLine("yes");

            if (foundOneSwap || rightIndex + 1 == arr.Length)
            {
                if(rightIndex-leftIndex ==1)
                {
                    Console.WriteLine("swap " + (leftIndex + 1) + " " + (rightIndex + 1));
                }
                else
                {
                    Console.WriteLine("reverse " + (leftIndex + 1) + " " + (rightIndex + 1));
                }
            }
        }


        public static int flatlandSpaceStations(int n, int[] c)
        {
            Array.Sort(c);
            int maxDistance = Math.Max(c[0], n-c[c.Length-1]-1);

            for(int x=0; x<c.Length-1;x++)
            {
                int y = (c[x + 1] - c[x]) / 2;
                if (y > maxDistance)
                    maxDistance = y;
            }


            Console.WriteLine(maxDistance);
            return maxDistance;
        }

        static int fairRations(int[] B)
        {
            int loaves = 0;

            for(int x=0; x<B.Length-1; x++)
            {
                if(B[x]%2==1) //is this odd?
                {
                    B[x]++;
                    B[x+1]++;
                    loaves += 2;
                }
            }
            if (B[B.Length-1] % 2 == 0)
            {
                Console.WriteLine(loaves.ToString());
                return loaves;
            }
            else
            {
                Console.WriteLine("NO");
                return -1;
            }
                


        }


        public static void xxwhatFlavors(int[] cost, int money)
        {
            var countDict = new Dictionary<int, List<int>>();    //price, list of indices
            for(int x=0; x<cost.Length; x++)
            {
                if (countDict.ContainsKey(cost[x]))
                    countDict[cost[x]].Add(x);
                else
                {
                    countDict.Add(cost[x], new List<int>());
                    countDict[cost[x]].Add(x);
                }    
            }

            int remainderAfterOne, a, b, temp;
            foreach (KeyValuePair<int, List<int>> x in countDict)
            {
                remainderAfterOne = money - x.Key;
            
                if (countDict.ContainsKey(remainderAfterOne) && countDict[x.Key][0] != countDict[remainderAfterOne][0])      //matching 2nd ice cream  && myHash[x.Key].Count == 1
                {
                    a = countDict[x.Key][0] + 1;
                    b = countDict[remainderAfterOne][0] + 1;
                    if (a > b)
                    {
                        temp = a;
                        a = b;
                        b = temp;
                    }
                    Console.WriteLine(a + " " + b);
                    return;
                }
            
                else if (x.Key == remainderAfterOne && countDict[x.Key].Count > 1)    //2 of the same that match
                {
                    a = countDict[x.Key][0] + 1;
                    b = countDict[x.Key][1] + 1;
                    if (a > b)
                    {
                        temp = a;
                        a = b;
                        b = temp;
                    }
                    Console.WriteLine(a + " " + b);
                    return;
                }
            }
        }


        public static void xxxwhatFlavors(int[] cost, int money)
        {
            var countDict = new Dictionary<int, int>();    //price, index

            for (int x = 0; x < cost.Length; x++)
            {
                if (countDict.ContainsKey(money - cost[x]))         //match
                {
                    Console.WriteLine((countDict[money - cost[x]] + 1) + " " + (x + 1));
                    return;
                }
                else if(!countDict.ContainsKey(cost[x]))                                                    //otherwise add price and index to dict
                {
                    countDict.Add(cost[x], x);
                }
            }
        }


        static int pairs(int k, int[] arr)
        {
            HashSet<int> myHash = new HashSet<int>();
            foreach (int i in arr)
                myHash.Add(i);

            int count = 0;

            foreach (int i in myHash)
            {
                int compliment = i + k;
                if (myHash.Contains(compliment))
                    count++;
            }

            return count;
        }


        public static long triplets(int[] d, int[] e, int[] f)
        {
            int[] a = d.Distinct().OrderBy(i=>i).ToArray();
            int[] b = e.Distinct().OrderBy(i => i).ToArray();
            int[] c = f.Distinct().OrderBy(i => i).ToArray();


            for (int x = 0; x < a.Length; x++)
            {
                
                int q = BinarySearchIterativeMax(c, a[x]);        //get index of #s > value (-1 if no values) //how many #s in next array are >= to me
                if (q == -1)
                    a[x] = 0;
                else
                    a[x] = c.Length - q;
            }

            for (int x = 0; x < c.Length; x++)
            {
                int q = BinarySearchIterativeMax(b, c[x]);        //get index of #s > value (-1 if no values) //how many #s in next array are >= to me
                if (q == -1)
                    c[x] = 0;
                else
                    c[x] = b.Length - q;
            }

            long count = 0;
            int countTouse = Math.Min(a.Length, c.Length);

            for(int x = 0; x< countTouse; x++)
            {
                count += a[x]*c[x];
            }
            return count;
        }
        public static int BinarySearchIterativeMax(int[] list, int value)        //get index of #s > value (-1 if no values)
        {
            int left = 0;
            int right = list.Length - 1;

            while (value != list[(left + right) / 2])
            {
                int middle = (left + right) / 2;

                if (left >= right)
                {
                    if (value > list[right])
                        return -1;
                    else
                        return left;   // -1;
                }
                    
                if (value < list[middle])
                    right = middle; // - 1;
                else
                    left = middle + 1;

            }
            return (left + right) / 2;
        }


        public static int buildString(int a, int b, string s)
        {
            StringBuilder myString = new StringBuilder();
            StringBuilder appender = new StringBuilder();

            //add first letter and charge A for it
            myString.Append(s[0].ToString());
            int price = a;

            int index = 1;
            while(myString.Length < s.Length)
            {
                do
                {
                    appender.Append(s[index++]);
                }
                while (myString.Length + appender.Length < s.Length && myString.ToString().Contains(appender.ToString() + s[index]));
                                

                //calculate price here
                int singlePrice = appender.Length * a;
                int substringPrice = b;
                price += singlePrice < substringPrice ? singlePrice : substringPrice;

                myString.Append(appender);
                appender.Clear();
            }
            Console.WriteLine(price);
            return price;
        }


        public static void ArrayAndSimpleQueriesMAIN(String[] args)     //this would be the    static void Main entrypoint
        {
            System.IO.TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nm = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(nm[0]); //array length
            int m = Convert.ToInt32(nm[1]); //# of queries

            int[] inputArray = Array.ConvertAll(Console.ReadLine().Split(' '), inputTemp => Convert.ToInt32(inputTemp));

            int[][] queriesArray = new int[m][];
            for (int x = 0; x < m; x++)
            {
                queriesArray[x] = Array.ConvertAll(Console.ReadLine().Split(' '), nTemp => Convert.ToInt32(nTemp));
            }

            ArrayAndSimpleQueries(inputArray, queriesArray);
            textWriter.Flush();
            textWriter.Close();
        }

        public static void ArrayAndSimpleQueries(int[] input, int[][] queries)  //xxxxx
        {
            LinkedList<int> frontList = new LinkedList<int>();
            LinkedList<int> endList = new LinkedList<int>();
            int adjustedIndex = 0;

            for (int x=0; x<queries.Length; x++)
            {
                int queryType = queries[x][0];
                int startIndex = queries[x][1]-1;
                int endIndex = queries[x][2]-1;

                if (queryType==1)   //add block to front
                {
                    for(int y=endIndex; y>=startIndex;y--)
                    {
                        //adjustedIndex
                        frontList.AddFirst(input[y+adjustedIndex]);
                        input[y+adjustedIndex] = -1;
                    }

                }
                else            //add block to end
                {
                    for (int y = startIndex; y <= startIndex; y++)
                    {
                        //adjustedIndex
                        endList.AddLast(input[y+adjustedIndex]);
                        input[y+adjustedIndex] = -1;
                    }


                }


            }
          
        }



        public static int[] waiter(int[] number, int q)
        {
            #region PrimeNumbers
            int[] primeNumbers = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997, 1009, 1013, 1019, 1021, 1031, 1033, 1039, 1049, 1051, 1061, 1063, 1069, 1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151, 1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223, 1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289, 1291, 1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373, 1381, 1399, 1409, 1423, 1427, 1429, 1433, 1439, 1447, 1451, 1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511, 1523, 1531, 1543, 1549, 1553, 1559, 1567, 1571, 1579, 1583, 1597, 1601, 1607, 1609, 1613, 1619, 1621, 1627, 1637, 1657, 1663, 1667, 1669, 1693, 1697, 1699, 1709, 1721, 1723, 1733, 1741, 1747, 1753, 1759, 1777, 1783, 1787, 1789, 1801, 1811, 1823, 1831, 1847, 1861, 1867, 1871, 1873, 1877, 1879, 1889, 1901, 1907, 1913, 1931, 1933, 1949, 1951, 1973, 1979, 1987, 1993, 1997, 1999, 2003, 2011, 2017, 2027, 2029, 2039, 2053, 2063, 2069, 2081, 2083, 2087, 2089, 2099, 2111, 2113, 2129, 2131, 2137, 2141, 2143, 2153, 2161, 2179, 2203, 2207, 2213, 2221, 2237, 2239, 2243, 2251, 2267, 2269, 2273, 2281, 2287, 2293, 2297, 2309, 2311, 2333, 2339, 2341, 2347, 2351, 2357, 2371, 2377, 2381, 2383, 2389, 2393, 2399, 2411, 2417, 2423, 2437, 2441, 2447, 2459, 2467, 2473, 2477, 2503, 2521, 2531, 2539, 2543, 2549, 2551, 2557, 2579, 2591, 2593, 2609, 2617, 2621, 2633, 2647, 2657, 2659, 2663, 2671, 2677, 2683, 2687, 2689, 2693, 2699, 2707, 2711, 2713, 2719, 2729, 2731, 2741, 2749, 2753, 2767, 2777, 2789, 2791, 2797, 2801, 2803, 2819, 2833, 2837, 2843, 2851, 2857, 2861, 2879, 2887, 2897, 2903, 2909, 2917, 2927, 2939, 2953, 2957, 2963, 2969, 2971, 2999, 3001, 3011, 3019, 3023, 3037, 3041, 3049, 3061, 3067, 3079, 3083, 3089, 3109, 3119, 3121, 3137, 3163, 3167, 3169, 3181, 3187, 3191, 3203, 3209, 3217, 3221, 3229, 3251, 3253, 3257, 3259, 3271, 3299, 3301, 3307, 3313, 3319, 3323, 3329, 3331, 3343, 3347, 3359, 3361, 3371, 3373, 3389, 3391, 3407, 3413, 3433, 3449, 3457, 3461, 3463, 3467, 3469, 3491, 3499, 3511, 3517, 3527, 3529, 3533, 3539, 3541, 3547, 3557, 3559, 3571, 3581, 3583, 3593, 3607, 3613, 3617, 3623, 3631, 3637, 3643, 3659, 3671, 3673, 3677, 3691, 3697, 3701, 3709, 3719, 3727, 3733, 3739, 3761, 3767, 3769, 3779, 3793, 3797, 3803, 3821, 3823, 3833, 3847, 3851, 3853, 3863, 3877, 3881, 3889, 3907, 3911, 3917, 3919, 3923, 3929, 3931, 3943, 3947, 3967, 3989, 4001, 4003, 4007, 4013, 4019, 4021, 4027, 4049, 4051, 4057, 4073, 4079, 4091, 4093, 4099, 4111, 4127, 4129, 4133, 4139, 4153, 4157, 4159, 4177, 4201, 4211, 4217, 4219, 4229, 4231, 4241, 4243, 4253, 4259, 4261, 4271, 4273, 4283, 4289, 4297, 4327, 4337, 4339, 4349, 4357, 4363, 4373, 4391, 4397, 4409, 4421, 4423, 4441, 4447, 4451, 4457, 4463, 4481, 4483, 4493, 4507, 4513, 4517, 4519, 4523, 4547, 4549, 4561, 4567, 4583, 4591, 4597, 4603, 4621, 4637, 4639, 4643, 4649, 4651, 4657, 4663, 4673, 4679, 4691, 4703, 4721, 4723, 4729, 4733, 4751, 4759, 4783, 4787, 4789, 4793, 4799, 4801, 4813, 4817, 4831, 4861, 4871, 4877, 4889, 4903, 4909, 4919, 4931, 4933, 4937, 4943, 4951, 4957, 4967, 4969, 4973, 4987, 4993, 4999, 5003, 5009, 5011, 5021, 5023, 5039, 5051, 5059, 5077, 5081, 5087, 5099, 5101, 5107, 5113, 5119, 5147, 5153, 5167, 5171, 5179, 5189, 5197, 5209, 5227, 5231, 5233, 5237, 5261, 5273, 5279, 5281, 5297, 5303, 5309, 5323, 5333, 5347, 5351, 5381, 5387, 5393, 5399, 5407, 5413, 5417, 5419, 5431, 5437, 5441, 5443, 5449, 5471, 5477, 5479, 5483, 5501, 5503, 5507, 5519, 5521, 5527, 5531, 5557, 5563, 5569, 5573, 5581, 5591, 5623, 5639, 5641, 5647, 5651, 5653, 5657, 5659, 5669, 5683, 5689, 5693, 5701, 5711, 5717, 5737, 5741, 5743, 5749, 5779, 5783, 5791, 5801, 5807, 5813, 5821, 5827, 5839, 5843, 5849, 5851, 5857, 5861, 5867, 5869, 5879, 5881, 5897, 5903, 5923, 5927, 5939, 5953, 5981, 5987, 6007, 6011, 6029, 6037, 6043, 6047, 6053, 6067, 6073, 6079, 6089, 6091, 6101, 6113, 6121, 6131, 6133, 6143, 6151, 6163, 6173, 6197, 6199, 6203, 6211, 6217, 6221, 6229, 6247, 6257, 6263, 6269, 6271, 6277, 6287, 6299, 6301, 6311, 6317, 6323, 6329, 6337, 6343, 6353, 6359, 6361, 6367, 6373, 6379, 6389, 6397, 6421, 6427, 6449, 6451, 6469, 6473, 6481, 6491, 6521, 6529, 6547, 6551, 6553, 6563, 6569, 6571, 6577, 6581, 6599, 6607, 6619, 6637, 6653, 6659, 6661, 6673, 6679, 6689, 6691, 6701, 6703, 6709, 6719, 6733, 6737, 6761, 6763, 6779, 6781, 6791, 6793, 6803, 6823, 6827, 6829, 6833, 6841, 6857, 6863, 6869, 6871, 6883, 6899, 6907, 6911, 6917, 6947, 6949, 6959, 6961, 6967, 6971, 6977, 6983, 6991, 6997, 7001, 7013, 7019, 7027, 7039, 7043, 7057, 7069, 7079, 7103, 7109, 7121, 7127, 7129, 7151, 7159, 7177, 7187, 7193, 7207, 7211, 7213, 7219, 7229, 7237, 7243, 7247, 7253, 7283, 7297, 7307, 7309, 7321, 7331, 7333, 7349, 7351, 7369, 7393, 7411, 7417, 7433, 7451, 7457, 7459, 7477, 7481, 7487, 7489, 7499, 7507, 7517, 7523, 7529, 7537, 7541, 7547, 7549, 7559, 7561, 7573, 7577, 7583, 7589, 7591, 7603, 7607, 7621, 7639, 7643, 7649, 7669, 7673, 7681, 7687, 7691, 7699, 7703, 7717, 7723, 7727, 7741, 7753, 7757, 7759, 7789, 7793, 7817, 7823, 7829, 7841, 7853, 7867, 7873, 7877, 7879, 7883, 7901, 7907, 7919, 7927, 7933, 7937, 7949, 7951, 7963, 7993, 8009, 8011, 8017, 8039, 8053, 8059, 8069, 8081, 8087, 8089, 8093, 8101, 8111, 8117, 8123, 8147, 8161, 8167, 8171, 8179, 8191, 8209, 8219, 8221, 8231, 8233, 8237, 8243, 8263, 8269, 8273, 8287, 8291, 8293, 8297, 8311, 8317, 8329, 8353, 8363, 8369, 8377, 8387, 8389, 8419, 8423, 8429, 8431, 8443, 8447, 8461, 8467, 8501, 8513, 8521, 8527, 8537, 8539, 8543, 8563, 8573, 8581, 8597, 8599, 8609, 8623, 8627, 8629, 8641, 8647, 8663, 8669, 8677, 8681, 8689, 8693, 8699, 8707, 8713, 8719, 8731, 8737, 8741, 8747, 8753, 8761, 8779, 8783, 8803, 8807, 8819, 8821, 8831, 8837, 8839, 8849, 8861, 8863, 8867, 8887, 8893, 8923, 8929, 8933, 8941, 8951, 8963, 8969, 8971, 8999, 9001, 9007, 9011, 9013, 9029, 9041, 9043, 9049, 9059, 9067, 9091, 9103, 9109, 9127, 9133, 9137, 9151, 9157, 9161, 9173, 9181, 9187, 9199, 9203, 9209, 9221, 9227, 9239, 9241, 9257, 9277, 9281, 9283, 9293, 9311, 9319, 9323, 9337, 9341, 9343, 9349, 9371, 9377, 9391, 9397, 9403, 9413, 9419, 9421, 9431, 9433, 9437, 9439, 9461, 9463, 9467, 9473, 9479, 9491, 9497, 9511, 9521, 9533, 9539, 9547, 9551, 9587, 9601, 9613, 9619, 9623, 9629, 9631, 9643, 9649, 9661, 9677, 9679, 9689, 9697, 9719, 9721, 9733 };
            #endregion

            Stack<int>[] queueA = new Stack<int>[q+1];
            Stack<int>[] queueB = new Stack<int>[q+1];

            //populate A[0]
            queueA[0] = new Stack<int>();
            for (int x = 0; x < number.Length; x++)
                queueA[0].Push(number[x]);

            for(int iteration = 1; iteration<=q; iteration++)
            {
                queueA[iteration] = new Stack<int>();  //queue A
                queueB[iteration] = new Stack<int>();  //queue B
                int myPrimeNumber = primeNumbers[iteration-1];

                int index2 = queueA[iteration - 1].Count;
                for (int w = 0; w<index2; w++)
                {
                    int numToTest = queueA[iteration - 1].Pop();
                    if (numToTest % myPrimeNumber == 0)
                        queueB[iteration].Push(numToTest);
                    else
                        queueA[iteration].Push(numToTest);
                }
            }

            var resultsList = new List<int>();
            for(int y=1; y<q+1; y++)
            {
                while(queueB[y].Count>0)
                    resultsList.Add(queueB[y].Pop());
            }

            while (queueA[q].Count > 0)
                resultsList.Add(queueA[q].Pop());

            return resultsList.ToArray();
        }


        public static long largestRectangle(int[] h)          //  xxxxx
        {
            Stack<int> myStack = new Stack<int>();
            myStack.Push(h[0]);

            int minHeightInStack = h[0];
            long maxSizeSoFar = h[0];

            for(int x=1; x<h.Length; x++)
            {
                long currentSize = minHeightInStack * myStack.Count;

                if(h[x] >= currentSize + minHeightInStack)
                {
                    myStack.Clear();
                    myStack.Push(h[x]);
                    minHeightInStack = h[x];
                    maxSizeSoFar = h[x];
                }
                else if(h[x] < minHeightInStack)
                {
                    long newPotentialSize = (myStack.Count + 1) * h[x];
                    if(newPotentialSize > currentSize)
                    {
                        maxSizeSoFar = newPotentialSize;
                        minHeightInStack = h[x];
                        myStack.Push(h[x]);
                    }
                    else
                    {
                        myStack.Clear();
                        myStack.Push(h[x]);
                        minHeightInStack = h[x];
                    }
                }
                else
                {
                    myStack.Push(h[x]);
                }

            }

            return 5;
        }


        /* for BoxOperations Main method
        string[] nq = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(nq[0]);
        int q = Convert.ToInt32(nq[1]);

        long[] box = Array.ConvertAll(Console.ReadLine().Split(' '), boxTemp => Convert.ToInt32(boxTemp))
        ;
        // Write Your Code Here
        long[][] queries = new long[q][];
            for (int x = 0; x < q; x++)
            {
                queries[x] = Array.ConvertAll(Console.ReadLine().Split(' '), nTemp => Convert.ToInt64(nTemp));
            }

           BoxOperations(box, queries); 
         */
        public static void BoxOperations(long[] boxes, long[][] queries)
        {
            long[] Ones = new long[boxes.Length];
            long minAdjusted = -1;
            long maxAdjusted = -1;
            long res;

            for(long x =0; x<queries.Length; x++)
            {
                long queryType = queries[x][0];
                switch (queryType)
                {
                    case 1:
                        Ones[queries[x][1]] += queries[x][3];
                        if (queries[x][2] + 1 != boxes.Length)
                            Ones[queries[x][2] + 1] -= queries[x][3];
                        else
                            queries[x][2]--;

                        //track range of adjusted values, needed to do query 2s
                        if (minAdjusted == -1)
                        {
                            minAdjusted = queries[x][1];
                            maxAdjusted = queries[x][2] + 1;
                        }
                        else
                        {
                            if (queries[x][1] < minAdjusted)
                                minAdjusted = queries[x][1];
                            if (queries[x][2] > maxAdjusted+1)
                                maxAdjusted = queries[x][2]+1;
                        }
                        break;
                    case 2:
                        if(minAdjusted!=-1)
                        {
                            UpdateBoxArray(boxes, Ones, minAdjusted, maxAdjusted);
                            minAdjusted = -1; //reset ranges to un adjusted values
                            maxAdjusted = -1;
                            Array.Clear(Ones, 0, Ones.Length);
                        }
                        FloorBoxArray(boxes, queries[x][3], queries[x][1], queries[x][2]);
                        break;
                    case 3:
                        if (minAdjusted != -1)
                        {
                            UpdateBoxArray(boxes, Ones, minAdjusted, maxAdjusted);
                            minAdjusted = -1; //reset ranges to un adjusted values
                            maxAdjusted = -1;
                            Array.Clear(Ones, 0, Ones.Length);
                        }
                        res = boxes.Skip((int)queries[x][1]).Take((int)queries[x][2] - (int)queries[x][1]+1).Min();
                        Console.WriteLine(res);
                        break;
                    case 4:
                        if (minAdjusted != -1)
                        {
                            UpdateBoxArray(boxes, Ones, minAdjusted, maxAdjusted);
                            minAdjusted = -1; //reset ranges to un adjusted values
                            maxAdjusted = -1;
                            Array.Clear(Ones, 0, Ones.Length);
                        }
                        res = boxes.Skip((int)queries[x][1]).Take((int)queries[x][2] - (int)queries[x][1]+1).Sum();
                        Console.WriteLine(res);
                        break;
                }
            }
        }

        private static void UpdateBoxArray(long[] boxes, long[]Ones, long min, long max)
        {
            boxes[min] += Ones[min];
            for(long x = min+1; x<=max; x++)
            {
                Ones[x] = Ones[x - 1] + Ones[ x];
                boxes[x] += Ones[x];
            }
        }

        private static void FloorBoxArray(long[] boxes, long d, long min, long max)
        {
            for (long x = min; x <= max; x++)
            {
                boxes[x] = (long)Math.Floor((decimal)boxes[x] / d);
            }
        }


        public static int restaurant(int l, int b)
        {
            List<int> lList = new List<int>();
            List<int> bList = new List<int>();

            for(int x=1; x <= l / x; x++)
            {
                if(l/x == ((decimal)l / (decimal)x))
                {
                    lList.Add(x);
                    if(x!=l/x)
                        lList.Add(l / x);
                }
            }

            for (int x = 1; x <= b / x; x++)
            {
                if (b / x == ((decimal)b / (decimal)x))
                {
                    bList.Add(x);
                    if (x != b / x)
                        bList.Add(b / x);
                }
            }

            lList.Sort();
            bList.Sort();

            int GCF = lList.Where(i => bList.Contains(i)).Max();

            return l / GCF * b / GCF;
        }


        static int[] jimOrders(int[][] orders)
        {
            Dictionary<int, List<int>> customerTimesDict = new Dictionary<int, List<int>>();

            for (int x = 0; x<orders.Length; x++)
            {
                int orderTime = orders[x][0] + orders[x][1];

                if (customerTimesDict.ContainsKey(orderTime))
                    customerTimesDict[orderTime].Add(x+1);
                else
                    customerTimesDict.Add(orderTime, new List<int>() {x+1 });
            }

            int[] times = customerTimesDict.Keys.ToArray();
            Array.Sort(times);

            List<int> results = new List<int>();

            foreach(int time in times)
            {
                results.AddRange(customerTimesDict[time]);
            }

            return results.ToArray();
        }


        public static int toys(int[] w)
        {
            var myHash = new HashSet<int>();

            foreach (int i in w)
                myHash.Add(i);

            int[] myArr = myHash.ToArray();
            Array.Sort(myArr);

            int result = 0;
            int index = 0;

            do
            {
                int weight = myArr[index];
                result++;
                while (index + 1 < myArr.Length && myArr[index + 1] <= weight + 4)
                    index++;
                index++;
            } 
            while (index<myArr.Length);

            return result;
        }


        public static void decentNumber(int n)
        {
            int fives = n / 3;                       //3      //  2
            int threesMod = (n-(fives*3)) % 5;       //2    //

            while(threesMod != 0)
            {
                fives--;
                threesMod = (n - (fives * 3)) % 5;
                if(fives<0)
                {
                    Console.WriteLine(-1);
                    return;
                }
            }

            threesMod = n - (fives * 3);

            StringBuilder sb = new StringBuilder();
            for(int x=0;x<fives;x++)
                sb.Append("555");
            for (int x = 0; x < threesMod; x++)
                sb.Append("3");

            Console.WriteLine(sb.ToString());
        }


        static int[] closestNumbers(int[] arr)
        {

            Array.Sort(arr);
            int smallestDifference = int.MaxValue;

            List<int> results = new List<int>();

            for(int x=0; x<arr.Length-1; x++)
            {
                if (arr[x + 1] - arr[x] < smallestDifference)
                {
                    results.Clear();
                    results.Add(arr[x]);
                    results.Add(arr[x + 1]);
                    smallestDifference = arr[x + 1] - arr[x];
                }
                else if (arr[x + 1] - arr[x] == smallestDifference)
                {
                    results.Add(arr[x]);
                    results.Add(arr[x + 1]);
                }
            }

            return results.ToArray();

        }


        public static int beautifulPairs(int[] A, int[] B)
        {
            Dictionary<int, int> dictA = new Dictionary<int, int>();    //number, count
 

            foreach(int i in A)
            {
                if (dictA.ContainsKey(i))
                    dictA[i]++;
                else
                    dictA.Add(i, 1);
            }

            int pairs = 0;

            foreach(int i in B)
            {
                if(dictA.ContainsKey(i) && dictA[i]>0)
                {
                    dictA[i]--;
                    pairs++;
                }
            }

            int qq = dictA.Sum(i => i.Value);

            if ( qq > 0)
                return pairs + 1;
            else
                return pairs-1;
        }

        public static string funnyString(string s)
        {
            int[] a = new int[s.Length-1];
            int[] b = new int[s.Length-1];

            for(int x=0; x<s.Length-1; x++)
            {
                a[x] = Math.Abs(s[x+1] - s[x]);
                b[x] = Math.Abs(s[x + 1] - s[x]);
            }

            Array.Reverse(b);

            for(int x=0; x<a.Length; x++)
            {
                if (a[x] != b[x])
                    return "Not Funny";
            }
            return "Funny";
        }



        static int findMedian(int[] arr)
        {
            Array.Sort(arr);
            int len = arr.Length;
            int index = len / 2;
            return arr[index];
        }

        static int[] countingSort(int[] arr)
        {
            int[] counter = new int[100];

            foreach (int i in arr)
                counter[i]++;

            return counter;

        }


        public static int workbook(int n, int k, int[] arr)
        {
            int startingPage = 0;
            int endingPage = 0;

            int specialProblems = 0;

            for(int x = 0; x<arr.Length; x++)
            {
                startingPage = endingPage+1;
                endingPage += (int)Math.Ceiling((double)arr[x] / k);

                for(int y = 1; y<=arr[x]; y++)
                {
                    if (y ==  (y-1)/k + startingPage)
                        specialProblems++;
                }
            }
            return specialProblems;
        }



        static string gameOfThrones(string s)
        {
            var myDict = new Dictionary<char, int>();

            foreach (char ch in s)
            {
                if (myDict.ContainsKey(ch))
                    myDict[ch]++;
                else
                    myDict.Add(ch, 1);
            }

            int odds = 0;
            foreach(KeyValuePair<char, int> kvp in myDict)
            {
                if (kvp.Value % 2 != 0)
                    odds++;
            }

            if (odds <= 1)
                return "YES";
            else
                return "NO";
        }


        public static int[] missingNumbers(int[] arr, int[] brr)   //brr original
        {
            var myDict = new Dictionary<int, int>();
            foreach(int i in brr)
            {
                if (myDict.ContainsKey(i))
                    myDict[i]++;
                else
                    myDict.Add(i, 1);
            }

            foreach (int i in arr)
            {
                myDict[i]--;
                if (myDict[i] == 0)
                    myDict.Remove(i);
            }

            var resultsList = new List<int>();

            foreach (KeyValuePair<int,int> kvp in myDict)
            {
                resultsList.Add(kvp.Key);

            }

            int[] results = resultsList.ToArray();
            Array.Sort(results);
            return results;
        }



        public static void MeanMedianMode()
        {
            System.IO.TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = int.Parse(Console.ReadLine());
            int[] data = Array.ConvertAll(Console.ReadLine().Split(' '), inputTemp => Convert.ToInt32(inputTemp));
            Array.Sort(data);

            //mean
            decimal mean = (decimal)data.Sum(i => i) / (decimal)n;
            textWriter.WriteLine(Math.Round(mean, 1));    

            //median
            if (n%2==1)                     //odd
                textWriter.WriteLine((decimal)data[data.Length / 2]);     
            else
            {                               //even
                int a = data[data.Length / 2];
                int b = data[(data.Length / 2) - 1];
                decimal median = (decimal)(((decimal)a + (decimal)b) / 2);
                textWriter.WriteLine(Math.Round(median, 1));
            }


            //mode
            var myDict = new Dictionary<int, int>();
            foreach(int i in data)
            {
                if (myDict.ContainsKey(i))
                    myDict[i]++;
                else
                    myDict.Add(i, 1);
            }

            int maxCount = myDict.Max(i => i.Value);
            int mode = myDict.Where(i => i.Value == maxCount).OrderBy(i => i.Key).First().Key;
            
            //int mode = myDict.OrderBy(i => i.Value).OrderBy(i => i.Key).First().Key;

            textWriter.WriteLine(mode);

            textWriter.Flush();
            textWriter.Close();
        }   //stats 1


        public static void WeightedMean()
        {
            System.IO.TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = int.Parse(Console.ReadLine());
            int[] values = Array.ConvertAll(Console.ReadLine().Split(' '), inputTemp => Convert.ToInt32(inputTemp));
            int[] weights = Array.ConvertAll(Console.ReadLine().Split(' '), inputTemp => Convert.ToInt32(inputTemp));

            decimal sums = 0;
            for(int x=0; x<n; x++)
            {
                sums += ((decimal)values[x] * (decimal)weights[x]);
            }

            decimal totalWeights = weights.Sum();

            decimal result = sums / totalWeights;


            textWriter.WriteLine("{0:0.0}", Math.Round(result, 1));

            textWriter.Flush();
            textWriter.Close();
        }   //stats 2



        static int handshake(int n)
        {
            n -= 1;
            int total = 0;

            while (n>0)
            {
                total += n;
                n--;
            }
            return total;
        }


        public static void Quartiles()
        {
            //System.IO.TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = int.Parse(Console.ReadLine());
            int[] values = Array.ConvertAll(Console.ReadLine().Split(' '), inputTemp => Convert.ToInt32(inputTemp));
            Array.Sort(values);

            decimal Q1 = 0, Q2 = 0, Q3 = 0;
            int topOfA = 0, bottomOfB = 0;
            int a, b;

            //Q2
            if (n % 2 == 1)                     //odd
            {
                Q2 = (decimal)values[values.Length / 2];
                topOfA = (values.Length / 2) - 1;
                bottomOfB = (values.Length / 2) + 1;
            }
            else
            {                               //even
                topOfA = (values.Length / 2)-1;
                bottomOfB = (values.Length / 2);
                a = values[values.Length / 2];
                b = values[(values.Length / 2) - 1];
                Q2 = (decimal)(((decimal)a + (decimal)b) / 2);
            }


            //Q1
            if ((topOfA-1) % 2 == 1)                     //odd
            {
                Q1 = (decimal)values[topOfA / 2];
            }
            else
            {                               //even
                a = values[topOfA / 2];
                b = values[(topOfA / 2) + 1];
                Q1 = (decimal)(((decimal)a + (decimal)b) / 2);
            }


            //Q3
            if ((n-bottomOfB) % 2 == 1)                     //odd
            {
                Q3 = (decimal)values[(values.Length+bottomOfB) / 2];
            }
            else
            {                               //even
                a = values[(values.Length + bottomOfB-1) / 2];
                b = values[((values.Length + bottomOfB) / 2)];
                Q3 = (decimal)(((decimal)a + (decimal)b) / 2);
            }

            //textWriter.WriteLine(Q1);
            //textWriter.WriteLine(Q2);
            //textWriter.WriteLine(Q3);

            //textWriter.Flush();
            //textWriter.Close();
        }   //stats 3



        static int gameWithCells(int n, int m)
        {
            int x = (n + n % 2) * (m + m % 2) / 4;
            return x;
        }


        public static void InterQuartiles()
        {
            //System.IO.TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = int.Parse(Console.ReadLine());
            int[] rawData = Array.ConvertAll(Console.ReadLine().Split(' '), inputTemp => Convert.ToInt32(inputTemp));
            int[] frequencies = Array.ConvertAll(Console.ReadLine().Split(' '), inputTemp => Convert.ToInt32(inputTemp));

            List<int> valuesList = new List<int>();
            for(int x=0;x<n; x++)
            {
                for(int y=0; y<frequencies[x];y++)
                {
                    valuesList.Add(rawData[x]);
                }
            }

            int[] values = valuesList.ToArray();
            Array.Sort(values);

            decimal Q1 = 0, Q2 = 0, Q3 = 0;
            int topOfA = 0, bottomOfB = 0;
            int a, b;

            //Q2
            if (n % 2 == 1)                     //odd
            {
                Q2 = (decimal)values[values.Length / 2];
                topOfA = (values.Length / 2) - 1;
                bottomOfB = (values.Length / 2) + 1;
            }
            else
            {                               //even
                topOfA = (values.Length / 2) - 1;
                bottomOfB = (values.Length / 2);
                a = values[values.Length / 2];
                b = values[(values.Length / 2) - 1];
                Q2 = (decimal)(((decimal)a + (decimal)b) / 2);
            }


            //Q1
            if ((topOfA - 1) % 2 == 1)                     //odd
            {
                Q1 = (decimal)values[topOfA / 2];
            }
            else
            {                               //even
                a = values[topOfA / 2];
                b = values[(topOfA / 2) + 1];
                Q1 = (decimal)(((decimal)a + (decimal)b) / 2);
            }


            //Q3
            if ((n - bottomOfB) % 2 == 1)                     //odd
            {
                Q3 = (decimal)values[(values.Length + bottomOfB) / 2];
            }
            else
            {                               //even
                a = values[(values.Length + bottomOfB - 1) / 2];
                b = values[((values.Length + bottomOfB) / 2)];
                Q3 = (decimal)(((decimal)a + (decimal)b) / 2);
            }

            decimal answer = Q3 - Q1;
            //textWriter.WriteLine("{0:0.0}", Math.Round(answer, 1));

            //textWriter.Flush();
            //textWriter.Close();
        }   //stats 4



        public static void StarndardDeviation()     //stats 5
        {
            System.IO.TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = int.Parse(Console.ReadLine());
            int[] data = Array.ConvertAll(Console.ReadLine().Split(' '), inputTemp => Convert.ToInt32(inputTemp));
            Array.Sort(data);

            //mean
            double mean = (double)data.Sum(i => i) / (double)n;

            double result = 0;

            foreach (int i in data)
            {
                result += (i - mean) * (i - mean);
            }

            result = Math.Sqrt(result / n);

            textWriter.WriteLine("{0:0.0}", Math.Round(result, 1));

            textWriter.Flush();
            textWriter.Close();
        }























    }
}

