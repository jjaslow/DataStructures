using System.Collections.Generic;
using System.Text;

namespace MyExercises
{
    class StringManipulation
    {

        public static int CountVowels(string str)
        {
            if (str == null)
                return 0;

            var letters = new Dictionary<char, int>();
            string strLower = str.ToLower();

            foreach (char c in strLower)
            {
                if (!letters.ContainsKey(c))
                    letters.Add(c, 1);
                else
                    letters[c]++;

            }

            int a, e, i, o, u;
            a = e = i = o = u = 0;

            if (letters.ContainsKey('a'))
                a = letters['a'];
            if (letters.ContainsKey('e'))
                e = letters['e'];
            if (letters.ContainsKey('i'))
                i = letters['i'];
            if (letters.ContainsKey('o'))
                o = letters['o'];
            if (letters.ContainsKey('u'))
                u = letters['u'];

            return a + e + i + o + u;

        }
    
    
        public static string ReverseString(string str)
        {
            if (str == null)
                return "";

            var myStack = new Stack<char>();

            foreach (char ch in str)
                myStack.Push(ch);

            StringBuilder sb = new StringBuilder();

            while (myStack.Count > 0)
                sb.Append(myStack.Pop(), 1);

            return sb.ToString();

        }


        public static string ReverseWords(string str)
        {
            if (str == null)
                return "";

            string reversedLetters = ReverseString(str);

            var myStack = new Stack<char>();
            StringBuilder sb = new StringBuilder();

            foreach (char ch in reversedLetters)
            {
                if (ch != ' ')
                    myStack.Push(ch);
                else
                {
                    while (myStack.Count > 0)
                        sb.Append(myStack.Pop(), 1);
                    sb.Append(ch,1);
                }

            }

            while (myStack.Count > 0)
                sb.Append(myStack.Pop(), 1);

            return sb.ToString();





        }
    
    
        public static bool CheckRotation(string a, string b)
        {
            if (a.Length != b.Length)
                return false;

    
            for(int x=1; x<a.Length; x++)
            {
                if (CheckRotation(a, b, x))
                    return true;
            }

            return false;

        }


        private static bool CheckRotation(string a, string b, int round)
        {
            int increment = round;

            for(int x=0; x<a.Length; x++)
            {
                int y = x + increment;
                if (y >= b.Length)
                    y = y - b.Length;

                if (a[x] != b[y])
                    return false;

            }

            return true;

        }
    
    

        public static string RemoveDupChar(string str)
        {
            var Dict = new HashSet<char>();
            var sb = new StringBuilder();

            foreach(char ch in str)
            {
                if(!Dict.Contains(ch))
                {
                    Dict.Add(ch);
                    sb.Append(ch);
                }

            }

            return sb.ToString();


        }

    }

}

