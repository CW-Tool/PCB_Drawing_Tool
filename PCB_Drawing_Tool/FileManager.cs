using System;
using System.IO;
using System.Linq;

namespace PCB_Drawing_Tool
{
    class FileManager
    {
        private static FileManager singleton = null;
        private string filepath;
        private string filename;
        private string fileExtension;
        const string LASTUSEDFILECONFIG = "fileManagerConfig.txt";

        private FileManager()
        {
            fileExtension = ".txt";
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

        public bool CheckForSavedCanvasObjects()
        {
            return File.Exists(filepath + filename);
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
            sw.WriteLine(filepath + " " + filename + fileExtension);
            sw.Close();
        }

        private string LoadFileConfig()
        {
            if (!File.Exists(LASTUSEDFILECONFIG))
            {
                SaveFileConfig("NotDefined", "NotDefined");
            }
            return new StreamReader(LASTUSEDFILECONFIG).ReadLine();
        }

        public void SaveToFile(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(filepath + filename);

            foreach(CanvasObject element in CanvasManager.Singleton.AllCanvasObjects)
            {
                sw.WriteLine(element.GetType().Name + " " + string.Join(" ", element.GetObjectParameters()));
            }
            sw.Close();
        }

        public void ReadFromFile()
        {
            StreamReader sr = new StreamReader(filepath + filename);
            string currentLine = sr.ReadLine();

            while (currentLine != null)
            {
                string[] rawData = currentLine.Split(' ');
                string objectType = rawData[0];
                int[] data = Array.ConvertAll(rawData.Skip(1).ToArray(), int.Parse);

                switch(objectType)
                {
                    case "Line":
                        new Line(data[0], data[1], data[2], data[3], data[4]);
                        break;
                    case "Circle":
                        new Circle(data[0], data[1], data[2], data[3]);
                        break;
                    case "Transistor":
                        new Transistor(data[0], data[1], data[2], data[3], data[4], data[5]);
                        break;
                }

            }
            sr.Close();
        }
    }
}
