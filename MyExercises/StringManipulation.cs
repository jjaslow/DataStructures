using System.Collections.Generic;
using System.Linq;
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


        public static char MostRepeatedChar(string str)
        {
            if (str == null || str.Length == 0)
                throw new System.Exception("Empty String");

            var Dict = new Dictionary<char, int>();
            foreach(char ch in str)
            {
                if (Dict.ContainsKey(ch))
                    Dict[ch]++;
                else
                    Dict.Add(ch, 1);
            }

            int count = 0;
            char letter = char.MinValue;

            foreach(char ch in Dict.Keys)
            {
                if (Dict[ch]>count)
                {
                    letter = ch;
                    count = Dict[ch];

                }

            }

            return letter;

        }


        public static string Capitalize(string str)
        {
            var StrArray = str.Trim().Split();

            int length = 0;
            var StrArray2 = new string[StrArray.Length];

            for(int x=0; x<StrArray.Length;x++)
            {
                if (StrArray[x].Length!=0)
                {
                    StrArray2[length++] = capFirst(StrArray[x].ToString());
                }

            }

            string result = string.Join(" ", StrArray2);
            return result.Trim();
        }


        private static string capFirst(string str)
        {
            var sb = new StringBuilder();

            if (str[0] >= 97 && str[0] <= 122)
                sb.Append((char)(str[0] - 32));
            else
                sb.Append((char)str[0]);

            for (int x = 1; x < str.Length; x++)
                sb.Append(str[x]);

            return sb.ToString();

        }


        public static bool Anagram(string str1, string str2)
        {
            if (str1 == null && str2 == null)
                return true;

            if (str1 == null || str2 == null)
                return false;

            if (str1.Length != str2.Length)
                return false;

            var Dict = new Dictionary<char, int>();

            foreach (char ch in str1)
            {
                if (!Dict.ContainsKey(ch))
                    Dict.Add(ch, 1);
                else
                    Dict[ch]++;
            }

            foreach (char ch in str2)
            {
                if (Dict.ContainsKey(ch))
                    Dict[ch]--;
                if (!Dict.ContainsKey(ch) || Dict[ch] < 0)
                    return false;
            }

            return true;
        }


        public static bool Palindrome(string str)
        {
            if (str == null || str.Length < 2)
                return true;

            int i = str.Length / 2;

            for(int x=0; x<=i-1; x++)
            {
                if (str[x] != str[str.Length - x-1])
                    return false;

            }

            return true;


        }

    }

}

