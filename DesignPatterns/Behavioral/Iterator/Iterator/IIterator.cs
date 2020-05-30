using System;
namespace DesignPatterns.Behavioral.Iterator
{
    public interface IIterator<T>
    {
        T First();
        T Next();
        bool HasMore();
        T GetCurrentItem();
    }
}
