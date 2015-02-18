using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task4TreeView
{
    class TreeViewList
    {
        private List<Process> procArr;
        private Process process;
        private List<List<string>> ThreeViewList;
        private Node _treeNode;
        private List<string> row;
        private Thread threadCalc;
        private ThreadStart threadStart;
        private delegate void MyDelegat();
        private MyDelegat del;
        private TreeView _inTree;

        public TreeViewList(TreeView inTree)
        {
            del = new MyDelegat(StartFillTree);
            _inTree = inTree;
            procArr = new List<Process>(Process.GetProcesses());
            process = new Process();

            ThreeViewList = new List<List<string>>();
            row = new List<string>();

            threadStart = new ThreadStart(CalcTree);
            threadCalc = new Thread(threadStart);
            threadCalc.Start();
        }

        private void CalcTree()
        {
            _treeNode = new Node();

            for (int i = 0; i < procArr.Count; i++)
            {
                Process item = procArr[i];

                try
                {
                    process = ProcessExtensions.Parent(item);
                }
                catch (Exception)
                {
                    process = item;
                }

                if (process.ProcessName == item.ProcessName)
                {
                    Node tmp = new Node(null, item.ProcessName, item.Id.ToString(), item);

                    _treeNode.Add(tmp);
                    procArr.RemoveAt(i);
                    i--;
                }
            }
            while (procArr.Count > 0)
            {
                for (int i = 0; i < procArr.Count; i++)
                {
                    Process item = procArr[i];

                    try
                    {
                        process = ProcessExtensions.Parent(item);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                    Node tmp = new Node(process.Id.ToString(), item.ProcessName, item.Id.ToString(), item);

                    if (_treeNode.Add(tmp))
                    {
                        procArr.RemoveAt(i);
                        i--;
                    }
                }
            }
            _inTree.Invoke(del);
        }

        public void StartFillTree()
        {
            _inTree.Nodes.Clear();
            _inTree.Nodes.Add("null");
            foreach (Node item in _treeNode._children)
            {
                FillTree(_inTree.Nodes[0], item);
            }
        }

        private void FillTree(TreeNode inTree, Node inNod)
        {
            string tmpStr = " ";
            if (inNod._property == null)
                tmpStr = "NULL";
            else
                tmpStr = inNod._nameProcess;

            TreeNode tn = inTree.Nodes.Add(tmpStr);

            foreach (Node item in inNod._children)
            {
                FillTree(tn, item);
            }
        }

        public string Find(TreeNode inTreeNode)
        {
            return _treeNode.Find(inTreeNode);
        }
    }
}
