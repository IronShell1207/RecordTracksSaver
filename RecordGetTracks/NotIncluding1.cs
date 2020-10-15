using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordGetTracks
{
    class NotIncluding1
    {
        IWebDriver ChromeDriver;
        List<IWebElement> ListStations;
        public NotIncluding1(IWebDriver chromeDriver, List<IWebElement> listStations)
        {
            ChromeDriver = chromeDriver;
            ListStations = listStations;
        }
        void getStationsNames()
        {
            for (int i = 0; i < ListStations.Count; i++)
            {
                ListStations[i].Click();
                ChromeDriver.SwitchTo().Frame("playlist_frame");
                var stationName = ChromeDriver.FindElement(By.ClassName("ntitle2")).Text;
                // listStationss.Add(stationName);
                ChromeDriver.SwitchTo().DefaultContent();

            }
            // File.AppendAllLines("stationss.txt", listStationss);
        }
        void FormatStationsList() //форматирует список станций
        {
            var files = File.ReadAllLines("stationss.txt");
            List<string> lines = new List<string> { };
            foreach (string line in files)
            {
                var liss = line.ToLower();
                liss = FirstUpper(liss);
                lines.Add("\"" + liss + "\",");
            }
            File.WriteAllLines("stationss.txt", lines);
        }
        void SaverStations()
        {
            //string urlStation = "http://air.radiorecord.ru:8102/{0}_{1}";

            List<string> airUrls = new List<string> { };
            // foreach (string staton in listBox1.Items)
            // {
            //     File.AppendAllText("stations.txt", String.Format(urlStation, staton.Substring(staton.IndexOf(".") + 2), 320)+"\r\n");
            // }

        }
        public static string FirstUpper(string str) // делает первую букву большой
        {
            return str.Substring(0, 1).ToUpper() + (str.Length > 1 ? str.Substring(1) : "");
        }
        //listStNames.Find(station.GetAttribute("src"))
        //{
        //   listBox.Invoke(new Action(() => listBox.Items.Add(++i + ". " + )));
        //}
        /* foreach (Station st in listStNames)// МЕДЛЕННО ОЧЕНЬ
         {
             string stLin = station.GetAttribute("src");
             if (st.Link == stLin)
                 listBox.Invoke(new Action(() => listBox.Items.Add(++i + ". " + st.Name)));
         }*/
        // msgCall(stationByName.GetAttribute("src"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        /*

        var listStation = StationsList();//.ToDictionary(x => x.Link, s => s.Name);
        // Найти станциЮ по имени и вернуть ее WebElement для дальнейшей обработки
        foreach (IWebElement element in listStations)
        {
            var staton = element.GetAttribute("src");
            if (listStation.ContainsKey(staton))
            {
                element.Click();      
                }
            }}*/
        #region spotifyOLD
        /*
          async Task CreatePlay()
        {
            await SpotifyCL();
            var plsts = await Spot.Playlists.CurrentUsers();
        }
          private void buttonOk_Click(object sender, EventArgs e)
          {
              string namePL = listBox.SelectedItem.ToString();
              var ThreadNewSpot = new Thread(() =>
              {
                  SpotifyMakePlaylist(trackss, namePL);
              }){ IsBackground = true };
              ThreadNewSpot.Start();

          }
          private SpotifyClient Spot;
          public async Task SpotifyCL()
          {
              if (Spot == null)
              {
                  var config = SpotifyClientConfig.CreateDefault();
                  var request = new ClientCredentialsRequest("537cb3d63ba847fa93c46fddd3e0e7ba", "a4fef10b36e343a69ceb432fec7935bd");
                  var response = await new OAuthClient(config).RequestToken(request);
                  Spot = new SpotifyClient(config.WithToken(response.AccessToken));
              }
          }
          List<FullTrack> tracksList = new List<FullTrack> { };
          async Task SpotifyGetTrack(string songname)
          {
              await SpotifyCL();

              SearchRequest searchRequest = new SearchRequest(SearchRequest.Types.Track, songname.Replace("/"," "));
              var track = await Spot.Search.Item(searchRequest);
              var trackk = track.Tracks.Items[0];
              tracksList.Add(trackk);
          }
          async Task SpotifyGetTrack1()
          {
              await SpotifyCL();

              SearchRequest searchRequest = new SearchRequest(SearchRequest.Types.Track, "toto africa");
              var track = await Spot.Search.Item(searchRequest);
              var trackk = track.Tracks.Items[0];
              tracksList.Add(trackk);
              CreatePlay();
          }
          async Task SpotifyMakePlaylist(List<string> Playlist, string plName)
          {
              foreach (string song in Playlist)
              {
                  await SpotifyGetTrack(song);
              }
              PlaylistCreateRequest playlistCreateRequest = new PlaylistCreateRequest(plName);
              playlistCreateRequest.BuildBodyParams();
              playlistCreateRequest.BuildQueryParams();


          }
         */
        #endregion
    }
}
