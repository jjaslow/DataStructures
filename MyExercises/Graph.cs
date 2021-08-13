using System;
using System.Collections.Generic;

namespace MyExercises
{
    class Graph
    {

        class Node
        {
            public string label { get; private set; }
            public List<Node> connections = new List<Node>();

            public Node(string value)
            {
                this.label = value;
            }

            public override string ToString()
            {
                return label;
            }
            
        }

        Node[] array = new Node[10];
        int count = 0;

        public void AddNode(string value)
        {

            for(int x=0; x<count; x++)
                if (array[x].label == value)
                    return;

            if (count == array.Length - 1)
                throw new Exception("array is full");

            array[count++] = new Node(value);

        }

        public void RemoveNode(string value)
        {
            bool exists = false;
            int index=0;

            for (int x = 0; x<array.Length; x++)
                if (array[x].label == value)
                {
                    exists = true;
                    index = x;
                    break;
                }

            if(exists)
            {

                for (int x=0; x<count; x++)
                {
                    RemoveEdge(array[x].label, value);
                }

                for (int x = index; x < count - 1; x++)
                {
                    array[x] = array[x + 1];
                }

                count--;

            }

        }

        public void AddEdge(string from, string to)
        {
            int fromIndex = NodeIndex(from);
            int toIndex = NodeIndex(to);

            if (fromIndex >= 0 && toIndex >= 0)
            {
                foreach (Node conn in array[fromIndex].connections)
                {
                    if (conn.label == to)
                        return;
                }
                array[fromIndex].connections.Add(array[toIndex]);

            }
            else
                throw new Exception("Node doesnt exisit.");
        }

        public void RemoveEdge(string from, string to)
        {
            int fromIndex = NodeIndex(from);
            int toIndex = NodeIndex(to);

            if (fromIndex >= 0 && toIndex >= 0)
            {
                array[fromIndex].connections.Remove(array[toIndex]);
            }

        }

        public void Print()
        {
            for (int x= 0; x < count; x++)
            {
                if(array[x].connections.Count>0)
                {
                    Console.Write(array[x].label + " is connected with: ");
                    Console.WriteLine("[{0}]", string.Join(", ", array[x].connections));
                }

            }
        }


        public void DepthFirstTraversal(string str)
        {
            int rootIndex = NodeIndex(str);
            if (rootIndex == -1)
                return;

            var set = new HashSet<Node>();
            DepthFirstTraversal(array[rootIndex], set);

        }

        private void DepthFirstTraversal(Node node, HashSet<Node> set)
        {
            //if (node.connections == null)
            //    return;

            set.Add(node);
            Console.WriteLine(node.label);

            foreach(Node x in node.connections)
                if (!set.Contains(x))
                    DepthFirstTraversal(x, set);

        }





 

        private int NodeIndex(string value)
        {
            for (int x = 0; x < count; x++)
                if (array[x].label == value)
                {
                    return x;
                }
            return -1;
        }




    }


}