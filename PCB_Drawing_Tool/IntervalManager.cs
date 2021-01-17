using System.Collections.Generic;
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

            Timer drawPreviewObject = new Timer();
            drawPreviewObject.Interval = 1;
            drawPreviewObject.Tick += MainProgram.MainForm.CreatePreviewObject;
            allTimers["drawPreviewObject"] = drawPreviewObject;

            Timer copySelectedObject = new Timer();
            copySelectedObject.Interval = 1;
            copySelectedObject.Tick += MainProgram.MainForm.CopySelectedObject;
            allTimers["copySelectedObject"] = copySelectedObject;

            Timer moveSelectedObject = new Timer();
            moveSelectedObject.Interval = 1;
            moveSelectedObject.Tick += MainProgram.MainForm.MoveSelectedObject;
            allTimers["moveSelectedObject"] = moveSelectedObject;

            Timer moveAllObjects = new Timer();
            moveAllObjects.Interval = 1;
            moveAllObjects.Tick += MainProgram.MainForm.MoveAllObjects;
            allTimers["moveAllObjects"] = moveAllObjects;

            Timer autosaveCanvas = new Timer();
            autosaveCanvas.Interval = 10000;
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


        /// <summary>
        /// Starts or stops a specific timer.
        /// </summary>
        /// <param name="timerName">String defining which timer to modifiy.</param>
        /// <param name="activate">True = start, False = stop.</param>
        public void ManageTimer(string timerName, bool activate)
        {
            if (activate)
            {
                allTimers[timerName].Start();
            }
            else
            {
                allTimers[timerName].Stop();
            }
            
        }


        /// <summary>
        /// Checks if a specific timer is running.
        /// </summary>
        /// <param name="timerName">The name of the timer which is to be checked.</param>
        /// <returns>True = active, False = inactive.</returns>
        public bool GetTimerStatus(string timerName)
        {
            return allTimers[timerName].Enabled;
        }
    }
}
