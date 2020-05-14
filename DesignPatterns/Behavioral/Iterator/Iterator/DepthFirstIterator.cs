using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Behavioral.Iterator
{
    public class DepthFirstIterator : IIterator<TreeItem>
    {
        private IList<TreeItem> _tree;
        private IList<TreeItem> _traversedNodes;
        private TreeItem _currentItem;

        public DepthFirstIterator(IList<TreeItem> items)
        {
            if (items == null || items.Count == 0)
            {
                throw new Exception("Tree is null or empty.");
            }
            _tree = items;
            _traversedNodes = new List<TreeItem>();
        }
        public TreeItem First()
        {
            return _tree.FirstOrDefault();
        }

        public TreeItem GetCurrentItem()
        {
            return _currentItem;
        }

        public bool HasMore()
        {
            return _traversedNodes.Count < _tree.Count;
        }

        public TreeItem Next()
        {
            // no more element left on the tree
            if (!HasMore())
                return null;

            TreeItem node = null;
            // first iteration
            if (_currentItem == null)
                node = _tree[0];
            else
            {
                node = GetUntraversedFirstChildRec(_currentItem);
            }
            // move and save the current position
            MoveToNode(node);
            return _currentItem;
        }

        /// <summary>
        /// move to the new node
        /// </summary>
        /// <param name="item"></param>
        private void MoveToNode(TreeItem item)
        {
            _currentItem = item;
            _traversedNodes.Add(item);
        }
        /// <summary>
        /// retreive the untraversed first child recursively
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private TreeItem GetUntraversedFirstChildRec(TreeItem item)
        {
            // if we hit the root of the tree
            if (item == null) return null; 
            // get untraversed child of the node
            var newChild = item.Childs.Where(c => !_traversedNodes.Contains(c)).FirstOrDefault();
            // all node childs are traversed => go back to parent
            if (newChild == null)
                newChild = GetUntraversedFirstChildRec(item.Parent);
            return newChild;
        }
    }
}
