using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecordGetTracks
{    
    public class JsnWorker1
    {
        public static List<RadioData.RadioStation> ReadJsnFile()
        {
            using (StreamReader jsReader = new StreamReader(SetStatic.JsonRecordPath))
            {
                JsonReader json = new JsonTextReader(jsReader);
                JsonSerializer jsonSerializer = new JsonSerializer();
                var list = jsonSerializer.Deserialize<List<RadioData.RadioStation>>(json);
                return list;
            }
        }
        public static SettingsM ReadSettingsJson()
        {
            using (StreamReader jsReader = new StreamReader(SetStatic.JsonSettingsPath))
            {
                JsonReader json = new JsonTextReader(jsReader);
                JsonSerializer jsonSerializer = new JsonSerializer();
                var list = jsonSerializer.Deserialize<SettingsM>(json);
                return list;
            }
        }

        public static void CreateJsnFile(object listFav, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                JsonWriter jsonWriter = new JsonTextWriter(sw);
                JsonSerializer jsnS = new JsonSerializer();
                jsnS.Serialize(jsonWriter, listFav);
            }
        }
    }
}
