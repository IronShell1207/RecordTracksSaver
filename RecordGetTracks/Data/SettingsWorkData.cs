using MetroFramework.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecordGetTracks
{
    public class SetStatic
    {
        private static SettingsM _sets;
        private static MetroStyleManager _msm;
        //public static MetroStyleManager mSM
        //{
        //    get
        //    {
        //        if (_msm != null)
        //            return _msm;
        //        _msm = new MetroStyleManager();
        //        _msm.Theme = settings.mTheme != 0 ? settings.mTheme : MetroFramework.MetroThemeStyle.Dark;
        //        _msm.Style = settings.mColor != 0 ? settings.mColor : MetroFramework.MetroColorStyle.Brown;
        //        return _msm;
        //    }
        //    set
        //    {
        //        _msm = value;
        //    }
        //}
        public static SettingsM settings
        {
            get
            {
                if (_sets != null)
                    return _sets;
                _sets = File.Exists(JsonSettingsPath) ? JsnWorker1.ReadSettingsJson() : null;
                if (_sets == null)
                {
                    string chrPath = ChromeDefPath;
                    if (chrPath == null)
                    {
                        string newPath = FindChromePath();
                        if (newPath != null)
                        {
                            chrPath = newPath;
                        }
                    }
                    _sets = new SettingsM { ChromePath = chrPath };
                    JsnWorker1.CreateJsnFile(_sets, JsonSettingsPath);
                }
                return _sets;
            }
            set
            {
                _sets = value;
            }
        }
        public static string FindChromePath()
        {
            var ofd = new OpenFileDialog()
            {
                FileName = "chrome.exe",
                Filter = "chrome.exe|chrome.exe|All files(*.*)|*.*",
                Title = "Укажите расположение Google Chrome",
            };
            if (DialogResult.OK == ofd.ShowDialog())
                return ofd.FileName;

            return null;
        }
        public static string ChromeDefPath
        {
            get
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\Application\";
                string GlobPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Google\Chrome\Application";
                if (Directory.Exists(appDataPath))
                    return appDataPath;
                if (Directory.Exists(GlobPath))
                    return GlobPath;
                return null;
            }
        }
        public static string JsonRecordPath { get { return FolderPath + "JsonRecord.json"; } }
        public static string JsonSettingsPath { get { return FolderPath + "JsonSetts.json"; } }
        public static string FolderPath
        {
            get
            {
                var _PathFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\RadioPlaylistConverter\";
                if (!Directory.Exists(_PathFolder))
                    Directory.CreateDirectory(_PathFolder);
                return _PathFolder;
            }
        }
    }
    public class SettingsM
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
