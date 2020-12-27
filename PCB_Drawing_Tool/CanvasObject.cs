using System.Windows.Forms;

namespace PCB_Drawing_Tool
{
    abstract class CanvasObject
    {
        public abstract PictureBox CreateCanvasObject();

        public void AddEventHandlers(PictureBox canvasObject)
        {
            canvasObject.MouseDown += new MouseEventHandler(MainProgram.MainForm.mainDrawBox_MouseDown);
            canvasObject.MouseUp += new MouseEventHandler(MainProgram.MainForm.mainDrawBox_MouseUp);
            canvasObject.Click += new System.EventHandler(MainProgram.MainForm.SelectObject);
        }
    }
}
