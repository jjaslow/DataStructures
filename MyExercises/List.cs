using System;

namespace MyExercises
{
    public class jjLinkedList
    {

        private class Node
        {
            public int value;
            public Node next;

            public Node(int val)
            {
                value = val;
            }


        }

        /// //////////////////


        private Node first;
        private Node last;
        private int count=0;

        private bool IsEmpty()
        {
            return first == null;
        }


        public void AddFirst(int value)
        {
            var newNode = new Node(value);
            count++;

            if(IsEmpty())
                first = last = newNode;
            else
            {
                newNode.next = first;
                first = newNode;
            }

        }
      

        public void AddLast(int value)
        {
            var newNode = new Node(value);
            count++;

            if (IsEmpty())
                first = last = newNode;
            else
            {
                last.next = newNode;
                last = newNode;
            }
                
        }


        public int IndexOf(int value)
        {
            var currNode = first;
            int index = 0;

            while (currNode != null)
            {
                if (currNode.value == value)
                    return index;
                else
                {
                    currNode = currNode.next;
                    index++;
                }
            }
            return -1;
        }


        public bool Contains(int value)
        {
            return IndexOf(value) != -1;
        }


        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new SystemException("List Empty Exception");

            if (first == last)
            {
                first = last = null;
                count--;
                return;
            }
                
            var secondNode = first.next;
            first.next = null;
            first = secondNode;
            count--;
        }


        public void RemoveLast()
        {
            if(IsEmpty())
                throw new SystemException("List Empty Exception");

            if (first == last)
            {
                first = last = null;
                count--;
                return;
            }

            Node secondLast = first;

            while (secondLast.next != last)
            {
                secondLast = secondLast.next;
            }

            secondLast.next = null;
            last = secondLast;
            count--;

        }


        public int Size()
        {
            return count;
        }


        public int[] ToArray()
        {
            int[] myArray = new int[count];
            var curr = first;
            for (int x=0; x<count; x++)
            {
                myArray[x] = curr.value;
                curr = curr.next;
            }

            return myArray;
        }


        public void Reverse()
        {
            if (IsEmpty()) return;

            Node curr = first;
            Node second = curr.next;
            
            for (int x=1; x<count; x++)
            {
                Node third = second.next;
                second.next = curr;
                curr = second;
                second = third;
            }

            Node temp = first;
            first.next = null;
            first = last;
            last = temp;


        }


        public int getKthFromTheEnd(int k)
        {
            if (k <= 0 || IsEmpty())
                return -1;

            var right = first;
            
            for(int x=0; x<k-1; x++)
            {
                if (right.next == null)
                    return -1;
                else
                {
                    right = right.next;
                }
            }

            var left = first;

            while(right.next != null)
            {
                right = right.next;
                left = left.next;
            }

            return left.value;
        }

    }





   
}
