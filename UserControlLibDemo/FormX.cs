using SIRpriseUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlLibDemo
{
    public partial class FormX : SpForm
    {
        public FormX()
        {
            InitializeComponent();
        }

        private void spBlockDiagram1_BlockClick(object sender, EventArgs e)
        {
            int idx = ((SpBlockDiagram.BlockClickEventArgs)e).BlockIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Color[] _data = new Color[1000];
            for (int i = 0; i < 1000; i++)
            {
                _data[i] = Color.FromArgb(255, rnd.Next(50, 255), rnd.Next(50, 255), rnd.Next(50, 255));
            }
            spBlockDiagram1.SetAnalyzeData(_data);
            if (spBlockDiagram1.AllBlocksDisplayed)
                textBox1.Text = "All Blocks are displayed";
            else
                textBox1.Text = "BlockDiagramControl size too small to display all Blocks";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            byte[] _data = new byte[1000];
            for (int i = 0; i < 1000; i++)
            {
                _data[i] = (byte)rnd.Next(0, 2); //use indexes of preselected colors (see BlockColors Property)
            }
            spBlockDiagram1.SetAnalyzeData(_data);
            if (spBlockDiagram1.AllBlocksDisplayed)
                textBox1.Text = "All Blocks are displayed";
            else
                textBox1.Text = "BlockDiagramControl size too small to display all Blocks";
        }

    }
}
