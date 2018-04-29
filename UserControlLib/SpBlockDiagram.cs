using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SIRpriseUserControls
{
    public partial class SpBlockDiagram : UserControl //System.Windows.Forms.PictureBox
    {
        private int _blocksPerLine;
        private int _blockSize = 15;
        private List<Color> _colorList = new List<Color>();
        private bool _allBlocksDisplayed = true;

        [Category("Appearance"), Description("BlockSize")]
        public int BlockSize
        {
            get { return _blockSize; }
            set { _blockSize = value;
                  this.Refresh();
                }
        }

        [Category("Appearance"), Description("BlockColors")]
        public List<Color> BlockColors
        {
            get { return _colorList; }
            set { _colorList = value; }
        }

        private Color[] _data;

        public bool AllBlocksDisplayed
        {
            get { return _allBlocksDisplayed; }
        }

        public SpBlockDiagram()
        {
            InitializeComponent();

            //Sample Data for Designer
            _colorList.Add(Color.Red);
            _colorList.Add(Color.Green);

            Random rnd = new Random();
            _data = new Color[1000];
            for(int i=0;i<1000;i++)
            {
                _data[i] = Color.FromArgb(255, rnd.Next(50, 255), rnd.Next(50, 255), rnd.Next(50, 255));
            }
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);
        }

        public void SetAnalyzeData(byte[] data)
        {
            _data = new Color[data.Length];
            for (int i = 0; i < data.Length; i++)
                _data[i] = _colorList[data[i]];
            this.Refresh();
        }

        public void SetAnalyzeData(Color[] data)
        {
            _data = new Color[data.Length];
            data.CopyTo(_data, 0);

            this.Refresh();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            
            //calculate number of blocks (per line, per row, decide if scrollable)
            int numberOfBlocks = _data.Length;
            int _borderSize = 2;
            _blocksPerLine = ClientRectangle.Width / (_blockSize + _borderSize);
            int numberOfLines = (int)Math.Ceiling((double)numberOfBlocks / _blocksPerLine);
            if ((numberOfBlocks / _blocksPerLine) > numberOfLines)
                numberOfLines++;
            _allBlocksDisplayed = !((ClientRectangle.Height / (numberOfLines * (_blockSize + _borderSize))) < 1);
            if (this.AutoScroll)
            {
                this.VScroll = !_allBlocksDisplayed;
            }

            //paint blocks dependend on decide-function (length) to decide color
            System.Drawing.SolidBrush b = new SolidBrush(Color.Red);
            Graphics g = pe.Graphics;
            for(int y=0; y<numberOfLines; y++)
                for(int x=0; x<_blocksPerLine; x++)
                {
                    if ((y * _blocksPerLine + x) < numberOfBlocks)
                    {
                        b.Color = _data[y * _blocksPerLine + x];
                        g.FillRectangle(b, x * (_blockSize + _borderSize), y * (_blockSize + _borderSize), _blockSize, _blockSize);
                    }
                }
            //g.Dispose();
            b.Dispose();
        }

        int getIndexOfPosition(int x, int y)
        {
            //calculate
            int numberOfBlocks = _data.Length;
            int _borderSize = 2;
            _blocksPerLine = ClientRectangle.Width / (_blockSize + _borderSize);
            int numberOfLines = (int)Math.Ceiling((double)numberOfBlocks / _blocksPerLine);
            if ((numberOfBlocks / _blocksPerLine) > numberOfLines)
                numberOfLines++;

            int linenumber = y / (_blockSize + _borderSize);
            int elementnumber = x / (_blockSize + _borderSize);

            int result = linenumber * _blocksPerLine + elementnumber;
            if (result >= _data.Length)
                return -1;
            return linenumber*_blocksPerLine+elementnumber;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            
            if(getIndexOfPosition(e.X,e.Y) != -1)
                BlockClick(this, new BlockClickEventArgs(getIndexOfPosition(e.X, e.Y)));
        }

        [Category("Action")]
        [Description("Fires when a block was clicked")]
        public event EventHandler BlockClick;

        public class BlockClickEventArgs : EventArgs
        {
            public int BlockIndex { get; set; }

            public BlockClickEventArgs( int index)
            {
                BlockIndex = index;
            }
        }

        protected override void OnMouseHover(EventArgs e)
        {
            
            //tooltip.SetToolTip(this, "test");
            
        }

    }
}
