using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PCB_Drawing_Tool
{
    class Circle : CanvasObject
    {
        private Point coordiantes;
        private Color backgroundColor;
        private int diameter;
        private int borderWidth;
        private int id;


        public int Id
        {
            get { return id; }
        }


        public Circle(int x1, int y1, int diameter, int borderWidth = 0)
        {
            coordiantes = new Point(x1, y1);
            backgroundColor = Color.Black;
            this.diameter = diameter;
            this.borderWidth = borderWidth;

            id = CanvasManager.Singleton.AddObject(CreateCanvasObject());
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
