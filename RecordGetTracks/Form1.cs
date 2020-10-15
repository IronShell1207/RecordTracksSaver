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

namespace RecordGetTracks
{

    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        JsonWorker1 jsnWrk;
        public Form1()
        {
            InitializeComponent();
            jsnWrk = new JsonWorker1();
        }
        IWebDriver chromeDriver;

        private List<Station> stationsList;
        private List<IWebElement> recordStations;
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
        public List<Station> StationsList()
        {
            if (stationsList == null)
            {
                stationsList = new List<Station> { };
            }
            return stationsList;
        }

        public List<IWebElement> RecordGetStations()
        {
            if (recordStations == null)
            {
                // ChromeDriver().Manage().Window.Position = new Point(1000, 0);
                SeleniumHelper.ChromeDriver.Url = "https://www.radiorecord.fm/playlist.html";
                Thread.Sleep(2000);
                recordStations = SeleniumHelper.ChromeDriver.FindElements(By.XPath("//div[@class='icon']//img")).ToList();
            }
            return recordStations;
        }
        //   Нужна подмога. Есть два разных списка и нужно сравнить значение из первого (который я перебираю) со значением из второго списка и вывести свойство Name из второго при совпадении. Я сделал перебором еще и второго списка. А есть ли вариант обойти перебор второго списка?
        private void buttonStart_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            StationsList().Clear();
            toggleIsFav.Checked = false;
            var ThreadNewListStations = new Thread(() =>
            {
                if (InvokeRequired) progressBar.Invoke(new Action(() => progressBar.ProgressBarStyle = ProgressBarStyle.Marquee));
                else progressBar.ProgressBarStyle = ProgressBarStyle.Marquee;
                Thread.Sleep(100);
                try
                {
                    var listStations = RecordGetStations();
                    var listStNames = jsnWrk.RadioNamesList(msgCall, SeleniumHelper.ChromeDriver, listStations).ToDictionary(c => c.Link, s => s.Name);
                    int i = 0;
                    foreach (IWebElement station in listStations)
                    {
                        var link = station.GetAttribute("src");
                        if (listStNames.ContainsKey(link))
                        {
                            var Name = listStNames.Where(x => x.Key == link).FirstOrDefault().Value;
                            //stats.Add(new StationN { Element = station, Name = listStNames.Where(x => x.Key == station.GetAttribute("src")).FirstOrDefault().Value });
                            Invoke((Action)(() => listBox.Items.Add(++i + ". " + Name)));
                            StationsList().Add(new Station { Link = link, Name = Name });
                        }
                        else
                        {
                            Invoke((Action)(() => listBox.Items.Add(++i + ". " + link)));
                            StationsList().Add(new Station { Link = link, Name = link });
                        }
                    }

                }
                catch (WebDriverException ex)
                {
                    msgCall(ex.Message, "Браузер потерян?", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chromeDriver = null;
                    Application.Exit();
                }
                if (InvokeRequired) progressBar.Invoke(new Action(() => progressBar.ProgressBarStyle = ProgressBarStyle.Continuous));
                else progressBar.ProgressBarStyle = ProgressBarStyle.Continuous;
                Thread.Sleep(100);
            })
            { IsBackground = true, Priority = ThreadPriority.Highest };
            ThreadNewListStations.Start();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex > -1)
            {
                if (toggleIsFav.Checked == false)
                    metroButton4.Enabled = true;
                if (toggleIsFav.Checked == true)
                    metroButton5.Enabled = true;
                buttongetTitle.Enabled = true;
            }
            else
            {
                buttongetTitle.Enabled = false;
                metroButton4.Enabled = false;
                metroButton5.Enabled = false;
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
            if (chromeDriver != null)
            {
                SeleniumHelper.ChromeDriver.Close();


            }
        }
        void panelShoweer(MetroPanel panel)
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
#if DEBUG
            metroButton8.Visible = true;
#endif
            if (File.Exists("favlist.json"))
            {
                toggleIsFav.Checked = true;
            }
        }
        List<string> TracksList = new List<string> { };
        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex > -1)
            {
                listBox1.Items.Clear();
                var ThreadGrabTracks = new Thread(() =>
                {
                    if (InvokeRequired) progressBar.Invoke(new Action(() => progressBar.ProgressBarStyle = ProgressBarStyle.Marquee));
                    else progressBar.ProgressBarStyle = ProgressBarStyle.Marquee;
                    Thread.Sleep(100);
                    string LinkStation = "";
                    if (InvokeRequired) Invoke((Action)(() => { LinkStation = StationsList()[listBox.SelectedIndex].Link; }));
                    else LinkStation = StationsList()[listBox.SelectedIndex].Link;
                    RecordGetStations().Find(x => x.GetAttribute("src") == LinkStation).Click();
                    SeleniumHelper.ChromeDriver.SwitchTo().Frame("playlist_frame");
                    var TracksNms = SeleniumHelper.ChromeDriver.FindElements(By.XPath("//div[@class='artist']"));
                    foreach (IWebElement el in TracksNms)
                    {
                        var es = el.Text.Replace("/", " ").Replace("—", " ").Replace("rmx", "remix");
                        TracksList.Add(es);
                        if (InvokeRequired) Invoke((Action)(() => listBox1.Items.Add(es)));
                        else listBox1.Items.Add(es);
                    }
                    SeleniumHelper.ChromeDriver.SwitchTo().DefaultContent();
                    if (InvokeRequired) Invoke((Action)(() => buttonAllList.Enabled = true));
                    else buttonAllList.Enabled = true;
                    if (InvokeRequired) Invoke((Action)(() => buttonMakePlaylist.Enabled = true));
                    else buttonMakePlaylist.Enabled = true;
                    if (InvokeRequired) progressBar.Invoke(new Action(() => progressBar.ProgressBarStyle = ProgressBarStyle.Continuous));
                    else progressBar.ProgressBarStyle = ProgressBarStyle.Continuous;
                    Thread.Sleep(100);
                }
                )
                { IsBackground = true };
                ThreadGrabTracks.Start();

            }

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
                metroButton1.Enabled = true;
            else metroButton1.Enabled = false;
        }
        public DialogResult msgCall(string text, string topic, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            // Invoke((Action)(() => { this.Focus(); }));
            return MetroMessageBox.Show(this, text, topic, buttons, icon);
        }
        List<Station> FavList = new List<Station> { };
        private void metroButton4_Click(object sender, EventArgs e)
        {
            var ind = listBox.SelectedIndex;
            var indIt = listBox.SelectedItem;
            FavList.Add(jsnWrk.RadioNamesList(msgCall, SeleniumHelper.ChromeDriver, RecordGetStations())[ind]);
            listBox.Items.RemoveAt(ind);
            listBox.Items.Insert(ind, indIt + " В избранном");
            jsnWrk.CreateJsnFile(FavList, "favlist.json");
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            StationsList().RemoveAt(listBox.SelectedIndex);
            listBox.Items.RemoveAt(listBox.SelectedIndex);
            jsnWrk.CreateJsnFile(StationsList(), "favlist.json");
        }

        private void toggleIsFav_CheckedChanged(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            FavList.Clear();
            StationsList().Clear();
            if (toggleIsFav.Checked == true)
            {
                if (File.Exists("favlist.json"))
                {
                    stationsList = jsnWrk.ReadJsnFile("favlist.json");
                    foreach (Station station in stationsList)
                        listBox.Items.Add(station.Name);
                }
            }
            else if (toggleIsFav.Checked == false)
            {
                metroButton2.PerformClick();
            }
        }

        private void metroButton3_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var th = new Thread(() =>
            {
                SeleniumHelper.ChromeDriver.SwitchTo().Frame("playlist_frame");
                SeleniumHelper.ChromeDriver.FindElement(By.XPath("//b[text()='Все']")).Click();
                var TracksNms = SeleniumHelper.ChromeDriver.FindElements(By.XPath("//div[@class='artist']"));
                foreach (IWebElement el in TracksNms)
                {
                    var es = el.Text.Replace("/", " ");
                    TracksList.Add(es);
                    if (InvokeRequired) Invoke((Action)(() => listBox1.Items.Add(es)));
                    else listBox1.Items.Add(es);

                }
                SeleniumHelper.ChromeDriver.SwitchTo().DefaultContent();

                if (InvokeRequired) Invoke((Action)(() => buttonAllList.Enabled = false));
                else buttonAllList.Enabled = false;
            });
            th.Start();
        }

        private void metroProgressBar1_Click(object sender, EventArgs e)
        {

        }

        void buttonMakePlaylist_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex > -1)
                tbPlName.Text = listBox.SelectedItem.ToString();
            panelShoweer(panelSpotify);
        }
        void Spoti(string login, string password, string PlaylistName, List<string> songs, bool IsNewPlaylist)
        {

            if (InvokeRequired) progressBar.Invoke(new Action(() => { progressBar.ProgressBarStyle = ProgressBarStyle.Marquee; progressBar.Value = 0; }));
            else {progressBar.ProgressBarStyle = ProgressBarStyle.Marquee; progressBar.Value = 0; }
            Thread.Sleep(100);
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
            if (InvokeRequired)
            {
                Invoke((Action)(() => progressBar.ProgressBarStyle = ProgressBarStyle.Continuous));
                Invoke((Action)(() => progressBar.Maximum = songs.Count));
            }
            else
            {
                progressBar.ProgressBarStyle = ProgressBarStyle.Continuous;
                progressBar.Maximum = songs.Count;
            }
            int i = 0;
            foreach (string song in songs)
            {
               i = AddTrackToPlaylist(song, i);
            }
            if (InvokeRequired) progressBar.Invoke(new Action(() =>   progressBar.Value = songs.Count));
            else  progressBar.Value = songs.Count;
            msgCall(String.Format("Создание плейлиста завершено.\nВсего добавлено {0}/{1} треков.",i,songs.Count), "Завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                if (InvokeRequired) progressBar.Invoke(new Action(() => progressBar.Value = ++i));
                else progressBar.Value = ++i;
                
            }
            catch (NoSuchElementException ex)
            {
            }
            ClickLink(By.XPath("//header/div[3]/div[1]/div[1]/div[1]/button[1]"));
            return i;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            panelShoweer(panelSpotify);
        }

        private void buttonStartSpoti_Click(object sender, EventArgs e)
        {
            if (tblogin.Text != "" && tbpass.Text != "" && tbPlName.Text != "")
            {
                var Th = new Thread(() => Spoti(tblogin.Text, tbpass.Text, tbPlName.Text, TracksList, metroCheckBox2.Checked)) { IsBackground = true };
                Th.Start();

            }
            else msgCall("Не все поля заполнены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonCancelSpoti_Click(object sender, EventArgs e)
        {
            panelSpotify.Visible = false;
            tblogin.Text = "";
            tbpass.Text = "";
            tbPlName.Text = "";
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Sexy chick");
            listBox1.Items.Add("Darlin");
            listBox1.Items.Add("JOji");
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            var proc = System.Diagnostics.Process.GetProcessesByName("chromedriver");
            foreach (System.Diagnostics.Process process in proc)
                process.Kill();
        }
    }
}

