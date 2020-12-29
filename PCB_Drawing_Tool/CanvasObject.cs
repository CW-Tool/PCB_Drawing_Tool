using System.Drawing;
using System.Windows.Forms;

namespace PCB_Drawing_Tool
{
    abstract class CanvasObject
    {
        protected Point coordiantes;
        protected Color backgroundColor;
        private int id;

        public int Id
        {
            get { return id; }
        }

        public CanvasObject (int x1, int y1, int id)
        {
            coordiantes = new Point(x1, y1);
            backgroundColor = Color.Black;
            this.id = id;
        }

        public abstract PictureBox CreateCanvasObject();

        public virtual string[] GetObjectParameters()
        {
            return new string[] { coordiantes.X.ToString(), coordiantes.Y.ToString() };
        }

        public void AddEventHandlers(PictureBox canvasObject)
        {
            canvasObject.MouseDown += new MouseEventHandler(MainProgram.MainForm.mainDrawBox_MouseDown);
            canvasObject.MouseUp += new MouseEventHandler(MainProgram.MainForm.mainDrawBox_MouseUp);
            canvasObject.Click += new System.EventHandler(MainProgram.MainForm.SelectObject);
        }
    }
}
