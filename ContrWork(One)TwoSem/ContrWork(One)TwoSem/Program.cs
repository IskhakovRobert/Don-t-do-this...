using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContrWork_One_TwoSem
{
    class SetOfStacks<T>
    {
        public int counter = 1;
        public List<Stack<T>> stackList = new List<Stack<T>>();
        public List<Stack<T>> newStackList = new List<Stack<T>>();
        public Stack<T> stack = new Stack<T>(2);
        public void Push(T item)
        {   
            if ( stack.Count == 2)
            {
                stackList.Add(stack);
                stack = new Stack<T>(2);
            }
            stack.Push(item);
            //stackList.Add(stack);
        }
        public void Pop()
        {
            stack.Pop();
            //if (stack.Count == 0)
            //{
            //    if (stackList[stackList.Count - counter].Count == 0)
            //    {
            //        counter++;
            //    }
            //    stackList[stackList.Count - counter].Pop();
                
            //}
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            SetOfStacks<int> MyStack = new SetOfStacks<int>();
            MyStack.Push(13);
            MyStack.Push(22);
            MyStack.Push(777);
            MyStack.Push(34);
            MyStack.Push(3);
            MyStack.Push(666);
            MyStack.Push(7);
            MyStack.Push(890);
            MyStack.Push(77777777);
            MyStack.Push(12);
            MyStack.Push(1111);
            MyStack.Pop();
            MyStack.Pop();
            MyStack.Pop();
            MyStack.Pop();
            MyStack.Pop();
            MyStack.Pop();
            MyStack.Pop();
            MyStack.Pop();
            //Console.WriteLine(MyStack.stackList[1].Pop());
            //Console.WriteLine(MyStack.stackList[1].Pop());
            //Console.WriteLine(MyStack.stackList[2].Pop());
            //Console.WriteLine(MyStack.stackList[2].Pop());
        }
    }
}
