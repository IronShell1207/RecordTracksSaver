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
        public static bool IsAuthorized = false;
        public static bool AuthSpoti(string usrName, string usrPass)
        {
            SeleniumHelper.ChromeDriver.Navigate().GoToUrl(SpotifyPages.MainPageUrl); // переходим на страницу spotify
            SeleniumHelper.ClickLink(SpotifyPatches.loginPageButton); // клик на ссылку Log in
            if (SeleniumHelper.ChromeDriver.Url != SpotifyPages.MainPageUrl)
            {
                SeleniumHelper.SendKeys(SpotifyPatches.LoginField, true, new[] { usrName });
                SeleniumHelper.SendKeys(SpotifyPatches.PassField, true, new[] { usrPass });
                SeleniumHelper.ClickLink(SpotifyPatches.LogInButt);
#if !DEBUG
                if (SeleniumHelper.FindErrors(SpotifyPatches.AllertLoginOrPassWrong) != null)
                    return false;
#endif
            }
            return true;
        }
        public static void GetPlaylists()
        {
            SeleniumHelper.ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            var wait = new WebDriverWait(SeleniumHelper.ChromeDriver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(SpotifyPatches.Playlists));
            var Playlists = SeleniumHelper.ChromeDriver.FindElements(SpotifyPatches.Playlists);
            SettingsStatic.settings.SpotiPlaylists = new List<string> { };
            foreach (IWebElement el in Playlists)
                SettingsStatic.settings.SpotiPlaylists.Add(el.Text);
            JsnWorker1.CreateJsnFile(SettingsStatic.settings, SettingsStatic.JsonSettingsPath);
            SeleniumHelper.ChromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public static void AddPlaylistSpotify(string name)
        {
            SeleniumHelper.ClickLink(SpotifyPatches.NewPlstBtn);
            var buttons = SeleniumHelper.ChromeDriver.FindElements(SpotifyPatches.NewPlstBtn);
            foreach (IWebElement el in buttons)
            {
                if (el.GetAttribute("shape-rendering") == "crispEdges")
                    el.Click();
            }
            SeleniumHelper.ClickLink(SpotifyPatches.NewPlstDefName); //жмем правой кнопкой по нему
            //SeleniumHelper.ClickLink(SpotifyPatches.NewPlstEditD); // жмем изменить название
            SeleniumHelper.SendKeys(SpotifyPatches.NewPlstFieldName, true, new[] { name });
            SeleniumHelper.ClickLink(SpotifyPatches.NewPlstSaveName);
        }
        public static void ImportTracksToPlaylist(string PlaylistName, List<string> tracks)
        {
            for (int trackId = 0; trackId < tracks.Count; trackId++)
            {
                string urlSong = SpotifyPages.SearchPageUrl + tracks[trackId].Replace("-", "").Replace(" ", "%20");
                SeleniumHelper.ChromeDriver.Navigate().GoToUrl(urlSong); 
                try
                {
                    SeleniumHelper.ChromeDriver.FindElement(By.XPath(String.Format(SpotifyPatches.SongMenu,1)));
                    AddTrackToPls(PlaylistName,1);
                }
                catch (NoSuchElementException ex)
                {
                    if (ex.Message.Contains("(//div[@data-testid='tracklist-row'])[1]"))
                    {
                        var indexsong = LocateTrack(tracks[trackId]);
                        if (indexsong>0)
                            AddTrackToPls(PlaylistName,indexsong);
                    }
                }
                Thread.Sleep(250);
            }
        }
        private static void AddTrackToPls(string PlaylistName, int indexSong)
        {
            SeleniumHelper.ContextClick(By.XPath(String.Format(SpotifyPatches.SongMenu, indexSong)));
            SeleniumHelper.ClickLink(SpotifyPatches.AddToPlBtn);
            var playlistsNames = SeleniumHelper.ChromeDriver.FindElements(By.XPath(SpotifyPatches.PlaylstsList));
            foreach (IWebElement plEL in playlistsNames)
            {
                var name = plEL.Text;
                if (name == PlaylistName)
                {
                     plEL.Click();
                    SeleniumHelper.FindErrors(SpotifyPatches.SuccessedAdding);
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
                SeleniumHelper.SendKeys(SpotifyPatches.SeatchField, true, new[] { sName });
                Thread.Sleep(550);
                var songsList = SeleniumHelper.ChromeDriver.FindElements(SpotifyPatches.SongsRow).ToList();
                List<string> songs = new List<string> { };
                foreach (IWebElement el in songsList)
                    songs.Add(el.Text);
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
