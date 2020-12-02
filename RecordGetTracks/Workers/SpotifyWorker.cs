using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpotifyData;

namespace RecordGetTracks
{
    class SpotifyWorker
    {
        Form1 form1;
        public SpotifyWorker(object form) => form1 = form as Form1;
        public void AuthSpoti(string usrName, string usrPass) //главная аунтификация в spotify 
        {
            SelHelper.ChromeDriver.Navigate().GoToUrl(SpotifyPages.MainPageUrl); // переходим на страницу spotify
            SelHelper.ClickLink(SpotifyPatches.loginPageButton); // клик на ссылку Log in
            if (SelHelper.ChromeDriver.Url != SpotifyPages.MainPageUrl)
            {
                SelHelper.SendKeys(SpotifyPatches.LoginField, true, new[] { usrName });
                SelHelper.SendKeys(SpotifyPatches.PassField, true, new[] { usrPass });
                var urlLogin = SelHelper.ChromeDriver.Url;
                SelHelper.ClickLink(SpotifyPatches.LogInButt);
                SpotifyData.SpotifyPages.IsAuthorized = true;
                Thread.Sleep(1000);
                if (SelHelper.ChromeDriver.Url == urlLogin)
                {
#if !DEBUG
                 if (SeleniumHelper.FindErrors(SpotifyPatches.AllertLoginOrPassWrong) != null)
                             SpotifyData.SpotifyPages.IsAuthorized = false;
#endif
                }
            }

        }
        public void GetPlaylists() // Получает список плейлистов расположенный в левом меню после авторизации
        {
            var wait = new WebDriverWait(SelHelper.ChromeDriver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(SpotifyPatches.Playlists));
            var Playlists = SelHelper.ChromeDriver.FindElements(SpotifyPatches.Playlists);
            SetStatic.settings.SpotiPlaylists = new List<string> { };
            foreach (IWebElement el in Playlists)
                SetStatic.settings.SpotiPlaylists.Add(el.Text);
            JsnWorker1.CreateJsnFile(SetStatic.settings, SetStatic.JsonSettingsPath);
        }
        public void AddPlaylistSpotify(string name) // Добавляет новый плейлист (по-умолчанию имя дефолтное) и меняет имя на заданное
        {
            SelHelper.ClickLink(SpotifyPatches.NewPlstBtn);
            var buttons = SelHelper.ChromeDriver.FindElements(SpotifyPatches.NewPlstBtn);
            foreach (IWebElement el in buttons)
            {
                if (el.GetAttribute("shape-rendering") == "crispEdges")
                    el.Click();
            }
            SelHelper.ClickLink(SpotifyPatches.NewPlstDefName); //жмем правой кнопкой по нему
            //SeleniumHelper.ClickLink(SpotifyPatches.NewPlstEditD); // жмем изменить название
            SelHelper.SendKeys(SpotifyPatches.NewPlstFieldName, true, new[] { name });
            SelHelper.ClickLink(SpotifyPatches.NewPlstSaveName);
        }
        public void ImportTracksToPlaylist(string PlaylistName, List<string> tracks)
        {
            form1.Invoke(new Action(() => { form1.ProgressProgressBar = 0; form1.MaximumProgressBar = tracks.Count; }));
            for (int trackId = 0; trackId < tracks.Count; trackId++)
            {
                if (SpotifyPages.BreakSpotify)
                {
                    SpotifyPages.BreakSpotify = false;
                    break;
                }
                form1.Invoke(new Action(() =>
                {
                    form1.labelSpotiCurrName.Text = tracks[trackId];
                    form1.labelCurrProcess.Text = $"Выполняется: {trackId+1}/{tracks.Count}";
                    form1.ProgressProgressBar = trackId;
                }));
                string urlSong = SpotifyPages.SearchPageUrl + tracks[trackId].Replace("-", "").Replace(" ", "%20");
                SelHelper.ChromeDriver.Navigate().GoToUrl(urlSong);
                try
                {
                    SelHelper.ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
                    SelHelper.ChromeDriver.FindElement(By.XPath(String.Format(SpotifyPatches.SongMenu, 1)));
                    AddTrackToPls(PlaylistName, 1);
                }
                catch (NoSuchElementException ex)
                {
                    if (ex.Message.Contains("(//div[@data-testid='tracklist-row'])[1]") && !form1.toggleAutoSkip.Checked)
                    {
                        var indexsong = form1.toggleAutoSelect.Checked ? 1 : LocateTrack(tracks[trackId]);
                        if (indexsong > 0)
                            AddTrackToPls(PlaylistName, indexsong);
                    }
                }
                Thread.Sleep(250);
            }
            SelHelper.ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        private void AddTrackToPls(string PlaylistName, int indexSong)
        {
            SelHelper.ContextClick(By.XPath(String.Format(SpotifyPatches.SongMenu, indexSong)));
            SelHelper.ClickLink(SpotifyPatches.AddToPlBtn);
            var playlistsNames = SelHelper.ChromeDriver.FindElements(By.XPath(SpotifyPatches.PlaylstsList));
            foreach (IWebElement plEL in playlistsNames)
            {
                var name = plEL.Text;
                if (name == PlaylistName)
                {
                    plEL.Click();
                    SelHelper.FindErrors(SpotifyPatches.SuccessedAdding);
                    break;
                }
            }
        }
        private int LocateTrack(string trackName)
        {
            var onlyArtist = trackName.Split('-');
            string onlyArt = "";
            for (int iz = 0; iz < onlyArtist.Length - 1; iz++)
            {
                onlyArt += onlyArtist[iz] + (onlyArtist.Length - 2 != iz? "-" : "");
            }
        var onlyName = trackName.Split('-').LastOrDefault();
        var onlyNameWithoutAdds = onlyName.Split('(').First();
        List<string> songNamesSplits = new List<string> { onlyArt, onlyName, onlyNameWithoutAdds };
            foreach (string sName in songNamesSplits)
            {
                SelHelper.ChromeDriver.Navigate().GoToUrl(SpotifyPages.SearchPageUrl + sName.Replace(" ", "%20") + "/tracks");
                var songsList = SelHelper.ChromeDriver.FindElements(SpotifyPatches.SongsRow).ToList();
        List<string> songs = new List<string> { };
        int count = (songsList.Count > 20) ? 20 : songsList.Count;
                for (int ix = 0; ix<count; ix++)
                    songs.Add(songsList[ix].Text);
                if (songs.Count != 0)
                {
                    using (var formx = new SongChoose(songs, trackName))
                    {
                        var result = formx.ShowDialog();
                        if (result == DialogResult.OK)
                            return formx.ReturnValue1;
                        else if (result == DialogResult.No)
                            continue;
                        else
                            return 0;
                    }
}
            }
            return 0;

        }

    }
}
