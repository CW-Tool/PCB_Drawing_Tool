using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PCB_Drawing_Tool
{
    class Line : CanvasObject
    {
        private int length;
        private int width;
        private int angle;


        public Line(int x1, int y1, int lineLength, int lineWidth, int lineAngle) : base(x1, y1, CanvasManager.Singleton.GetCountOfCanvasObjects() + 1)
        {
            length = lineLength;
            width = lineWidth;
            angle = lineAngle;

            CanvasManager.Singleton.AddObject(this, CreateCanvasObject());
        }


        public override string[] GetObjectParameters()
        {
            string[] baseParameters = base.GetObjectParameters();
            string[] classParameters = new string[] { length.ToString(), width.ToString(), angle.ToString() };
            return baseParameters.Union(classParameters).ToArray();
        }


        public override PictureBox CreateCanvasObject()
        {
            PictureBox graphicObject = new PictureBox
            {
                Location = coordiantes,
                BackColor = backgroundColor,
                Width = length,
                Height = width
            };

            GraphicsPath gp = new GraphicsPath();
            gp.AddRectangle(new Rectangle(0, 0, length, width));
            
            Matrix matrix = new Matrix();
            matrix.RotateAt(angle, new Point(length / 2, width / 2));
            gp.Transform(matrix);
            
            Region rg = new Region(gp);
            graphicObject.Region = rg;

            AddEventHandlers(graphicObject);
            return graphicObject;
        }
    }
}
