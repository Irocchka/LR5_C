using System;
using System.Linq;

namespace LR5_2
{
    class MyList<T>
    {
        public T[] newList = new T[7];
        int size = 7;
        int index = 0;
        public MyList(params T[] tmpList)
        {
            newList = new T[tmpList.Count()];
            size = tmpList.Count();
            foreach(T elem in tmpList)
            {
                newList[index] = elem;
                index++;
            }
        }
        public T this[int elem]
        {
            get=>newList[elem];
            set=>newList[elem] = value;
        }
        public void Add(params T[] tmpList)
        {
            if (tmpList.Count() >= size - newList.Count())
            {
                T[] timp = new T[newList.Count()];
                for(int i = 0; i < index; i++)
                {
                    timp[i] = newList[i];
                }
                newList = new T[tmpList.Count() + size];
                size = tmpList.Count() + size;
                for (int i = 0; i < index; i++)
                {
                    newList[i] = timp[i];
                }
            }
            foreach (T elem in tmpList)
            {
                newList[index] = elem;
                index++;
            }
        }
        public int Size
        {
            get
            {
                Console.Write("MyList size: ");
                return newList.Count();
            }
        }
        public void Print()
        {
            for (int i = 0; i < index; i++)
            {
                Console.Write(newList[i]);
                Console.Write(" ");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>(23, 19, 15, 90, 95, 345);
            list.Print();
            Console.Write("\n");
            Console.WriteLine(list.Size);
            list.Add(1, 2, 3, 4, 5);
            list.Print();
            Console.Write("\n");
            Console.WriteLine(list.Size);
            Console.WriteLine(list[3]);
        }
    }
}
