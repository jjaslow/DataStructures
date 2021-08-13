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
        /* ARRAYS //////////////////////////////////////////////////////////////////////////////////////////////////

            We started off trying to solve the problem in one pass, and we noticed that it wouldn't work. try sorting

            Solve a simpler version of the problem (in this case, reversing the characters instead of the words), 
            and see if that gets us closer to a solution for the original problem.
        */ //////////////////////////////////////////////////////////////////////////////////////////////////
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


        /* DICT & HASH //////////////////////////////////////////////////////////////////////////////////////////////////

            Using hash-based data structures, like dictionaries or hash sets, is so common in coding challenge solutions, it should always be your first thought. 
            
            Can we do the testing AS we build the hash instead of building a full hash and then testing on it later?

            Start with a brute force solution, look for repeat work in that solution, and modify it to only do that work once.
        */ //////////////////////////////////////////////////////////////////////////////////////////////////
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


        /* GREEDY //////////////////////////////////////////////////////////////////////////////////////////////////

            Greedy approaches are great because they're fast (usually just one pass through the input). But they don't work for every problem.

            Trying out a greedy approach should be one of the first ways you try to break down a new question. ASK YOURSELF: "Suppose we could come up with the answer in one pass through the input, by simply
            updating the 'best answer so far' as we went. What additional values would we need to keep updated as we looked at each item in our input, in order to be able to update the 'best answer so far' in
            constant time?"

            maybe cant solve in 1 pass, but maybe 2? start by coming up with a slow (but correct) brute force solution and trying to improve from there. We looked at what our solution actually calculated, step by
            step, and found some repeat work. 
        */ //////////////////////////////////////////////////////////////////////////////////////////////////
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


        /* SORTING, SEARCHING (BINARY SEARCH) //////////////////////////////////////////////////////////////////////////////
        */ //////////////////////////////////////////////////////////////////////////////////////////////////
        public static int FindRotationPoint(String[] words)
        {
            // Find the rotation point in the array
            int left = 0;
            int right = words.Length-1;

            int index = ((right+left) / 2)+1;
            int charNumb = 0;

            char currentChar = words[index][charNumb];
            char charIndexZero = words[left][charNumb];

            while (index>0 && currentChar > words[index - 1][charNumb])
            {
                while (currentChar == charIndexZero)
                {
                    charNumb++;
                    currentChar = words[index][charNumb];
                    charIndexZero = words[left][charNumb];
                }
                charNumb = 0;

                if (currentChar > charIndexZero)   //go right
                {
                    left = index + 1;
                }
                else                            //go left
                {
                    right = index - 1;
                }

                index = (right + left) / 2;
                currentChar = words[index][charNumb];
            }

            return index;
        }



        public static int FindRepeat(int[] numbers)
        {
            // Find a number that appears more than once
            Array.Sort(numbers);

            for (int x = 0; x < numbers.Length - 1; x++)
            {
                if(numbers[x]==numbers[x+1])
                  return numbers[x];
            }

            return 0;
        }


        /* TREES //////////////////////////////////////////////////////////////////////////////////////////////////
         
           -number of nodes on each level 2x as we move down the tree (for a perfect / full BINARY SEARCH tree)
           -number of nodes on the LAST level equals the sum of all the nodes on the other levels + 1 (for perfect tree)
           -depth of tree is # of levels (root is level 0). COUNT the number of EDGES to leaf.
           -height starts at leaf. = 1+ max(height(L), height(R))
           -BST: left is smaller than node, right is larger than node
           -O(log n) lookup for BST

           GRAPHS //////////////////////////////////////////////////////////////////////////////////////////////////

            -nodes / vertex are connected by EDGES
            -useful for cases where things connect to other things
            -most graph algorithms are O(n log n) or slower
            -nodes are stored in an array (as a dictionary), usually as adjency lists (dictionary of node, and a linked list of connections)

            Breadth-First Search: explore level by level starting at root. used to find shortest path and any other reachable node. requires more memory than DFS. Uses a queue (hit all 1-hops, then all 2-hops, and so on). Memory used is proportional to breadth of tree. O(N+M), where M = current node's neighbors (ie connections between the users).

            Depth-First Search: go as deep as possible down 1 path before trying another. uses recursion. Uses a stack. Memory used is proportional to depth of tree.


            -is there a path btw 2 nodes? run either search from one node and see if you reach the other.
            -shortest path? BFS from 1 node and backtrack once you reach the second.

            SIMPLIFY THE PROBLEM: solve for easier problem (eg. just check one hop away) and then adapt to solve for final problem.

        */ //////////////////////////////////////////////////////////////////////////////////////////////////


        public static bool IsBalanced(BinaryTreeNode treeRoot)      //my function doesnt short circuit. not ideal...
        {
            var heightHash = new HashSet<int>();
            GetDepth(treeRoot, 0, heightHash);

            if (heightHash.Count > 2)
                return false;
            else if (heightHash.Max() - heightHash.Min() > 1)
                return false;
            else
                return true;
        }


        private static void GetDepth(BinaryTreeNode node, int depth, HashSet<int> heightHash)
        {
            if (node.Left == null && node.Right==null)
            {
                heightHash.Add(depth);
                return;
            }
            else
            {
                if(node.Left!=null)
                    GetDepth(node.Left, depth+1, heightHash);
                if(node.Right!=null)
                    GetDepth(node.Right, depth+1, heightHash);
            }
            return;
        }


        //not finished...not correct if largest node has a left subtree
        public static int FindSecondLargest(BinaryTreeNode rootNode)
        {
            // Find the second largest item in the binary search tree
            if(rootNode.Right==null)
            {
                if (rootNode.Left == null)
                    throw new System.ArgumentException("need more than 1 node");
                else
                    return rootNode.Left.Value;
            }

            BinaryTreeNode currNode = rootNode;
            Stack<int> nodeStack = new Stack<int>();

            while (currNode.Right != null)
            {
                nodeStack.Push(currNode.Value);
                currNode = currNode.Right;
            }

            if (currNode.Left != null)
                return currNode.Left.Value;
            else
                return nodeStack.Pop();
        }


        public static void ColorGraph(GraphNode[] graph, String[] colors)
        {
            // Create a valid coloring for the graph
            for(int x=0; x<graph.Length; x++)
            {
                GraphNode currNode = graph[x];
                if(!currNode.HasColor)
                {
                    List<string> usedColors = new List<string>();
                    usedColors = currNode.Neighbors.Where(node => node.HasColor).Select(node => node.Color).ToList();
                    currNode.Color = colors.First(c => !usedColors.Contains(c));
                }
            }
        }


        public static string[] BfsGetPath(Dictionary<string, string[]> graph, string startNode, string endNode)
        {
            if (!graph.ContainsKey(startNode))
            {
                throw new ArgumentException("Start node not in graph", nameof(startNode));
            }
            if (!graph.ContainsKey(endNode))
            {
                throw new ArgumentException("End node not in graph", nameof(endNode));
            }

            var nodesToVisit = new Queue<string>();
            nodesToVisit.Enqueue(startNode);

            // Keep track of how we got to each node.
            // We'll use this to reconstruct the shortest path at the end.
            // We'll ALSO use this to keep track of which nodes we've already visited.
            var howWeReachedNodes = new Dictionary<string, string>();
            howWeReachedNodes.Add(startNode, null);

            while (nodesToVisit.Count > 0)
            {
                var currentNode = nodesToVisit.Dequeue();

                // Stop when we reach the end node
                if (currentNode == endNode)
                {
                    return ReconstructPath(howWeReachedNodes, startNode, endNode);
                }

                foreach (var neighbor in graph[currentNode])
                {
                    if (!howWeReachedNodes.ContainsKey(neighbor))
                    {
                        nodesToVisit.Enqueue(neighbor);
                        howWeReachedNodes.Add(neighbor, currentNode);
                    }
                }
            }

            // If we get here, then we never found the end node
            // so there's NO path from startNode to endNode
            return null;
        }

        private static string[] ReconstructPath(Dictionary<string, string> howWeReachedNodes, string startNode, string endNode)
        {
            var reversedShortestPath = new List<string>();

            // Start from the end of the path and work backwards
            var currentNode = endNode;

            while (currentNode != null)
            {
                reversedShortestPath.Add(currentNode);
                currentNode = howWeReachedNodes[currentNode];
            }

            // Reverse our path to get the right order
            // by flipping it around, in place
            reversedShortestPath.Reverse();
            return reversedShortestPath.ToArray();
        }



        /* DYNAMIC PROGRAMMING & RECURSION ///////////////////////////////////////////////////////////////////////////

            A problem has overlapping subproblems if finding its solution involves solving the same subproblem multiple times.

            Memoization ensures that a method doesn't run for the same inputs more than once by keeping a record of the results for the given inputs 
                (usually in a dictionary). Memoization is a common strategy for dynamic programming problems, which are problems where the solution 
                is composed of solutions to the same problem with smaller inputs 
           
            Going bottom-up is a way to avoid recursion. Put simply, a bottom-up algorithm "starts from the beginning," 
                while a recursive algorithm often "starts from the end and works backwards."

            Going bottom-up is a common strategy for dynamic programming problems, 
                which are problems where the solution is composed of solutions to the same problem with smaller inputs

            recursive factorial starts at end:          n*factorial(n-1) ...
            bottom up factorial starts at beginning:    while(result *= x+1) ...

            With any recursive method, we just need a base case and a recursive case.

        */ //////////////////////////////////////////////////////////////////////////////////////////////////

        public static ISet<string> GetPermutations(String inputString)
        {
            // Generate all permutations of the input string


            return new HashSet<string>();
        }


        static Dictionary<int, int> memo = new Dictionary<int, int>();
        public static int Fib(int n)
        {
            if (n == 1 || n == 0)
                return n;

            if (memo.ContainsKey(n))
                return memo[n];
            else
            {
                int result = Fib(n - 1) + Fib(n - 2);
                memo.Add(n, result);
                return result;
            }           
        }


        public static int FibIterative(int n)
        {
            if (n == 0)
                return 0;
            if (n < 0)
                throw new System.ArgumentException("need positive #");

            int priorValue = 0;
            int result = 1;
            for(int x=2; x<=n; x++)
            {
                int temp = result;
                result += priorValue;
                priorValue = temp;
            }
            return result;
        }



        public static int ChangePossibilities(int amount, int[] denominations)
        {
            int count = 0;



            return count;
        }

             //STILL HAVE LOTS TO LEARN AND DO HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
             /////////////////////////////////////////////////////////////////////////////////////




        /* STACK & QUEUE ///////////////////////////////////////////////////////////////////////////////////////

        Stack is good for string parsing (bracket validation)

        */ //////////////////////////////////////////////////////////////////////////////////////////////////


        public class MaxStack
        {
            int max;
            
            Stack<int> myStack = new Stack<int>();

            public void Push(int item)
            {
                if (myStack.Count == 0)
                    max = item;
                else if (item > max)
                    max = item;

                myStack.Push(item);
            }

            public int Pop()
            {
                if(myStack.Count>0)
                {
                    int temp = myStack.Pop();
                    if(temp==max)
                    {
                        max = myStack.Max();
                    }
                    return temp;
                }
                else
                {
                    throw new System.Exception("Stack is Empty");
                }
                
            }

            public int GetMax()
            {
                if (myStack.Count > 0)
                    return max;
                else
                    throw new System.Exception("Stack is empty");
            }
        }


        public class QueueTwoStacks
        {
            Stack<int> _inStack = new Stack<int>();
            Stack<int> _outStack = new Stack<int>();

            public void Enqueue(int item)
            {
                _inStack.Push(item);
            }

            public int Dequeue()
            {
                if(_outStack.Count==0)
                {
                    while (_inStack.Count > 0)
                        _outStack.Push(_inStack.Pop());
                }

                return _outStack.Pop();
            }
        }

        public static int GetClosingParen(string sentence, int openingParenIndex)
        {
            // Find the position of the matching closing parenthesis
            Stack<char> myStack = new Stack<char>();
            for(int x = openingParenIndex; x<sentence.Length; x++)
            {
                char c = sentence[x];
                
                if(c=='(')
                    myStack.Push(c);
                else if(c==')')
                {
                    if (myStack.Count == 0)
                        throw new System.ArgumentException("stack is empty");
                    else if (myStack.Peek() == '(')
                    {
                        myStack.Pop();
                        if (myStack.Count == 0)
                            return x;
                    }
                    else
                        throw new System.ArgumentException("mismatch");
                }
            }
            if (myStack.Count > 0)
                throw new System.ArgumentException("item still left in stack");
            return 0;
        }


        public static bool IsValid(string code)
        {
            char[] openers = new char[] { '(', '{', '[' };
            char[] closers = new char[] { ')', '}', ']' };

            Stack<char> myStack = new Stack<char>();

            for (int x = 0; x < code.Length; x++)
            {
                char c = code[x];

                if (openers.Contains(c))
                    myStack.Push(c);
                else if (closers.Contains(c))
                {
                    if (myStack.Count == 0)
                        return false;

                    char match = myStack.Pop();
                    int matchIndex = Array.IndexOf(openers, match); 
                    int thisIndex = Array.IndexOf(closers, c);

                    if (matchIndex != thisIndex)
                        return false;
                }

            }

            if (myStack.Count > 0)
                return false;
            return true;
        }


        /* LINKED LIST ///////////////////////////////////////////////////////////////////////////////////////

            can be singly or doubly linked.

        */ //////////////////////////////////////////////////////////////////////////////////////////////////


        public static void DeleteNode(LinkedListNode nodeToDelete)
        {
            // Delete the input node from the linked list

            if(nodeToDelete.Next==null)
            {
                throw new System.InvalidOperationException();
            }

            LinkedListNode next = nodeToDelete.Next;

            nodeToDelete.Value = nodeToDelete.Next.Value;
            nodeToDelete.Next = next.Next;


            next.Next = null;
        }

        public static bool ContainsCycle(LinkedListNode firstNode)
        {
            // Check if the linked list contains a cycle
            if (firstNode == null || firstNode.Next == null || firstNode.Next.Next == null)
                return false;

            LinkedListNode slow = firstNode;
            LinkedListNode fast = firstNode.Next;

            while(fast!=null)
            {
                slow = slow.Next;

                if (fast.Next == null)
                    return false;
                else
                    fast = fast.Next.Next;

                if (fast == slow)
                    return true;
            }
            return false;
        }

        public static LinkedListNode Reverse(LinkedListNode headOfList)
        {
            if (headOfList == null)
                return null;
            if (headOfList.Next == null)
                return headOfList;

            LinkedListNode A = headOfList;
            LinkedListNode B = A.Next;
            LinkedListNode C;

            while (B!=null || B.Next != null)
            {
                C = B.Next;
                B.Next = A;

                A = B;
                B = C;
            }

            B.Next = A;
            headOfList.Next = null;
            return B;
        }


        public static LinkedListNode KthToLastNode(int k, LinkedListNode head)
        {
            if(k<1)
                throw new System.ArgumentException("K must be > 1");

            // Return the kth to last node in the linked list
            LinkedListNode mainPointer = head;

            for(int x=1; x<k; x++)
            {
                mainPointer = mainPointer.Next;
                if (mainPointer == null)
                    throw new System.ArgumentException("not enough items in list");
            }

            LinkedListNode secondPointer = head;

            while(mainPointer.Next != null)
            {
                mainPointer = mainPointer.Next;
                secondPointer = secondPointer.Next;
            }

            return secondPointer;
        }



    }

    public class BinaryTreeNode
    {
        public int Value { get; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }

        public BinaryTreeNode(int value)
        {
            Value = value;
        }

        public BinaryTreeNode InsertLeft(int leftValue)
        {
            Left = new BinaryTreeNode(leftValue);
            return Left;
        }

        public BinaryTreeNode InsertRight(int rightValue)
        {
            Right = new BinaryTreeNode(rightValue);
            return Right;
        }
    }


    public class GraphNode
    {
        public string Label { get; }
        public ISet<GraphNode> Neighbors { get; }
        public string Color { get; set; }
        public bool HasColor { get { return Color != null; } }

        public GraphNode(string label)
        {
            Label = label;
            Neighbors = new HashSet<GraphNode>();
        }

        public void AddNeighbor(GraphNode neighbor)
        {
            Neighbors.Add(neighbor);
        }
    }

    public class LinkedListNode
    {
        public int Value { get; set; }

        public LinkedListNode Next { get; set; }

        public LinkedListNode(int value)
        {
            Value = value;
        }
    }
}

