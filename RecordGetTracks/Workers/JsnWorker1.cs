using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecordGetTracks
{    
    public class JsnWorker1
    {
        public static List<RadioRec> ReadJsnFile()
        {
            using (StreamReader jsReader = new StreamReader(SetStatic.JsonRecordPath))
            {
                JsonReader json = new JsonTextReader(jsReader);
                JsonSerializer jsonSerializer = new JsonSerializer();
                var list = jsonSerializer.Deserialize<List<RadioRec>>(json);
                return list;
            }
        }
        public static Preferenses ReadSettingsJson()
        {
            using (StreamReader jsReader = new StreamReader(SetStatic.JsonSettingsPath))
            {
                JsonReader json = new JsonTextReader(jsReader);
                JsonSerializer jsonSerializer = new JsonSerializer();
                var list = jsonSerializer.Deserialize<Preferenses>(json);
                return list;
            }
        }
        public static string ReadJsnYoutubeLink(string link)
        {
            var webClient = new WebClient();
          
            try
            {
                string linkz = $"https://tags.radiorecord.fm/y.php?tid={link}";
                string readHtml = webClient.DownloadString(linkz);
                var jsn = JsonConvert.DeserializeObject<LinkYoutube>(readHtml);
                if (jsn.vid != "")
                    return $"https://www.youtube.com/watch?v={jsn.vid}";
            }
            catch (System.Net.WebException netex)
            {
                //  if (netex.Message.Contains("500"))
                //   throw new Exception("500 huli");
                return "";
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                return "";
            }
            return "";
        }

        public static void CreateJsnFile(object listFav, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                JsonWriter jsonWriter = new JsonTextWriter(sw);
                JsonSerializer jsnS = new JsonSerializer();
                jsnS.Formatting = Formatting.Indented;
                jsnS.Serialize(jsonWriter, listFav);
            }
        }
    }
}
