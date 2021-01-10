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


        public Line(int x, int y, int lineWidth, int lineLength, int lineAngle) : base(x, y)
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

            if (angle != 0)
            {
                List<Point> points = GetPolygonPoints(angle);

                gp.AddPolygon(new Point[]
                {
                    points[0],
                    points[1],
                    points[2],
                    points[3]
                });
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


        private List<Point> GetPolygonPoints(int angle)
        {
            List<Point> points;

            switch(angle)
            {
                case 45:
                    //Console.WriteLine(length + " " + width + " " + coordiantes.X + " " + coordiantes.Y);
                    
                    points = new List<Point>
                    {
                        new Point(0, 7),
                        new Point(7, 0),
                        new Point(width, width - 7),
                        new Point(width - 7, width)
                    };
                    break;
                case 135:
                    points = new List<Point>
                    {
                        new Point(0, 7),
                        new Point(7, 0),
                        new Point(400, 393),
                        new Point(393, 400)
                    };
                    break;
                case 225:
                    points = new List<Point>
                    {
                        new Point(0, 7),
                        new Point(7, 0),
                        new Point(400, 393),
                        new Point(393, 400)
                    };
                    break;
                case 315:
                    //Console.WriteLine(length + " " + width + " " + coordiantes.X + " " + coordiantes.Y);
                    points = new List<Point>
                    {
                        new Point(0, 7),
                        new Point(7, 0),
                        new Point(length, length - 7),
                        new Point(length - 7, length)
                    };
                    break;
                default:
                    points = new List<Point>();
                    break;
            }

            return points;
        }
    }
}
