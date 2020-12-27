using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCB_Drawing_Tool
{
    class IntervalManager
    {
        private static IntervalManager singleton = null;
        private Dictionary<string, Timer> allTimers;

        private IntervalManager()
        {
            allTimers = new Dictionary<string, Timer>();
            
            Timer mouseDownTracker = new Timer();
            mouseDownTracker.Interval = 1;
            mouseDownTracker.Tick += MainProgram.MainForm.CreatePreviewObject;
            allTimers["mouseDownTracker"] = mouseDownTracker;

            Timer autosaveCanvas = new Timer();
            autosaveCanvas.Interval = 60000;
            autosaveCanvas.Tick += FileManager.Singleton.SaveToFile;
            allTimers["autosaveCanvas"] = autosaveCanvas;
        }

        public static IntervalManager Singleton
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new IntervalManager();
                }
                return singleton;
            }
        }

        public void ManageTimer(string timerName, bool activate)
        {
            if (activate)
            {
                allTimers[timerName].Start();
            }
            else if (!activate)
            {
                allTimers[timerName].Stop();
            }
            
        }
    }
}
