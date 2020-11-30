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

namespace RecordGetTracks
{

    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        private ContextMenus ctxm;
        RadioWorker rwork;
        int ReturnStationIndex() => RadioLists.StationsList.FindIndex(x => x.Name == listBox.SelectedItem.ToString().Replace(" 💙", ""));

        public Form1()
        {
            InitializeComponent();
            rwork = new RadioWorker(this);
            ctxm = new ContextMenus(this);
            //  Names.progressMax = progressBar.Maximum;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Text = Text + " " + Application.ProductVersion;
            var th = new Thread(() =>
            {
                CreateListRadios(false);
                if (File.Exists(SettingsStatic.JsonSettingsPath))
                {
                    Invoke(new Action(() =>
                    {
                        toggleRecIsFav.Checked = SettingsStatic.settings.UseFavList;
                        tbGooglePath.Text = SettingsStatic.settings.ChromePath;
                        toggleBrowser.Checked = SettingsStatic.settings.HideBrowser;
                        toggleBigSmallLetters.Checked = SettingsStatic.settings.IsBigSymsInRadios;
                        if (SettingsStatic.settings.SpotiPlaylists != null && SettingsStatic.settings.SpotiPlaylists.Count > 0)
                            listBoxPlaylists.Items.AddRange(SettingsStatic.settings.SpotiPlaylists.ToArray());
                        tblogin.Text = SettingsStatic.settings.SpotiLogin;
                        tbpass.Text = SettingsStatic.settings.SpotiPass;
                    }));
                }
            })
            { IsBackground = true };
            th.Start();
            panelRecMain.Dock = DockStyle.Fill;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SeleniumHelper.QuitDriver();
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

        private void metroButton4_Click(object sender, EventArgs e)
        {
            var IndexItem = listBox.SelectedIndex;
            var ItemSelected = listBox.SelectedItem;
            RadioLists.StationsList[IndexItem].isFavorite = true;
            listBox.Items[IndexItem] = ItemSelected + " 💙";
            JsnWorker1.CreateJsnFile(RadioData.RadioLists.StationsList, SettingsStatic.JsonRecordPath);
        }
        private void tbTracksNum_KeyDown(object sender, KeyEventArgs e)
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

        private void btnHideSetts_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = false;
        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {
            panelSpotiMain.Visible = false;
            panelRecMain.Visible = true;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var btn = sender as Button;
                btn.PerformClick();
                Thread.Sleep(50);
            }
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

        private void metroButton8_Click(object sender, EventArgs e)
        {
            var proc = System.Diagnostics.Process.GetProcessesByName("chromedriver");
            foreach (System.Diagnostics.Process process in proc)
                process.Kill();
        }

        private void toggleBrowser_Click(object sender, EventArgs e)
        {
            SettingsStatic.settings.HideBrowser = (sender as MetroToggle).Checked;
            JsnWorker1.CreateJsnFile(SettingsStatic.settings, SettingsStatic.JsonSettingsPath);
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
        private void button4_Click(object sender, EventArgs e)
        {
            int cNum = tbTracksNum.Text != "" ? int.Parse(tbTracksNum.Text) : 0;
            cNum += 5;
            tbTracksNum.Text = cNum.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
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
        private void btnBackupRadios_Click(object sender, EventArgs e)
        {
            var newNameBackup = SettingsStatic.JsonRecordPath + ".backup";
            while (File.Exists(newNameBackup))
            {
                newNameBackup = newNameBackup + ".backup";
            }
            if (DialogResult.Yes == msgCall($"Вы уверены что хотите сделать бэкап? Файл будет сохранен в:\n{newNameBackup}", "Бэкап станций", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                File.Copy(SettingsStatic.JsonRecordPath, newNameBackup);
                if (File.Exists(newNameBackup))
                    msgCall("Бэкап успешно сделан", "Бэкап станций", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    msgCall("Непредвиденная ошибка", "Бэкап станций", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LdTracks_click(object sender, EventArgs e) // загружает список треков в новом потоке
        {
            listBox1.Items.Clear();
            var station = ReturnStationIndex();
            var thread = new Thread(() =>
            {

                rwork.LoadTracks(station, 0);
                Invoke(new Action(() =>
                {

                    listBox1.Items.AddRange(RadioLists.StationsList[station].TracksList.ToArray());
                    labelDatePlaylist.Text = "Список треков от: " + RadioLists.StationsList[station].DateLoadedTracks;
                }));
            });
            thread.Start();
        }
        // возвращает индекс станции в json файле.



        private void buttonStart_Click(object sender, EventArgs e)
        {
            var StartCreator = new Thread(() =>
            {
                listBox.Invoke(new Action(() => listBox.Items.Clear()));
                rwork.CollectLinks();
                CreateListRadios(false);
                SettingsStatic.settings.IsBigSymsInRadios = true;
                JsnWorker1.CreateJsnFile(SettingsStatic.settings, SettingsStatic.JsonSettingsPath);
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
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox.SelectedItem);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }
        private void buttonStartSpoti_Click(object sender, EventArgs e)
        {
            var th = new Thread(() =>
            {
                Invoke(new Action(() => StatusProgressBar = true));
                if (SpotifyWorker.AuthSpoti(tblogin.Text, tbpass.Text))
                {
                    Invoke(new Action(() => listBoxPlaylists.Items.Clear()));
                    Invoke(new Action(() => (sender as Button).Enabled = false));
                    SpotifyWorker.GetPlaylists();
                    if (SettingsStatic.settings.SpotiPlaylists != null && SettingsStatic.settings.SpotiPlaylists.Count > 0)
                        Invoke(new Action(() => listBoxPlaylists.Items.AddRange(SettingsStatic.settings.SpotiPlaylists.ToArray())));
                    if (cboxRemind.Checked)
                    {
                        SettingsStatic.settings.SpotiLogin = tblogin.Text;
                        SettingsStatic.settings.SpotiPass = tbpass.Text;
                        JsnWorker1.CreateJsnFile(SettingsStatic.settings, SettingsStatic.JsonSettingsPath);
                    }

                }
                else msgCall("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Invoke(new Action(() => StatusProgressBar = false));
            });
            th.Start();

        }
        private void SelectFolderForChrome_Click(object sender, EventArgs e)
        {
            var chr = SettingsStatic.FindChromePath();
            if (chr != null)
            {
                SettingsStatic.settings.ChromePath = chr;
                JsnWorker1.CreateJsnFile(SettingsStatic.settings, SettingsStatic.JsonSettingsPath);
                tbGooglePath.Text = SettingsStatic.settings.ChromePath;
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

                var station = RadioLists.StationsList.Find(x => x.Name == listBox.Items[cInd].ToString().Replace(" 💙", ""));
                var stationTracks = station.TracksList;
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
            CreateListRadios(toggleRecIsFav.Checked);
        }
        private void changeRadioBigtoLittleSyms_Click(object sender, EventArgs e)
        {
            ChangeStationsNames((sender as MetroToggle).Checked);
        }
        void ChangeStationsNames(bool isBig)
        {
            SettingsStatic.settings.IsBigSymsInRadios = isBig;
            var th = new Thread(() =>
            {
                Invoke(new Action(() => toggleBigSmallLetters.Enabled = false));
                if (!isBig)
                {
                    Invoke(new Action(() => listBox.Items.Clear()));
                    Invoke(new Action(() => MaximumProgressBar = RadioLists.StationsList.Count - 1));
                    for (int i = 0; i < RadioLists.StationsList.Count; i++)
                    {
                        RadioLists.StationsList[i].Name = FirstLetterToUpAndOtherToLow(RadioLists.StationsList[i].Name);
                        Invoke(new Action(() => listBox.Items.Add(RadioLists.StationsList[i].Name)));
                        Invoke(new Action(() => ProgressProgressBar = i));
                    }
                }
                else if (isBig)
                {
                    Invoke(new Action(() => listBox.Items.Clear()));
                    Invoke(new Action(() => MaximumProgressBar = RadioLists.StationsList.Count - 1));
                    for (int i = 0; i < RadioLists.StationsList.Count; i++)
                    {
                        RadioLists.StationsList[i].Name = RadioLists.StationsList[i].Name.ToUpper();
                        Invoke(new Action(() => listBox.Items.Add(RadioLists.StationsList[i].Name)));
                        Invoke(new Action(() => ProgressProgressBar = i));
                    }
                }
                JsnWorker1.CreateJsnFile(RadioLists.StationsList, SettingsStatic.JsonRecordPath);
                JsnWorker1.CreateJsnFile(SettingsStatic.settings, SettingsStatic.JsonSettingsPath);
                Invoke(new Action(() => toggleBigSmallLetters.Enabled = true));

            });
            th.Start();
        }
        private string FirstLetterToUpAndOtherToLow(string str)
        {
            str = str.ToLower();
            return Char.ToUpper(str[0]) + str.Remove(0, 1);
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
        private void toggleRecIsFav_Click(object sender, EventArgs e)
        {
            SettingsStatic.settings.UseFavList = (sender as MetroToggle).Checked;
            JsnWorker1.CreateJsnFile(SettingsStatic.settings, SettingsStatic.JsonSettingsPath);
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
            SpotifyWorker.AddPlaylistSpotify(tbPlaylsName.Text);
            listBoxPlaylists.Items.Insert(0, tbPlaylsName.Text);
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
            if (DialogResult.Yes == msgCall("Эта функция удаляет треки, в названии которых есть русские символы. Не удаляются русские треки, указанные на английском. Продолжить?", "Внимание. Функция только для русофобов!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                int count = 0;
                var station = ReturnStationIndex();
                var tracks = RadioLists.StationsList[station].TracksList;
                for (int i = 0; i < tracks.Count; i++)
                {
                    if (Regex.IsMatch(tracks[i], @"\p{IsCyrillic}")) // Выборка киррилических символов.
                    {
                        RadioLists.StationsList[station].TracksList.RemoveAt(i);
                        count++;
                    }
                }
                listBox1.Items.Clear();
                listBox1.Items.AddRange(RadioLists.StationsList[station].TracksList.ToArray());
                JsnWorker1.CreateJsnFile(RadioLists.StationsList, SettingsStatic.JsonRecordPath);
                msgCall($"Русских треков удалено: {count}. Очистка произведена успешно!", "Record cleaner");
            }
        }

        private void btnStartImport_Click(object sender, EventArgs e)
        {
            var index = ReturnStationIndex();
            var StationName = listBoxPlaylists.SelectedItem.ToString();
            var th = new Thread(() => {
                var playlist = RadioLists.StationsList[index].TracksList;
                SpotifyWorker.ImportTracksToPlaylist(StationName, playlist);
            });
            th.Start();
        }
    }
}

