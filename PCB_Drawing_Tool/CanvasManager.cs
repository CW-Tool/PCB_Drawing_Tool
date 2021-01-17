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


		public int GetCountOfCanvasObjects()
		{
			return allCanvasObjects.Count();
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


		/// <summary>
		/// Removes an entry from the allCanvasObjects collection. 
		/// </summary>
		/// <param name="value">The PictureBox which is the value of a stored dictionary entry.</param>
		public void RemoveObject(PictureBox value)
		{
			CanvasObject dictKey = null;

			foreach (var entry in allCanvasObjects)
			{
				if (entry.Value == value)
				{
					dictKey = entry.Key;
				}
			}

			if (dictKey != null)
			{
				allCanvasObjects.Remove(dictKey);
			}
		}


		/// <summary>
		/// Gets the reference to a stored CanvasObject from allCanvasObjects.
		/// </summary>
		/// <param name="entryValue">The PictureBox whos the value of the desired CanvasObject.</param>
		/// <returns>The CanvasObject used for creating the provided PictureBox.</returns>
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


		/// <summary>
		/// Removes the last CanvasObject from the allCanvasObjects collection.
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
		/// If the right mouse button is being pressed onto a PictureBox, make it the selected object.
		/// </summary>
		public void SelectObject(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				PictureBox clickedObject = sender as PictureBox;
				ChangeSelectedObject(clickedObject);
			}
		}


		/// <summary>
		/// Change the PictureBox stored in selectedObject. 
		/// If the provided object is the same as the one stored in selectedObject, it will be replaced with a null reference.
		/// </summary>
		/// <param name="objectToChange">The PictureBox which is to be stored in selectedObject.</param>
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
			MainProgram.MainForm.UpdateButtonStatus("delete");
		}


		/// <summary>
		/// Clears the selectedObject value.
		/// </summary>
		/// <returns>The PictureBox which was stored in the selectedObject.</returns>
		public PictureBox ClearSelectedObject()
        {
			PictureBox pb = selectedObject;
			ChangeSelectedObject(selectedObject);

			return pb;
		}


		/// <summary>
		/// Clears the previewObject value.
		/// </summary>
		/// <returns>The PictureBox which was stored in the previewObject.</returns>
		public PictureBox ClearPreviewObject()
		{
			PictureBox pb = null;
			
			if (previewObject.Count != 0)
			{
				pb = previewObject.First().Value;
				previewObject.Remove(previewObject.First().Key);
			}

			return pb;
		}
	}
}

