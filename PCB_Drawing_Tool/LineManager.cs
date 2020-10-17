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

		public int GetLineCount()
        {
			return allLines.Count();
        }

		public List<int> GetLineDetails(int lineID)
		{
			return allLines[lineID];
        }
		public LineManager()
		{
			this.allLines = new Dictionary<int, List<int>>();
		}
		
		public void AddLine(int x1, int y1, int lineLength, int lineWidth)
        {
			int lineID = allLines.Count + 1;
			allLines.Add(lineID, new List<int>() {x1, y1, lineLength, lineWidth});
        }

	}
}

