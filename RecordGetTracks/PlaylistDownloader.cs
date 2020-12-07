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
    class PlaylistDownloader
    {
        private Form1 form_;
        public PlaylistDownloader(object form) => form_ = form as Form1;
        public string YoutubeDLPath
        {
            get
            {
                if (SetStatic.settings.YoutubeDLpath != "" && File.Exists(SetStatic.settings.YoutubeDLpath))
                    return SetStatic.settings.YoutubeDLpath;
                DownloadYoutubeDL();
                return SetStatic.settings.YoutubeDLpath;
            }
        }
        public void DownloadTracks(List<string> tracks1)
        {
            var ytdl = new YoutubeDL();
            ytdl.YoutubeDLPath = YoutubeDLPath;
            ytdl.OutputFolder = SetStatic.FolderPath;
            foreach (string songname in tracks1)
            {
                var res = await ytdl.RunAudioDownload("");
            }
        }
        public void DownloadYoutubeDL()
        {
            var listToHide = new List<Control> { form_.metroLabel11, form_.toggleAutoSkip, form_.metroLabel12, form_.toggleAutoSelect };
            form_.Invoke(new Action(() =>
            {
                form_.panelSpoti.Visible = true;
                foreach (Control ctrl in listToHide)
                    ctrl.Visible = false;
                form_.labelSpotiCurrName.Text = "Youtube-Dl Downloading";
                form_.labelCurrProcess.Text = "Выполняется: 0/0";
                form_.buttonBreakSpoti.Text = "Отменить\nскачивания";
            }));
            var ClientDownloader = new WebClient();
            ClientDownloader.DownloadProgressChanged += ClientDownloader_DownloadProgressChanged;
            ClientDownloader.DownloadFileCompleted += ClientDownloader_DownloadFileCompleted;
            ClientDownloader.DownloadFileAsync(new Uri("https://github.com/ytdl-org/youtube-dl/releases/download/2020.12.05/youtube-dl.exe"), $"{SetStatic.FolderPath}youtube-dl.exe");
        }

        private void ClientDownloader_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
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
