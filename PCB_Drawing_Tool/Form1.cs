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
using System.Reflection;

namespace PCB_Drawing_Tool
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer mouseDownTracker;
        private PictureBox startDotNewLine;
        private PictureBox previewLine;

        public Form1()
        {
            InitializeComponent();

            mouseDownTracker = new System.Windows.Forms.Timer();
            mouseDownTracker.Interval = 1;
            mouseDownTracker.Tick += new EventHandler(CreatePreviewLine);
            this.WindowState = FormWindowState.Maximized;
            mainDrawCanvas.Size = new Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height);
        }

        private void ResizeCompontensToForm(object sender, EventArgs e)
        {
            Control window = sender as Control;
            mainContainer.Size = new Size(window.Width - 150, window.Height - 50);
            mainContainer.Location = new Point(0, 0);
            sidebarContainer.Size = new Size(115, window.Height - 60);
            sidebarContainer.Location = new Point(window.Width - 140, 10);
        }

        private void DrawAllObjects(List<PictureBox> objectsToDraw)
        {
            
        }

        // This overloaded method creates a line.
        public PictureBox DrawObject(int x1, int y1, int lineLength, int lineWidth, int lineAngle)
        {
            PictureBox graphicObject = new PictureBox
            {
                Location = new Point(x1, y1),
                BackColor = Color.Black,
                Width = lineLength,
                Height = lineWidth
            };

            GraphicsPath gp = new GraphicsPath();
            gp.AddRectangle(new Rectangle(0, 0, lineLength, lineWidth));
            Matrix matrix = new Matrix();
            matrix.RotateAt(lineAngle, new Point(lineLength / 2, lineWidth / 2));
            gp.Transform(matrix);
            Region rg = new Region(gp);
            graphicObject.Region = rg;
            mainDrawCanvas.Controls.Add(graphicObject);

            graphicObject.Click += new EventHandler(this.SelectLine);
            return graphicObject;
        }

        // This overloaded method creates a circle (filled/empty)
        private PictureBox DrawObject(int x1, int y1, int diameter, int y2, bool filled)
        {
            PictureBox graphicObject = new PictureBox
            {
                Location = new Point(x1, y1),
                BackColor = Color.Black,
                Width = diameter,
                Height = 500
            };

            if (filled == true)
            {

            }

            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, 300, 300);
            Region rg = new Region(gp);
            graphicObject.Region = rg;
            mainDrawCanvas.Controls.Add(graphicObject);

            //graphicObject.Click += new EventHandler(this.SelectLine);
            return graphicObject;
        }

        private void SelectLine(object sender, EventArgs e)
        {
            PictureBox clickedLine = sender as PictureBox;
            clickedLine.BackColor = Color.Red;
        }

        private Point GetCursorPosition()
        {
            return mainDrawCanvas.PointToClient(Cursor.Position);
        }

        private void ZoomInOut(bool zoomOut)
        {
            int zoomSize = 10;
          
            if (zoomOut)
            {
                zoomSize *= -1;
            }

            if (CanvasManager.Singleton.GetSmallestObjectAspect() + zoomSize > 0)
            {
                mainDrawCanvas.Controls.Clear();
                int numberOfLines = CanvasManager.Singleton.GetCountOfCanvasObjects();
                for (int i = 1; i <= numberOfLines; i++)
                {
                    List<int> info = CanvasManager.Singleton.GetObjectDetails(i);
                    CanvasManager.Singleton.UpdateObject(i, DrawObject(info[0], info[1], info[2] + zoomSize, info[3] + zoomSize, info[4]));
                }

                for (int i = 0; i < cboLinewidth.Items.Count; i++)
                {
                    cboLinewidth.Items[i] = (Convert.ToInt32(cboLinewidth.Items[i]) + zoomSize).ToString();
                } 
            }   
            else
            {
                MessageBox.Show("Can't Zoom out anymore!");
            }
        }


        private void ClearMainDrawCanvas(PictureBox elementToRemove)
        {
            if (mainDrawCanvas.Controls.Contains(elementToRemove))
            {
                mainDrawCanvas.Controls.Remove(elementToRemove);
            }
        }

        private void CreateStartPoint()
        {
            ClearMainDrawCanvas(startDotNewLine);

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
            gp.AddEllipse(0, 0, diameter, diameter);
            Region rg = new Region(gp);
            startDotNewLine.Region = rg;
            mainDrawCanvas.Controls.Add(startDotNewLine);
        }

        private void CreatePreviewLine(object sender, EventArgs e)
        {
            ClearMainDrawCanvas(previewLine);

            Point cursorLocation = GetCursorPosition();
            int penThickness = Int16.Parse(cboLinewidth.Text);
            int x1 = startDotNewLine.Location.X;
            int y1 = startDotNewLine.Location.Y;
            int lineLength = 0;
            int lineWidth = penThickness;
            int lineAngle = 0;
            int lineOffset = 30;

            // East-line
            if ((cursorLocation.X - x1) > lineOffset && (cursorLocation.Y - y1) > -lineOffset)
            {
                lineLength = Math.Abs(cursorLocation.X - x1);
            }


            Console.WriteLine(cursorLocation.X - x1);
            Console.WriteLine(cursorLocation.Y - y1);
            // South/East-diagonal
            if ((cursorLocation.X - x1) > lineOffset && (cursorLocation.Y - y1) > lineOffset)
            {
                lineAngle = -45;
                lineLength = Math.Abs(cursorLocation.X - x1);
                lineWidth = Math.Abs(cursorLocation.Y - y1);
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
                Height = lineWidth,
                Name = lineAngle.ToString()
            };


            GraphicsPath gp = new GraphicsPath();
            gp.AddRectangle(new Rectangle(0, 0, lineLength, lineWidth));
            Matrix matrix = new Matrix();
            matrix.RotateAt(lineAngle, new Point(lineLength/2, lineWidth/2));
            gp.Transform(matrix);
            Region rg = new Region(gp);
            previewLine.Region = rg;
            mainDrawCanvas.Controls.Add(previewLine);
        }

        private List<int> GetObjectParameters()
        {
            List<int> parameters = new List<int>();
            switch(cboObjectType.Text)
            {
                case "Line":
                    parameters.Add(previewLine.Location.X);
                    parameters.Add(previewLine.Location.Y);
                    parameters.Add(previewLine.Width);
                    parameters.Add(previewLine.Height);
                    parameters.Add(Convert.ToInt32(previewLine.Name));
                    break;
                case "Circle (empty)":
                case "Circle (filled)":
                    parameters.Add(previewLine.Location.X);
                    parameters.Add(previewLine.Location.Y);
                    parameters.Add(previewLine.Width);
                    parameters.Add(previewLine.Height);
                    break;
            }
            return parameters;
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
                
                List<int> parameters = GetObjectParameters();
                switch (parameters.Count)
                {
                    case 3:
                        
                        break;
                    case 4:
                        bool filled = cboObjectType.Text == "Circle (empty)" ? false : true;
                        CanvasManager.Singleton.AddObject(DrawObject(parameters[0], parameters[1], parameters[2], parameters[3], filled));
                        break;
                    case 5:
                        CanvasManager.Singleton.AddObject(DrawObject(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]));
                        break;
                }
                
                ClearMainDrawCanvas(startDotNewLine);
                ClearMainDrawCanvas(previewLine);
                UpdateUndoButtonStatus();
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                ClearMainDrawCanvas(CanvasManager.Singleton.RemoveLastObjectFromCanvas());
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            ClearMainDrawCanvas(CanvasManager.Singleton.RemoveLastObjectFromCanvas());
            UpdateUndoButtonStatus();
        }

        private void UpdateUndoButtonStatus()
        {
            if (CanvasManager.Singleton.GetCountOfCanvasObjects() > 0)
            {
                btnUndo.Enabled = true;
            }
            else
            {
                btnUndo.Enabled = false;
            }
            Console.WriteLine(btnUndo.Enabled);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FileManager.Singleton.SaveToFile(CanvasManager.Singleton.GetAllObjects());
        }
    }
}
