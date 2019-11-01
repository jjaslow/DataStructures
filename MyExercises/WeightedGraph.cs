using System;
using System.Collections.Generic;

namespace MyExercises
{
    class WeightedGraph 
    {

        class Node
        {
            public string Value { get; private set; }
            private List<Edge> Connections = new List<Edge>();

            public Node(string value)
            {
                this.Value = value;
            }

            public override string ToString()
            {
                return Value;
            }

            public int NumberOfEdges()
            {
                return Connections.Count;
            }

            public List<Edge> GetConnections()
            {
                return Connections;
            }

        }

        class Edge
        {
            public Node From { get; private set; }
            public Node To { get; private set; }
            public int Weight { get; private set; } 

            public Edge(Node from, Node to, int weight)
            {
                this.From = from;
                this.To = to;
                this.Weight = weight;
            }

            public override string ToString()
            {
                return (From + "->" + To + "@" + Weight);
            }

        }

        Node[] Graph = new Node[10];
        int count = 0;


        public void AddNode(string value)
        {
            for (int x = 0; x < count; x++)
                if (Graph[x].Value == value)
                    return;

            if (count == Graph.Length - 1)
                throw new Exception("array is full");

            Graph[count++] = new Node(value);

        }


        public void AddEdge(string from, string to, int weight)
        {
            int fromIndex = NodeIndex(from);
            int toIndex = NodeIndex(to);

            if (fromIndex >= 0 && toIndex >= 0)
            {
                Edge newEdge = new Edge(Graph[fromIndex], Graph[toIndex], weight);
                Edge newEdge2 = new Edge(Graph[toIndex], Graph[fromIndex], weight);

                if (!Graph[fromIndex].GetConnections().Contains(newEdge))
                    Graph[fromIndex].GetConnections().Add(newEdge);
                if (!Graph[toIndex].GetConnections().Contains(newEdge2))
                    Graph[toIndex].GetConnections().Add(newEdge2);
            }
            else
                throw new Exception("Node doesnt exisit.");
        }


        private int NodeIndex(string value)
        {
            for (int x = 0; x < count; x++)
                if (Graph[x].Value == value)
                {
                    return x;
                }
            return -1;
        }


        public void Print()
        {
            for (int x = 0; x < count; x++)
            {
                if (Graph[x].NumberOfEdges() > 0)  //Graph[x].Connections.Count
                {
                    Console.Write(Graph[x].Value + " is connected with: ");
                    Console.WriteLine("[{0}]", string.Join(", ", Graph[x].GetConnections()));
                }

            }
        }









    }



}

