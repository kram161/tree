using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static MyTree.TreeSort;

namespace TreeSortApp
{
    public partial class TreeForm : Form
    {
        public TreeForm()
        {
            InitializeComponent();
        }
        List<string> Data;
        private void OpenBtn_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Data = new List<string>(File.ReadAllLines(openFileDialog.FileName));
                    OutputUPD();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void OutputUPD()
        {
            if (Data != null)
                Output.Text = string.Join("\r\n", Data);
            else
                Output.Text = "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(Data!= null)
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllLines(saveFileDialog.FileName, Data.ToArray());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
        }

        private void SortBtn_Click(object sender, EventArgs e)
        {
            Sort(Data);
            OutputUPD();
        }
    }
}
