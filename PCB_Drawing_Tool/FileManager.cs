using System;
using System.IO;
using System.Linq;

namespace PCB_Drawing_Tool
{
    class FileManager
    {
        private static FileManager singleton = null;
        private string filepath;
        const string FILENAME = "CanvasObjects.txt";
        const string CONFIGFILE = "FileManagerConfig.txt";

        private FileManager()
        {
            filepath = ReadConfigFile();
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
            return File.Exists(filepath + FILENAME);
        }

        public void UpdateConfigFile(string filepath)
        {
            this.filepath = filepath;
            SaveConfigFile(filepath);
        }

        private void SaveConfigFile(string filepath)
        {
            StreamWriter sw = new StreamWriter(CONFIGFILE);
            sw.WriteLine(filepath);
            sw.Close();
        }

        public string ReadConfigFile()
        {
            if (!File.Exists(CONFIGFILE))
            {
                SaveConfigFile("Not Defined Jet");
            }

            StreamReader sr = new StreamReader(CONFIGFILE);
            string data = sr.ReadLine();
            sr.Close();

            return data;
        }


        public void SaveToFile(object sender, EventArgs e)
        {
            StreamWriter sw = filepath != "Not Defined Jet" ? new StreamWriter(filepath + FILENAME) : new StreamWriter(FILENAME);

            foreach(CanvasObject element in CanvasManager.Singleton.AllCanvasObjects)
            {
                sw.WriteLine(element.GetType().Name + " " + string.Join(" ", element.GetObjectParameters()));
            }
            sw.Close();
        }

        public void ReadFromFile()
        {
            StreamReader sr = new StreamReader(filepath + FILENAME);
            string currentLine;

            while ((currentLine = sr.ReadLine()) != null)
            {
                string[] rawData = currentLine.Split(' ');
                string objectType = rawData[0];
                int[] data = Array.ConvertAll(rawData.Skip(1).ToArray(), int.Parse);

                switch(objectType)
                {
                    case "Line":
                        MainProgram.MainForm.DrawObject(data[0], data[1], data[2], data[3], data[4]);
                        break;
                    case "Circle":
                        bool filled = data[3] == 0 ? false : true;
                        MainProgram.MainForm.DrawObject(data[0], data[1], data[2], filled);
                        break;
                    case "Transistor":
                        //MainProgram.MainForm.DrawObject(data[0], data[1], data[2], data[3], data[4], data[5]);
                        break;
                }

            }
            sr.Close();
        }
    }
}
