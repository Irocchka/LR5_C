using System;
using System.Collections;

 class Program
    {
        class MyDictionary<TKey, TValue> : IEnumerable
        {
            Tuple<TKey, TValue>[] _data;
            int _size;

            public int Count { get => _size; }

            public MyDictionary(int size)
            {
                _data = new Tuple<TKey, TValue>[size];
                _size = 0;
            }

            public void Add(TKey key, TValue val)
            {
                if (_size == _data.Length)
                {
                    Tuple<TKey, TValue>[] newData = new Tuple<TKey, TValue>[_size * 2];
                    for (int i = 0; i < _size; i++)
                    {
                        newData[i] = _data[i];
                    }
                    _data = newData;
                }
                _data[_size] = new Tuple<TKey, TValue>(key, val);
                _size++;
            }

            public Tuple<TKey, TValue> this[int index]
            {
                get => _data[index];
            }

            IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)_data.GetEnumerator();
        }
        static void Main(string[] args)
        {
            MyDictionary<int, string> Dict = new MyDictionary<int, string>(2);
            Dict.Add(1, "Meow");
            Dict.Add(1, "Mrrr");
            Dict.Add(2, "Frr");
            Dict.Add(3, "Feow");

            for (int i = 0; i < Dict.Count; i++)
            {
                Console.WriteLine(Dict[i]);
            }
            Console.WriteLine("=============");
            foreach (Tuple<int, string> pair in Dict)
            {
                Console.WriteLine(pair);
            }

        }
    }
