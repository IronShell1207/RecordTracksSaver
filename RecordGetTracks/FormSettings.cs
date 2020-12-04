using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Components;
using MetroFramework.Controls;

namespace RecordGetTracks
{
    public partial class FormSettings : MetroFramework.Forms.MetroForm
    {
        public object ReturnValue1 { get; set; }
        private Form1 Form1s;
        public FormSettings(object fom)
        { 
            InitializeComponent();
            Form1s = fom as Form1;
            MetroStyleManager msmm = SetStatic.mSM;
            msmm.Owner = this;
            StyleManager = msmm;
            toggleTheme.Checked = SetStatic.settings.mTheme == MetroThemeStyle.Dark ? true : false;
            numUpDownMetr2.msTheme = Theme;
            Refresh();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            toggleBrowserHide.Checked = SetStatic.settings.HideBrowser;          // Автоскрытие браузера 
            toggleBigSmallLetters.Checked = SetStatic.settings.IsBigSymsInRadios;// Переключатель состояния списка станций
            tbGooglePath.Text = SetStatic.settings.ChromePath;                   // Путь к Chrome

        }

        private void toggleBigSmallLetters_Click(object sender, EventArgs e)
        {
            SetStatic.settings.IsBigSymsInRadios = (sender as MetroToggle).Checked;
            toggleBigSmallLetters.Enabled = false;
            Form1s.listBox.Items.Clear();
            var th = new Thread(() =>
            {
                Form1s.rwork.LetterFormatTransfo();
                Invoke(new Action(() =>
                {
                    toggleBigSmallLetters.Enabled = true;
                    Form1s.ctrlWorker.CreateListRadios(SetStatic.settings.UseFavList, Form1s.listBox);
                }));

            });
            th.Start();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var chr = SetStatic.FindChromePath();
            if (chr != null)
            {
                SetStatic.settings.ChromePath = chr;
                JsnWorker1.CreateJsnFile(SetStatic.settings, SetStatic.JsonSettingsPath);
                tbGooglePath.Text = SetStatic.settings.ChromePath;
                MetroMessageBox.Show(this,$"Место размещения chrome изменено на:\n{chr}", "Месторасположение изменено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroToggle2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void toggleBrowserHide_Click(object sender, EventArgs e)
        {
            SetStatic.settings.HideBrowser = (sender as MetroToggle).Checked;
            JsnWorker1.CreateJsnFile(SetStatic.settings, SetStatic.JsonSettingsPath);
        }

        private void btnBackupRadios_Click(object sender, EventArgs e)
        {
            var newNameBackup = SetStatic.JsonRecordPath + ".backup";
            while (File.Exists(newNameBackup))
            {
                newNameBackup = newNameBackup + ".backup";
            }
            if (DialogResult.Yes == MetroMessageBox.Show(this,$"Вы уверены что хотите сделать бэкап? Файл будет сохранен в:\n{newNameBackup}", "Бэкап станций", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                File.Copy(SetStatic.JsonRecordPath, newNameBackup);
                if (File.Exists(newNameBackup))
                    MetroMessageBox.Show(this, "Бэкап успешно сделан", "Бэкап станций", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MetroMessageBox.Show(this, "Непредвиденная ошибка", "Бэкап станций", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroLabel7_Click(object sender, EventArgs e)
        {

        }

        private void toggleTheme_Click(object sender, EventArgs e)
        {
            SetStatic.mSM.Theme = toggleTheme.Checked ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
            //  SetStatic.settings.mTheme = toggleTheme.Checked ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
            //  mSM.Theme = toggleTheme.Checked ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
            numUpDownMetr2.msTheme = toggleTheme.Checked ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
            Theme = toggleTheme.Checked ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
            Refresh();
            JsnWorker1.CreateJsnFile(SetStatic.settings, SetStatic.JsonSettingsPath);
        }
    }
}
