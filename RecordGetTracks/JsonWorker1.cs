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
    public class Station
    {
        public string Link { get; set; }
        public string Name { get; set; }
    }
    public delegate DialogResult messageCaller(string message, string topic, MessageBoxButtons buttNS, MessageBoxIcon icon);
    
    public class JsonWorker1
    {
        public string jSonStationFile()
        {
            string path = "allst.json";
            if (!Directory.Exists(path))
            {
             //   Directory.CreateDirectory(path);
            }
            return path;

        }
        public string[] RadioList = new string[] { "Radio record",
"Mafblan fm",
"Trancemission",
"Pirate station",
"Gold",
"Megamix",
"Rock radio",
"Record club",
"Future house",
"Record dubstep",
"Record breaks",
"Teodor hardstyle",
"Yo! fm",
"Record dancecore",
"Супердискотека 90-x",
"Vip mix",
"Minimal/techno",
"Record deep",
"Record trap",
"Record chill-out",
"Russian mix",
"Гоп fm",
"Медляк fm",
"Rave",
"Pump'n'klubb",
"Tropical",
"Goa",
"Нафталин",
"Аншлаг",
"Hard bass",
"Techno",
"Remix",
"Future bass",
"Гастарбайтер",
"Маятник фуко",
"Симфония",
"Electro",
"Midtempo",
"Moombahton",
"Progressive",
"House hits",
"Synthwave",
"Dreamdance",
"Big hits",
"Record darkside",
"Record uplifting",
"House classics",
"Record edm hits",
"Trancehouse",
"Record hypnotic",
"Record neurofunk",
"Record tecktonik",
"2-step",
"Trance hits",
"Jungle",
"Liquid funk",
"Drum’n’bass hits",
"Russian gold",
"Eurodance",
"Technopop",
"Disco/funk",
"Rap classics",
"Rap",
"Cadillac fm",
"1980-e",
"Chill house",
"1970-e",
"Complextro",
"Groove/tribal",
"Russian hits",
"Innocence",
"Bass house",
"Веснушка fm",
"Руки вверх",
 };
        public string[] links = new string[] {"https://www.radiorecord.fm/player2/butlogo/rr.gif",
"https://www.radiorecord.fm/player2/butlogo/mafblan.gif",
"https://www.radiorecord.fm/player2/butlogo/tm.gif",
"https://www.radiorecord.fm/player2/butlogo/ps.gif",
"https://www.radiorecord.fm/player2/butlogo/gold.gif",
"https://www.radiorecord.fm/player2/butlogo/mix.gif",
"https://www.radiorecord.fm/player2/butlogo/rock.gif",
"https://www.radiorecord.fm/player2/butlogo/club.gif",
"https://www.radiorecord.fm/player2/butlogo/fut.gif",
"https://www.radiorecord.fm/player2/butlogo/dub.gif",
"https://www.radiorecord.fm/player2/butlogo/brks.gif",
"https://www.radiorecord.fm/player2/butlogo/teo.gif",
"https://www.radiorecord.fm/player2/butlogo/yo.gif",
"https://www.radiorecord.fm/player2/butlogo/dc.gif",
"https://www.radiorecord.fm/player2/butlogo/sd90.gif",
"https://www.radiorecord.fm/player2/butlogo/vip.gif",
"https://www.radiorecord.fm/player2/butlogo/mini.gif",
"https://www.radiorecord.fm/player2/butlogo/deep.gif",
"https://www.radiorecord.fm/player2/butlogo/trap.gif",
"https://www.radiorecord.fm/player2/butlogo/chil.gif",
"https://www.radiorecord.fm/player2/butlogo/rus.gif",
"https://www.radiorecord.fm/player2/butlogo/gop.gif",
"https://www.radiorecord.fm/player2/butlogo/mdl.gif",
"https://www.radiorecord.fm/player2/butlogo/rave.gif",
"https://www.radiorecord.fm/player2/butlogo/pump.gif",
"https://www.radiorecord.fm/player2/butlogo/trop.gif",
"https://www.radiorecord.fm/player2/butlogo/goa.gif",
"https://www.radiorecord.fm/player2/butlogo/naft.gif",
"https://www.radiorecord.fm/player2/butlogo/ansh.gif",
"https://www.radiorecord.fm/player2/butlogo/hbass.gif",
"https://www.radiorecord.fm/player2/butlogo/techno.gif",
"https://www.radiorecord.fm/player2/butlogo/rmx.gif",
"https://www.radiorecord.fm/player2/butlogo/fbass.gif",
"https://www.radiorecord.fm/player2/butlogo/gast.gif",
"https://www.radiorecord.fm/player2/butlogo/mf.gif",
"https://www.radiorecord.fm/player2/butlogo/symph.gif",
"https://www.radiorecord.fm/player2/butlogo/electro.gif",
"https://www.radiorecord.fm/player2/butlogo/midtemp.gif",
"https://www.radiorecord.fm/player2/butlogo/mmbt.gif",
"https://www.radiorecord.fm/player2/butlogo/progr.gif",
"https://www.radiorecord.fm/player2/butlogo/househits.gif",
"https://www.radiorecord.fm/player2/butlogo/synth.gif",
"https://www.radiorecord.fm/player2/butlogo/dream.gif",
"https://www.radiorecord.fm/player2/butlogo/bighits.gif",
"https://www.radiorecord.fm/player2/butlogo/darkside.gif",
"https://www.radiorecord.fm/player2/butlogo/uplift.gif",
"https://www.radiorecord.fm/player2/butlogo/houseclss.gif",
"https://www.radiorecord.fm/player2/butlogo/edmhits.gif",
"https://www.radiorecord.fm/player2/butlogo/trancehouse.gif",
"https://www.radiorecord.fm/player2/butlogo/hypno.gif",
"https://www.radiorecord.fm/player2/butlogo/neurofunk.gif",
"https://www.radiorecord.fm/player2/butlogo/tecktonik.gif",
"https://www.radiorecord.fm/player2/butlogo/2step.gif",
"https://www.radiorecord.fm/player2/butlogo/trancehits.gif",
"https://www.radiorecord.fm/player2/butlogo/jungle.gif",
"https://www.radiorecord.fm/player2/butlogo/liquidfunk.gif",
"https://www.radiorecord.fm/player2/butlogo/drumhits.gif",
"https://www.radiorecord.fm/player2/butlogo/russiangold.gif",
"https://www.radiorecord.fm/player2/butlogo/eurodance.gif",
"https://www.radiorecord.fm/player2/butlogo/technopop.gif",
"https://www.radiorecord.fm/player2/butlogo/discofunk.gif",
"https://www.radiorecord.fm/player2/butlogo/rapclassics.gif",
"https://www.radiorecord.fm/player2/butlogo/rap.gif",
"https://www.radiorecord.fm/player2/butlogo/cadillac.gif",
"https://www.radiorecord.fm/player2/butlogo/1980.gif",
"https://www.radiorecord.fm/player2/butlogo/chillhouse.gif",
"https://www.radiorecord.fm/player2/butlogo/1970.gif",
"https://www.radiorecord.fm/player2/butlogo/complextro.gif",
"https://www.radiorecord.fm/player2/butlogo/groovetribal.gif",
"https://www.radiorecord.fm/player2/butlogo/russianhits.gif",
"https://www.radiorecord.fm/player2/butlogo/innocence.gif",
"https://www.radiorecord.fm/player2/butlogo/basshouse.gif",
"https://www.radiorecord.fm/player2/butlogo/deti.gif",
"https://www.radiorecord.fm/player2/butlogo/rv.gif",
 };
        public List<Station> SetRadioNamesListFirst(string[] linkss, string[] names)
        {
            List<Station> list = new List<Station> { };
            for (int i = 0; i < links.Length; i++)
            {
                Station station = new Station() { Link = linkss[i], Name = names[i] };
                list.Add(station);
            }
            CreateJsnFile(list, "allst.json");
            return list;
        }
        private List<Station> listRadio;
        public List<Station> RadioNamesList(messageCaller msg, IWebDriver ChromeDriver, List<IWebElement> webElements)
        {
            string path = "allst.json";
            if (listRadio == null)
            {
                listRadio = new List<Station> { };
                if (File.Exists(path))
                    listRadio = ReadJsnFile(path);
                else
                {
                    DialogResult rs = msg("Загрузить втроенный лист станций или создать новый?\nЧтобы использовать встроенный нажми 'Yes'\nЧтобы загрузить лист с сайта нажми 'No'","Названия плейлистов", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (rs == DialogResult.Yes)
                        listRadio = SetRadioNamesListFirst(links, RadioList);
                    else if (rs == DialogResult.No)
                        listRadio = LoadStationNames(ChromeDriver, webElements);
                }
            }
            return listRadio;
        }
        public List<Station> LoadStationNames(IWebDriver ChromeDriver, List<IWebElement> webElements)
        {
            List<Station> stations = new List<Station> { };
            for (int i = 0; i < webElements.Count; i++)
            {
                webElements[i].Click();
                var GifLink = webElements[i].GetAttribute("src");
                ChromeDriver.SwitchTo().Frame("playlist_frame");
                var stationName = ChromeDriver.FindElement(By.ClassName("ntitle2")).Text;
                ChromeDriver.SwitchTo().DefaultContent();
                stations.Add(new Station { Link = GifLink, Name = stationName });
            }
            CreateJsnFile(stations, "allst.json");
            return stations;
        }
        public List<Station> ReadJsnFile(string path)
        {
            List<Station> stations = new List<Station> { };
            using (StreamReader jsReader = new StreamReader(path))
            {
                Station station = new Station();

                JsonReader json = new JsonTextReader(jsReader);
                JsonSerializer jsonSerializer = new JsonSerializer();
                var favoriteList = jsonSerializer.Deserialize<List<Station>>(json);
                return favoriteList;
            }
        }
        public void CreateJsnFile(List<Station> listFav, string path)
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
