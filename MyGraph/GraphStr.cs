using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGraph
{
    public class GraphStr
    {
        public List<Node> Nodes { get; set; }
        public void AddNode(string value, int x, int y) => Nodes.Add(new Node(value, x, y));
        public void ClearWas()
        {
            foreach (Node item in Nodes)
            {
                item.Was = false;
                item.Distance = -1;
            }
        }
        public void ClearSelected()
        {
            foreach (Node item in Nodes)
            {
                item.Selected = false;
            }
        }
        private void SetDist(Node node)
        {
            ClearWas();
            node.Distance = 0;
            for (int i = 0; i < Nodes.Count; i++)
            {
                Node Min = null;
                for (int j = 0; j < Nodes.Count; j++)
                {
                    if(!Nodes[j].Was && Nodes[j].Distance >= 0 &&(Min == null || Nodes[j].Distance < Min.Distance))
                    {
                        Min = Nodes[j];
                    }
                }
                if (Min == null)
                    break;
                Min.Was = true;
                foreach (Edge item in Min.Edges)
                {
                    if (item.B.Distance > Min.Distance + item.Value||item.B.Distance == -1)
                        item.B.Distance = Min.Distance + item.Value;
                }
            }
        }
        private List<Node> GetNodesWithMaxDist(Node node, int value)
        {
            ClearWas();
            node.Distance = 0;
            for (int i = 0; i < Nodes.Count; i++)
            {
                Node Min = null;
                for (int j = 0; j < Nodes.Count; j++)
                {
                    if (!Nodes[j].Was && Nodes[j].Distance >= 0 && (Min == null || Nodes[j].Distance < Min.Distance))
                    {
                        Min = Nodes[j];
                    }
                }
                if (Min == null || Min.Distance > value)
                    break;
                Min.Was = true;
                foreach (Edge item in Min.Edges)
                {
                    if (item.B.Distance > Min.Distance + item.Value || item.B.Distance == -1)
                        item.B.Distance = Min.Distance + item.Value;
                }
            }
            List<Node> selected = new List<Node>();
            for (int i = 0; i < Nodes.Count; i++)
            {
                if (Nodes[i].Distance >= 0 && Nodes[i].Distance < value)
                    selected.Add(Nodes[i]);
            }
            return selected;
        }
        private bool SetNewEdges(List<Node> Unavailable, Node Main, int Value)
        {
            if (Value >= 100)
                return false;
            if (Unavailable.Count < 4)
            {
                bool t = true;
                foreach (Node item in Unavailable)
                {
                    if(Main.Contains(item))
                    {
                        t = false;
                        break;
                    }
                }
                if (t)
                {
                    foreach (Node item in Unavailable)
                    {
                        Main.AddEdge(item, Value);
                    }
                    return true;

                }
            }
            List<List<Node>> selected = new List<List<Node>>();
            List<Node> AllSelected = new List<Node>();
            for (int i = 0; i < Unavailable.Count; i++)
            {
                selected.Add(GetNodesWithMaxDist(Unavailable[i], 99 - Value));
                foreach (Node item in selected[i])
                {
                    if (!AllSelected.Contains(item))
                        AllSelected.Add(item);
                }
            }
            if (AllSelected.Count < 4)
            {
                List<Node> ToAdd = new List<Node>();
                foreach (List<Node> list in selected)
                {
                    bool t = false;
                    foreach (Node item in list)
                    {
                        if(!Main.Contains(item))
                        {
                            t = true;
                            ToAdd.Add(item);
                            break;
                        }
                    }
                    if (!t)
                        return false;
                }
                foreach (Node item in ToAdd)
                {
                    Main.AddEdge(item, Value);
                }
                return true;
            }
            for (int i = 0; i < AllSelected.Count - 2; i++)
                for (int j = i + 1; j < AllSelected.Count - 1; j++)
                    for (int k = j + 1; k < AllSelected.Count; k++)
                        if (!Main.Contains(AllSelected[i]) && !Main.Contains(AllSelected[j]) && !Main.Contains(AllSelected[k]))
                        {
                            bool t = true;
                            for (int n = 0; n < selected.Count; n++)
                            {
                                if (!selected[n].Contains(AllSelected[i]) && !selected[n].Contains(AllSelected[j]) && !selected[n].Contains(AllSelected[k]))
                                {
                                    t = false;
                                    break;
                                }
                            }
                            if (t)
                            {
                                Main.AddEdge(AllSelected[i], Value);
                                Main.AddEdge(AllSelected[j], Value);
                                Main.AddEdge(AllSelected[k], Value);
                                return true;
                            }
                        }
            return false;
        }
        public Node GetBestNode(int Value)
        {
            foreach (Node Main in Nodes)
            {
                SetDist(Main);
                List<Node> Unavailable = new List<Node>();
                foreach (Node item in Nodes)
                {
                    if (item.Distance >= 100 || item.Distance == -1)
                        Unavailable.Add(item);
                }
                if (Unavailable.Count == 0)
                    return Main;
                if (SetNewEdges(Unavailable, Main, Value))
                    return Main;
            }
            return null;
        }
        public void Remove(Node node)
        {
            foreach (Node item in Nodes)
            {
                node.RemoveEdge(item);
            }
            Nodes.Remove(node);
        }

        public GraphStr()
        {
            Nodes = new List<Node>();
        }
    }
}
