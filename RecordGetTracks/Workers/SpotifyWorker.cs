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
        public static bool IsAuthorized { get; set; }
        public static void AuthSpoti(string usrName, string usrPass)
        {
            SelHelper.ChromeDriver.Navigate().GoToUrl(SpotifyPages.MainPageUrl); // переходим на страницу spotify
            SelHelper.ClickLink(SpotifyPatches.loginPageButton); // клик на ссылку Log in
            if (SelHelper.ChromeDriver.Url != SpotifyPages.MainPageUrl)
            {
                SelHelper.SendKeys(SpotifyPatches.LoginField, true, new[] { usrName });
                SelHelper.SendKeys(SpotifyPatches.PassField, true, new[] { usrPass });
                var urlLogin = SelHelper.ChromeDriver.Url;
                SelHelper.ClickLink(SpotifyPatches.LogInButt);

                Thread.Sleep(1000);
                if (SelHelper.ChromeDriver.Url == urlLogin)
                {
#if !DEBUG
                 if (SeleniumHelper.FindErrors(SpotifyPatches.AllertLoginOrPassWrong) != null)

#endif
                }
            }
            IsAuthorized = true;
        }
        public static void GetPlaylists()
        {
            SelHelper.ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            var wait = new WebDriverWait(SelHelper.ChromeDriver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(SpotifyPatches.Playlists));
            var Playlists = SelHelper.ChromeDriver.FindElements(SpotifyPatches.Playlists);
            SettingsStatic.settings.SpotiPlaylists = new List<string> { };
            foreach (IWebElement el in Playlists)
                SettingsStatic.settings.SpotiPlaylists.Add(el.Text);
            JsnWorker1.CreateJsnFile(SettingsStatic.settings, SettingsStatic.JsonSettingsPath);
            SelHelper.ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public static void AddPlaylistSpotify(string name)
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
        public static void ImportTracksToPlaylist(string PlaylistName, List<string> tracks, object form)
        {
            Form1 ff = form as Form1;
            ff.ProgressProgressBar = 0;
            for (int trackId = 0; trackId < tracks.Count; trackId++)
            {
                ff.MaximumProgressBar = tracks.Count;
                ff.ProgressProgressBar = trackId;
                string urlSong = SpotifyPages.SearchPageUrl + tracks[trackId].Replace("-", "").Replace(" ", "%20");
                SelHelper.ChromeDriver.Navigate().GoToUrl(urlSong);
                try
                {
                    SelHelper.ChromeDriver.FindElement(By.XPath(String.Format(SpotifyPatches.SongMenu, 1)));
                    AddTrackToPls(PlaylistName, 1);
                }
                catch (NoSuchElementException ex)
                {
                    if (ex.Message.Contains("(//div[@data-testid='tracklist-row'])[1]"))
                    {
                        var indexsong = LocateTrack(tracks[trackId]);
                        if (indexsong > 0)
                            AddTrackToPls(PlaylistName, indexsong);
                    }
                }
                Thread.Sleep(250);
            }
        }
        private static void AddTrackToPls(string PlaylistName, int indexSong)
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
        private static int LocateTrack(string trackName)
        {
            var onlyArtist = trackName.Split('-').FirstOrDefault();
            var onlyName = trackName.Split('-').LastOrDefault();
            var onlyNameWithoutAdds = onlyName.Split('(').First();
            List<string> songNamesSplits = new List<string> { onlyArtist, onlyName, onlyNameWithoutAdds };
            foreach (string sName in songNamesSplits)
            {
                SelHelper.ChromeDriver.Navigate().GoToUrl(SpotifyPages.SearchPageUrl + sName.Replace(" ", "%20") + "/tracks");
                var songsList = SelHelper.ChromeDriver.FindElements(SpotifyPatches.SongsRow).ToList();
                List<string> songs = new List<string> { };
                int count = (songsList.Count > 20) ? 20 : songsList.Count;
                for (int ix = 0; ix < count; ix++)
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
