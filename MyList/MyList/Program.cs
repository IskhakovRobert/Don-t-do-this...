using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class MyList<T>
    {
        public int count = 0;

        public T[] MyArray = new T[1];
        public T[] NewArray = new T[1];

        public void Add(T item)
        {
            try { MyArray[count] = item; }
            catch { ExpansArray(); }
            MyArray[count] = item; count++;
        }
        void ExpansArray()
        {
            NewArray = new T[MyArray.Length];
            for (int i = 0; i < MyArray.Length; i++)
            {
                NewArray[i] = MyArray[i];
            }
            MyArray = new T[MyArray.Length * 2];
            for (int i = 0; i < NewArray.Length; i++)
            {
                MyArray[i] = NewArray[i];
            }
        }
        public void AddRange(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Add(array[i]);
            }
        }
        public int IndexOf(T item)
        {
            string str = Convert.ToString(item);
            for (int i = 0; i < MyArray.Length; i++)
            {
                if (Convert.ToString(MyArray[i]) == str) return i;
            }
            return -1;
        }
        public void Insert(int index, T item)
        {
            T[] timeArray = new T[MyArray.Length - index];
            T[] newArray = new T[MyArray.Length + 1];
            for (int i = 0; i < MyArray.Length - index; i++)
            {
                timeArray[i] = MyArray[index + i];
            }
            for (int i = 0; i < index; i++)
            {
                newArray[i] = MyArray[i];
            }
            newArray[index] = item;
            for (int i = index+1; i < MyArray.Length + 1; i++)
            {
                newArray[i] = timeArray[i - (index+1)];
            }
            MyArray = new T[MyArray.Length + 1];
            for (int i = 0; i < MyArray.Length; i++)
            {
                MyArray[i] = newArray[i];
            }
        }
        public bool Remove(T item)
        {
            T[] timeArray = new T[MyArray.Length];
            T[] newArray = new T[MyArray.Length];
            int num = 0;
            for (int i = 0; i < MyArray.Length; i++)
            {
                timeArray[i] = MyArray[i];
                if (Convert.ToString(item) == Convert.ToString(timeArray[i])) num++;
            }
            int index = 0;
            for (int i = 0; i < newArray.Length; i++)
            {
                while (Convert.ToString(item) == Convert.ToString(timeArray[i])) 
                {
                    i++;
                }
                newArray[index] = timeArray[i];
                index++;
            }
            MyArray = new T[newArray.Length - num];
            for (int i = 0; i < MyArray.Length; i++)
            {
                MyArray[i] = newArray[i];
            }
            if (num > 0) return true;
            return false;
        }
        public void RemiveAt(int index)
        {
            T[] newArray = new T[MyArray.Length];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = MyArray[i];
            }
            for (int i = index + 1; i < newArray.Length; i++)
            {
                newArray[i - 1] = MyArray[i];
            }
            MyArray = new T[newArray.Length - 1];
            for (int i = 0; i < MyArray.Length; i++)
            {
                MyArray[i] = newArray[i];
            }
        }
        public void Sort()
        {
            T temp;
            for (int i = 0; i < MyArray.Length; i++)
            {
                for (int j = i + 1; j < MyArray.Length; j++)
                {
                    Convert.ToString(MyArray[i]);
                    string strI = Convert.ToString(MyArray[i]);
                    string strJ = Convert.ToString(MyArray[j]);

                    if (strI.CompareTo(strJ) > 0)
                    {
                        if (strI != "" && strJ != "")
                        {
                            temp = MyArray[i];
                            MyArray[i] = MyArray[j];
                            MyArray[j] = temp;
                        }
                    }
                }
            }
        }
        public void Changemin()
        {
            T[] oldArray = new T[MyArray.Length];
            for (int i = 0; i < MyArray.Length; i++)
            {
                oldArray[i] = MyArray[i];
            }
            Sort();
            T max = MyArray[MyArray.Length- 1];
            T min = MyArray[0];
            int indexMin = 0; int indexMax = 0;
            for (int i = 0; i < MyArray.Length; i++)
            {
                if (Convert.ToString(oldArray[i]) == Convert.ToString(min)) indexMin = i;
                if (Convert.ToString(oldArray[i]) == Convert.ToString(max)) indexMax = i;
            }
            oldArray[indexMin] = max;
            oldArray[indexMax] = min;
            for (int i = 0; i < MyArray.Length; i++)
            {
                MyArray[i] = oldArray[i];
            }
        }
        public List<string> All_eq(List<string> list)
        {
            string[] workList = new string[list.Count];
            int maxLengthStr = 0;
            for (int i = 0; i < workList.Length; i++)
            {
                workList[i] = list[i];
                if (workList[i].Length > maxLengthStr) maxLengthStr = workList[i].Length;
            }
            for (int i = 0; i < workList.Length; i++)
            {
                while (workList[i].Length < maxLengthStr)
                {
                    workList[i] = workList[i] + "_";
                }
            }
            for (int i = 0; i < workList.Length; i++)
            {
                list[i] = workList[i];
            }
            return list;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {   //Для теста   All_eq
            List<string> myList33 = new List<string>();
            myList33.Add("Forest"); myList33.Add("Apple"); myList33.Add("Red"); 
            myList33.Add("stream"); myList33.Add("LionGeat"); myList33.Add("Misha");
            //
            //ДляТеста Лист цифр...
            MyList<int> myListInt = new MyList<int>();
            int[] arrInt1 = new int[2] { 5, 2 }; int[] arrInt2 = new int[2] { 5, 9 };
            int[] arrInt3 = new int[2] { 8, 6 }; int[] arrInt4 = new int[2] { 1, 5 };
            //
            //ДляТеста Лист символов, слов...
            MyList<string> myList = new MyList<string>();
            myList.Add("w"); myList.Add("b"); myList.Add("c"); myList.Add("f"); myList.Add("h");
            myList.Add("k");myList.Add("l"); myList.Add("o"); myList.Add("q"); myList.Add("p");
            Console.WriteLine();
            for (int i = 0; i < myList.MyArray.Length; i++)
            {
                Console.WriteLine($"{i}){myList.MyArray[i]}");
            }
            //
            myListInt.AddRange(arrInt1); myListInt.AddRange(arrInt2);
            myListInt.AddRange(arrInt3); myListInt.AddRange(arrInt4);
            Console.WriteLine();
            for (int i = 0; i < myListInt.MyArray.Length; i++)
            {
                Console.WriteLine($"{i}){myListInt.MyArray[i]}");
            }
            //
            myListInt.Insert(3,100); myListInt.Insert(1, 100);
            myListInt.Insert(2, 100); myListInt.Insert(4, 99);
            Console.WriteLine();
            for (int i = 0; i < myListInt.MyArray.Length; i++)
            {
                Console.WriteLine($"{i}){myListInt.MyArray[i]}");
            }
            //
            Console.WriteLine();
            Console.WriteLine(myListInt.Remove(100));
            Console.WriteLine();
            Console.WriteLine(myListInt.IndexOf(8));
            //
            myListInt.RemiveAt(2);
            myListInt.RemiveAt(2);
            Console.WriteLine();
            for (int i = 0; i < myListInt.MyArray.Length; i++)
            {
                Console.WriteLine($"{i}){myListInt.MyArray[i]}");
            }
            //
            myListInt.Sort();
            Console.WriteLine();
            for (int i = 0; i < myListInt.MyArray.Length; i++)
            {
                Console.WriteLine($"{i}){myListInt.MyArray[i]}");
            }
            //
            myListInt.Changemin();
            Console.WriteLine();
            for (int i = 0; i < myListInt.MyArray.Length; i++)
            {
                Console.WriteLine($"{i}){myListInt.MyArray[i]}");
            }
            //
            Console.WriteLine();
            foreach (var f in myList.All_eq(myList33)) Console.WriteLine(f);
            //
        }
    }
}
