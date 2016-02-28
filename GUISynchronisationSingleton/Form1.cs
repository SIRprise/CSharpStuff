using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUISynchronisationSingleton
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            CHelper helper = CHelper.getInstance(this);
            helper.NewData += this.updateBar4;
        }

        public void updateBar2(object sender, EventArgs e) //Aufruf durch anderen Thread
        {
            if(progressBar1.Maximum > progressBar1.Value)
                progressBar1.Value += 1;
        }

        public void updateBar3(object sender, TimerNewDataEventArgs e) //Aufruf durch anderen Thread
        {
            int zusatzdaten = e.timeMs;

            if (progressBar1.Maximum > progressBar1.Value)
                progressBar1.Value += 1;
        }

        public void updateBar4(object sender, TimerNewDataEventArgs e) //Aufruf durch anderen Thread
        {
            int zusatzdaten = e.timeMs;

            if (InvokeRequired) //aktueller Thread GUI-Thread? (Invoke = "anrufen")
            {
                if (IsHandleCreated && !IsDisposed)
                { //soll Absturz beim Beenden verhindern
                    //Invoke durch BeginInvoke ersetzt (BeginInvoke blockiert nicht)
                    BeginInvoke(new EventHandler<TimerNewDataEventArgs>(updateBar4),sender,e); //ruf dich selbst ggf. nochmal im richtigen Thread auf
                }
                return;
            }

            if (progressBar1.Maximum > progressBar1.Value)
                progressBar1.Value += 1;
        }
        
    }
    
    public class TimerNewDataEventArgs : EventArgs
    {
        public readonly int timeMs;

        public TimerNewDataEventArgs(int timeMs)
        {
            this.timeMs = timeMs;
        }
    }
    
    
}
