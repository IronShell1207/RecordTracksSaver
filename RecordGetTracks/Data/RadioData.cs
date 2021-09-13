using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordGetTracks;

namespace RadioData
{

    public class Pages
    {
        public static readonly string MainPageUrl = "https://www.radiorecord.fm/playlist.html"; // основная страница
        public static readonly string StationUrlPat = "https://www.radiorecord.fm/player2/butlogo/"; // не используется
        public static readonly string YoutubeJsonGetLink = "https://tags.radiorecord.fm/y.php?tid={0}"; // $ подставить номер
        #region By locations
        #endregion

    }
    //div[@class='icon']
    public class xPathes
    {
        public static readonly By StationBtns = By.XPath("//div[@class='icon']//img");
        public static readonly string TracksFrameN = "content_frame";
        public static readonly By FramePlaylist = By.Name("playlist_frame");
        public static readonly string LinkAttr = "src";
        public static readonly By TrackXPath = By.XPath("//div[@class='artist']");
        public static readonly By TrTdList = By.XPath("//tbody/tr");
        public static readonly By TracksPath = By.ClassName("artist");
        public static readonly By TrackAllXPath = By.XPath("//b[text()='Все']");
        public static readonly By TracksList = By.XPath("//tbody/tr");
        public class IframePage
        {
            public static By PageRef = By.ClassName("pages");
            public static By PageName = By.ClassName("ntitle2");
            public static string YoutubeLink = "(//div[@class='youtubeimg'])[{0}]"; //attibute onclick
            public static string FindButtonAtRow = "";
        }
    }
    public class Converting
    {
        public static string NameFromLink(string link)
        {
            return link.Replace(Pages.StationUrlPat, "").Replace(".gif", "").ToUpper().Trim();
        }
        public static readonly string[] SymToChange = new string[] { "—", "—", "/", "rmx" };
        public static readonly string[] SymEnd = new string[] { "-", "-", " ", "Remix" };
    }
    public class RadioLists
    {
        private static List<RadioRec> _stationList;
        public static List<RadioRec> StationsList
        {
            get
            {
                if (_stationList != null)
                    return _stationList;
                try
                {
                    _stationList = JsnWorker1.ReadJsnFile();
                    return _stationList;
                }
                catch (Exception ex) { }
                if (_stationList != null)
                    return _stationList;
                _stationList = new List<RadioRec> { };
                return _stationList;
            }
            set
            {
                _stationList = value;
            }
        }
    }
}

