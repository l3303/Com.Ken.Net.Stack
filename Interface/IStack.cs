namespace Com.Ken.NET.Stack.Interface
{
    public interface IStack<T>
    {
        void Push(T obj);
        T Pop();
        bool IsFull();
        int Length();
    }
}
