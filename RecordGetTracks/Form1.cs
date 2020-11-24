using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using MetroFramework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Diagnostics.Eventing.Reader;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using MetroFramework.Controls;
using System.Diagnostics;
using RadioData;
using System.Windows.Threading;

namespace RecordGetTracks
{

    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private Thread StationsLoader, TracksLoader, FullTracksList, SpotifyListCreator;
        private ContextMenus ctxm;
        RadioWorker rwork;
        /* private void timerProgress_Tick(object sender, EventArgs e)
         {
             //if (Names.progressMax == Names.progressValue)
             //   timerProgress.Stop();
             progressBar.Value = Names.progressValue;
             var curValueMax = progressBar.Maximum;
             var curState = progressBar.ProgressBarStyle;
             if (Names.progressMax != curValueMax)
                 progressBar.Maximum = Names.progressMax;
             if (curState.Equals(ProgressBarStyle.Continuous) == Names.isMarqueee) // по умолчанию первое значение (текущее состояние Continuous)=true,
                                                                            //то правое тоже должно быть равно true (то есть Marquee) для изменения значения.
                                                                            // если у нас сейчас состояние Marquee (слева) то будет false и справа будет false, потому что мы меняем обратно на Continous и false = false и значение применится
                 progressBar.ProgressBarStyle = Names.isMarqueee ? ProgressBarStyle.Marquee : ProgressBarStyle.Continuous;

         }*/
        //private List<IWebElement> recordStations;
        //private List<Station> favList;
        //public List<Station> StationsList
        //{
        //    get
        //    {
        //        if (stationsList == null)
        //        {
        //            stationsList = new List<Station> { };
        //        }
        //        return stationsList;
        //    }
        //    set
        //    {
        //        stationsList = value;
        //    }
        //}
        //public List<IWebElement> RecordGetStations
        //{
        //    get
        //    {
        //        if (recordStations == null)
        //        {
        //            // ChromeDriver().Manage().Window.Position = new Point(1000, 0);
        //            SeleniumHelper.ChromeDriver.Url = "https://www.radiorecord.fm/playlist.html";
        //            Thread.Sleep(2000);
        //            recordStations = SeleniumHelper.ChromeDriver.FindElements(By.XPath("//div[@class='icon']//img")).ToList();
        //        }
        //        return recordStations;
        //    }
        //    set
        //    {
        //        recordStations = value;
        //    }
        //}
        //public List<Station> FavList
        //{
        //    get
        //    {
        //        if (favList== null)
        //        {
        //            if (File.Exists("favlist.json"))
        //            {
        //                StationsList = jsnWrk.ReadJsnFile("favlist.json");
        //                foreach (Station station in StationsList)
        //                    listBox.Items.Add(station.Name);
        //            }
        //        }
        //        return favList;
        //    }
        //    set
        //    {
        //        favList = value;
        //    }
        //}
        public Form1()
        {
            InitializeComponent();
            rwork = new RadioWorker();
            ctxm = new ContextMenus(this);
            //  Names.progressMax = progressBar.Maximum;
        }
        private void ContextMenuShower(Button btn, ContextMenuStrip ctx)
        {
            var btnloc = new Point(btn.Location.X, btn.Location.Y + btn.Size.Height);
            var pnt = new Point(Location.X, Location.Y);
            var pnlloc = panelMenu.Location;
            var fpn = new Point(btnloc.X + pnlloc .X+ pnt.X, btnloc.Y+ pnlloc.Y + pnt.Y);
            ctx.Show(fpn);
        }


        /* public IWebDriver ChromeDriver()
         {
             if (chromeDriver == null)
             {
                 var chDrSer = ChromeDriverService.CreateDefaultService(@"C:\Users\unkno\AppData\Local\Google\Chrome\Application\");
                 chDrSer.HideCommandPromptWindow = true;
                 var chrOpts = new ChromeOptions();9
                 // chrOpts.AddArguments("--window-size=1400,1000");
                 chrOpts.PageLoadStrategy = PageLoadStrategy.Normal;
                 //chromeDriver = new ChromeDriver(@"C:\Programs\chrome-win", chrOpts);
                 chromeDriver = new ChromeDriver(chDrSer, chrOpts);
                 //ChromeDriver().Manage().Window.Minimize();
             }
             return chromeDriver;
         }*/



