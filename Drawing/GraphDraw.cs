using MyGraph;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing
{
    public class GraphDraw
    {

        private int Rad = 35;
        Bitmap Bitmap { get; set; }
        Graphics G;
        public int Height { get; set; }
        public int Width { get; set; }
        public Size size
        {
            get => new Size(Width, Height);
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }
        public GraphStr graph { get; set; }
        private void DrawNode(Node node)
        {
            node.Was = true;
            for (int i = 0; i < node.Edges.Count; i++)
                if (!node.Edges[i].B.Was)
                {
                    G.DrawLine(Pens.Black, node.X, node.Y, node.Edges[i].B.X, node.Edges[i].B.Y);
                    G.DrawString(node.Edges[i].Value.ToString(), new Font("Microsoft Sans Serif", 20), Brushes.Black, (node.X + node.Edges[i].B.X) / 2 + 10, (node.Y + node.Edges[i].B.Y) / 2 + 10);
                }
            G.FillEllipse(node.Selected?Brushes.Blue: Brushes.Red, node.X - Rad, node.Y - Rad, 2 * Rad, 2 * Rad);
            float t = 0;
            string text = node.Value.ToString();
            do
            {
                t += (float)0.2;
            }
            while (G.MeasureString(text, new Font("Microsoft Sans Serif", t)).Width < Rad * 3 / 2);
            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            G.DrawString(text, new Font("Microsoft Sans Serif", t), Brushes.Black, new Rectangle(node.X - Rad, node.Y - Rad, 2 * Rad, 2 * Rad), sf);
        }
        public GraphDraw(Size size, GraphStr graph)
        {
            this.size = size;
            this.graph = graph;
        }
        public GraphDraw(int height, int width, GraphStr graph)
        {
            Height = height;
            Width = width;
            this.graph = graph;
        }
        public Bitmap Draw()
        {
            Bitmap = new Bitmap(Width, Height);
            G = Graphics.FromImage(Bitmap);
            graph.ClearWas();
            foreach (Node item in graph.Nodes)
                DrawNode(item);
            return Bitmap;
        }
        public bool Empty(int X, int Y)
        {
            foreach (Node item in graph.Nodes)
            {
                if (Math.Pow(item.X - X, 2) + Math.Pow(item.Y - Y, 2) < 4 * Rad)
                    return false;
            }
            return true;
        }


        public Node GetNode(int X, int Y)
        {
            foreach (Node item in graph.Nodes)
            {
                if (Math.Pow(item.X - X, 2) + Math.Pow(item.Y - Y, 2) < Rad * Rad)
                    return item;
            }
            return null;
        }
    }
}
