using System;
namespace DesignPatterns.Behavioral.Iterator
{
    public interface ITreeCollection
    {
        IIterator<TreeItem> GetDepthFirstIterator();
    }
}