        //   Нужна подмога. Есть два разных списка и нужно сравнить значение из первого (который я перебираю) со значением из второго списка и вывести свойство Name из второго при совпадении. Я сделал перебором еще и второго списка. А есть ли вариант обойти перебор второго списка?
        private void buttonStart_Click(object sender, EventArgs e)
        {
            var StartCreator = new Thread(() =>
            {
                listBox.Invoke(new Action(() => listBox.Items.Clear()));

                rwork.CollectLinks();
                CreateListRadios(false);
            });
            if (RadioLists.StationsList.Any() && DialogResult.Yes == msgCall("Список станций уже создан! Вы уверены что хотите полностью пересоздать список станций? Это займет какое-то время.", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                timerProgress.Start();
                StartCreator.Start();

            }
            else if (RadioLists.StationsList == null || RadioLists.StationsList.Count <= 0)
            {
                timerProgress.Start();
                StartCreator.Start();
            }
        }
        //public void CreateListRadios(List<Station> list)
        //{
        //    if (InvokeRequired) Invoke((Action)(() => listBox.Items.Clear()));
        //    else listBox.Items.Clear();
        //    foreach (Station fx in list)
        //    {
        //        if (InvokeRequired) Invoke((Action)(() => listBox.Items.Add(fx.Name)));
        //        else listBox.Items.Add(fx.Name);
        //    }
        //}
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex > -1)
            {
                if (toggleRecIsFav.Checked == false)
                    btnRecAddFav.Enabled = true;
                if (toggleRecIsFav.Checked == true)
                    btnRecRemFav.Enabled = true;
                buttongetTitle.Enabled = true;
            }
            else
            {
                buttongetTitle.Enabled = false;
                btnRecAddFav.Enabled = false;
                btnRecRemFav.Enabled = false;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox.SelectedItem);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (StationsLoader != null)
                StationsLoader.Abort();
            if (TracksLoader != null)
                TracksLoader.Abort();
            if (FullTracksList != null)
                FullTracksList.Abort();
            if (SpotifyListCreator != null)
                SpotifyListCreator.Abort();
            //if (SeleniumHelper.ChromeDriver!=null && SeleniumHelper.ChromeDriver.CurrentWindowHandle.Any())
            //    SeleniumHelper.ChromeDriver.Quit();
            var procs = Process.GetProcessesByName("chromedriver");
            if (procs.Any())
            {
                foreach (Process proc in procs)
                    proc.Kill();
            }


        }
        public void panelShoweer(MetroPanel panel)
        {
            var form = this.Size;
            // +form.Location.X + form.Location.Y
            int xx = (form.Width / 2) - (panel.Size.Width / 2);
            int yy = (form.Height / 2) - (panel.Size.Height / 2);
            panel.Location = new Point(xx, yy);
            panel.Visible = true;
            //ControlMover.ControlMover.Add((Control)panel); //textbox крашит программу
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var th = new Thread(() =>
            {
                CreateListRadios(false);
            })
            { IsBackground = true };
            th.Start();
            panelRecMain.Dock = DockStyle.Fill;
            //if (File.Exists(GlVars.favFile))
            //{
            //    toggleIsFav.Checked = true;
            //}
        }
        List<string> TracksList = new List<string> { };

        private void LoadTracks_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            TracksList.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
                btnTracksRemove.Enabled = true;
            else btnTracksRemove.Enabled = false;
        }
        public DialogResult msgCall(string text, string topic, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            // Invoke((Action)(() => { this.Focus(); }));
            return MetroMessageBox.Show(this, text, topic, buttons, icon);
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            var ind = listBox.SelectedIndex;
            var indIt = listBox.SelectedItem;
            var lls = RadioData.RadioLists.StationsList.ToArray();
            lls[ind].isFavorite = true;
            RadioData.RadioLists.StationsList.Clear();

            RadioData.RadioLists.StationsList.AddRange(lls.ToList());

            lblRecFav.Text = RadioData.RadioLists.StationsList[ind].isFavorite.ToString();
            //    GlVars.FavList.Add(jsnWrk.RadioNamesList(msgCall, SeleniumHelper.ChromeDriver, GlVars.RecordGetStations)[ind]);
            listBox.Items.RemoveAt(ind);
            listBox.Items.Insert(ind, indIt + " 💙");
            JsonWorker1.CreateJsnFile(RadioData.RadioLists.StationsList, Names.JsonRadioList);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            //GlVars.StationsList.RemoveAt(listBox.SelectedIndex);
            //listBox.Items.RemoveAt(listBox.SelectedIndex);
            //jsnWrk.CreateJsnFile(GlVars.StationsList, GlVars.favFile);
        }

        private void toggleIsFav_CheckedChanged(object sender, EventArgs e)
        {
            CreateListRadios(toggleRecIsFav.Checked);
        }
        void CreateListRadios(bool isFavorite)
        {
            listBox.Invoke(new Action(() => listBox.Items.Clear()));
            if (isFavorite)
                foreach (RadioData.RadioStation radios in RadioData.RadioLists.StationsList)
                {
                    if (radios.isFavorite) listBox.Invoke(new Action(() => listBox.Items.Add(radios.Name + " 💙")));
                }
            else if (!isFavorite)
                foreach (RadioData.RadioStation radios in RadioData.RadioLists.StationsList)
                {
                    listBox.Invoke(new Action(() => listBox.Items.Add(radios.Name + (radios.isFavorite ? " 💙" : ""))));
                }
        }

        private void metroButton3_Click_1(object sender, EventArgs e)
        {

            //    listBox1.Items.Clear();
            //    buttonAllList.Enabled = false;
            //    FullTracksList = new Thread(() =>
            //    {
            //        SeleniumHelper.ChromeDriver.SwitchTo().Frame("playlist_frame");
            //        SeleniumHelper.ChromeDriver.FindElement(By.XPath("//b[text()='Все']")).Click();
            //        var TracksNms = SeleniumHelper.ChromeDriver.FindElements(By.XPath("//div[@class='artist']"));
            //        foreach (IWebElement el in TracksNms)
            //        {
            //            var es = el.Text.Replace("/", " ");
            //            TracksList.Add(es);
            //            if (InvokeRequired) Invoke((Action)(() => listBox1.Items.Add(es)));
            //            else listBox1.Items.Add(es);

            //        }
            //        SeleniumHelper.ChromeDriver.SwitchTo().DefaultContent();

            //    });
            //    FullTracksList.Start();
        }
        void buttonMakePlaylist_Click(object sender, EventArgs e)
        {

            //if (listBox.SelectedIndex > -1)
            //    tbPlName.Text = listBox.SelectedItem.ToString();
            //panelShoweer(panelSpotify);
        }
        void Spoti(string login, string password, string PlaylistName, List<string> songs, bool IsNewPlaylist)
        {
            // if (InvokeRequired) progressBar.Invoke(new Action(() => { progressBar.ProgressBarStyle = ProgressBarStyle.Marquee; progressBar.Value = 0; }));
            // else { progressBar.ProgressBarStyle = ProgressBarStyle.Marquee; progressBar.Value = 0; }
            // Thread.Sleep(100);
            IWebDriver webDriver = SeleniumHelper.ChromeDriver;
            webDriver.Url = "https://open.spotify.com";
            var wait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(10000));
            ClickLink(By.XPath("//button[@data-testid='login-button']")); // click login button
            SendKeys(By.Id("login-username"), login); //push login 
            SendKeys(By.Id("login-password"), password); //push pass
            ClickLink(By.Id("login-button")); //click to login
            if (IsNewPlaylist)
            {
                ClickLink(By.XPath("(//button[@type='button'])[3]")); //click to New playlist
                SendKeys(By.XPath("//input[@placeholder='New Playlist']"), PlaylistName); // Send 
                ClickLink(By.XPath("//button[text()='CREATE']")); // Create playlist
            }
            //  SeleniumHelper.ChromeDriver.Url = SpotifyPages.SearchPageUrl;
            // if (InvokeRequired)
            //{
            //    Invoke((Action)(() => progressBar.ProgressBarStyle = ProgressBarStyle.Continuous));
            //    Invoke((Action)(() => progressBar.Maximum = songs.Count));
            // }
            //else
            //{
            //    progressBar.ProgressBarStyle = ProgressBarStyle.Continuous;
            //   progressBar.Maximum = songs.Count;
            //}
            int i = 0;
            foreach (string song in songs)
            {
                i = AddTrackToPlaylist(song, i);
            }
            //if (InvokeRequired) progressBar.Invoke(new Action(() => progressBar.Value = songs.Count));
            // else progressBar.Value = songs.Count;
            msgCall(String.Format("Создание плейлиста завершено.\nВсего добавлено {0}/{1} треков.", i, songs.Count), "Завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        void ClickLink(By by)
        {
            var wait = new WebDriverWait(SeleniumHelper.ChromeDriver, TimeSpan.FromMilliseconds(10000));
            var element = by;
            wait.Until(d => d.FindElement(element));
            SeleniumHelper.ChromeDriver.FindElement(element).Click();

        }
        void SendKeys(By by, string keys)
        {
            var wait = new WebDriverWait(SeleniumHelper.ChromeDriver, TimeSpan.FromMilliseconds(10000));
            var element = by;
            wait.Until(d => d.FindElement(element));
            SeleniumHelper.ChromeDriver.FindElement(element).SendKeys(keys);
        }
        int AddTrackToPlaylist(string songname, int i)
        {
            ClickLink(By.XPath("(//a[@draggable='false'])[3]"));
            SendKeys(By.XPath("//input[@data-testid='search-input']"), songname);
            //  ClickLink(By.XPath("//span[text()='See all']"));
            try
            {
                Actions actions = new Actions(SeleniumHelper.ChromeDriver);
                var songMenu = SeleniumHelper.ChromeDriver.FindElement(By.XPath("//div[@data-testid='tracklist-row']"));
                actions.ContextClick(songMenu).Perform();
                ClickLink(By.XPath("//div[text()='Add to Playlist']"));
                ClickLink(By.XPath("//div[@class='media-object']//div"));
                // if (InvokeRequired) progressBar.Invoke(new Action(() => progressBar.Value = ++i));
                // else progressBar.Value = ++i;

            }
            catch (NoSuchElementException ex)
            {
            }
            ClickLink(By.XPath("//header/div[3]/div[1]/div[1]/div[1]/button[1]"));
            return i;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //panelShoweer(panelSpotify);
        }

        private void buttonStartSpoti_Click(object sender, EventArgs e)
        {
            SpotifyWorker.AuthSpoti(tblogin.Text, tbpass.Text);
            /*if (tblogin.Text != "" && tbpass.Text != "" && tbPlName.Text != "")
            {
                SpotifyListCreator = new Thread(() => Spoti(tblogin.Text, tbpass.Text, tbPlName.Text, TracksList, metroCheckBox2.Checked)) { IsBackground = true };
                SpotifyListCreator.Start();

            }
            else msgCall("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
        }

        private void buttonCancelSpoti_Click(object sender, EventArgs e)
        {
            // panelSpotify.Visible = false;
            tblogin.Text = "";
            tbpass.Text = "";
            //  tbPlName.Text = "";
        }

        private void LdTracks_click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var station = RadioLists.StationsList.FindIndex(x => x.Name == listBox.SelectedItem.ToString().Replace(" 💙", ""));
            rwork.LoadTracks(station, 0);
        }


        private void btnFileMenu_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenuShower(sender as Button, ctxm.ctxFile);
        }

        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tb = sender as MetroTextBox;

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
                // only allow one decimal point
                if ((e.KeyChar == '.') && (tb.Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int cNum = tbTracksNum.Text!="" ? int.Parse(tbTracksNum.Text) : 0;
            cNum += 5;
            tbTracksNum.Text = cNum.ToString();
        }
        private void metroButton8_Click(object sender, EventArgs e)
        {
            var proc = System.Diagnostics.Process.GetProcessesByName("chromedriver");
            foreach (System.Diagnostics.Process process in proc)
                process.Kill();
        }
    }
}

