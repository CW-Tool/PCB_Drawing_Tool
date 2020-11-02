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
            mainForm = new Form1();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(mainForm);
        }

        public static Form1 MainForm
        {
            get { return mainForm; }
        }
    }
}
