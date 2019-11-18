using System.Collections.Generic;

namespace MyExercises
{
    class jjHash
    {
        int Length;
        LinkedList<Entry>[] Arr;

        public static char FirstNonRepeatingChar(string str)
        {
            Dictionary<char, int> Dict = new Dictionary<char, int>();
            
            foreach (char x in str)
            {
                if (!Dict.ContainsKey(x))
                    Dict.Add(x, 1);
                else
                    Dict[x] += 1;
            }

            foreach (char x in str)
                if (Dict[x] == 1)
                {
                    return x;
                }

            return char.MinValue;


        }

        public static char FirstRepeatedChar(string str)
        {

            var Set = new HashSet<char>();

            foreach (char ch in str)
            {
                if (!Set.Contains(ch))
                    Set.Add(ch);
                else
                    return ch;
            }

            return char.MinValue;

        }

        //put(k,v), get(k):V, remove(k)
        //int/str
        //chaining, store KV pair in cell

        private class Entry
        {
            public int Key { get; private set; }
            public string Value { get;  set; }

            public Entry(int k, string v)
            {
                Key = k;
                Value = v;
            }
        }

        public jjHash(int len)
        {
            Length = len;
            Arr = new LinkedList<Entry>[Length];
        }

        public void Put(int key, string value)
        {
            int hash = key % Length;
            var List = Arr[hash];
            var Entry = new Entry(key, value);

            if(Arr[hash]==null)
                Arr[hash] = new LinkedList<Entry>();

            foreach (Entry e in Arr[hash])
                if (e.Key == key)
                {
                    e.Value = value;
                    return;
                }

            Arr[hash].AddLast(Entry);
        }

        public string Get(int key)
        {
            int hash = key % Length;
            var List = Arr[hash];

            if (List == null)
                return null;

            foreach (Entry e in List)
                if (e.Key == key)
                    return e.Value;

            return null;
            
        }

        public void Remove(int key)
        {
            int hash = key % Length;
            var List = Arr[hash];

            if (Arr[hash] == null)
                throw new System.Exception("Empty Exception");

            foreach (Entry e in List)
                if (e.Key == key)
                {
                    List.Remove(e);
                    return;
                }

            throw new System.Exception("Empty Exception2");
        }

    }
}
