using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB_Drawing_Tool
{
    class LineManager
    {
		private Dictionary<int, List<int>> allLines;
		
		public LineManager()
		{
			this.allLines = new Dictionary<int, List<int>>();
		}

		public int GetSmallestLineAspect()
        {
			int smallestValue = 100000;

			for (int i = 1; i <= GetLineCount(); i++)
			{
				List<int> info = GetLineDetails(i);
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

		public int GetLineCount()
		{
			return allLines.Count();
		}

		public List<int> GetLineDetails(int lineID)
		{
			return allLines[lineID];
		}

		public void AddLine(int x1, int y1, int lineLength, int lineWidth)
        {
			int lineID = allLines.Count + 1;
			allLines.Add(lineID, new List<int>() {x1, y1, lineLength, lineWidth});
	
        }

		public void UpdateLine(int id, int x1, int y1, int lineLength, int lineWidth)
		{
			allLines[id] = new List<int>() { x1, y1, lineLength, lineWidth };
		}
	}
}

