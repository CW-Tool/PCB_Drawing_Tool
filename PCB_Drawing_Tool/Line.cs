using System.Drawing;
using System;
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


        public Line(int x1, int y1, int lineWidth, int lineLength, int lineAngle) : base(x1, y1)
        {
            width = lineWidth;
            length = lineLength;
            angle = lineAngle;
        }


        public override int[] GetObjectParameters()
        {
            int[] baseParameters = base.GetObjectParameters();
            int[] classParameters = new int[] { width, length, angle };
            return baseParameters.Concat(classParameters).ToArray();
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
