using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Iterator
{
    public class TreeItem
    {
        public string Name { get; set; }
        public TreeItem Parent { get; set; }
        public IList<TreeItem> Childs { get; set; }
        public bool HasChild
        {
            get
            {
                return Childs != null && Childs.Count > 0;
            }
        }
        public TreeItem(string name, params TreeItem[] items)
        {
            Name = name;
            Childs = new List<TreeItem>();
            AddChilds(items);
        }
        public void AddChilds(params TreeItem[] items)
        {
            foreach (var node in items)
            {
                Childs.Add(node);
            }
        }
    }
}
