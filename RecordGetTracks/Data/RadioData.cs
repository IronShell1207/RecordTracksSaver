using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordGetTracks;

namespace RadioData
{ 
    public class RadioStation // ОСНОВНОЙ КЛасс радио станций ВКЛЮЧАЮЩИЙ Список треков.!!
    {
        private List<string> _tracksList;
        public string Name { get; set; }
        public string LinkTracksList { get; set; }
        public bool isFavorite { get; set; }
        public string DateLoadedTracks { get; set; }
        public List<string> TracksList // список треков, пусть тоже записывается в json с датой создания
        {
            get
            {
                if (_tracksList != null)
                    return _tracksList;
                _tracksList = new List<string> { };
                return _tracksList;
            }
            set
            {
                _tracksList = value;
            }
        }

    }
    public class Pages
    {
        public static readonly string MainPageUrl = "https://www.radiorecord.fm/playlist.html"; // основная страница
        public static readonly string StationUrlPat = "https://www.radiorecord.fm/player2/butlogo/"; // не используется
        #region By locations
        #endregion

    }
    //div[@class='icon']
    public class xPathes
    {
        public static readonly By StationBtns = By.XPath("//div[@class='icon']//img");
        public static readonly string TracksFrameN = "playlist_frame";
        public static readonly string LinkAttr = "src";
        
        public static readonly By TrackAllXPath = By.XPath("//b[text()='Все']");
        public class IframePage
        {
            public static By TrackXPath = By.ClassName("artist");
            public static By PageRef = By.ClassName("pages");
            public static By PageName = By.ClassName("ntitle2");
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
        private static List<RadioData.RadioStation> _stationList;
        public static List<RadioData.RadioStation> StationsList
        {
            get
            {
                if (_stationList != null)
                    return _stationList;
                try
                {
                    _stationList = JsonWorker1.ReadJsnFile(Names.JsonRadioList);
                    return _stationList;
                }
                catch (Exception ex) { }
                if (_stationList != null)
                    return _stationList;
                _stationList = new List<RadioData.RadioStation> { };
                return _stationList;
            }
            set
            {
                _stationList = value;
            }
        }
    }
}

