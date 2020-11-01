using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PCB_Drawing_Tool
{
    class FileManager
    {
        private static FileManager singleton = null;
        private string filepath;
        private string filename;
        const string LASTUSEDFILECONFIG = "fileConfig.txt";

        private FileManager()
        {
            string[] config = LoadFileConfig().Split(' ');
            filepath = config[0];
            filename = config[1];
        }

        public static FileManager Singleton
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new FileManager();
                }
                return singleton;
            }
        }

        public bool CheckForLastUsedFile()
        {
            if (File.Exists(filepath + filename))
            {
                return true;
            }
            
            return false;
        }

        public void UpdateFileConfig(string filepath, string filename)
        {
            this.filepath = filepath;
            this.filename = filename;
            SaveFileConfig(filepath, filename);
        }

        private void SaveFileConfig(string filepath, string filename)
        {
            StreamWriter sw = new StreamWriter(LASTUSEDFILECONFIG);
            sw.WriteLine(filepath + " " + filename + ".txt");
            sw.Close();
        }

        private string LoadFileConfig()
        {
            return new StreamReader(LASTUSEDFILECONFIG).ReadLine();
        }

        public void SaveToFile(List<PictureBox> infoToStore)
        {
            StreamWriter sw = new StreamWriter(filepath + filename);
            for (int i = 0; i < infoToStore.Count(); i++)
            {
                PictureBox pb = infoToStore[i];
                sw.WriteLine(i + " " + pb.Location.X + " " + pb.Location.Y + " " + pb.Width + " " + pb.Height + " " + pb.Name);
            }
            sw.Close();
        }

        public Dictionary<int, PictureBox> ReadFromFile()
        {
            Dictionary<int, PictureBox> storedInfo = new Dictionary<int, PictureBox>();
            StreamReader sr = new StreamReader(filepath + filename);
            string currentLine = sr.ReadLine();

            while (currentLine != null)
            {
                string[] dataStr = currentLine.Split(' ');
                int[] dataInt = Array.ConvertAll(dataStr, int.Parse);

                storedInfo.Add(dataInt[0], new PictureBox
                {
                    Location = new Point(dataInt[1], dataInt[2]),
                    BackColor = Color.Black,
                    Width = dataInt[3],
                    Height = dataInt[4]
                });
            }
            sr.Close();
            return storedInfo;
        }
    }
}
