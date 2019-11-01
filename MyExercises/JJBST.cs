using System;
using System.Collections.Generic;

namespace MyExercises
{
    class JJBST
    {
        private class Node
        {
            public int Value { get; private set; }
            public Node LeftChild, RightChild;

            public Node(int v)
            {
                Value = v;
            }

            public override string ToString()
            {
                return "Node="+Value;
            }
        }
        private enum Direction
        {
            Left,
            Right
        }

        private Node Root;

        public void Insert(int value)
        {
            Node NewNode = new Node(value);

            if (Root == null)
            {
                Root = NewNode;
                return;
            }

            var CurrentNode = Root;
            var PriorNode = Root;
            Direction Dir;

            do
            {
                if (value < CurrentNode.Value)
                {
                    PriorNode = CurrentNode;
                    CurrentNode = CurrentNode.LeftChild;
                    Dir = Direction.Left;
                }
                else
                {
                    PriorNode = CurrentNode;
                    CurrentNode = CurrentNode.RightChild;
                    Dir = Direction.Right;
                }
            }
            while (CurrentNode != null);

            if (Dir == Direction.Left)
                PriorNode.LeftChild = NewNode;
            else
                PriorNode.RightChild = NewNode;
        }

        public bool Find(int value)
        {
            Node CurrNode = Root;

            while(CurrNode != null)
            {
                if (value == CurrNode.Value)
                    return true;

                if (value < CurrNode.Value)
                    CurrNode = CurrNode.LeftChild;
                else
                    CurrNode = CurrNode.RightChild;
            }

            return false;

        }



        public void PreOrderTraverse()  //overload method w/o parameter
        {
            PreOrderTraverse(Root);
        }

        private void PreOrderTraverse(Node root)
        {
            if (root == null)
                return;
            
            System.Console.WriteLine(root.Value);
            PreOrderTraverse(root.LeftChild);
            PreOrderTraverse(root.RightChild);
        }



        public void InOrderTraverse()  //overload method w/o parameter
        {
            InOrderTraverse(Root);
        }

        private void InOrderTraverse(Node root)
        {
            if (root == null)
                return;

            InOrderTraverse(root.LeftChild);
            System.Console.WriteLine(root.Value);
            InOrderTraverse(root.RightChild);
        }



        public void PostOrderTraverse()  //overload method w/o parameter
        {
            PostOrderTraverse(Root);
        }

        private void PostOrderTraverse(Node root)
        {
            if (root == null)
                return;

            PostOrderTraverse(root.LeftChild);
            PostOrderTraverse(root.RightChild);
            System.Console.WriteLine(root.Value);
        }



        public void LevelOrderTraverse()  //overload method w/o parameter
        {
            for(int x=0; x<=Height(); x++)
            {
                   foreach (int value in NodesAtKDistance(x))
                    Console.WriteLine(value);
            }
        }


               

        public int Height()  //overload method w/o parameter
        {
            return Height(Root);
        }

        private int Height(Node root)
        {
            if (root == null)
                return -1;

            int left = Height(root.LeftChild);
            int right = Height(root.RightChild);

            return ((left > right) ? left : right )+ 1;
        }



        public int MinValue()  //overload method w/o parameter
        {
            return MinValue(Root);
        }

        private int MinValue(Node root)
        {
            if (IsLeaf(root))
                return root.Value;

            int left = root.Value, right = root.Value;

            if (root.LeftChild!=null)
                left = MinValue(root.LeftChild);

            if (root.RightChild != null)
                right = MinValue(root.RightChild);
                

            return Math.Min(root.Value, Math.Min(left, right));
        }



        public bool IsEqual(JJBST Tree2)
        {
            if (this == null || Tree2 == null)
                return false;

            return IsEqual(this.Root, Tree2.Root);
        }

        private bool IsEqual(Node T1, Node T2)
        {
            if (T1 == null & T2 == null)
                return true;
            if (T1 == null || T2 == null)
                return false;

            if (T1.Value != T2.Value)
                return false;
            else
                return IsEqual(T1.LeftChild, T2.LeftChild) && IsEqual(T1.RightChild, T2.RightChild);
        }


        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(Root, int.MinValue, int.MaxValue);
        }

        private bool IsBinarySearchTree(Node node, int min, int max)
        {
            if (node == null)
                return true;

            if (node.Value < min || node.Value > max)
                    return false;

            return IsBinarySearchTree(node.LeftChild, min, node.Value) &&
                    IsBinarySearchTree(node.RightChild, node.Value, max);
       }


        public List<int> NodesAtKDistance(int Distance)
        {
            List<int> List = new List<int>();
            NodesAtKDistance(Root, Distance, List);
            return List;
        }

        private void NodesAtKDistance(Node node, int Distance, List<int> List)
        {
            if (node == null)
                return;
            if (Distance == 0)
                List.Add(node.Value);

            NodesAtKDistance(node.LeftChild, Distance-1, List);
            NodesAtKDistance(node.RightChild, Distance-1, List);

        }


        public int CountLeaves()
        {
            return CountLeaves(Root);
        }

        private int CountLeaves(Node root)
        {
            int count = 0;

            if (root == null)
                return 0;

            if (IsLeaf(root))
                return 1;

            count += CountLeaves(root.LeftChild);
            count += CountLeaves(root.RightChild);

            return count;

        }


        public int Max()
        {
            if (Root == null)
                throw new Exception("tree is empty.");
            return Max(Root);
        }

        private int Max(Node root)
        {
            if (IsLeaf(root))
                return root.Value;

            int left = root.Value, right = root.Value;

            if (root.LeftChild != null)
                left = Max(root.LeftChild);

            if (root.RightChild != null)
                right = Max(root.RightChild);

            return Math.Max(right, Math.Max(root.Value, left));

        }







        public void SwapNodes()
        {
            Node temp = Root.LeftChild;
            Root.LeftChild = Root.RightChild;
            Root.RightChild = temp;
        }

        private bool IsLeaf(Node root)
        {
            return (root.LeftChild == null && root.RightChild == null);
        }
    }
}
