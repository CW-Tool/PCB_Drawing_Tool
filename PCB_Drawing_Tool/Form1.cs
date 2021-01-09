using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
        private CanvasManager cm;
        private FileManager fm;
        private Size defaultCanvasSize;


        public Form1()
        {
            InitializeComponent();
            cm = CanvasManager.Singleton;
            fm = FileManager.Singleton;
            WindowState = FormWindowState.Maximized;
            cboLinewidth.SelectedIndex = 0;
            cboObjectType.SelectedIndex = 0;
            defaultCanvasSize = new Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height);
            mainDrawingCanvas.Size = defaultCanvasSize;
            mainDrawingCanvas.Select();
            SetDefaultFilepathValue();
        }


        /// <summary>
        /// Adjusts the size and location of the layout components which make up the GUI, to fit the size of the current Form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResizeCompontensToForm(object sender, EventArgs e)
        {
            Control window = sender as Control;
            mainContainer.Size = new Size(window.Width - 193, window.Height - 63);
            mainContainer.Location = new Point(4, 24);
            sidebarContainer.Size = new Size(180, window.Height - 60);
            sidebarContainer.Location = new Point(window.Width - 190, 23);
            picSidebar.Location = new Point(10, sidebarContainer.Height - 235);
            sidebarLeft.Size = new Size(5, window.Height);
        }


        /// <summary>
        /// Sets the text property of the "Default Location Textfield" to match the one stored in the configuration. 
        /// </summary>
        private void SetDefaultFilepathValue()
        {
            string defaultFilepath = fm.ReadConfigFile()[0];
            mItemDefLoc.Text = defaultFilepath != "" ? defaultFilepath : "Not Defined Jet";
        }


        /// <summary>
        /// Checks if autosave is to be active, and enables it if so. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetAutosaveStatus(object sender, EventArgs e)
        {
            string autosaveStatus = fm.ReadConfigFile()[1];
            if (autosaveStatus == "true")
            {
                ToggleAutosave();
            }
        }


        /// <summary>
        /// Changes the current state for the autosave function to the opposite.
        /// </summary>
        private void ToggleAutosave()
        {
            IntervalManager.Singleton.ManageTimer("autosaveCanvas", !mItemAutoSave.Checked);
            string result = !mItemAutoSave.Checked ? "true" : "false";
            fm.SaveDefaultConfig(result);
            mItemAutoSave.Checked = !mItemAutoSave.Checked;
        }


        private void ExtendCanvas(int objectWidth, int objectHeight)
        {
            int w = mainDrawingCanvas.Width;
            int h = mainDrawingCanvas.Height;
            if ((w - objectWidth) < 100 || (h - objectHeight) < 100 || (w - objectHeight) < 100 || (h - objectWidth) < 100)
            {
                mainDrawingCanvas.Size = new Size(mainDrawingCanvas.Width + 100, mainDrawingCanvas.Height + 100);
            }
        }


        public void DrawObject(string objectType, int[] data, bool drawPermanent)
        {
            ClearPreviewObject();
            CanvasObject newCanvasObject;

            switch (objectType)
            {
                case "Line":
                    newCanvasObject = new Line(data[0], data[1], data[2], data[3], data[4]);
                    ExtendCanvas(data[0] + data[2], data[1] + data[3]);
                    break;
                case "Circle":
                    newCanvasObject = new Circle(data[0], data[1], data[2], data[3]);
                    ExtendCanvas(data[0] + data[2], data[1] + data[2]);
                    break;
                default:
                    // Switch should never end up here!
                    newCanvasObject = new Line(0, 0, 0, 0, 0);
                    break;
            }

            PictureBox newPicBox = newCanvasObject.CreateCanvasObject();

            if (drawPermanent)
            {
                cm.AddObject(newCanvasObject, newPicBox);
            }
            else
            {
                cm.PreviewObject = new Dictionary<CanvasObject, PictureBox>() { { newCanvasObject, newPicBox } };
            }

            mainDrawingCanvas.Controls.Add(newPicBox);
        }


        private void ClearPreviewObject()
        {
            if (cm.PreviewObject.Count != 0)
            {
                ClearMainDrawCanvas(cm.PreviewObject.First().Value);
                cm.PreviewObject.Remove(cm.PreviewObject.First().Key);
            }
        }


        private Point GetCursorPosition()
        {
            return mainDrawingCanvas.PointToClient(Cursor.Position);
        }


        private void ZoomInOut(bool zoomOut)
        {
            /*
            string rawString = txtCanvasZoom.Text;
            int currentZoom = Convert.ToInt32(rawString.Substring(0, rawString.Length - 2));


            int zoomSize = 10;

            if (zoomOut)
            {
                zoomSize *= -1;
            }

            mainDrawingCanvas.Controls.Clear();

            Dictionary<CanvasObject, PictureBox> tmpAllCanvasObjects = new Dictionary<CanvasObject, PictureBox>(cm.AllCanvasObjects);

            foreach (var element in tmpAllCanvasObjects)
            {
                
                int[] data = element.Key.GetObjectParameters();

                //Only for lines
                data[0] += zoomSize;
                data[1] += zoomSize;
                data[2] += zoomSize;
                data[3] += zoomSize;

                DrawObject(element.Key.GetType().Name, data, true);

                switch (element.Key.GetType().Name)
                {
                    case "Line":

                        break;
                    case "Circle":

                        break;
                    case "Transistor":
                        //Transistor newTransistor = new Transistor(data[0], data[1], data[2], data[3], data[4], data[5]);
                        break;
                }

                cm.AllCanvasObjects.Remove(element.Key);
            }



            /*
            if (CanvasManager.Singleton.GetSmallestObjectAspect() + zoomSize > 0)
            {
                mainDrawingCanvas.Controls.Clear();
                int numberOfLines = CanvasManager.Singleton.GetCountOfCanvasObjects();
                for (int i = 1; i <= numberOfLines; i++)
                {
                    List<int> info = CanvasManager.Singleton.GetObjectDetails(i);
                    cm.UpdateObject(i, DrawObject(info[0], info[1], info[2] + zoomSize, info[3] + zoomSize, info[4]));
                }

                for (int i = 0; i < cboLinewidth.Items.Count; i++)
                {
                    cboLinewidth.Items[i] = (Convert.ToInt32(cboLinewidth.Items[i]) + zoomSize).ToString();
                }


                /*
                if ((zoomOut && currentZoom != 10) || (!zoomOut && currentZoom != 190))
                {
                    //mainDrawingCanvas.Scale(new SizeF(1 + ((float)(100 - currentZoom) / (float)100), 1 + ((float)(100 - currentZoom) / (float)100)));

                    float zoomSize;

                    if (zoomOut && currentZoom <= 100 || !zoomOut && currentZoom < 100)
                    {
                        zoomSize = zoomOut ? ((float)currentZoom - 10) / (float)100 : 1 + (1 - ((float)currentZoom / (float)100));
                    }
                    else
                    {
                        zoomSize = zoomOut ? 2 - ((float)currentZoom / (float)100) : ((float)currentZoom + 10) / (float)100;
                    }

                    mainDrawingCanvas.Scale(new SizeF(zoomSize, zoomSize));
                    //mainDrawingCanvas.Size = new Size(Convert.ToInt32(mainDrawingCanvas.Width * zoomSize), Convert.ToInt32(mainDrawingCanvas.Height * zoomSize));

                    txtCanvasZoom.Text = zoomOut ? currentZoom - 10 + " %" : currentZoom + 10 + " %";
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


        public void CopySelectedObject(object sender, EventArgs e)
        {
            CanvasObject selectedObject = cm.GetCanvasObject(cm.SelectedObject);
            int[] data = selectedObject.GetObjectParameters();

            Point location = GetCursorPosition();
            data[0] = location.X;
            data[1] = location.Y;

            DrawObject(selectedObject.GetType().Name, data, false);
        }


        public void MoveSelectedObject(object sender, EventArgs e)
        {
            cm.SelectedObject.Location = GetCursorPosition();
        }


        public void CreatePreviewObject(object sender, EventArgs e)
        {
            string objectType = cboObjectType.Text;
            int[] data;

            Point cursorLocation = GetCursorPosition();
            int penThickness = Int16.Parse(cboLinewidth.Text);
            int x = startLocation.X;
            int y = startLocation.Y;
            int length = 0;
            int width = penThickness;
            int angle = 0;

            switch (objectType)
            {
                case "Line":

                    switch(DetectCursorPosition(cursorLocation))
                    {
                        case "east":
                            length = Math.Abs(cursorLocation.X - x);
                            break;
                        case "south-east":
                            angle = -45;
                            length = 500;// Math.Abs(cursorLocation.X - x);
                            width = 100;//Math.Abs(cursorLocation.Y - y);
                            break;
                        case "north":
                            length = penThickness;
                            width = Math.Abs(cursorLocation.Y - y);
                            y += (cursorLocation.Y - y);
                            break;
                        case "west":
                            length = Math.Abs(cursorLocation.X - x);
                            x += (cursorLocation.X - x);
                            break;
                        case "south":
                            length = penThickness;
                            width = Math.Abs(cursorLocation.Y - y);
                            break;
                    }
                        
                    data = new int[] { x, y, width, length, angle };
                    break;

                case "Circle (empty)":
                case "Circle (filled)":
                    
                    switch (DetectCursorPosition(cursorLocation))
                    {
                        case "east":
                        case "south-east":
                            width = cursorLocation.X - x;
                            break;
                        case "north":
                            width = cursorLocation.X - x;
                            y -= width;
                            break;
                        case "west":
                            width = x - cursorLocation.X;
                            x -= width;
                            y -= width;
                            break;
                        case "south":
                            width = x - cursorLocation.X;
                            x = cursorLocation.X;
                            break;
                    }

                    int borderWidth = objectType == "Circle (empty)" ? penThickness : 0;
                    data = new int[] { x, y, width, borderWidth };
                    objectType = "Circle";
                    break;

                default:
                    // Switch should never end up here!
                    data = new int[0];
                break;
            }

            DrawObject(objectType, data, false);
        }

        private string DetectCursorPosition(Point cursor)
        {
            string position = "";
            int divX = cursor.X - startLocation.X;
            int divY = cursor.Y - startLocation.Y;
            int lineOffset = 40;

            if (divX > lineOffset && divY > lineOffset)
            {
                position = "south-east";
            } 
            else if (divX > lineOffset && divY > -lineOffset)
            {
                position = "east";
            }
            else if (divX > -lineOffset && divY < -lineOffset)
            {
                position = "north";
            }
            else if (divX < -lineOffset && divY < lineOffset)
            {
                position = "west";
            }
            else if (divX < lineOffset && divY > lineOffset)
            {
                position = "south";
            }

            return position;
        }

        
        public void mainDrawingCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (IntervalManager.Singleton.GetTimerStatus("copySelectedObject"))
                {
                    IntervalManager.Singleton.ManageTimer("copySelectedObject", false);

                    CanvasObject objectToDraw = cm.PreviewObject.First().Key;
                    DrawObject(objectToDraw.GetType().Name, objectToDraw.GetObjectParameters(), true);
                }
                else if (cm.SelectedObject == null)
                {
                    startLocation = GetCursorPosition();
                    IntervalManager.Singleton.ManageTimer("drawPreviewObject", true);
                }
                else if (cm.SelectedObject != null)
                {
                    IntervalManager.Singleton.ManageTimer("moveSelectedObject", true);
                }
            }
        }


        public void mainDrawingCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                if (IntervalManager.Singleton.GetTimerStatus("drawPreviewObject"))
                {
                    IntervalManager.Singleton.ManageTimer("drawPreviewObject", false);
                    CanvasObject previewObject = cm.PreviewObject.First().Key;
                    int[] parameters = previewObject.GetObjectParameters();
                    DrawObject(previewObject.GetType().Name, parameters, true);
                
                    UpdateUndoButtonStatus();
                }
                else if (IntervalManager.Singleton.GetTimerStatus("moveSelectedObject"))
                {
                    IntervalManager.Singleton.ManageTimer("moveSelectedObject", false);
                    cm.ChangeSelectedObject(cm.SelectedObject);
                }
                
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
                ClearMainDrawCanvas(cm.RemoveLastObjectFromCanvas());
            }
            else if (e.KeyCode == Keys.Delete && cm.SelectedObject != null)
            {
                ClearMainDrawCanvas(cm.SelectedObject);
                cm.AllCanvasObjects.Remove(cm.GetCanvasObject(cm.SelectedObject));
            }
            else if (e.Control && e.KeyCode == Keys.C && cm.SelectedObject != null)
            {
                IntervalManager.Singleton.ManageTimer("copySelectedObject", true);
            }
        }

        private void mainDrawingCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                bool zoomStatus = e.Delta < 0 ? true : false;
                ZoomInOut(zoomStatus);
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            ClearMainDrawCanvas(cm.RemoveLastObjectFromCanvas());
            UpdateUndoButtonStatus();
        }


        private void UpdateUndoButtonStatus()
        {
            if (cm.GetCountOfCanvasObjects() > 0)
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
            fm.SaveToFile(sender, e);
        }


        private void enableAutosaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleAutosave();
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
                fm.SaveDefaultConfig(Path.GetDirectoryName(folderBrowser.FileName) + "\\");
            }

            SetDefaultFilepathValue();
        }
    }
}
