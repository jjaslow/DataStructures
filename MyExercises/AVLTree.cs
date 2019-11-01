using System;

namespace MyExercises
{
    class AVLTree
    {
        private class AVLNode
        {
            public int value { get; private set; }
            public int height;
            public AVLNode leftChild;
            public AVLNode rightChild;

            public AVLNode(int value)
            {
                this.value = value;
                this.height = 0;
            }

            public override string ToString()
            {
                return "Value=" + value;
            }
        }

        private AVLNode Root;

        public void Insert(int value)
        {
            Root = Insert(value, Root);
        }

        private AVLNode Insert(int value, AVLNode node)
        {
            if (node == null)
            {
                return new AVLNode(value);
            }

            if (value < node.value)
                node.leftChild = Insert(value, node.leftChild);
            else
                node.rightChild = Insert(value, node.rightChild);

            node.height = Math.Max(Height(node.leftChild), Height(node.rightChild)) + 1;

            int balanceFactor = Height(node.leftChild) - Height(node.rightChild);
            if (balanceFactor>1)
                Console.WriteLine("node: " + node.value + " is LEFT heavy by " + (balanceFactor-1));
            if (balanceFactor < -1)
                Console.WriteLine("node: " + node.value + " is RIGHT heavy by " + (balanceFactor+1));

            return node;
        }

        private int Height(AVLNode node)
        {
            if (node == null)
                return -1;

            return Math.Max(Height(node.leftChild), Height(node.rightChild)) + 1;

        }


        private bool IsLeaf(AVLNode root)
        {
            return (root.leftChild == null && root.rightChild == null);
        }


    
    
    
    
    
    
    }
}
