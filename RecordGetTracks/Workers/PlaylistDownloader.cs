using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeDLSharp;

namespace RecordGetTracks
{
    public class LinkYoutube
    {
        public string vid { get; set; }
    }
    class PlaylistDownloader
    {
        private Form1 form_;
        public PlaylistDownloader(object form) => form_ = form as Form1;
        private WebClient webDld = new WebClient();
        public bool CheckDownloadedContent()
        {
            if (SetStatic.settings.YoutubeDLpath==null || SetStatic.settings.YoutubeDLpath=="")
            {
                webDld.DownloadFileCompleted += YoutubeDl_DownloadFileCompleted;
                DownloaderEXE(new Uri("https://github.com/ytdl-org/youtube-dl/releases/download/2020.12.05/youtube-dl.exe"), "youtube-dl.exe");
                    return false;
            }
            if (SetStatic.settings.FFMpegPath==null || SetStatic.settings.FFMpegPath == "")
            {
                SetStatic.settings.FFMpegPath = $"{SetStatic.FolderPath}ffmpeg\\bin\\ffmpeg.exe";
                JsnWorker1.CreateJsnFile(SetStatic.settings, SetStatic.JsonSettingsPath);
                //webDld.DownloadFileCompleted += FFMpDld_DownloadFileCompleted;
              //  DownloaderEXE(new Uri("https://www.gyan.dev/ffmpeg/builds/ffmpeg-git-full.7z"), "ffmpeg-git-full.7z");
            }
            return true;
        }

       /* private void FFMpDld_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            var file =$"{SetStatic.FolderPath}ffmpeg-git-full.7z";
            
            var listToHide = new List<Control> { form_.metroLabel11, form_.toggleAutoSkip, form_.metroLabel12, form_.toggleAutoSelect };
            form_.panelSpoti.Visible = false;
            foreach (Control ctrl in listToHide)
                ctrl.Visible = true;
            SetStatic.settings.YoutubeDLpath = $"{SetStatic.FolderPath}youtube-dl.exe";
            JsnWorker1.CreateJsnFile(SetStatic.settings, SetStatic.JsonSettingsPath);
        }
       */
        public async void DownloadTracks(List<Track> links,string FolderName)//List<string> tracks1)
        {
            //if (CheckDownloadedContent())
            {
                var ytdl = new YoutubeDL();
                ytdl.YoutubeDLPath = SetStatic.settings.YoutubeDLpath;
                ytdl.FFmpegPath = SetStatic.settings.FFMpegPath;
                if (!Directory.Exists(SetStatic.FolderPath + FolderName))
                    Directory.CreateDirectory(SetStatic.FolderPath + FolderName);
                ytdl.OutputFolder = SetStatic.FolderPath+ FolderName;
                form_.panelSpoti.Visible = true;
                form_.labelCurrProcess.Text = $"Выполняется: 0/0";
                form_.MaximumProgressBar = links.Count;
                for (int i = 0; i < links.Count; i++)
                {
                    form_.labelCurrProcess.Text = $"Выполняется: {i}/{links.Count}";
                    form_.labelSpotiCurrName.Text = links[i].Name;
                    form_.ProgressProgressBar = i+1;
                    var res = await ytdl.RunAudioDownload($"{links[i].YoutubeLink}", YoutubeDLSharp.Options.AudioConversionFormat.Mp3);
                }
             //   foreach (string songname in tracks1)
                {
                    
                }
            }
        
        }
        
        public void DownloaderEXE(Uri link, string name)
        {
            var listToHide = new List<Control> { form_.metroLabel11, form_.toggleAutoSkip, form_.metroLabel12, form_.toggleAutoSelect };
            form_.Invoke(new Action(() =>
            {
                form_.panelSpoti.Visible = true;
                foreach (Control ctrl in listToHide)
                    ctrl.Visible = false;
                form_.labelSpotiCurrName.Text = $"Downloading: {name}";
                form_.labelCurrProcess.Text = "Выполняется: 0/0";
                form_.buttonBreakSpoti.Text = "Отменить\nскачивание";
            }));
            webDld.DownloadProgressChanged += ClientDownloader_DownloadProgressChanged;
          
            webDld.DownloadFileAsync(link, $"{SetStatic.FolderPath}{name}");
        }

        private void YoutubeDl_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            var listToHide = new List<Control> { form_.metroLabel11, form_.toggleAutoSkip, form_.metroLabel12, form_.toggleAutoSelect };
            form_.panelSpoti.Visible = false;
            foreach (Control ctrl in listToHide)
                ctrl.Visible = true;
            SetStatic.settings.YoutubeDLpath = $"{SetStatic.FolderPath}youtube-dl.exe";
            JsnWorker1.CreateJsnFile(SetStatic.settings, SetStatic.JsonSettingsPath);
        }

        private void ClientDownloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            form_.ProgressProgressBar = e.ProgressPercentage;
            form_.labelCurrProcess.Text = $"Выполняется: {SizeSuffix(e.BytesReceived)}/{SizeSuffix(e.TotalBytesToReceive)}";
        }
        public static string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            int i = 0;
            decimal dValue = (decimal)value;
            while (Math.Round(dValue / 1024) >= 1)
            {
                dValue /= 1024;
                i++;
            }
            return string.Format("{0:n1} {1}", dValue, SizeSuffixes[i]);
        }
        public static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
    }
}
