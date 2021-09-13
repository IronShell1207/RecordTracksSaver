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
        private static Preferenses _sets;
        public static int CountTracksToShow { get; set; }
        public static Preferenses settings
        {
            get
            {
                if (_sets != null)
                    return _sets;
                _sets = File.Exists(JsonSettingsPath) ? JsnWorker1.ReadSettingsJson() : null;
                if (_sets == null)
                {

                    _sets = new Preferenses { mColor= MetroFramework.MetroColorStyle.Brown, mTheme= MetroFramework.MetroThemeStyle.Dark, IsBigSymsInRadios=true };
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
        public static void DownloadChromeDriver()
        {
            
        }
        public static string ChromeDefPath
        {
            get
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Google\Chrome\Application\";
                string GlobPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\Google\Chrome\Application\";
                string GlobPath64 = @"C:\Program Files\Google\Chrome\Application\";
                if (Directory.Exists(appDataPath))
                    return appDataPath;
                if (Directory.Exists(GlobPath))
                    return GlobPath;
                if (Directory.Exists(GlobPath64))
                    return GlobPath64;
                return "";
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
    
}
