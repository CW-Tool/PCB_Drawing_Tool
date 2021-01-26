using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCB_Drawing_Tool
{
    static class MainProgram
    {
        private static Form1 mainForm;
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();

            mainForm = new Form1();

            if (FileManager.Singleton.CheckForSavedCanvasObjects())
            {
                FileManager.Singleton.ReadFromFile();
            }

            Application.Run(mainForm);
        }

        public static Form1 MainForm
        {
            get { return mainForm; }
        }
    }
}
