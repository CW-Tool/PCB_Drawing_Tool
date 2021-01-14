using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PCB_Drawing_Tool
{
    class Circle : CanvasObject
    {
        private int diameter;
        private int borderWidth;


        public Circle(int x, int y, int diameter, int borderWidth) : base(x, y)
        {
            this.diameter = diameter;
            this.borderWidth = borderWidth;
        }


        public override int[] GetObjectParameters()
        {
            int[] baseParameters = base.GetObjectParameters();
            int[] classParameters = new int[] { diameter, borderWidth };
            return baseParameters.Concat(classParameters).ToArray();
        }


        public override PictureBox CreateCanvasObject()
        {
            PictureBox graphicObject = new PictureBox
            {
                Location = coordiantes,
                BackColor = backgroundColor,
                Width = diameter,
                Height = diameter
            };

            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, diameter, diameter);
           
            if (borderWidth != 0)
            {
                gp.AddEllipse(borderWidth/2, borderWidth/2, diameter - borderWidth, diameter - borderWidth);
            }

            Region rg = new Region(gp);
            graphicObject.Region = rg;

            AddEventHandlers(graphicObject);
            return graphicObject;
        }
    }
}
