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
        private CanvasManager cm;
        private FileManager fm;
        private Point startLocation;


        public Form1()
        {
            InitializeComponent();
            cm = CanvasManager.Singleton;
            fm = FileManager.Singleton;

            // Set some default layout parameters.
            WindowState = FormWindowState.Maximized;
            cboLinewidth.SelectedIndex = 0;
            cboObjectType.SelectedIndex = 0;
            mainDrawingCanvas.Size = new Size(Screen.FromControl(this).Bounds.Width, Screen.FromControl(this).Bounds.Height);
            mainDrawingCanvas.Select();
            
            SetDefaultFilepathValue();
        }


        /// <summary>
        /// Adjusts the size and location of the layout components which make up the GUI, to fit the size of the current Form. 
        /// </summary>
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


        /// <summary>
        /// Checks if a newly created CanvasObject is close to the egde of the main drawing canvas.
        /// If the object is close the canvas will be extended by a certain amount. 
        /// </summary>
        /// <param name="objectWidth">Width of the newly create CanvasObject.</param>
        /// <param name="objectHeight">Height of the newly create CanvasObject.</param>
        private void ExtendCanvas(int objectWidth, int objectHeight)
        {
            int w = mainDrawingCanvas.Width;
            int h = mainDrawingCanvas.Height;
            if ((w - objectWidth) < 100 || (h - objectHeight) < 100 || (w - objectHeight) < 100 || (h - objectWidth) < 100)
            {
                mainDrawingCanvas.Size = new Size(mainDrawingCanvas.Width + 100, mainDrawingCanvas.Height + 100);
            }
        }


        /// <summary>
        /// Draws a new CanvasObject onto the main drawing canvas. 
        /// </summary>
        /// <param name="objectType">The name of the CanvasObject subclass.</param>
        /// <param name="data">The parameters required to draw the new CanvasObject.</param>
        /// <param name="drawPermanent">True = drawn new object permanently, False = only draw a preview.</param>
        public void DrawObject(string objectType, int[] data, bool drawPermanent)
        {
            ClearMainDrawCanvas(cm.ClearPreviewObject());
            CanvasObject newCanvasObject;

            switch (objectType)
            {
                case "Line":
                    newCanvasObject = new Line(data[0], data[1], data[2], data[3], data[4], data[5]);
                    ExtendCanvas(data[0] + data[2], data[1] + data[3]);
                    break;
                case "Circle":
                    newCanvasObject = new Circle(data[0], data[1], data[2], data[3]);
                    ExtendCanvas(data[0] + data[2], data[1] + data[2]);
                    break;
                default:
                    // Switch should never end up here!
                    newCanvasObject = new Line(0, 0, 0, 0, 0, 0);
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


        /// <summary>
        /// Get the current X- and Y-coordinates of the cursor.
        /// </summary>
        /// <returns>A point containing the coordiantes.</returns>
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


        /// <summary>
        /// Changes the enabled proterty of a spesific button based on certain circumstances.
        /// </summary>
        /// <param name="buttonName">The identifying name of the button whos to be updated.</param>
        public void UpdateButtonStatus(string buttonName)
        {
            switch (buttonName)
            {
                case "undo":
                    btnUndo.Enabled = cm.GetCountOfCanvasObjects() > 0 ? true : false;
                    break;
                case "delete":
                    btnDelete.Enabled = cm.SelectedObject != null ? true : false;
                    break;
            }
        }


        /// <summary>
        /// Removes a child element from the main drawing canvas.
        /// </summary>
        /// <param name="elementToRemove">The child element whos to be removed.</param>
        private void ClearMainDrawCanvas(PictureBox elementToRemove)
        {
            if (mainDrawingCanvas.Controls.Contains(elementToRemove))
            {
                mainDrawingCanvas.Controls.Remove(elementToRemove);
            }
        }


        /// <summary>
        /// Makes a copy of the selected CanvasObject, and creates a preview of the new object at the cursor location.
        /// </summary>
        public void CopySelectedObject(object sender, EventArgs e)
        {
            CanvasObject selectedObject = cm.GetCanvasObject(cm.SelectedObject);
            int[] data = selectedObject.GetObjectParameters();

            Point location = GetCursorPosition();
            data[0] = location.X;
            data[1] = location.Y;

            DrawObject(selectedObject.GetType().Name, data, false);
        }


        /// <summary>
        /// Moves the currently selected CanvasObject by permanently changing its location to that of the cursor. 
        /// </summary>
        public void MoveSelectedObject(object sender, EventArgs e)
        {
            Point cursorCoords = GetCursorPosition();

            foreach (var entry in cm.AllCanvasObjects)
            {
                if (entry.Value == cm.SelectedObject)
                {
                    entry.Key.Coordinates = cursorCoords;
                    entry.Value.Location = cursorCoords;
                }
            }
        }


        /// <summary>
        /// Moves all of the CanvasObjects relative to the cursor location, and stores their new location permanently.  
        /// </summary>
        public void MoveAllObjects(object sender, EventArgs e)
        {
            Point cursorCoords = GetCursorPosition();

            foreach(var entry in cm.AllCanvasObjects)
            {
                Point storedCoords = entry.Key.Coordinates;
                Point newCoords = new Point(storedCoords.X - (startLocation.X - cursorCoords.X), storedCoords.Y - (startLocation.Y - cursorCoords.Y));

                entry.Key.Coordinates = newCoords;
                entry.Value.Location = newCoords;
            }

            startLocation = cursorCoords;
        }


        /// <summary>
        /// Captures the currently visible drawing canvas and stores the image as a PNG-file.
        /// </summary>
        private void ExportCanvas()
        {
            int width = mainContainer.Width - 16;
            int height = mainContainer.Height - 16;

            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(new Point(Bounds.Left + 12, Bounds.Top + 55), Point.Empty, new Size(width, height));

            bitmap.Save(fm.ReadConfigFile()[0] + "PCB_Drawing.png", ImageFormat.Png);
        }


        /// <summary>
        /// Creates a preview object which shows where- and how the new object will look like. 
        /// Gets its parameters for drawing the new object directly from the Form components.
        /// </summary>
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
                        case "north-east":
                            angle = 90;
                            length = Math.Abs(x - cursorLocation.X);
                            width = Math.Abs(y - cursorLocation.Y);
                            y = Math.Abs(cursorLocation.Y);
                            break;
                        case "north":
                            length = penThickness;
                            width = Math.Abs(cursorLocation.Y - y);
                            y += (cursorLocation.Y - y);
                            break;
                        case "north-west":
                            angle = 180;
                            length = Math.Abs(cursorLocation.X - x);
                            width = Math.Abs(cursorLocation.Y - y);
                            x = Math.Abs(cursorLocation.X);
                            y = Math.Abs(cursorLocation.Y);
                            break;
                        case "west":
                            length = Math.Abs(cursorLocation.X - x);
                            x += (cursorLocation.X - x);
                            break;
                        case "south-west":
                            angle = 270;
                            length = Math.Abs(x - cursorLocation.X);
                            width = Math.Abs(y - cursorLocation.Y);
                            x = Math.Abs(cursorLocation.X);
                            break;
                        case "south":
                            length = penThickness;
                            width = Math.Abs(cursorLocation.Y - y);
                            break;
                        case "south-east":
                            angle = 360;
                            length = Math.Abs(cursorLocation.X - x);
                            width = Math.Abs(cursorLocation.Y - y);
                            break;
                    }
                        
                    data = new int[] { x, y, width, length, angle, penThickness };
                    break;

                case "Circle (empty)":
                case "Circle (filled)":
                    switch (DetectCursorPosition(cursorLocation))
                    {
                        case "south-east":
                        case "east":
                            width = cursorLocation.X - x;
                            break;
                        case "north-east":
                        case "north":
                            width = cursorLocation.X - x;
                            y -= width;
                            break;
                        case "north-west":
                        case "west":
                            width = x - cursorLocation.X;
                            x -= width;
                            y -= width;
                            break;
                        case "south-west":
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


        /// <summary>
        /// Checks where the cursor is in proximity to the startLocation. 
        /// </summary>
        /// <param name="cursor">Current cursor location.</param>
        /// <returns>The compass direction which the cursor is in.</returns>
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
            else if (divX > lineOffset && divY < -lineOffset)
            {
                position = "north-east";
            }
            else if (divX > -lineOffset && divY < -lineOffset)
            {
                position = "north";
            }
            else if (divX < lineOffset && divY < -lineOffset)
            {
               position = "north-west";
            }
            else if (divX < -lineOffset && divY < lineOffset)
            {
                position = "west";
            }
            else if (divX < -lineOffset && divY > lineOffset)
            {
                position = "south-west";
            }
            else if (divX < lineOffset && divY > lineOffset)
            {
                position = "south";
            }

            return position;
        }


        /// <summary>
        /// Checks if a set with CanvasObject parameters is valid, to ensures no "invisible" objects are being created. 
        /// </summary>
        /// <param name="objectData">The array with parameters.</param>
        /// <returns>True = all parameters are valid, False = some parameters will lead to an "invisible" object.</returns>
        private bool CheckForInvisibleObject(int[] objectData)
        {
            switch(objectData.Length)
            {
                case 4:
                    return objectData[2] > 0 ? true : false;
                case 6:
                    return objectData[3] > 0 ? true : false;
                default:
                    return true;
            }
        }


        public void MouseDownEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // If the left mouse button is pressed while the copySelectedObject timer is active,
                // stop the timer and draw a permanent version of the current preview object onto the canvas.
                if (IntervalManager.Singleton.GetTimerStatus("copySelectedObject"))
                {
                    IntervalManager.Singleton.ManageTimer("copySelectedObject", false);

                    CanvasObject objectToDraw = cm.PreviewObject.First().Key;
                    DrawObject(objectToDraw.GetType().Name, objectToDraw.GetObjectParameters(), true);
                }
                // If the left mouse button is pressed while the moveAllObjects timer is active, stop the timer.
                else if (IntervalManager.Singleton.GetTimerStatus("moveAllObjects"))
                {
                    IntervalManager.Singleton.ManageTimer("moveAllObjects", false);
                }
                // If the left mouse button is pressed and there is no CanvasObject selected, start the drawPreviewObject timer.
                else if (cm.SelectedObject == null)
                {
                    startLocation = GetCursorPosition();
                    IntervalManager.Singleton.ManageTimer("drawPreviewObject", true);
                }
                // If the left mouse button is pressed and there is a CanvasObject selected, start the moveSelectedObject timer.
                else if (cm.SelectedObject != null)
                {
                    IntervalManager.Singleton.ManageTimer("moveSelectedObject", true);
                }
            }
        }


        public void MouseUpEvent(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) 
            {
                // If the left mouse button is released and the drawPreviewObject timer is active, 
                // stop it and premanently draw the last preview CanvasObject onto the canvas.
                // Only preview object with valid parameters are being permanently drawn. 
                if (IntervalManager.Singleton.GetTimerStatus("drawPreviewObject"))
                {
                    IntervalManager.Singleton.ManageTimer("drawPreviewObject", false);
                    CanvasObject previewObject = cm.PreviewObject.First().Key;
                    int[] parameters = previewObject.GetObjectParameters();
                    
                    if (CheckForInvisibleObject(parameters))
                    {
                        DrawObject(previewObject.GetType().Name, parameters, true);
                        UpdateButtonStatus("undo");
                    }
                }
                // If the left mouse button is released and the moveSelectedObject timer is active, 
                // stop it and store the new coordinates of the selected object. 
                else if (IntervalManager.Singleton.GetTimerStatus("moveSelectedObject"))
                {
                    IntervalManager.Singleton.ManageTimer("moveSelectedObject", false);
                    cm.ChangeSelectedObject(cm.SelectedObject);
                }
                
            }
        }


        private void MouseWheelEvent(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                bool zoomStatus = e.Delta < 0 ? true : false;
                ZoomInOut(zoomStatus);
            }
        }


        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            // If the Ctrl + Z keys are being pressed while the undo-button is enabled, trigger the "undo" function.
            if ((e.Control && e.KeyCode == Keys.Z) && btnUndo.Enabled)
            {
                btnUndo_Click(sender, e);
            }
            // If the del key is being pressed while the delete-button is enabled, remove that object.
            else if (e.KeyCode == Keys.Delete && btnDelete.Enabled)
            {
                btnDelete_Click(sender, e);
            }
            // If the Ctrl + C keys are being pressed, start the copySelectedObject timer.
            else if (e.Control && e.KeyCode == Keys.C && cm.SelectedObject != null)
            {
                IntervalManager.Singleton.ManageTimer("copySelectedObject", true);
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


        private void btnUndo_Click(object sender, EventArgs e)
        {
            ClearMainDrawCanvas(cm.RemoveLastObjectFromCanvas());
            UpdateButtonStatus("undo");
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


        private void btnDelete_Click(object sender, EventArgs e)
        {
            PictureBox pb = cm.ClearSelectedObject();
            cm.RemoveObject(pb);
            ClearMainDrawCanvas(pb);
        }


        private void btnMoveObjects_Click(object sender, EventArgs e)
        {
            startLocation = new Point(Screen.FromControl(this).Bounds.Width / 2 - 100, Screen.FromControl(this).Bounds.Height / 2);
            Cursor.Position = startLocation;
            IntervalManager.Singleton.ManageTimer("moveAllObjects", true);
        }


        private void mItemExport_Click(object sender, EventArgs e)
        {
            ExportCanvas();
        }
    }
}
