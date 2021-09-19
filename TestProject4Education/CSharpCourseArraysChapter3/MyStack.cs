using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourseOOPChapter3
{
    public class MyStack<T>
    {
        private T[] _items;
        public int Count { get; private set; }
        public int Capacity
        {
            get
            {
                return _items.Length;
            }
        }
        public MyStack()
        {
            const int defaultCapacity = 4;
            _items = new T[defaultCapacity];
        }

        public MyStack(int capacity)
        {
            _items = new T[capacity];
        }

        public void Push(T item)
        {
            if(_items.Length == Count)
            {
                T[] expandArray = new T[Count * 2];
                Array.Copy(_items, expandArray, Count);

                _items = expandArray;
            }
            _items[Count++] = item; // Inc Count after add a object;
        }

        public void Pop()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }

            _items[--Count] = default; 
        }

        public object Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return _items[Count - 1];
        }
    }
}
