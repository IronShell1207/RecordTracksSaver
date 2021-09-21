using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.IO.Compression;
using System.IO;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace ChromeDriverDownloader
{
     public class Program
     {
       public static void Main(string[] args)
        {
            
            if (args.Length > 0)
            {
                int instver = args[1] != null ? int.Parse(args[1]) : 0;
                var versionlink = GetVersions(instver);
                pathChrome = args[0].Replace("\"","");
                
                Console.WriteLine(pathChrome);
                Console.WriteLine("");
                DownlChromeDr(Links.chromeLinkAdder+ versionlink);
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
        private static void DownlChromeDr(string link)
        {
            wb.DownloadProgressChanged += Wb_DownloadProgressChanged;
            wb.DownloadFileCompleted += Wb_DownloadFileCompleted;
            wb.DownloadFileAsync(new Uri(link), "chromedriver.zip");
        }

        private static void Wb_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Unpacking chromedriver...");
            ZipFile.ExtractToDirectory("chromedriver.zip", pathChrome);// @"C:\Program Files\Google\Chrome\Application");
            Console.WriteLine("Unpacked successufuly");
            Thread.Sleep(1000);
            
        }
        public static string GetVersions(int keyvers = 0)
        {
            Console.WriteLine("Please, select your chrome version by sending the number from list bellow (for exable send '0' for selecting 70 version of chrome");
            var webDr = new WebClient();
            
            var data = webDr.OpenRead(Links.ChromeDriversApiXMLLink);
            var ser = new XmlSerializer(typeof(ListBucketResult));
            var listvers = new List<string> { };
            var versions = (ListBucketResult)ser.Deserialize(data);
            int lastVer = 0;
            foreach (ListBucketResultContents chver in versions.Contents)
            {
                if (Links.VersionRE.IsMatch(chver.Key))
                {
                    var match = Links.VersionRE.Match(chver.Key);
                    var curver = int.Parse(Links.VersionRE.Replace(chver.Key, "${rootver}"));
                    if (keyvers == curver)
                    {
                        Console.WriteLine($"Your version is: {Links.VersionRE.Replace(chver.Key, "${ver}")}");
                        return chver.Key;
                    }
                    if (curver!=lastVer)
                    {
                        lastVer = curver; 
                        Console.WriteLine($"{listvers.Count}. {Links.VersionRE.Replace(chver.Key, "${ver}")}");
                        listvers.Add(chver.Key);
                        
                    }

                    
                }
                if (Links.LastVe.IsMatch(chver.Key))
                    break;

            }
            try
            {
                
                Console.Write("\nSend me a number: ");
                var result = int.Parse(Console.ReadLine());
                if (result<=listvers.Count)
                {
                    Console.WriteLine($"Version selected: {Links.VersionRE.Replace(listvers[result], "${ver}")}");
                    return listvers[result];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
            return "";
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