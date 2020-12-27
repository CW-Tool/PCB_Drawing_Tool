using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PCB_Drawing_Tool
{
    class Transistor : CanvasObject
    {
        private Point coordiantes;
        private Color backgroundColor;
        private int length;
        private int height;
        private int borderWidth;
        private int angle;
        private int id;


        public int Id
        {
            get { return id; }
        }


        public Transistor(int x1, int y1, int length, int height, int borderWidth, int angle)
        {
            coordiantes = new Point(x1, y1);
            backgroundColor = Color.Black;
            this.length = length;
            this.height = height;
            this.borderWidth = borderWidth;
            this.angle = angle;

            id = CanvasManager.Singleton.AddObject(CreateCanvasObject());
        }

        public override PictureBox CreateCanvasObject()
        {
            PictureBox graphicObject = new PictureBox
            {
                Location = coordiantes,
                BackColor = backgroundColor,
                Width = length,
                Height = height
            };

            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(new Rectangle(0, 0, length, height), 50, 50);

            Region rg = new Region(gp);
            graphicObject.Region = rg;

            AddEventHandlers(graphicObject);
            return graphicObject;
        }
    }
}
