using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTree
{
    public static class TreeSort
    {
        public static void Sort(List<string> data)
        {
            if (data.Count == 0)
                return;
            Node Root = new Node(data[0]);
            for (int i = 1; i < data.Count; i++)
            {
                Root.AddNode(data[i]);
            }
            data.Clear();
            data.AddRange(Root.GetSorted());
        }
    }
}
