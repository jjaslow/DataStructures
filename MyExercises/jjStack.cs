using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyExercises
{
  
    public class jjStack
    {
        //int array
        //push, pop, peek, isEmpty
        
        int TotalLength = 10;
        int CurrLength = 0;
        int[] Stack;

        public jjStack()
        {
            Stack = new int[TotalLength];
        }

        public void Push(int value) 
        {
            if (CurrLength == TotalLength)
                ExpandStack();

            Stack[CurrLength++] = value;        
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new Exception("Stack is Empty Exception");
            return Stack[CurrLength-1];
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new Exception("Stack is Empty Exception");
            return Stack[--CurrLength];
        }

        public bool IsEmpty()
        {
            return CurrLength == 0;
        }


        private void ExpandStack()
        {
            int[] Stack2 = new int[TotalLength * 2];
            foreach (int x in Stack)
                Stack2[x] = Stack[x];
            TotalLength = TotalLength * 2;
            Stack = Stack2;
        }

        public string Reverse(string str)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            Stack<char> myStack = new Stack<char>();

            if (str == null)
                return null;

            foreach (char c in str)
                myStack.Push(c);

            while (myStack.Count() > 0)
            {
                //myNewString += myStack.Pop();
                sb.Append(myStack.Pop());
            }

            return sb.ToString();
        }

        public bool IsBalanced(string str)
        {
            if (str == null)
                return true;

            char[] LeftBrackets =  {'[', '<', '(', '{'};
            char[] RightBrackets = {']', '>', ')', '}'};

            Stack<char> MyStack = new Stack<char>();

            foreach(char c in str)
            {
                if (LeftBrackets.Contains(c))   
                    MyStack.Push(c);

                if (RightBrackets.Contains(c))
                {
                    if (MyStack.Count == 0)
                        return false;

                    int right = Array.IndexOf(RightBrackets, c);
                    int left = Array.IndexOf(LeftBrackets, MyStack.Pop());
                    if (right != left)
                        return false;
                }
            }

            if (MyStack.Count > 0)
                return false;

            return true;
        }

    }

}
