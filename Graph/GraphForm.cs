using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Drawing;
using MyGraph;
namespace Graph
{
    public partial class GraphForm : Form
    {
        public GraphForm()
        {
            InitializeComponent();
        }
        GraphDraw GraphDraw;
        GraphStr graph;
        private void GraphForm_Load(object sender, EventArgs e)
        {
            graph = new GraphStr();
            GraphDraw = new GraphDraw(Image.Size, graph);
            Add.SelectedIndex = 0;
            ND.SelectedIndex = 0;
        }
        private void UpdateImage()
        {
            Image.Image = GraphDraw.Draw();
        }

        private void OpenBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileWork file = new FileWork(openFileDialog.FileName);
                    graph = file.Read();
                    GraphDraw.graph = graph;
                    UpdateImage();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileWork file = new FileWork(saveFileDialog.FileName);
                    file.Write(graph);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        Node S = null;
        private void Image_MouseClick(object sender, MouseEventArgs e)
        {
            if(ND.SelectedIndex == 0)
            {
                if(Add.SelectedIndex == 0 )
                {
                    if(GraphDraw.Empty(e.X,e.Y))
                    {
                        InputForm input = new InputForm();
                        if (input.ShowDialog() == DialogResult.OK)
                        {
                            if (!string.IsNullOrWhiteSpace(input.Str))
                            {
                                graph.AddNode(input.Str, e.X, e.Y);
                                UpdateImage();
                            }
                            else MessageBox.Show("неккоректны ввод");
                        }
                    }
                }
                else
                {
                    S = GraphDraw.GetNode(e.X, e.Y);
                    graph.Remove(S);
                    UpdateImage();
                    S = null;
                }
            }
            else
            {
                if(S == null)
                    S = GraphDraw.GetNode(e.X, e.Y);
                else
                {
                    Node SS = GraphDraw.GetNode(e.X, e.Y);
                    if(Add.SelectedIndex == 0)
                    {
                        InputForm input = new InputForm();
                        if (input.ShowDialog() == DialogResult.OK)
                        {
                            if (!string.IsNullOrWhiteSpace(input.Str) && int.TryParse(input.Str,out int result))
                            {
                                S.AddEdge(SS, result);
                                UpdateImage();
                            }
                            else MessageBox.Show("неккоректны ввод");
                        }
                    }
                    else
                    {
                        S.RemoveEdge(SS);
                        UpdateImage();
                    }
                    S = null;
                }
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(InputValue.Text, out int Value))
                {
                    graph.ClearSelected();
                    Node node = graph.GetBestNode(Value);
                    if (node != null)
                    {
                        node.Selected = true;
                    }
                    else
                        MessageBox.Show("невозможно");
                    UpdateImage();
                }
                else MessageBox.Show("неккоректны ввод");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }

        private void Add_SelectedIndexChanged(object sender, EventArgs e) => S = null;

        private void ND_SelectedIndexChanged(object sender, EventArgs e) => S = null;
    }
}
