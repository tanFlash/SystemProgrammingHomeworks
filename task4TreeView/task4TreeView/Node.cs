using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task4TreeView
{
    class Node
    {
        public List<Node> _children = new List<Node>();
        private Node _parent = null;
        private Process _thisProc;
        public string _nameProcess;
        public string _property;
        private string _parentProp;

        public Node(string parentProp, string nameProcess, string property, Process inProc)
        {
            _parentProp = parentProp;
            _nameProcess = nameProcess;
            _property = property;
            _thisProc = inProc;
        }

        public Node()
        {
        }

        public bool Add(Node tmp)
        {
            if (tmp._parentProp == _property)
            {
                _children.Add(tmp);
                return true;
            }
            else
            {
                foreach (Node item in _children)
                {
                    if (item.Add(tmp))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public string Find(TreeNode node)
        {
            List<int> NodeIndex = new List<int>();

            TreeNode asd = node;

            while (asd.Parent != null)
            {
                NodeIndex.Add(asd.Index);
                asd = asd.Parent;
            }

            return RecursionFind(NodeIndex, this);

        }

        private string RecursionFind(List<int> IndexNode, Node node)
        {
            if (IndexNode.Count != 0)
            {
                int i = IndexNode[IndexNode.Count - 1];
                IndexNode.RemoveAt(IndexNode.Count - 1);
                return RecursionFind(IndexNode, node._children[i]);
            }
            return node._property;
        }

    }
}
