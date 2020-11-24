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

namespace RadioData
{
    // public delegate void ProgressStatus(int value, int max, bool isMarquee); //bool положительный когда требуется анимация загрузки (бегущая строка)
    class RadioWorker
    {
        public void CollectLinks() // первоначальный сбор станций и создание json списка БЕЗ СТАНЦИЙ и БЕЗ FAVORITE
        {
            RadioLists.StationsList = new List<RadioStation> { }; // пересоздаем список для того чтобы не возникало проблем с текущим его наполнением
            var CurrURL = SeleniumHelper.ChromeDriver.Url; // переходим на сайт Record
            if (CurrURL != RadioData.Pages.MainPageUrl)
                SeleniumHelper.ChromeDriver.Url = RadioData.Pages.MainPageUrl;
            var radBtns = SeleniumHelper.ChromeDriver.FindElements(RadioData.xPathes.StationBtns);// находим кнопки всех станций
            for (int i = 0; i < radBtns.Count; i++) // прокликиваем все кнопки и собираем ссылки
            {
                radBtns[i].Click(); // кликаем по станцици
                try
                {
                    SeleniumHelper.ChromeDriver.SwitchTo().Frame(RadioData.xPathes.TracksFrameN); // Свитч на iframe
                    var TitleName = SeleniumHelper.ChromeDriver.FindElement(RadioData.xPathes.IframePage.PageName).Text; // находим заголовок станции

                    var GetLinkFirstPage = SeleniumHelper.ChromeDriver.FindElements(RadioData.xPathes.IframePage.PageRef);
                    if (GetLinkFirstPage.Any())
                    {
                        string link = GetLinkFirstPage.LastOrDefault().GetAttribute("href");  // находим по атрибуту ССЫЛКА
                        RadioData.RadioStation radioStation = new RadioData.RadioStation()
                        {
                            Name = TitleName, // присваеваем элементу списка радиостанций имя и ссылку
                            LinkTracksList = link
                        };
                        RadioData.RadioLists.StationsList.Add(radioStation); // и добавляем в список
                    }
                }
                catch (NoSuchElementException ex) { }
                SeleniumHelper.ChromeDriver.SwitchTo().DefaultContent();
            }
            JsonWorker1.CreateJsnFile(RadioData.RadioLists.StationsList, Names.JsonRadioList);
        }
        public void LoadTracks(int index, int count)
        {
            SeleniumHelper.ChromeDriver.Navigate().GoToUrl(RadioLists.StationsList[index].LinkTracksList);
            List<string> songs = new List<string> { };
            try
            {
                var AllTracks = SeleniumHelper.ChromeDriver.FindElements(xPathes.IframePage.TrackXPath);
                int iTracksCount = count != 0 && count<=AllTracks.Count ? count : AllTracks.Count;
                for (int ix = 0; ix<iTracksCount; ix++)
                {
                    var name = AllTracks[ix].Text;
                    for (int i = 0; i < Converting.SymToChange.Length; i++)
                    {
                        name.Replace(Converting.SymToChange[i], Converting.SymEnd[i]); // не много не то находит. поменять xpath
                    }
                    songs.Add(name);
                }
            }
            catch (NoSuchElementException ex)
            { }
            if (songs.Count > 0)
            {
                RadioLists.StationsList[index].TracksList = songs;
            }
        }
    }
}
