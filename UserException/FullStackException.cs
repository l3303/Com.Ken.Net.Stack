using System;

namespace Com.Ken.NET.Stack.UserException
{
    public class FullStackException :Exception
    {
        public FullStackException(int count) :base("Stack is full with max amount " + count)
        {
        }
    }
}
