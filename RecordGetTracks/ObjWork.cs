using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
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
    class ObjWork
    {
        //private JsonWorker1 jsnWrk = new JsonWorker1();
       
        ////public int ListCurrIndex
        ////{
        ////    get
        ////    {
        ////        int l = 0;
        ////        lb.Invoke(new Action(() => l = lb.SelectedIndex));
        ////        return l;
        ////    }
        ////}
        //public List<Station> RadioListCreator(messageCaller caller)
        //{
        //    try
        //    {
        //        GlVars.StationsList.Clear();
        //        var SiteList = GlVars.RecordGetStations;
        //        var RadioNames = jsnWrk.RadioNamesList(caller, SeleniumHelper.ChromeDriver, SiteList).ToDictionary(c => c.Link, s => s.Name);
        //        for (int c = 0; c < SiteList.Count; c++)
        //        {
        //            var getLink = SiteList[c].GetAttribute("src");
        //            string name;
        //            if (RadioNames.ContainsKey(getLink))
        //                name = RadioNames.Where(x => x.Key == getLink).FirstOrDefault().Value;
        //            else
        //                name = RecordPage.NameFromLink(getLink);
        //            //ListAdder(c + ". " + name);
        //            GlVars.StationsList.Add(new Station { Link = getLink, Name = name });
        //        }
        //    }
        //    catch (WebDriverException ex)
        //    {
        //        BrowserCrash(ex.Message, caller);
        //    }            
        //    return GlVars.StationsList;
        //}
        ////public bool GetTracksPls(bool ifFoolList, int selectedInd)
        ////{
        ////    if (!ifFoolList)
        ////    {
        ////        string LinkSt = GlVars.FavList[selectedInd].Link;
        ////        var element = GlVars.RecordGetStations.Find(x => x.GetAttribute(RecordPage.LinkAttr) == LinkSt);
        ////        element.Click();
        ////    }
        ////  //  var wait = new WebDriverWait(SeleniumHelper.ChromeDriver, TimeSpan.FromSeconds(5));
        ////   // wait.Until(d => element);
        ////    SeleniumHelper.ChromeDriver.SwitchTo().Frame(RecordPage.TracksFrameN);
        ////    if (ifFoolList)
        ////        ClickLink(RecordPage.TrackAllXPath);
        ////    var Tracks = SeleniumHelper.ChromeDriver.FindElements(RecordPage.TrackXPath);
        ////    var TracksList = new List<string> { };
        ////    if (Tracks.Any())
        ////        foreach (IWebElement wel in Tracks)
        ////        {
        ////            var trackName = wel.Text;
        ////            for (int i1 = 0; i1 < GlVars.SymNAll.Length; i1++)
        ////                trackName = trackName.Replace(GlVars.SymNAll[i1], GlVars.SymAlld[i1]);
        ////            GlVars.SongsList.Add(trackName);
        ////        }
        ////    SeleniumHelper.ChromeDriver.SwitchTo().DefaultContent();
        ////    return true;  
        ////}

        //public void BrowserCrash(string msg, messageCaller caller)
        //{
        //    caller(msg, "Браузер утерян", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    SeleniumHelper.ChromeDriver.Quit();
        //    SeleniumHelper.ChromeDriver = null;
        //}
        //public static List<string> LoadTracks(List<Station> stationsList, int index, messageCaller caller)
        //{
        //    var trlist = new List<string> { };
        //    try
        //    {
        //        var LinkSt = stationsList[index].Link;
        //        GlVars.RecordGetStations.Find(x => x.GetAttribute(RecordPage.LinkAttr) == LinkSt).Click();
        //        SeleniumHelper.ChromeDriver.SwitchTo().Frame(RecordPage.TracksFrameN);
        //        var TracksNames = SeleniumHelper.ChromeDriver.FindElements(RecordPage.TrackXPath);
        //        foreach (IWebElement element in TracksNames)
        //        {
        //            string trackName = element.Text;
        //            for (int i = 0; i < GlVars.SymAlld.Length; i++)
        //                trackName = trackName.Replace(GlVars.SymNAll[i], GlVars.SymAlld[i]);
        //            trlist.Add(trackName);
        //        }
        //        SeleniumHelper.ChromeDriver.SwitchTo().DefaultContent();
        //        return trlist;
        //    }
        //    catch (WebDriverException ex)
        //    {
        //        //BrowserCrash(ex.Message, caller);
        //        return null;
        //    }
        //}
        //public List<string> GetAllPlstsLinks() // Делает ссылки на полные плейлисты и возвращает список ссылок
        //{
        //    List<string> links = new List<string> { };
        //    var linksd = SeleniumHelper.ChromeDriver.FindElements(By.ClassName("icon"));
        //    foreach (IWebElement els in linksd)
        //        els.Click();
        //  //  GlVars.RecordGetStations.Find(x => x.GetAttribute(RecordPage.LinkAttr) == LinkSt).Click();
        //   // SeleniumHelper.ChromeDriver.SwitchTo().Frame(RecordPage.TracksFrameN);
        //    return links;
        //}
        //bool ClickLink(By by)
        //{
        //    var wait = new WebDriverWait(SeleniumHelper.ChromeDriver, TimeSpan.FromSeconds(5));
        //    try
        //    {
        //        wait.Until(d => d.FindElement(by));
        //        SeleniumHelper.ChromeDriver.FindElement(by).Click();
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

    }
}
