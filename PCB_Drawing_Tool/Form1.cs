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
            mouseDownTracker.Interval = 1;
            mouseDownTracker.Tick += new EventHandler(CreatePreviewLine);

            InitializeComponent();
        }

        private void PaintGraphics(object sender, PaintEventArgs args)
        {
            int numberOfLines = lineManager.GetLineCount();
            for (int i = 1; i <= numberOfLines; i++)
            {
                Console.WriteLine(i);
                List<int> info = lineManager.GetLineDetails(i);
                DrawLine(info[0], info[1], info[2], info[3]);
            }
        }

        private void DrawLine(int x1, int y1, int lineLength, int lineWidth)
        {
            lineManager.AddLine(x1, y1, lineLength, lineWidth);
            int picBoxNum = lineManager.GetLineCount();

            PictureBox lineBox = new PictureBox
            {
                Name = "lineBox" + picBoxNum,
                Location = new Point(x1, y1),
                BackColor = Color.Black,
                Width = lineLength,
                Height = lineWidth
            };

            GraphicsPath gp = new GraphicsPath();
            gp.AddRectangle(new Rectangle(0, 0, lineLength, lineWidth));
            Region rg = new Region(gp);
            lineBox.Region = rg;
            mainDrawBox.Controls.Add(lineBox);

            CreateLineLabel(x1, y1);
        }

        private void CreateLineLabel(int x1, int y1)
        {
            int lineID = this.lineManager.GetLineCount();
            Point location = new Point(x1, y1);
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

                CreateLineLabel(x1, y1);
                DrawLine(x1, y1, x2, y2);
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

            GraphicsPath gp = new GraphicsPath();
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
            int x1 = startDotNewLine.Location.X;
            int y1 = startDotNewLine.Location.Y;
            int lineLength = 0;
            int lineWidth = penThickness;
            //int lineAngle = 0;
            int lineOffset = 40;

            // Left-line
            if ((cursorLocation.X - x1) > lineOffset && (cursorLocation.Y - y1) > -lineOffset)
            {
                lineLength = Math.Abs(cursorLocation.X - x1);
            }

            // Up-line
            if ((cursorLocation.X - x1) > -lineOffset && (cursorLocation.Y - y1) < -lineOffset)
            {
                lineLength = penThickness; 
                lineWidth = Math.Abs(cursorLocation.Y - y1) + 12;
                y1 += (cursorLocation.Y - y1);
            }

            // Right-line
            if ((cursorLocation.X - x1) < -lineOffset && (cursorLocation.Y - y1) < lineOffset)
            {
                lineLength = Math.Abs(cursorLocation.X - x1) + 12;
                x1 += (cursorLocation.X - x1);
            }

            // Down-line
            if ((cursorLocation.X - x1) < lineOffset && (cursorLocation.Y - y1) > lineOffset)
            {
                lineLength = penThickness;
                lineWidth = Math.Abs(cursorLocation.Y - y1);
            }


            previewLine = new PictureBox
            {
                Location = new Point(x1, y1),
                BackColor = Color.Black,
                Width = lineLength,
                Height = lineWidth
            };

            GraphicsPath gp = new GraphicsPath();
            gp.AddRectangle(new Rectangle(0, 0, lineLength, lineWidth));
            //Matrix matrix = new Matrix();
            //matrix.RotateAt(lineAngle, new Point(0, 0));
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
                DrawLine(previewLine.Location.X, previewLine.Location.Y, previewLine.Width, previewLine.Height);
            }
        }
    }
}
