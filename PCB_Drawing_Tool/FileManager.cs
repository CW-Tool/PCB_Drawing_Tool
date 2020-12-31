using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

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
            filepath = ReadConfigFile()[0];
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


        /// <summary>
        /// Checks if there exists a text-file containing stored CanvasObject from the previous session.
        /// </summary>
        /// <returns>True or false based on if a file exists or not.</returns>
        public bool CheckForSavedCanvasObjects()
        {
            return File.Exists(filepath + FILENAME);
        }


        /// <summary>
        /// Stores new configuration data in a text-file.
        /// The data which can be stored is either a local filepath or the status of the autosave feature (true/false). 
        /// </summary>
        /// <param name="newConfig">A string of data which is to be stored.</param>
        public void SaveDefaultConfig(string newConfig)
        {
            List<string> currentConfig = ReadConfigFile();
            StreamWriter sw = new StreamWriter(CONFIGFILE);

            if (newConfig != "true" && newConfig != "false")
            {
                filepath = newConfig;
                sw.WriteLine(newConfig);
                sw.WriteLine(currentConfig[1]);
            }
            else
            {
                sw.WriteLine(currentConfig[0]);
                sw.WriteLine(newConfig);
            }
            
            sw.Close();
        }


        /// <summary>
        /// Gets all the data stored in the configuration text-file.
        /// </summary>
        /// <returns>A list with to string objects, first being a filepath and second the status of the autosave feature.</returns>
        public List<string> ReadConfigFile()
        {
            List<string> data = new List<string>();

            if (File.Exists(CONFIGFILE))
            {
                StreamReader sr = new StreamReader(CONFIGFILE);
                string currentLine;

                while ((currentLine = sr.ReadLine()) != null)
                {
                    data.Add(currentLine);
                }
                sr.Close();
            }
            else
            {
                data.Add("");
                data.Add("false");
            }

            return data;
        }


        /// <summary>
        /// Saves all of the currently present CanvasObjects in a text-file in the specified directory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SaveToFile(object sender, EventArgs e)
        {
            StreamWriter sw = filepath != "" ? new StreamWriter(filepath + FILENAME) : new StreamWriter(FILENAME);

            foreach(CanvasObject element in CanvasManager.Singleton.AllCanvasObjects)
            {
                sw.WriteLine(element.GetType().Name + " " + string.Join(" ", element.GetObjectParameters()));
            }
            sw.Close();
        }


        /// <summary>
        /// Retrieves the stored CanvasObject data, and creates new objects based on it. 
        /// </summary>
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
                        MainProgram.MainForm.DrawObject(data[0], data[1], data[2], data[3]);
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
