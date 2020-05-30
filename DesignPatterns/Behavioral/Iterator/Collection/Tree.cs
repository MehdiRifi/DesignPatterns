using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Iterator
{
    public class Tree : ITreeCollection
    {
        private readonly IList<TreeItem> _tree;
        public Tree(IList<TreeItem> list)
        {
            _tree = list;
        }
        public IIterator<TreeItem> GetDepthFirstIterator()
        {
            return new DepthFirstIterator(_tree);
        }
    }
}
