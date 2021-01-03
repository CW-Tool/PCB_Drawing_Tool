using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PCB_Drawing_Tool
{
	class CanvasManager
	{
		private static CanvasManager singleton = null;
		private Dictionary<CanvasObject, PictureBox> allCanvasObjects;


		private CanvasManager()
		{
			allCanvasObjects = new Dictionary<CanvasObject, PictureBox>();
		}


		public Dictionary<CanvasObject, PictureBox> AllCanvasObjects
		{
			get { return allCanvasObjects; }
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
	

		public int GetSmallestObjectAspect()
        {
			int smallestValue = 10;

			/*
			foreach(CanvasObject element in allCanvasObjects)
            {
				string[] info = element.GetObjectParameters();
            }

			for (int i = 1; i <= GetCountOfCanvasObjects(); i++)
			{
				List<int> info = GetObjectDetails(i);
				if (info[2] < smallestValue || info[3] < smallestValue)
                {
					if (info[2] < info[3])
                    {
						smallestValue = info[2];
                    }
					else
                    {
						smallestValue = info[3];
                    }
                }
			}
			*/
			return smallestValue;
        }


		public void UpdateObject(CanvasObject objectToChange, PictureBox newGraphic)
        {
			allCanvasObjects[objectToChange] = newGraphic;
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


		public int GetCountOfCanvasObjects()
		{
			return allCanvasObjects.Count();
		}


		public PictureBox GetObjectGraphic(CanvasObject objectKey)
		{
			return allCanvasObjects[objectKey];
		}
	}
}

