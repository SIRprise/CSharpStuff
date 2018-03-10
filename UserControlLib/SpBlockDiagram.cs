using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SIRpriseUserControls
{
    public partial class SpBlockDiagram : UserControl //System.Windows.Forms.PictureBox
    {
        private int _numberOfBlocks;

        public SpBlockDiagram()
        {
            InitializeComponent();
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
        }

        [Category("Appearance"), Description("Number of Blocks per Line")]
        public int BlocksPerLine { get; set; }

        [Category("Appearance"), Description("Number of Blocks per Row")]
        public int BlocksPerRow { get; set; }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Color c1 = Color.FromArgb
                (255, Color.Green);
            Color c2 = Color.FromArgb
                (255, Color.Red);
            Brush b = new System.Drawing.Drawing2D.LinearGradientBrush
                (ClientRectangle, c1, c2, 10);
            pe.Graphics.FillRectangle(b, ClientRectangle);
            b.Dispose();
        }

    }
}
