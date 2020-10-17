using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PCB_Drawing_Tool
{
    public partial class Form1 : Form
    {
        private LineManager lineManager;
        private System.Windows.Forms.Timer mouseDownTracker;
        private PictureBox startDotNewLine;
        private PictureBox previewLine;

        public Form1()
        {
            lineManager = new LineManager();
            mouseDownTracker = new System.Windows.Forms.Timer();
            mouseDownTracker.Interval = 500;
            mouseDownTracker.Tick += new EventHandler(CreatePreviewLine);

            InitializeComponent();
        }

        private void PaintGraphics(object sender, System.Windows.Forms.PaintEventArgs args)
        {
            int numberOfLines = lineManager.GetLineCount();
            for (int i = 1; i <= numberOfLines; i++)
            {
                Console.WriteLine(i);
                List<int> info = lineManager.GetLineDetails(i);
                DrawLine(info[0], info[1], info[2], info[3], info[4]);
            }
        }

        private void DrawLine(int x1, int y1, int x2, int y2, int penThickness)
        {
            int lineWidth = Math.Abs(x2-x1);
            int lineHeight = Math.Abs(y2-y1);
            int containerWidth = lineWidth + penThickness + 7;
            int containerHeight = lineHeight + penThickness + 7;
            int picBoxNum = lineManager.GetLineCount();

            PictureBox picBox = new PictureBox { 
                Location = new Point(x2, y2), 
                Name = "lineBox"+picBoxNum, 
                Size = new Size(containerWidth, containerHeight), 
                BackColor = Color.Transparent 
            };

            Bitmap bitmap = new Bitmap(containerWidth, containerHeight);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (Pen pen = new Pen(Color.Black, penThickness))
                {
                    int margin = Convert.ToInt16(penThickness / 1.4);
                    int startPosX = 0; 
                    int startPosY = 0;
                    int endPosX = x2;
                    int endPosY = y2;
                    /*if (x2-x1 < 0 ^ y2-y1 < 0)
                    {
                        startPosX = 0;
                        startPosY = lineHeight;
                        endPosX = lineWidth;
                        endPosY = 0;
                    } */
                    g.DrawLine(pen, startPosX+margin, startPosY+margin, endPosX+margin, endPosY+margin);
                }
            }

            picBox.Image = bitmap;
            picBox.BringToFront();

            mainDrawBox.Controls.Add(picBox);
        }

        private void CreateLineLabel(int x1, int y1, int x2, int y2, int penThickness)
        {
            int lineID = this.lineManager.AddLine(x1, y1, x2, y2, penThickness);
            Point location = new Point(15 + x1 + (x2 - x1) / 2, -15 + y1 + (y2 - y1) / 2);
            Label currentLabel = new Label { 
                Name = "lblID"+lineID, 
                Location = location, 
                Text = "ID"+lineID, 
                BackColor = Color.Transparent, 
                Width = 28, 
                Height = 13
            };

            mainDrawBox.Controls.Add(currentLabel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                int x1 = Int16.Parse(txtX1.Text);
                int y1 = Int16.Parse(txtY1.Text);
                int x2 = Int16.Parse(txtX2.Text);
                int y2 = Int16.Parse(txtY2.Text);
                int penThickness = Int16.Parse(cboLinewidth.Text);

                CreateLineLabel(x1, y1, x2, y2, penThickness);
                DrawLine(x1, y1, x2, y2, penThickness);
            } catch (Exception error)
            {
                CreateErrorMsgBox(error);
            }
            
        }

        private void CreateErrorMsgBox(Exception error) 
        {
            System.Windows.Forms.MessageBox.Show("Something went wrong: " + error);
        }

        private Point GetCursorPosition()
        {
            return this.PointToClient(Cursor.Position);
        }

        private void CreateStartPoint()
        {
            if (mainDrawBox.Controls.Contains(startDotNewLine))
            {
                mainDrawBox.Controls.Remove(startDotNewLine);
            }

            Point cursorLocation = GetCursorPosition();

            startDotNewLine = new PictureBox
            {
                Name = "startDot",
                Location = new Point(cursorLocation.X-18, cursorLocation.Y-18),
                BackColor = Color.Red,
                Width = 15,
                Height = 15
            };

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, startDotNewLine.Width - 3, startDotNewLine.Height - 3);
            Region rg = new Region(gp);
            startDotNewLine.Region = rg;
            mainDrawBox.Controls.Add(startDotNewLine);
        }

        private void CreatePreviewLine(object sender, EventArgs e)
        {
            if (mainDrawBox.Controls.Contains(previewLine))
            {
                mainDrawBox.Controls.Remove(previewLine);
            }

            Point cursorLocation = GetCursorPosition();
            int penThickness = Int16.Parse(cboLinewidth.Text);
            int linelength = cursorLocation.Y - startDotNewLine.Location.Y;

            previewLine = new PictureBox
            {
                Location = new Point(startDotNewLine.Location.X, startDotNewLine.Location.Y),
                BackColor = Color.Black,
                Width = linelength,
                Height = penThickness
            };

            GraphicsPath gp = new GraphicsPath();
            

            
 
            gp.AddRectangle(new Rectangle(0, 0, linelength, penThickness));
            //gp.AddRectangle(new Rectangle(0, 0, 300, 10));
            //Matrix matrix = new Matrix();
            //matrix.RotateAt(90, new Point(0, 0));
            //gp.Transform(matrix);
            Region rg = new Region(gp);
            previewLine.Region = rg;
            mainDrawBox.Controls.Add(previewLine);
   
        }

        private void mainDrawBox_MouseDown(object sender, MouseEventArgs e)
        {
            CreateStartPoint();

            if (e.Button == MouseButtons.Left)
            {
                mouseDownTracker.Start();
            }
        }

        private void mainDrawBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownTracker.Stop();
            }
        }
    }
}
