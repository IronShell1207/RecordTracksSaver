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
using System.Text.RegularExpressions;

namespace RadioData
{
    public delegate DialogResult MsgMess(string text, string topic, MessageBoxButtons buttons, MessageBoxIcon icon); //bool положительный когда требуется анимация загрузки (бегущая строка)

    public class RadioWorker
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
            RadioLists.StationsList = new List<RadioRec> { }; // пересоздаем список для того чтобы не возникало проблем с текущим его наполнением
            var CurrURL = SelHelper.ChromeDriver.Url; // переходим на сайт Record
            if (CurrURL != RadioData.Pages.MainPageUrl) SelHelper.ChromeDriver.Url = RadioData.Pages.MainPageUrl;
            var radBtns = SelHelper.ChromeDriver.FindElements(RadioData.xPathes.StationBtns);// находим кнопки всех станций
            form1.Invoke(new Action(() => form1.StatusProgressBar = false));
            form1.Invoke(new Action(() => form1.MaximumProgressBar = radBtns.Count - 1));
            for (int i = 0; i < radBtns.Count; i++) // прокликиваем все кнопки и собираем ссылки
            {
                form1.Invoke(new Action(() => form1.ProgressProgressBar = i));
                radBtns[i].Click(); // кликаем по станцици
                try
                {
                    var Frame = SelHelper.ChromeDriver.FindElement(xPathes.FramePlaylist);
                    SelHelper.ChromeDriver.SwitchTo().Frame(Frame); // Свитч на iframe
                    var TitleName = SelHelper.ChromeDriver.FindElement(RadioData.xPathes.IframePage.PageName).Text; // находим заголовок станции
                    var GetLinkFirstPage = SelHelper.ChromeDriver.FindElements(RadioData.xPathes.IframePage.PageRef);
                    if (GetLinkFirstPage.Any())
                    {
                        string link = GetLinkFirstPage.LastOrDefault().GetAttribute("href");  // находим по атрибуту ССЫЛКА
                        RadioRec radioStation = new RadioRec()
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
            JsnWorker1.CreateJsnFile(RadioLists.StationsList, SetStatic.JsonRecordPath);

        }
        public void LoadTracks(int index, int count)
        {
            form1.Invoke(new Action(() => form1.StatusProgressBar = true));
            form1.Invoke(new Action(() => form1.ProgressProgressBar = 0));
            SelHelper.ChromeDriver.Navigate().GoToUrl(RadioLists.StationsList[index].LinkTracksList);
            List<Track> songs = new List<Track> { };

            var AllTracks = SelHelper.ChromeDriver.FindElements(xPathes.TrTdList);
            int iTracksCount = count != 0 && count <= AllTracks.Count ? count : AllTracks.Count;
            form1.Invoke(new Action(() => form1.StatusProgressBar = false));
            Thread.Sleep(1150);
            form1.Invoke(new Action(() => form1.MaximumProgressBar = iTracksCount - 1));
            for (int ix = 2; ix < iTracksCount; ix++)
            {
                form1.Invoke(new Action(() => form1.ProgressProgressBar = ix));
                try
                {
                    SelHelper.ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                    var isYoutubeTrack = AllTracks[ix].FindElement(By.XPath($"(//tbody/tr)[{ix}]//div[@class=\"youtubeimg\"]"));
                    var name = AllTracks[ix].FindElement(By.XPath($"(//tbody/tr)[{ix}]//div[@class=\"artist\"]")).Text;  
                    var linkYt = isYoutubeTrack.GetAttribute("onclick").Replace("parent.get_youtube(", "").Replace(");", "");
                    linkYt = JsnWorker1.ReadJsnYoutubeLink(linkYt);
                    for (int i = 0; i < Converting.SymToChange.Length; i++)
                    {
                        name = name.Replace(Converting.SymToChange[i], Converting.SymEnd[i]); // не много не то находит. поменять xpath
                    }
                    // if (!SetStatic.settings.IsSkipRusAuto && !IsRussian(name)) не работает как нужно
                    songs.Add(new Track { Name = name, YoutubeLink = linkYt });
                }
                catch (NoSuchElementException ex)
                { }
                SelHelper.ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            }
            if (songs.Count > 0)
            {
                RadioLists.StationsList[index].DateLoadedTracks = DateTime.Now.ToLongDateString();
                RadioLists.StationsList[index].TracksList = songs;
                JsnWorker1.CreateJsnFile(RadioLists.StationsList, SetStatic.JsonRecordPath);
            }
        }
        public void LetterFormatTransfo()
        {
            for (int i = 0; i < RadioLists.StationsList.Count; i++)
            {
                if (!SetStatic.settings.IsBigSymsInRadios)
                    RadioLists.StationsList[i].Name = FirstLetterToUpAndOtherToLow(RadioLists.StationsList[i].Name);
                else if (SetStatic.settings.IsBigSymsInRadios)
                    RadioLists.StationsList[i].Name = RadioLists.StationsList[i].Name.ToUpper();
            }
            //  JsnWorker1.CreateJsnFile(RadioLists.StationsList, SetStatic.JsonRecordPath);
            //  JsnWorker1.CreateJsnFile(SetStatic.settings, SetStatic.JsonSettingsPath);

        }
        private string FirstLetterToUpAndOtherToLow(string str)
        {
            str = str.ToLower();
            return Char.ToUpper(str[0]) + str.Remove(0, 1);
        }
        public void RussRemover(int stationIndex, MsgMess msgMess)
        {
            if (DialogResult.Yes == msgMess("Эта функция удаляет треки, в названии которых есть русские символы. Не удаляются русские треки, указанные на английском. Продолжить?", "Внимание. Функция только для русофобов!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                int count = 0;
                //var station = ReturnStationIndex();
                var tracks = RadioLists.StationsList[stationIndex].TracksList;
                for (int i = 0; i < tracks.Count; i++)
                {
                    if (IsRussian(tracks[i].Name)) // Выборка киррилических символов.
                    {
                        RadioLists.StationsList[stationIndex].TracksList.RemoveAt(i);
                        count++;
                    }
                }
                JsnWorker1.CreateJsnFile(RadioLists.StationsList, SetStatic.JsonRecordPath);
                msgMess($"Русских треков удалено: {count}. Очистка произведена успешно!", "Record cleaner", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool IsRussian(string track)
        {
            if (Regex.IsMatch(track, @"\p{IsCyrillic}"))
                return true;
            return false;
        }
    }
}
