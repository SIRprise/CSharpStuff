using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GUISynchronisationSingleton
{
    class CHelper
    {
        //lokale Events in öffentlichen EventHandler weitergeben
        public event EventHandler<TimerNewDataEventArgs> NewData;

        #region Variablen
        private static volatile CHelper instanzvar;
        private static object syncRoot = new Object();

        private System.Timers.Timer t1;
        private const int iTimerIntervall = 250; //in Millisekunden, also delay für "manuelles" Anstoßen der Berechnung

        private static Form1 form1;
        #endregion

        private CHelper()
        {
            t1 = new System.Timers.Timer(iTimerIntervall);
            t1.Elapsed += new ElapsedEventHandler(OnTimedEvent); // Eventhandler ezeugen der beim Timerablauf aufgerufen wird
            t1.Start();
        }

        public static CHelper getInstance(Form1 f1)
        {
            form1 = f1;
            if (instanzvar == null)
            {
                lock (syncRoot)
                {
                    if (instanzvar == null)
                        instanzvar = new CHelper();
                }
            }
            return instanzvar;
        }

        public static CHelper getInstance()
        {
            if (instanzvar == null)
            {
                lock (syncRoot)
                {
                    if (instanzvar == null)
                        instanzvar = new CHelper();
                }
            }
            return instanzvar;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            //updateBar
            if (form1.InvokeRequired) //aktueller Thread GUI-Thread? (Invoke = "anrufen")
            {
                if (form1.IsHandleCreated && !form1.IsDisposed)
                { //soll Absturz beim Beenden verhindern / Invoke durch BeginInvoke ersetzt (BeginInvoke blockiert nicht)


                    //Wähle eine Variante:

                    //form1.BeginInvoke(new EventHandler(form1.updateBar2)); //einfachste Version
                    //form1.BeginInvoke(new EventHandler<TimerNewDataEventArgs>(form1.updateBar3), this, new TimerNewDataEventArgs(1234)); //mit Datenübergabe
                    NewData(this, new TimerNewDataEventArgs(1234)); //elegant als Event, welches sich selbst kümmert + Datenübergabe
                }
                return;
            }
        }

    }
}
