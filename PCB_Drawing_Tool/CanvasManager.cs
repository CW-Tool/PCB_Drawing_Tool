using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCB_Drawing_Tool
{
    class CanvasManager
    {
		private Dictionary<int, PictureBox> allCanvasObjects;
		
		public CanvasManager()
		{
			allCanvasObjects = new Dictionary<int, PictureBox>();
		}

		public int GetSmallestObjectAspect()
        {
			int smallestValue = 100000;

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
			return smallestValue;
        }

		public int GetCountOfCanvasObjects()
		{
			return allCanvasObjects.Count();
		}

		public List<int> GetObjectDetails(int objectID)
		{
			PictureBox picObject = allCanvasObjects[objectID]; 
			return new List<int>(){ picObject.Location.X, picObject.Location.Y, picObject.Width, picObject.Height };
		}

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

		public void AddObject(PictureBox newObject)
        {
			int objectID = allCanvasObjects.Count + 1;
			allCanvasObjects.Add(objectID, newObject);
        }

		public void UpdateObject(int id, PictureBox newObject)
		{
			allCanvasObjects[id] = newObject;
		}
	}
}

