using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace PCB_Drawing_Tool
{
	class CanvasManager
	{
		private static CanvasManager singleton = null;
		private Dictionary<CanvasObject, PictureBox> allCanvasObjects;
		private PictureBox selectedObject;
		private Dictionary<CanvasObject, PictureBox> previewObject;

		private CanvasManager()
		{
			allCanvasObjects = new Dictionary<CanvasObject, PictureBox>();
			previewObject = new Dictionary<CanvasObject, PictureBox>();
		}


		public Dictionary<CanvasObject, PictureBox> AllCanvasObjects
		{
			get { return allCanvasObjects; }
		}


		public PictureBox SelectedObject
        {
			get { return selectedObject; }
			set { selectedObject = value; }
        }


		public Dictionary<CanvasObject, PictureBox> PreviewObject
        {
			get { return previewObject; }
			set { previewObject = value; }
        }

		public static CanvasManager Singleton
        {
			get
            {
				if (singleton == null)
                {
					singleton = new CanvasManager();
                }
				return singleton;
            }
        }


		public void UpdateObject(CanvasObject objectToChange, CanvasObject newObject, PictureBox newGraphic)
        {
			allCanvasObjects.Remove(objectToChange);
			allCanvasObjects.Add(newObject, newGraphic);
		}


		/// <summary>
		/// Removes the last CanvasObject be removing it from both the allCanvasObjects and allCanvasGraphics collection.
		/// </summary>
		/// <returns>The corresponding PictureBox which is physically represented on the main Canvas in the Form.</returns>
		public PictureBox RemoveLastObjectFromCanvas()
		{
			if (GetCountOfCanvasObjects() > 0)
			{
				PictureBox removedObject = allCanvasObjects[allCanvasObjects.Keys.Last()];
				allCanvasObjects.Remove(allCanvasObjects.Keys.Last());
				return removedObject;
			}
			else
			{
				MessageBox.Show("There are no objects that can be removed!");
				return null;
			}
		}


		/// <summary>
		/// Registers the creation of a new CanvasObject, by storing it in the allCanvasObjects and allCanvasGraphics collections.
		/// </summary>
		/// <param name="newObject"></param>
		/// <param name="newGraphic"></param>
		public void AddObject(CanvasObject newObject, PictureBox newGraphic)
        {
			allCanvasObjects.Add(newObject, newGraphic);
		}


		public CanvasObject GetCanvasObject(PictureBox entryValue)
        {
			foreach (var element in new Dictionary<CanvasObject, PictureBox>(allCanvasObjects))
			{
				if (element.Value == entryValue)
				{
					return element.Key;
				}
			}

			return null;
		}


		public int GetCountOfCanvasObjects()
		{
			return allCanvasObjects.Count();
		}

		
		public void ChangeSelectedObject(PictureBox objectToChange)
        {
			if (objectToChange != selectedObject)
			{
				if (selectedObject != null)
				{
					selectedObject.BackColor = Color.Black;
				}
				objectToChange.BackColor = ColorTranslator.FromHtml("#7f7f7f");
			}
			else
			{
				objectToChange.BackColor = Color.Black;
				objectToChange = null;
			}

			selectedObject = objectToChange;
		}


		public void SelectObject(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				PictureBox clickedObject = sender as PictureBox;
				ChangeSelectedObject(clickedObject);
			}
		}
	}
}

