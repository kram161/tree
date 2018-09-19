using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTree
{
    class Node
    {
        public string Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public void AddNode(string value)
        {
            if(value.Length > Value.Length)
            {
                if (Right == null)
                    Right = new Node(value);
                else
                    Right.AddNode(value);
            }
            else
            {
                if (Left == null)
                    Left = new Node(value);
                else
                    Left.AddNode(value);
            }
        }
        public Node(string value) => Value = value;
        public List<string> GetSorted()
        {
            List<string> list = new List<string>();
            if (Left != null)
                list.AddRange(Left.GetSorted());
            list.Add(Value);
            if (Right != null)
                list.AddRange(Right.GetSorted());
            return list;
        }
    }
}
