using Lucene.Net.Support;
using System;
using System.Collections.Generic;

namespace MyExercises
{
    class Trie
    {

        class Node
        {
            public char Value { get; private set; }
            public bool IsEndOfWord { get; set; }
            public HashMap<char, Node> Children { get; private set; }

            public Node(char ch)
            {
                Value = ch;
                IsEndOfWord = false;
                Children = new HashMap<char, Node>();
            }


            public bool HasChild(char ch)
            {
                return Children.ContainsKey(ch);
            }

            public void AddChild(char ch)
            {
                Children.Add(ch, new Node(ch));
            }


            public Node GetChild(char ch)
            {
                return Children[ch];
            }

            public Node[] GetChildren()
            {
                var xxx = new Node[26];
                Children.Values.CopyTo(xxx, 0);
                return xxx;
            }

            public void RemoveChild(char ch)
            {
                Children.Remove(ch);
            }
             
  

            public override string ToString()
            {
                return "Value= " + Value;
            }

        }

        Node Root = new Node(char.MinValue);


        public void Insert(string str)
        {
            char[] ch = str.ToCharArray();
            Node current = Root;

            for(int x=0; x<str.Length; x++)
            {
                if(!current.HasChild(ch[x]))
                    current.AddChild(ch[x]);
                current = current.GetChild(ch[x]);
            }
            current.IsEndOfWord = true;

        }


        public bool Lookup(string str)
        {
            if (str == null)
                return false;

            char[] ch = str.ToCharArray();
            Node current = Root;

            for (int x = 0; x < str.Length; x++)
            {
                if (!current.HasChild(ch[x]))
                    return false;
                current = current.GetChild(ch[x]);
            }

            return current.IsEndOfWord;
        }
    

        public void Traverse()
        {
            Traverse(Root);
        }

        private void Traverse(Node root)
        {
            if (root == null)
                return;

            System.Console.Write(root.Value);
            System.Console.Write(", ");
            System.Console.WriteLine(root.IsEndOfWord);
            foreach (Node child in root.GetChildren())
                Traverse(child);
        }




        public void Remove(string str)
        {
            if (str == null)
                return;

            Remove(str, Root, 0);
        }

        private void Remove(string str, Node root, int count)
        {
            if (count == str.Length)
            {
                if(root.IsEndOfWord==true)
                    root.IsEndOfWord = false;

                return;
            }

            char ch = str[count];

            if (!root.HasChild(ch))
                throw new Exception("word not found");

            Remove(str, root.GetChild(ch), count+1);


            var rootChildren = root.GetChild(ch).GetChildren();
            foreach (Node child in rootChildren)
                if (child != null)
                    return;


            //root.Children.Remove(ch);
            if(!root.IsEndOfWord)
                root.RemoveChild(ch);


        }




        //public List<String> Complete(string word)
        //{
        //    if (word == null)
        //        return null;

        //    List<string> wordList = new List<string>();
        //    string stub = "";

        //    Complete(word, Root, 0, stub);
        //    return wordList;

        //}

        //private void Complete(string word, Node root, int index, string stub)
        //{

        //    if (root.Value >= 'A' && root.Value <= 'z')
        //        stub += root.Value;

        //    if (index==word.Length)
        //        return;

        //    char ch = word[index];

        //    Complete(word, root.GetChild(ch), index + 1, stub);

        //    Console.WriteLine(stub +".");

        //}





    }


    


}
