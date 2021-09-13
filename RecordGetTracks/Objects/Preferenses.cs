using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordGetTracks
{
    public class Preferenses
    {
        private string _chrPath = SetStatic.ChromeDefPath;
        public string ChromePath
        {
            get
            {
                if (_chrPath == null)
                    _chrPath = SetStatic.ChromeDefPath;
                return _chrPath;
            }
            set => _chrPath = value;
        }
        public bool UseFavList { get; set; }
        public string SpotiLogin { get; set; }
        public string SpotiPass { get; set; }
        public bool HideBrowser { get; set; }
        public bool IsBigSymsInRadios { get; set; }
        public bool IsSkipRusAuto { get; set; }
        public List<string> SpotiPlaylists { get; set; }
        public MetroFramework.MetroThemeStyle mTheme { get; set; }
        public MetroFramework.MetroColorStyle mColor { get; set; }
        public string YoutubeDLpath { get; set; }
        public string FFMpegPath { get; set; }
    }
}

