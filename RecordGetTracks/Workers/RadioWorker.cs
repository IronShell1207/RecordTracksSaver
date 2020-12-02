using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecordGetTracks;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.Windows.Threading;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace RadioData
{
    // public delegate void ProgressStatus(int value, int max, bool isMarquee); //bool положительный когда требуется анимация загрузки (бегущая строка)
    class RadioWorker
    {
        Form1 form1;
        public RadioWorker(object form)
        {
            form1 = form as Form1;
        }
        public void CollectLinks() // первоначальный сбор станций и создание json списка БЕЗ СТАНЦИЙ и БЕЗ FAVORITE
        {
            form1.Invoke(new Action(() => form1.StatusProgressBar = true));
            form1.Invoke(new Action(() => form1.ProgressProgressBar = 0));
            RadioLists.StationsList = new List<RadioStation> { }; // пересоздаем список для того чтобы не возникало проблем с текущим его наполнением
            var CurrURL = SelHelper.ChromeDriver.Url; // переходим на сайт Record
            if (CurrURL != RadioData.Pages.MainPageUrl) SelHelper.ChromeDriver.Url = RadioData.Pages.MainPageUrl; 
            var radBtns = SelHelper.ChromeDriver.FindElements(RadioData.xPathes.StationBtns);// находим кнопки всех станций
            form1.Invoke(new Action(() => form1.StatusProgressBar = false));
            form1.Invoke(new Action(() => form1.MaximumProgressBar = radBtns.Count - 1));
            for (int i = 0; i < radBtns.Count; i++) // прокликиваем все кнопки и собираем ссылки
            {
                form1.Invoke(new Action(() => form1.ProgressProgressBar=i));
                radBtns[i].Click(); // кликаем по станцици
                try
                {
                    var Frame = SelHelper.ChromeDriver.FindElement(xPathes.FramePlaylist);
                    SelHelper.ChromeDriver.SwitchTo().Frame(Frame) ; // Свитч на iframe
                    var TitleName = SelHelper.ChromeDriver.FindElement(RadioData.xPathes.IframePage.PageName).Text; // находим заголовок станции
                    var GetLinkFirstPage = SelHelper.ChromeDriver.FindElements(RadioData.xPathes.IframePage.PageRef);
                    if (GetLinkFirstPage.Any())
                    {
                        string link = GetLinkFirstPage.LastOrDefault().GetAttribute("href");  // находим по атрибуту ССЫЛКА
                        RadioData.RadioStation radioStation = new RadioData.RadioStation()
                        {
                            Name = TitleName, // присваеваем элементу списка радиостанций имя и ссылку
                            LinkTracksList = link
                        };
                        RadioLists.StationsList.Add(radioStation); // и добавляем в список
                    }
                    SelHelper.ChromeDriver.SwitchTo().DefaultContent();
                }
                catch (NoSuchElementException ex) { SelHelper.ChromeDriver.SwitchTo().DefaultContent(); }
                
            }
            JsnWorker1.CreateJsnFile(RadioLists.StationsList, SettingsStatic.JsonRecordPath);

        }
        public void LoadTracks(int index, int count)
        {
            form1.Invoke(new Action(() => form1.StatusProgressBar = true));
            form1.Invoke(new Action(() => form1.ProgressProgressBar = 0));
            SelHelper.ChromeDriver.Navigate().GoToUrl(RadioLists.StationsList[index].LinkTracksList);
            List<string> songs = new List<string> { };
            try
            {
                var AllTracks = SelHelper.ChromeDriver.FindElements(xPathes.TrackXPath);
                int iTracksCount = count != 0 && count <= AllTracks.Count ? count : AllTracks.Count;
                form1.Invoke(new Action(() => form1.StatusProgressBar = false));
                Thread.Sleep(1150);
                form1.Invoke(new Action(() => form1.MaximumProgressBar=iTracksCount-1));
                for (int ix = 0; ix < iTracksCount; ix++)
                {
                    form1.Invoke(new Action(() => form1.ProgressProgressBar = ix));

                    var name = AllTracks[ix].Text;
                    for (int i = 0; i < Converting.SymToChange.Length; i++)
                    {
                        name = name.Replace(Converting.SymToChange[i], Converting.SymEnd[i]); // не много не то находит. поменять xpath
                    }
                    songs.Add(name);
                }
                if (songs.Count > 0)
                {
                    RadioLists.StationsList[index].DateLoadedTracks = DateTime.Now.ToLongDateString();
                    RadioLists.StationsList[index].TracksList = songs;
                }
                JsnWorker1.CreateJsnFile(RadioLists.StationsList, SettingsStatic.JsonRecordPath);
            }
            catch (NoSuchElementException ex)
            { }
        }
    }
}
