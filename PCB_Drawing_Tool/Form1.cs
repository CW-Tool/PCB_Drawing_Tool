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
using System.IO;

namespace PCB_Drawing_Tool
{
    public partial class Form1 : Form
    {
        private Point startLocation;
        private PictureBox previewObject;

        public Form1()
        {
            InitializeComponent();
            mainDrawingCanvas.Size = new Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height);
            SetDefaultFilepathValue();
        }


        private void ResizeCompontensToForm(object sender, EventArgs e)
        {
            Control window = sender as Control;
            mainContainer.Size = new Size(window.Width - 150, window.Height - 50);
            mainContainer.Location = new Point(0, 25);
            sidebarContainer.Size = new Size(140, window.Height - 60);
            sidebarContainer.Location = new Point(window.Width - 149, 23);
        }

        private void SetDefaultFilepathValue()
        {
            mItemDefLoc.Text = FileManager.Singleton.ReadConfigFile();
        }


        // This overloaded method creates a line.
        public void DrawObject(int x1, int y1, int lineLength, int lineWidth, int lineAngle)
        {
            int objectID = new Line(x1, y1, lineLength, lineWidth, lineAngle).Id;
            mainDrawingCanvas.Controls.Add(CanvasManager.Singleton.GetCanvasGraphic(objectID));
        }


        // This overloaded method creates a circle (filled/empty)
        public void DrawObject(int x1, int y1, int diameter, bool filled)
        {
            int objectID = 0;

            if (filled)
            {
                objectID = new Circle(x1, y1, diameter).Id;
            }
            else
            {
                objectID = new Circle(x1, y1, diameter, Convert.ToInt32(cboLinewidth.Text)).Id;
            }

            mainDrawingCanvas.Controls.Add(CanvasManager.Singleton.GetCanvasGraphic(objectID));
        }


        private Point GetCursorPosition()
        {
            return mainDrawingCanvas.PointToClient(Cursor.Position);
        }


        private void ZoomInOut(bool zoomOut)
        {
            /*
            int zoomSize = 10;
          
            if (zoomOut)
            {
                zoomSize *= -1;
            }

            if (CanvasManager.Singleton.GetSmallestObjectAspect() + zoomSize > 0)
            {
                mainDrawingCanvas.Controls.Clear();
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
            */
        }


        private void ClearMainDrawCanvas(PictureBox elementToRemove)
        {
            if (mainDrawingCanvas.Controls.Contains(elementToRemove))
            {
                mainDrawingCanvas.Controls.Remove(elementToRemove);
            }
        }


        public void CreatePreviewObject(object sender, EventArgs e)
        {
            ClearMainDrawCanvas(previewObject);

            Point cursorLocation = GetCursorPosition();
            int penThickness = Int16.Parse(cboLinewidth.Text);
            int x1 = startLocation.X;
            int y1 = startLocation.Y;
            int lineLength = 0;
            int lineWidth = penThickness;
            int lineAngle = 0;
            int lineOffset = 30;

            // East-line
            if ((cursorLocation.X - x1) > lineOffset && (cursorLocation.Y - y1) > -lineOffset)
            {
                lineLength = Math.Abs(cursorLocation.X - x1);
            }

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

            previewObject = new PictureBox
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
            previewObject.Region = rg;
            mainDrawingCanvas.Controls.Add(previewObject);
        }


        private List<int> GetObjectParameters()
        {
            List<int> parameters = new List<int>();
            switch(cboObjectType.Text)
            {
                case "Line":
                    parameters.Add(previewObject.Location.X);
                    parameters.Add(previewObject.Location.Y);
                    parameters.Add(previewObject.Width);
                    parameters.Add(previewObject.Height);
                    parameters.Add(Convert.ToInt32(previewObject.Name));
                    break;
                case "Circle (empty)":
                case "Circle (filled)":
                    parameters.Add(previewObject.Location.X);
                    parameters.Add(previewObject.Location.Y);
                    parameters.Add(previewObject.Width);
                    break;
            }
            return parameters;
        }


        public void mainDrawBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startLocation = GetCursorPosition();
                IntervalManager.Singleton.ManageTimer("mouseDownTracker", true);
            }
        }


        public void mainDrawBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IntervalManager.Singleton.ManageTimer("mouseDownTracker", false);

                List<int> parameters = GetObjectParameters();
                switch (parameters.Count)
                {
                    case 3:
                        bool filled = cboObjectType.Text == "Circle (empty)" ? false : true;
                        DrawObject(parameters[0], parameters[1], parameters[2], filled);
                        break;
                    case 5:
                        DrawObject(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4]);
                        break;
                }
                
                ClearMainDrawCanvas(previewObject);
                UpdateUndoButtonStatus();
            }
        }


        public void SelectObject(object sender, EventArgs e)
        {
            PictureBox clickedObject = sender as PictureBox;
            clickedObject.BackColor = Color.Red;
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
        }


        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileManager.Singleton.SaveToFile(sender, e);
        }


        private void enableAutosaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mItemAutoSave.Enabled)
            {
                IntervalManager.Singleton.ManageTimer("autosaveCanvas", false);
                mItemAutoSave.Enabled = false;
            } 
            else
            {
                IntervalManager.Singleton.ManageTimer("autosaveCanvas", true);
                mItemAutoSave.Enabled = true;
            }
            
        }


        private void mItemSetDefLoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "CanvasObjects.txt";

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                FileManager.Singleton.UpdateConfigFile(Path.GetDirectoryName(folderBrowser.FileName) + "\\");
            }

            SetDefaultFilepathValue();
        }
    }
}
