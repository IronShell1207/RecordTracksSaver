using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordGetTracks
{
    class Names
    {
        public static string JsonRadioList = DataFolderPath + "RadioStations.json";
        
        public static string DataFolderPath
        {
            get
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+"\\RecordGetTracks\\";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                return path;
            }
        }
    }

}
