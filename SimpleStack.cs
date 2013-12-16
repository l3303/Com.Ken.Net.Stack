using System;
using Com.Ken.NET.Stack.Interface;
using Com.Ken.NET.Stack.UserException;

namespace Com.Ken.NET.Stack
{
    public class SimpleStack<T> : IStack<T>
    {
        private static readonly int MAX_COUNT = 10000000;

        private T[] stack;
        private int maxCount;
        private int length;

        public SimpleStack():this(MAX_COUNT)
        {
        }

        public SimpleStack(int maxCount)
        {
            if (maxCount > MAX_COUNT)
            {
                throw new ArgumentOutOfRangeException("Cannot initialize stack larger than " + MAX_COUNT + " elements!");
            }
            else
            {
                this.maxCount = maxCount;
                stack = new T[maxCount];
                length = 0;
            }
        }

        public void Push(T obj)
        {
            try
            {
                stack[length] = obj;
                length++;
            }
            catch (ArgumentOutOfRangeException exp)
            {
                throw new FullStackException(maxCount);
            }
        }

        public T Pop()
        {
            if (length == 0)
            {
                throw new ArgumentOutOfRangeException("Cannot pop empty stack!");
            }
            else
            {
                length--;
                return stack[length];
            }
        }

        public bool IsFull()
        {
            return length > maxCount;
        }

        public int Length()
        {
            return length;
        }
    }
}
