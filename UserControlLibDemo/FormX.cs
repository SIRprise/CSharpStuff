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
        }

    }
}
