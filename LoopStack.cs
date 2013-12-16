using System;
using Com.Ken.NET.Stack.Interface;
using Com.Ken.NET.Stack.Util;

namespace Com.Ken.NET.Stack
{
    public class LoopStack<T> : IStack<T>
    {
        private static readonly int MAX_COUNT = 5000000;
        private int maxCount;

        private T[][] stack;

        private Flag startFlag;
        private Flag endFlag;

        public LoopStack() :this(MAX_COUNT)
        {
        }

        public LoopStack(int maxCount)
        {
            if (maxCount > MAX_COUNT)
            {
                throw new ArgumentOutOfRangeException("Cannot initialize stack larger than " + MAX_COUNT + " elements!");
            }
            else
            {
                this.maxCount = maxCount;
                stack = new T[2][];
                stack[0] = new T[maxCount];
                stack[1] = new T[maxCount];
                startFlag = new Flag(maxCount);
                endFlag = new Flag(maxCount);
            }
        }

        public void Push(T obj)
        {
            if (!(obj is ValueType) && obj == null)
            {
                throw new NullReferenceException("Cannot push null into a stack!");
            }

            endFlag++;
            if (!(endFlag - startFlag < maxCount))
            {
                startFlag++;
                if (startFlag.PageIndex > 0)
                {
                    startFlag.SubstractPage();
                    endFlag.SubstractPage();
                    var tmp = stack[0];
                    stack[0] = stack[1];
                    stack[1] = tmp;
                }
            }

            stack[endFlag.PageIndex][endFlag.LengthIndex] = obj;
        }

        public T Pop()
        {
            if (startFlag < endFlag)
            {
                var returnValue = stack[endFlag.PageIndex][endFlag.LengthIndex];
                endFlag--;
                return returnValue;
            }
            else
            {
                throw new ArgumentOutOfRangeException(this.GetType().Name, "Cannot pop empty stack!");
            }
        }

        public bool IsFull()
        {
            return false;
        }

        public int Length()
        {
            return endFlag - startFlag;
        }
    }
}
