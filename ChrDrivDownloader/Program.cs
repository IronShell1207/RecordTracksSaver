using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.IO.Compression;
using System.IO;

namespace ChromeDriverDownloader
{
     public class Program
     {
       public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                pathChrome = args[0].Replace("\"","");
                Console.WriteLine(pathChrome);
                Console.WriteLine("Select the chrome version which you have:\n1. Version 86\n2. Version 87\n3. Version 88\n\nInput the number (1-3)");
                var ver = int.Parse(Console.ReadKey().KeyChar.ToString());
                Console.WriteLine("");
                DownlChromeDr(ver);
                while (wb.IsBusy)
                    Thread.Sleep(500);
              //  if (File.Exists("chromedriver.zip")) return true;
            }
            else
            {
                Console.WriteLine("Не указан путь к Google Chrome!");
                Console.ReadKey();
            }
           // return false;
        }
        static string pathChrome = "";
        static WebClient wb = new WebClient();
        private static void DownlChromeDr(int link)
        {
            var links = new List<Uri> { Links.ch86, Links.ch87, Links.ch88 };
            wb.DownloadProgressChanged += Wb_DownloadProgressChanged;
            wb.DownloadFileCompleted += Wb_DownloadFileCompleted;
            wb.DownloadFileAsync(links[link-1], "chromedriver.zip");
        }

        private static void Wb_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Unpacking chromedriver...");
            ZipFile.ExtractToDirectory("chromedriver.zip", pathChrome);// @"C:\Program Files\Google\Chrome\Application");
            Console.WriteLine("Unpacked successufuly");
            Thread.Sleep(1000);
            
        }

        private static void Wb_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.Write($"\rDownloading: {SizeSuffix(e.BytesReceived)}/{SizeSuffix(e.TotalBytesToReceive)}                             ");
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