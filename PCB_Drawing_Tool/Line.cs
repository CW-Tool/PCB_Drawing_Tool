using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PCB_Drawing_Tool
{
    class Line : CanvasObject
    {
        private Point coordiantes;
        private Color backgroundColor;
        private int length;
        private int width;
        private int angle;
        private int id;


        public int Id
        {
            get { return id; }
        }

        public Line(int x1, int y1, int lineLength, int lineWidth, int lineAngle)
        {
            coordiantes = new Point(x1, y1);
            backgroundColor = Color.Black;
            length = lineLength;
            width = lineWidth;
            angle = lineAngle;

            id = CanvasManager.Singleton.AddObject(CreateCanvasObject());
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
