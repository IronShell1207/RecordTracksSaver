using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecordGetTracks
{
    public delegate DialogResult messageCaller(string message, string topic, MessageBoxButtons buttNS, MessageBoxIcon icon);
    public class GlVars
    {
        /*   #region private
           private static JsonWorker1 jsnWrk = new JsonWorker1();
           private static List<Station> stationsList;
           private static List<IWebElement> recordStations;
           private static List<Station> favList;
           private static List<string> songList;
           private static string mainDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\RecordToSpoti\";
           #endregion
           public static string favFile { get { return DirF + "FavoriteStations.json"; } }
           public static string namesFile { get { return DirF + "StationNames.json"; } }
           public static string[] SymNAll = new string[] { "—", "—", "/", "rmx" };
           public static string[] SymAlld = new string[] { "-", "-", " ", "Remix" };
           public static string DirF
           {
               get
               {
                   if (!Directory.Exists(mainDir))
                       Directory.CreateDirectory(mainDir);
                   return mainDir;
               }
           }//mainDir
           public static List<Station> StationsList
           {
               get
               {
                   if (stationsList == null)
                   {
                       stationsList = new List<Station> { };
                   }
                   return stationsList;
               }
               set
               {
                   stationsList = value;
               }
           }
           public static List<IWebElement> RecordGetStations
           {
               get
               {
                   if (recordStations == null)
                   {
                      // SeleniumHelper.ChromeDriver.Url = RecordPage.MainPageUrl;
                       Thread.Sleep(2000);
                       recordStations = SeleniumHelper.ChromeDriver.FindElements(By.XPath("//div[@class='icon']//img")).ToList();
                   }
                   return recordStations;
               }
               set
               {
                   recordStations = value;
               }
           }
           public static List<Station> FavList
           {
               get
               {
                   if (favList == null)
                       if (File.Exists(favFile))
                           favList = jsnWrk.ReadJsnFile(favFile);
                       else favList = new List<Station> { };
                   return favList;
               }
               set
               {
                   favList = value;
               }
           }
           public static List<string> SongsList
           {
               get
               {
                   if (songList == null)
                       songList = new List<string>();
                   return songList;
               }
               set
               {
                   songList = value;
             }
           }*/
    }
}
