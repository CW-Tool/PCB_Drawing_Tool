using System.Drawing;
using System.Windows.Forms;

namespace PCB_Drawing_Tool
{
    abstract class CanvasObject
    {
        protected Point coordiantes;
        protected Color backgroundColor;

        public CanvasObject (int x1, int y1)
        {
            coordiantes = new Point(x1, y1);
            backgroundColor = Color.Black;
        }


        /// <summary>
        /// Creates a PictureBox with the desired shape based on which class it belongs to. 
        /// </summary>
        /// <returns>A PictureBox which represents the new CanvasObject.</returns>
        public abstract PictureBox CreateCanvasObject();


        /// <summary>
        /// Retrieves all of the object attributes which are needed in order to be able to recreate the given CanvasObject. 
        /// </summary>
        /// <returns>An array of string values.</returns>
        public virtual string[] GetObjectParameters()
        {
            return new string[] { coordiantes.X.ToString(), coordiantes.Y.ToString() };
        }


        /// <summary>
        /// Adds the default EventHandlers which every CanvasObjects has to have. 
        /// </summary>
        /// <param name="canvasObject"></param>
        public void AddEventHandlers(PictureBox canvasObject)
        {
            canvasObject.MouseDown += new MouseEventHandler(MainProgram.MainForm.mainDrawBox_MouseDown);
            canvasObject.MouseUp += new MouseEventHandler(MainProgram.MainForm.mainDrawBox_MouseUp);
            canvasObject.Click += new System.EventHandler(MainProgram.MainForm.SelectObject);
        }
    }
}
