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
            InitializeComponent();

            lineManager = new LineManager();
            mouseDownTracker = new System.Windows.Forms.Timer();
            mouseDownTracker.Interval = 1;
            mouseDownTracker.Tick += new EventHandler(CreatePreviewLine);
            this.WindowState = FormWindowState.Maximized;
        }

        private void ResizeCompontensToForm(object sender, EventArgs e)
        {
            Control window = sender as Control;
            mainDrawBox.Size = new Size(window.Width - 150, window.Height);
            mainDrawBox.Location = new Point(0, 0);
            panel1.Size = new Size(115, window.Height - 60);
            panel1.Location = new Point(window.Width - 140, 10);
        }

        private void DrawLine(int x1, int y1, int lineLength, int lineWidth)
        {
            PictureBox lineBox = new PictureBox
            {
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

            lineBox.Click += new EventHandler(this.SelectLine);

            //Console.WriteLine(lineLength + " " + lineWidth);
            //CreateLineLabel(lineLength, lineWidth);
        }

        private void SelectLine(object sender, EventArgs e)
        {
            PictureBox clickedLine = sender as PictureBox;
            clickedLine.BackColor = Color.Red;

        }

        /*
        private void CreateLineLabel(int x1, int y1)
        {
            int lineID = this.lineManager.GetLineCount();
            Point location = new Point(startDotNewLine.Location.X + (x1 / 2), startDotNewLine.Location.Y + (y1 / 2));

            Label currentLabel = new Label
            {
                Name = "lblID" + lineID,
                Location = location,
                Text = "ID" + lineID,
                BackColor = Color.Transparent,
                Width = 28,
                Height = 13
            };

            mainDrawBox.Controls.Add(currentLabel);
        }
        */

        /*
        private void CreateErrorMsgBox(Exception error)
        {
            MessageBox.Show("Something went wrong: " + error);
        }
        */
        private Point GetCursorPosition()
        {
            return this.PointToClient(Cursor.Position);
        }

        private void ZoomInOut(bool zoomOut)
        {
            int zoomSize = 10;
          
            if (zoomOut)
            {
                zoomSize *= -1;
            }

            if (lineManager.GetSmallestLineAspect() + zoomSize > 0)
            {
                mainDrawBox.Controls.Clear();
                int numberOfLines = lineManager.GetLineCount();
                for (int i = 1; i <= numberOfLines; i++)
                {
                    List<int> info = lineManager.GetLineDetails(i);

                    DrawLine(info[0], info[1], info[2] + zoomSize, info[3] + zoomSize);
                    lineManager.UpdateLine(i, info[0], info[1], info[2] + zoomSize, info[3] + zoomSize);
                }
            }   
            else
            {
                MessageBox.Show("Can't Zoom out anymore!");
            }
        }


        private void ClearMainDrawBox(PictureBox elementToRemove)
        {
            if (mainDrawBox.Controls.Contains(elementToRemove))
            {
                mainDrawBox.Controls.Remove(elementToRemove);
            }
        }

        private void CreateStartPoint()
        {
            ClearMainDrawBox(startDotNewLine);

            int diameter = Convert.ToInt32(cboLinewidth.Text) < 20 ? Convert.ToInt32(cboLinewidth.Text) + 6 : 20;
            Point cursorLocation = GetCursorPosition();

            startDotNewLine = new PictureBox
            {
                Name = "startDot",
                Location = new Point(cursorLocation.X - 18, cursorLocation.Y - 18),
                BackColor = Color.Red,
                Width = diameter,
                Height = diameter
            };

            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, startDotNewLine.Width, startDotNewLine.Height);
            Region rg = new Region(gp);
            startDotNewLine.Region = rg;
            mainDrawBox.Controls.Add(startDotNewLine);
        }

        private void CreatePreviewLine(object sender, EventArgs e)
        {
            ClearMainDrawBox(previewLine);

            Point cursorLocation = GetCursorPosition();
            int penThickness = Int16.Parse(cboLinewidth.Text);
            int x1 = startDotNewLine.Location.X;
            int y1 = startDotNewLine.Location.Y;
            int lineLength = 0;
            int lineWidth = penThickness;
            int lineAngle = 0;
            int lineOffset = 30;

            // East-line
            if ((cursorLocation.X - x1) > 250 && (cursorLocation.Y - y1) > -lineOffset)
            {
                lineLength = Math.Abs(cursorLocation.X - x1);
            }

            // South/East-diagonal
            if ((cursorLocation.X - x1) > 30 && (cursorLocation.X - x1) < 250 && (cursorLocation.Y - y1) > 0)
            {
                lineAngle = 45;
                lineLength = Math.Abs(cursorLocation.X - x1);
                lineWidth += 100;
            }

            // North-line
            else if ((cursorLocation.X - x1) > -lineOffset && (cursorLocation.Y - y1) < -lineOffset)
            {
                lineLength = penThickness;
                lineWidth = Math.Abs(cursorLocation.Y - y1) + 12;
                y1 += (cursorLocation.Y - y1);
            }

            // West-line
            else if ((cursorLocation.X - x1) < -lineOffset && (cursorLocation.Y - y1) < lineOffset)
            {
                lineLength = Math.Abs(cursorLocation.X - x1) + 12;
                x1 += (cursorLocation.X - x1);
            }

            // South-line
            else if ((cursorLocation.X - x1) < lineOffset && (cursorLocation.Y - y1) > lineOffset)
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
            Matrix matrix = new Matrix();
            matrix.RotateAt(lineAngle, new Point(x1, y1));
            gp.Transform(matrix);
            Region rg = new Region(gp);
            previewLine.Region = rg;
            mainDrawBox.Controls.Add(previewLine);
        }

        private void mainDrawBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CreateStartPoint();
                mouseDownTracker.Start();
            }
        }

        private void mainDrawBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownTracker.Stop();
                DrawLine(previewLine.Location.X, previewLine.Location.Y, previewLine.Width, previewLine.Height);
                lineManager.AddLine(previewLine.Location.X, previewLine.Location.Y, previewLine.Width, previewLine.Height);
                ClearMainDrawBox(startDotNewLine);
                ClearMainDrawBox(previewLine);
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            ZoomInOut(true);
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            ZoomInOut(false);
        }
    }
}
