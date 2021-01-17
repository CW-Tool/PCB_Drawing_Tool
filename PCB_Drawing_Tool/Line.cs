using System.Drawing;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace PCB_Drawing_Tool
{
    class Line : CanvasObject
    {
        private int length;
        private int width;
        private int angle;
        private int thickness;


        public Line(int x, int y, int width, int length, int angle, int thickness) : base(x, y)
        {
            this.width = width;
            this.length = length;
            this.angle = angle;
            this.thickness = thickness;
        }


        public override int[] GetObjectParameters()
        {
            int[] baseParameters = base.GetObjectParameters();
            int[] classParameters = new int[] { width, length, angle, thickness };
            return baseParameters.Concat(classParameters).ToArray();
        }


        public override PictureBox CreateCanvasObject()
        {
            PictureBox graphicObject = new PictureBox
            {
                Location = coordinates,
                BackColor = backgroundColor,
                Width = length,
                Height = width
            };

            GraphicsPath gp = new GraphicsPath();

            // Check if the line whos to be drawn is straight or diagonal, and act accordingly.
            if (angle != 0)
            {
                gp.AddPolygon(new Point[]
                {
                    new Point(0, thickness - 3),
                    new Point(thickness - 3, 0),
                    new Point(length - 3, length - thickness),
                    new Point(length - thickness, length - 3)
                });

                Matrix matrix = new Matrix();
                matrix.RotateAt(angle, new Point(length / 2, width / 2));
                gp.Transform(matrix);
            }
            else
            {
                gp.AddRectangle(new Rectangle(0, 0, length, width));
            }
           
            Region rg = new Region(gp);
            graphicObject.Region = rg;

            AddEventHandlers(graphicObject);
            return graphicObject;
        }
    }
}
