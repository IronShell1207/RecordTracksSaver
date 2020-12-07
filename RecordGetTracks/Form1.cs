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
using System.Text.RegularExpressions;
using MetroFramework.Components;

namespace RecordGetTracks
{

    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public ContextMenus ctxm;
        public RadioWorker rwork;
        public SpotifyWorker sWorker;
        public ControlsWorker ctrlWorker;
        private string StartNameForm;
       
        int ReturnStationIndex() => RadioLists.StationsList.FindIndex(x => x.Name == listBox.SelectedItem.ToString().Replace(" 💙", ""));
        public Form1()
        {
            InitializeComponent();
            rwork = new RadioWorker(this);
            sWorker = new SpotifyWorker(this);
            ctxm = new ContextMenus(this);
            ctrlWorker = new ControlsWorker();
            //  Names.progressMax = progressBar.Maximum;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            StartNameForm = Text = $"{Text} {Application.ProductVersion}";
            panelSpoti.Location = new Point(20, 493);
            StartUPConfiguration(); // 
        }
        public void RefreshTheme()
        {
            List<ListBox> lboses = new List<ListBox> { listBox, listBox1, listBoxPlaylists };    
            metroStyleManager1.Theme = SetStatic.settings.mTheme;
            metroStyleManager1.Style = SetStatic.settings.mColor;
            Theme = SetStatic.settings.mTheme;
            Style = SetStatic.settings.mColor;
            foreach (ListBox lbx in lboses)
            {
                bool isDark = SetStatic.settings.mTheme == MetroThemeStyle.Dark ? true: false;
                lbx.ForeColor = isDark ? Color.White : Color.Black;
                lbx.BackColor = isDark ? Color.Black : Color.White;
            }
            Refresh();
        }
        void StartUPConfiguration()
        {
            if (File.Exists(SetStatic.JsonSettingsPath))
            {
                toggleRecIsFav.Checked = SetStatic.settings.UseFavList;// Переключатель избранного
                RefreshTheme();
                toggleBrowserHide.Checked = SetStatic.settings.HideBrowser;          // Автоскрытие браузера 
                toggleBigSmallLetters.Checked = SetStatic.settings.IsBigSymsInRadios;// Переключатель состояния списка станций
                tbGooglePath.Text = SetStatic.settings.ChromePath;                   // Путь к Chrome
                tblogin.Text = SetStatic.settings.SpotiLogin;                        // Spotify login
                tbpass.Text = SetStatic.settings.SpotiPass;                          // Spotify Pass
                var spotiList = SetStatic.settings.SpotiPlaylists;                   // Список плейлистов из Spotify
                ctrlWorker.CreateListRadios(toggleRecIsFav.Checked, listBox);
                if (listBox.Items.Count > 0) listBox.SelectedIndex = 0;
                if (spotiList != null && spotiList.Count > 0)
                {
                    listBoxPlaylists.Items.Clear();
                    listBoxPlaylists.Items.AddRange(spotiList.ToArray());            // Список плейлистов из Spotify
                }
                panelRecMain.Dock = DockStyle.Fill;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SelHelper.QuitDriver();
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


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex > -1)
            {
                btnTracksRemove.Enabled = true;

            }
            else { btnTracksRemove.Enabled = false; }
        }
        public DialogResult msgCall(string text, string topic, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            // Invoke((Action)(() => { this.Focus(); }));
            return MetroMessageBox.Show(this, text, topic, buttons, icon);
        }
        public DialogResult msgCall(string text, string topic)
        {
            // Invoke((Action)(() => { this.Focus(); }));
            return MetroMessageBox.Show(this, text, topic, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void butnLikeStation_Click(object sender, EventArgs e) // добавляет станцию в избранное
        {
            var IndexItem = listBox.SelectedIndex;
            var ItemSelected = listBox.SelectedItem;
            RadioLists.StationsList[IndexItem].isFavorite = true;
            listBox.Items[IndexItem] = ItemSelected + " 💙";
            JsnWorker1.CreateJsnFile(RadioData.RadioLists.StationsList, SetStatic.JsonRecordPath);
        }

        private void btnHideSetts_Click(object sender, EventArgs e) // убрать
        {
            panelSettings.Visible = false;
        }
        private void lblSpotifyPanelClose_Click(object sender, EventArgs e) // переключатель с панели spotify на станции
        {
            panelSpotiMain.Visible = false;
            panelRecMain.Visible = true;
        }
        private void tbNumTracks_KeyPress(object sender, KeyPressEventArgs e) // текстовое поле с кол-вом треков (только цифры)
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
        private void tbTracksNum_KeyDown(object sender, KeyEventArgs e) // текстовое поле с количеством треков
        {
            var txt = tbTracksNum.Text;
            if (txt.Length > 0)
            {
                if (e.KeyData == System.Windows.Forms.Keys.Up)
                {
                    var isz = int.Parse(txt);
                    isz += 1;
                    tbTracksNum.Text = isz.ToString();
                }
                if (e.KeyData == System.Windows.Forms.Keys.Down)
                {
                    var isz = int.Parse(txt);
                    isz -= 1;
                    tbTracksNum.Text = isz.ToString();
                }
            }
        }
        private void button4_Click(object sender, EventArgs e) // эмуляция numupdown ТУт кнопка вверх
        {
            int cNum = tbTracksNum.Text != "" ? int.Parse(tbTracksNum.Text) : 0;
            cNum += 5;
            tbTracksNum.Text = cNum.ToString();
        }
        private void button3_Click(object sender, EventArgs e) // numUpDOWN тут вниз
        {
            int cNum = tbTracksNum.Text != "" ? int.Parse(tbTracksNum.Text) : 0;
            if (cNum > 0)
            {
                cNum -= 5;
                tbTracksNum.Text = cNum.ToString();
            }
            if (cNum == 0)
                tbTracksNum.Text = "";

        }
        private void toggleBrowserHide_Click(object sender, EventArgs e) // переключатель автоскрывателя браузера
        {
            
        }
        #region Menu Button
        private void btnExpMenu_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenuShower(btnExpMenu, ctxm.ctxExport);
        }
        private void btnFileMenu_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenuShower(sender as Button, ctxm.ctxFile);
        }
        private void ContextMenuShower(Button btn, ContextMenuStrip ctx)
        {
            var btnloc = new Point(btn.Location.X, btn.Location.Y + btn.Size.Height);
            var pnt = new Point(Location.X, Location.Y);
            var pnlloc = panelMenu.Location;
            var fpn = new Point(btnloc.X + pnlloc.X + pnt.X, btnloc.Y + pnlloc.Y + pnt.Y);
            ctx.Show(fpn);
        }
        #endregion
        #region События на кнопки
        private void btnBackupRadios_Click(object sender, EventArgs e) // Бэкап станций
        {
            var newNameBackup = SetStatic.JsonRecordPath + ".backup";
            while (File.Exists(newNameBackup))
            {
                newNameBackup = newNameBackup + ".backup";
            }
            if (DialogResult.Yes == msgCall($"Вы уверены что хотите сделать бэкап? Файл будет сохранен в:\n{newNameBackup}", "Бэкап станций", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                File.Copy(SetStatic.JsonRecordPath, newNameBackup);
                if (File.Exists(newNameBackup))
                    msgCall("Бэкап успешно сделан", "Бэкап станций", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    msgCall("Непредвиденная ошибка", "Бэкап станций", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LdTracks_click(object sender, EventArgs e) // загружает список треков в новом потоке
        {
            var station = ReturnStationIndex();
            if (listBox1.Items.Count > 0 && DialogResult.Yes == msgCall("Список треков уже сформирован. Перезаписать текущий треклист?", $"{listBox.SelectedItem}", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                var count = tbTracksNum.Text != "" ? int.Parse(tbTracksNum.Text) : 0;
                var thread = new Thread(() =>
                {
                    
                    rwork.LoadTracks(station, count);
                    SelHelper.ChromeDriver.Manage().Window.Position = new Point(0, 0);
                    Invoke(new Action(() =>
                    {
                        listBox1.Items.Clear();
                        lblCountTracks.Text = $"Кол-во: {RadioLists.StationsList[station].TracksList.Count}";
                        listBox1.Items.AddRange(RadioLists.StationsList[station].TracksList.ToArray());
                        labelDatePlaylist.Text = "Список треков от: " + RadioLists.StationsList[station].DateLoadedTracks;
                    }));
                    if (SetStatic.settings.HideBrowser) SelHelper.ChromeDriver.Manage().Window.Minimize();
                });
                thread.Start();
            }
        }
        // возвращает индекс станции в json файле.

        private void buttonStart_Click(object sender, EventArgs e)
        {
            var StartCreator = new Thread(() =>
            {
                SelHelper.ChromeDriver.Manage().Window.Position = new Point(0, 0);
                listBox.Invoke(new Action(() => listBox.Items.Clear()));
                rwork.CollectLinks();
                ctrlWorker.CreateListRadios(false, listBox);
                SetStatic.settings.IsBigSymsInRadios = true;
                JsnWorker1.CreateJsnFile(SetStatic.settings, SetStatic.JsonSettingsPath);
                if (SetStatic.settings.HideBrowser) SelHelper.ChromeDriver.Manage().Window.Minimize();
                msgCall("Список успешно загружен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
            if (RadioLists.StationsList.Any() && DialogResult.Yes == msgCall("Список станций уже создан! Вы уверены что хотите полностью пересоздать список станций? Это займет какое-то время.", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (toggleRecIsFav.Checked == true)
                    toggleRecIsFav.Checked = false;
                StartCreator.Start();
            }
            else if (RadioLists.StationsList == null || RadioLists.StationsList.Count <= 0)
            {
                if (toggleRecIsFav.Checked == true)
                    toggleRecIsFav.Checked = false;
                StartCreator.Start();
            }
        }

        private void buttonStartSpoti_Click(object sender, EventArgs e)
        {
            var th = new Thread(() =>
            {
                SelHelper.ChromeDriver.Manage().Window.Position = new Point(0, 0);
                Invoke(new Action(() => StatusProgressBar = true));
                Invoke(new Action(() => (sender as Button).Enabled = false));
                sWorker.AuthSpoti(tblogin.Text, tbpass.Text);
                if (SpotifyData.SpotifyPages.IsAuthorized)
                {
                    Invoke(new Action(() => listBoxPlaylists.Items.Clear()));
                    //Invoke(new Action(() => (sender as Button).Enabled = false));
                    sWorker.GetPlaylists();
                    if (SetStatic.settings.SpotiPlaylists != null && SetStatic.settings.SpotiPlaylists.Count > 0)
                        Invoke(new Action(() => listBoxPlaylists.Items.AddRange(SetStatic.settings.SpotiPlaylists.ToArray())));
                    if (cboxRemind.Checked)
                    {
                        SetStatic.settings.SpotiLogin = tblogin.Text;
                        SetStatic.settings.SpotiPass = tbpass.Text;
                        JsnWorker1.CreateJsnFile(SetStatic.settings, SetStatic.JsonSettingsPath);
                    }

                }
                else
                {
                    msgCall("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Invoke(new Action(() => (sender as Button).Enabled = true));
                };

                Invoke(new Action(() => StatusProgressBar = false));
                if (SetStatic.settings.HideBrowser) SelHelper.ChromeDriver.Manage().Window.Minimize();
            });
            th.Start();

        }
        private void SelectFolderForChrome_Click(object sender, EventArgs e)
        {
            var chr = SetStatic.FindChromePath();
            if (chr != null)
            {
                SetStatic.settings.ChromePath = chr;
                JsnWorker1.CreateJsnFile(SetStatic.settings, SetStatic.JsonSettingsPath);
                tbGooglePath.Text = SetStatic.settings.ChromePath;
                msgCall($"Место размещения chrome изменено на:\n{chr}", "Месторасположение изменено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region listboxes
        private void listBoxStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cInd = listBox.SelectedIndex;

            listBox1.Items.Clear();
            if (cInd > -1)
            {
                Text = $"{StartNameForm} - {listBox.SelectedItem.ToString()}";
                Refresh();
                var station = RadioLists.StationsList.Find(x => x.Name == listBox.Items[cInd].ToString().Replace(" 💙", ""));
                var stationTracks = station.TracksList;
                lblCountTracks.Text = $"Кол-во: {station.TracksList.Count}";
                if (stationTracks.Count > 0)
                {
                    listBox1.Items.AddRange(stationTracks.ToArray());
                    if (station.DateLoadedTracks != null)
                    {
                        labelDatePlaylist.Text = $"Список треков от: {station.DateLoadedTracks}";
                        labelDatePlaylist.Visible = true;
                    }
                    else labelDatePlaylist.Visible = false;
                }
                if (toggleRecIsFav.Checked == false) btnRecAddFav.Enabled = true;
                if (toggleRecIsFav.Checked == true || station.isFavorite == true) btnRecRemFav.Enabled = true;
                buttongetTitle.Enabled = true;
                if (listBox1.Items.Count > 1)
                    labelRemoveRusMusic.Enabled = true;
                else
                    labelRemoveRusMusic.Enabled = false;
            }
            else
            {
                Text = StartNameForm;
                labelRemoveRusMusic.Enabled = false;
                buttongetTitle.Enabled = false;
                labelDatePlaylist.Visible = false;
                btnRecAddFav.Enabled = false;
                buttongetTitle.Enabled = false;
            }
        }
        #endregion
        #region TOGGLER!!!!!!!!!!!!
        private void toggleIsFav_CheckedChanged(object sender, EventArgs e)
        {
            ctrlWorker.CreateListRadios(toggleRecIsFav.Checked, listBox);
        }
        private void changeRadioBigtoLittleSyms_Click(object sender, EventArgs e)
        {
            SetStatic.settings.IsBigSymsInRadios = (sender as MetroToggle).Checked;
            toggleBigSmallLetters.Enabled = false;
            listBox.Items.Clear();
            var th = new Thread(() =>
            {
                rwork.LetterFormatTransfo();
                Invoke(new Action(() =>
                {
                    toggleBigSmallLetters.Enabled = true;
                    ctrlWorker.CreateListRadios(toggleRecIsFav.Checked, listBox);
                }));
                
            });
            th.Start();
        }

        
        /* void CreateListRadios(bool isFavorite)
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
        }*/
        private void toggleRecIsFav_Click(object sender, EventArgs e)
        {
            SetStatic.settings.UseFavList = (sender as MetroToggle).Checked;
            JsnWorker1.CreateJsnFile(SetStatic.settings, SetStatic.JsonSettingsPath);
        }
        #endregion
        #region Прогресс Бар 
        public int ProgressProgressBar
        {
            set =>
                progressBar.Value = value;
        }

        public int MaximumProgressBar
        {
            set =>
                progressBar.Maximum = value;
        }

        public bool StatusProgressBar
        {
            set =>
                progressBarLoaging.Visible = value;
        }
        #endregion

        private void tbTracksNum_Leave(object sender, EventArgs e)
        {
            if (tbTracksNum.Text != "" && int.Parse(tbTracksNum.Text) == 0)
                tbTracksNum.Text = "";
        }

        private void listBoxPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lb = sender as ListBox;
            if (lb.SelectedIndex > -1)
                btnStartImport.Enabled = true;
            else
                btnStartImport.Enabled = false;
        }

        private void buttonAddPlst_Click(object sender, EventArgs e)
        {
            var name = tbPlaylsName.Text;
            var th = new Thread(() =>
            {
                SelHelper.ChromeDriver.Manage().Window.Position = new Point(0, 0);
                sWorker.AddPlaylistSpotify(name);
                if (SetStatic.settings.HideBrowser) SelHelper.ChromeDriver.Manage().Window.Minimize();
            });
            if (SpotifyData.SpotifyPages.IsAuthorized)
            {
                th.Start();
                listBoxPlaylists.Items.Insert(0, name);
                SetStatic.settings.SpotiPlaylists.Insert(0, name);
                JsnWorker1.CreateJsnFile(SetStatic.settings, SetStatic.JsonSettingsPath);
            }
        }

        private void tbPlaylsName_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as MetroTextBox;
            if (tb.Text != "")
                buttonAddPlst.Enabled = true;
            else
                buttonAddPlst.Enabled = false;
        }

        private void labelRemoveRusMusic_Click(object sender, EventArgs e) // Удаляет русские треки
        {
            var ind = ReturnStationIndex();
            rwork.RussRemover(ind, msgCall);
            listBox1.Items.Clear();
            listBox1.Items.AddRange(RadioLists.StationsList[ind].TracksList.ToArray());
        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {
            var index = ReturnStationIndex();
            var StationName = listBoxPlaylists.SelectedItem.ToString();
            buttonBreakSpoti.Text = "Отменить\n импорт";
            panelSpoti.Visible = true;
            var th = new Thread(() =>
            {
                SelHelper.ChromeDriver.Manage().Window.Position = new Point(0, 0);
                var playlist = RadioLists.StationsList[index].TracksList;
                sWorker.ImportTracksToPlaylist(StationName, playlist);
                Invoke(new Action(() => panelSpoti.Visible = false));
                if (SetStatic.settings.HideBrowser) SelHelper.ChromeDriver.Manage().Window.Minimize();
            });
            th.Start();
        }

        private void buttonBreakSpoti_Click(object sender, EventArgs e)
        {
            SpotifyData.SpotifyPages.BreakSpotify = true;
            buttonBreakSpoti.Text = "Отменяем...";
        }

        private void toggleBigSmallLetters_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toggleBrowserHide_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel13_Click(object sender, EventArgs e)
        {
            panelExportFile.Visible = false;
            panelRecMain.Visible = true;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            var folderTB = tbSavePath.Text;
            string path = $"{(Directory.Exists(folderTB) ? folderTB : Environment.GetFolderPath(Environment.SpecialFolder.Desktop))}\\{(tbSaveName.Text != "" ? tbSaveName.Text : listBox.SelectedItem.ToString())}";
            var tracklist = RadioLists.StationsList[ReturnStationIndex()].TracksList;
            File.WriteAllText(path+".txt", String.Join("\n",tracklist.ToArray()));
            msgCall($"Файл сохранен по пути:\n{path}.txt","Успешно экспортировано");
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            var tracklist = RadioLists.StationsList[ReturnStationIndex()].TracksList;
            PlaylistDownloader plsDownl = new PlaylistDownloader(this);
            var dl = plsDownl.YoutubeDLPath;
        }
    }
}

