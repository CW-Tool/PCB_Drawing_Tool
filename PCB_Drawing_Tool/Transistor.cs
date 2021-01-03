using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PCB_Drawing_Tool
{
    class Transistor : CanvasObject
    {
        private int length;
        private int height;
        private int borderWidth;
        private int angle;


        public Transistor(int x1, int y1, int length, int height, int borderWidth, int angle) : base(x1, y1)
        {
            this.length = length;
            this.height = height;
            this.borderWidth = borderWidth;
            this.angle = angle;
        }


        public override string[] GetObjectParameters()
        {
            string[] baseParameters = base.GetObjectParameters();
            string[] classParameters = new string[] { length.ToString(), height.ToString(), borderWidth.ToString(), angle.ToString() };
            return baseParameters.Concat(classParameters).ToArray();
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
