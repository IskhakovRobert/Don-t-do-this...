using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DoubleNode
{
    class NumberOne<T>
    {
        public LinkedList<T> linkedList = new LinkedList<T>();
        public List<T> list = new List<T>();
        public LinkedList<T> AddSaveOrder(T str)
        {
            list.Add(str);
            list.Sort();
            linkedList = new LinkedList<T>();
            linkedList.AddFirst(list[0]);
            for (int i = 1; i < list.Count; i++)
            {
                linkedList.AddLast(list[i]);
            }
            return linkedList;
        }
    }
    class NumberTwo<T>
    {
        //public LinkedList<T> linkedList = new LinkedList<T>();
        public LinkedList<T> linkedList1 = new LinkedList<T>();
        public LinkedList<T> linkedList2 = new LinkedList<T>();
        public LinkedList<T> linkedListMerge = new LinkedList<T>();
        public List<T> list1 = new List<T>();
        public List<T> list2 = new List<T>();
        public void SortRevers(T str, int num)
        {
            if (num > 0)
            {
                list1.Add(str);
                list1.Sort();
                linkedList1 = new LinkedList<T>();
                linkedList1.AddFirst(list1[0]);
                for (int i = 1; i < list1.Count; i++)
                {
                    linkedList1.AddFirst(list1[i]);
                }
            }
            else
            {
                list2.Add(str);
                list2.Sort();
                linkedList2 = new LinkedList<T>();
                linkedList2.AddFirst(list2[0]);
                for (int i = 1; i < list2.Count; i++)
                {
                    linkedList2.AddFirst(list2[i]);
                }
            }
        }
        public void MergeLink()
        {
            List<T> workList = new List<T>();
            for(int i = 0; i < list1.Count; i ++)
                workList.Add(list1[i]);
            for (int i = 0; i < list2.Count; i++)
                workList.Add(list2[i]);

            workList.Sort();
            linkedListMerge = new LinkedList<T>();
            linkedListMerge.AddFirst(workList[0]);
            for (int i = 1; i < workList.Count; i++)
            {
                linkedListMerge.AddFirst(workList[i]);
            }
        }
    }
    class NumberThree
    {
        public LinkedList<int> linkedList = new LinkedList<int>();
        public List<int> list = new List<int>();
        public List<int> listNeed = new List<int>();
        public List<int> listUseless = new List<int>();
        
        public void SortLinkWithPositiveNum()
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 0)
                {
                    listNeed.Add(list[i]);
                }
                else listUseless.Add(list[i]);
            }
            listNeed.Sort();
            linkedList = new LinkedList<int>();
            linkedList.AddFirst(listNeed[0]);
            for (int i = 1; i < listNeed.Count; i++)
            {
                linkedList.AddLast(listNeed[i]);
            }
            for(int i = 0; i < listUseless.Count; i++)
                linkedList.AddLast(listUseless[i]);
        }
        public void SortLinkWithEvenindex()
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                {
                    listNeed.Add(list[i]);
                }
                else listUseless.Add(list[i]);
            }
            listNeed.Sort();
            linkedList = new LinkedList<int>();
            linkedList.AddFirst(listNeed[0]);
            for (int i = 1; i < listNeed.Count; i++)
            {
                linkedList.AddLast(listNeed[i]);
            }
            for (int i = 0; i < listUseless.Count; i++)
                linkedList.AddLast(listUseless[i]);
        }
    }
    class NumberFour<T>
    {
        public LinkedList<T> linkedList1 = new LinkedList<T>();
        public LinkedList<T> linkedList2 = new LinkedList<T>();
        public List<T> list1 = new List<T>();
        public List<T> list2 = new List<T>();
        public bool Equals()
        {
            if (linkedList1.Count != linkedList2.Count) return false;
            LinkedListNode<T> node;
            node = linkedList1.First;
            list1.Add(node.Value);
            for (int i = 1; i < linkedList1.Count; i++)
            {
                node = node.Next;
                list1.Add(node.Value);
            }

            node = linkedList2.First;
            list2.Add(node.Value);
            for (int i = 1; i < linkedList2.Count; i++)
            {
                node = node.Next;
                list2.Add(node.Value);
            }
            list1.Sort();
            list2.Sort();
            for (int i = 0; i < list1.Count; i++)
            {
                if (Convert.ToString(list1[i]) != Convert.ToString(list2[i])) return false;
            }
            return true;
        }
    }
    class NumberFive<T>
    {
        public LinkedList<T> linkedList = new LinkedList<T>();
        public LinkedList<T> newLinkedList = new LinkedList<T>();
        List<T> list = new List<T>();
        public void SumLastNode()
        {
            LinkedListNode<T> node = linkedList.First;
            newLinkedList.AddFirst(node.Value);
            list.Add(node.Value);
            for (int i = 1; i < linkedList.Count; i++)
            {
                node = node.Next;
                newLinkedList.AddLast(node.Value);
                list.Add(node.Value);
                for(int j = 0; j < list.Count-1; j++)
                {
                    newLinkedList.AddLast(list[j]);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Возможно тут сделано только 4-ое и 5-ое задание как задумывали,
            //но работа первых трех тоже в теории можно считать работающими,
            //просто не задействована полная развертка двусвязного списка

            LinkedList<string> linkedListStr = new LinkedList<string>();
            linkedListStr.AddFirst("Silence"); linkedListStr.AddLast("Boby"); linkedListStr.AddLast("Yeah");
            LinkedList<int> linkedListInt = new LinkedList<int>();
            linkedListInt.AddFirst(1); linkedListInt.AddLast(2); linkedListInt.AddLast(3); linkedListInt.AddLast(4);

            NumberOne<string> one = new NumberOne<string>();
            one.AddSaveOrder("Silence"); one.AddSaveOrder("Boby");
            one.AddSaveOrder("Quick"); one.AddSaveOrder("Tetris");
            foreach (var f in one.linkedList) Console.WriteLine(f); Console.WriteLine();

            NumberTwo<string> two = new NumberTwo<string>();
            two.SortRevers("Silence", 1); two.SortRevers("Boby", 1); two.SortRevers("Yeah", 1);
            two.SortRevers("Quick", 0); two.SortRevers("Tetris", 0); two.SortRevers("Right", 0);
            two.MergeLink();
            foreach (var f in two.linkedListMerge) Console.WriteLine(f); Console.WriteLine();

            NumberThree three = new NumberThree();
            three.list.Add(3); three.list.Add(-6);
            three.list.Add(-3); three.list.Add(6);
            //three.SortLinkWithPositiveNum(); //   а)
            three.SortLinkWithEvenindex();   //   б)
            foreach (var f in three.linkedList) Console.WriteLine(f); Console.WriteLine();

            NumberFour<int> four = new NumberFour<int>();
            four.linkedList1.AddFirst(3); four.linkedList1.AddLast(5); four.linkedList1.AddLast(6);
            four.linkedList2.AddFirst(3); four.linkedList2.AddLast(5); four.linkedList2.AddLast(5);
            Console.WriteLine(four.Equals()); Console.WriteLine();

            NumberFive<int> five = new NumberFive<int>();
            five.linkedList = linkedListInt;
            five.SumLastNode();
            foreach (var f in five.newLinkedList) Console.WriteLine(f); Console.WriteLine();
        }
    }
}
