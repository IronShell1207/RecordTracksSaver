
namespace RecordGetTracks
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMain = new MetroFramework.Controls.MetroPanel();
            this.labelCLose = new MetroFramework.Controls.MetroLabel();
            this.buttonCLose = new MetroFramework.Controls.MetroButton();
            this.toggleTheme = new MetroFramework.Controls.MetroToggle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.numUpDownMetr2 = new RecordGetTracks.numUpDownMetr();
            this.labalTracks = new MetroFramework.Controls.MetroLabel();
            this.btnBackupRadios = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.tbGooglePath = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.toggleBigSmallLetters = new MetroFramework.Controls.MetroToggle();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.toggleBrowserHide = new MetroFramework.Controls.MetroToggle();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.labelCLose);
            this.panelMain.Controls.Add(this.buttonCLose);
            this.panelMain.Controls.Add(this.toggleTheme);
            this.panelMain.Controls.Add(this.metroLabel1);
            this.panelMain.Controls.Add(this.numUpDownMetr2);
            this.panelMain.Controls.Add(this.labalTracks);
            this.panelMain.Controls.Add(this.btnBackupRadios);
            this.panelMain.Controls.Add(this.metroLabel7);
            this.panelMain.Controls.Add(this.metroButton2);
            this.panelMain.Controls.Add(this.tbGooglePath);
            this.panelMain.Controls.Add(this.metroLabel6);
            this.panelMain.Controls.Add(this.metroToggle1);
            this.panelMain.Controls.Add(this.metroLabel10);
            this.panelMain.Controls.Add(this.toggleBigSmallLetters);
            this.panelMain.Controls.Add(this.metroLabel9);
            this.panelMain.Controls.Add(this.toggleBrowserHide);
            this.panelMain.Controls.Add(this.metroLabel8);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.HorizontalScrollbarBarColor = true;
            this.panelMain.HorizontalScrollbarHighlightOnWheel = false;
            this.panelMain.HorizontalScrollbarSize = 10;
            this.panelMain.Location = new System.Drawing.Point(20, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(542, 370);
            this.panelMain.TabIndex = 0;
            this.panelMain.VerticalScrollbarBarColor = true;
            this.panelMain.VerticalScrollbarHighlightOnWheel = false;
            this.panelMain.VerticalScrollbarSize = 10;
            // 
            // labelCLose
            // 
            this.labelCLose.AutoSize = true;
            this.labelCLose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCLose.Location = new System.Drawing.Point(205, 345);
            this.labelCLose.Name = "labelCLose";
            this.labelCLose.Size = new System.Drawing.Size(150, 19);
            this.labelCLose.TabIndex = 56;
            this.labelCLose.Text = "Закрыть все процессы ";
            this.labelCLose.Click += new System.EventHandler(this.labelCLose_Click);
            // 
            // buttonCLose
            // 
            this.buttonCLose.Location = new System.Drawing.Point(423, 344);
            this.buttonCLose.Name = "buttonCLose";
            this.buttonCLose.Size = new System.Drawing.Size(116, 23);
            this.buttonCLose.TabIndex = 55;
            this.buttonCLose.Text = "Закрыть";
            this.buttonCLose.UseSelectable = true;
            // 
            // toggleTheme
            // 
            this.toggleTheme.AutoSize = true;
            this.toggleTheme.Checked = true;
            this.toggleTheme.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleTheme.Location = new System.Drawing.Point(433, 114);
            this.toggleTheme.Name = "toggleTheme";
            this.toggleTheme.Size = new System.Drawing.Size(80, 17);
            this.toggleTheme.TabIndex = 54;
            this.toggleTheme.Text = "On";
            this.toggleTheme.UseSelectable = true;
            this.toggleTheme.Click += new System.EventHandler(this.toggleTheme_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(11, 113);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(174, 19);
            this.metroLabel1.TabIndex = 53;
            this.metroLabel1.Text = "Использовать темную тему";
            // 
            // numUpDownMetr2
            // 
            this.numUpDownMetr2.isZeroEqualsEmpty = true;
            this.numUpDownMetr2.Location = new System.Drawing.Point(432, 142);
            this.numUpDownMetr2.MaxValue = 100000;
            this.numUpDownMetr2.MinValue = 0;
            this.numUpDownMetr2.msTheme = MetroFramework.MetroThemeStyle.Light;
            this.numUpDownMetr2.Name = "numUpDownMetr2";
            this.numUpDownMetr2.Size = new System.Drawing.Size(93, 25);
            this.numUpDownMetr2.TabIndex = 52;
            this.numUpDownMetr2.TextV = "";
            this.numUpDownMetr2.ValueStep = 5;
            this.numUpDownMetr2.ValueStepByArrows = 1;
            this.numUpDownMetr2.Load += new System.EventHandler(this.numUpDownMetr2_Load);
            // 
            // labalTracks
            // 
            this.labalTracks.AutoSize = true;
            this.labalTracks.Location = new System.Drawing.Point(11, 144);
            this.labalTracks.Name = "labalTracks";
            this.labalTracks.Size = new System.Drawing.Size(251, 19);
            this.labalTracks.TabIndex = 50;
            this.labalTracks.Text = "Кол-во загружаемых в плейлист треков";
            this.labalTracks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBackupRadios
            // 
            this.btnBackupRadios.AutoSize = true;
            this.btnBackupRadios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackupRadios.Location = new System.Drawing.Point(11, 318);
            this.btnBackupRadios.Name = "btnBackupRadios";
            this.btnBackupRadios.Size = new System.Drawing.Size(237, 19);
            this.btnBackupRadios.TabIndex = 46;
            this.btnBackupRadios.Text = "Создать бэкап станций и плейлистов";
            this.btnBackupRadios.Click += new System.EventHandler(this.btnBackupRadios_Click);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel7.Location = new System.Drawing.Point(12, 348);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(168, 15);
            this.metroLabel7.TabIndex = 45;
            this.metroLabel7.Text = "Сбросить настройки и пароли";
            this.metroLabel7.Click += new System.EventHandler(this.metroLabel7_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButton2.Location = new System.Drawing.Point(423, 290);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(116, 23);
            this.metroButton2.TabIndex = 44;
            this.metroButton2.Text = "Указать папку";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // tbGooglePath
            // 
            // 
            // 
            // 
            this.tbGooglePath.CustomButton.Image = null;
            this.tbGooglePath.CustomButton.Location = new System.Drawing.Point(383, 1);
            this.tbGooglePath.CustomButton.Name = "";
            this.tbGooglePath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbGooglePath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbGooglePath.CustomButton.TabIndex = 1;
            this.tbGooglePath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbGooglePath.CustomButton.UseSelectable = true;
            this.tbGooglePath.CustomButton.Visible = false;
            this.tbGooglePath.Lines = new string[] {
        "С:\\Program Files (x86)\\Google\\Chrome\\Application\\"};
            this.tbGooglePath.Location = new System.Drawing.Point(12, 290);
            this.tbGooglePath.MaxLength = 32767;
            this.tbGooglePath.Name = "tbGooglePath";
            this.tbGooglePath.PasswordChar = '\0';
            this.tbGooglePath.PromptText = "С:\\Program Files (x86)\\Google\\Chrome\\Application\\";
            this.tbGooglePath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbGooglePath.SelectedText = "";
            this.tbGooglePath.SelectionLength = 0;
            this.tbGooglePath.SelectionStart = 0;
            this.tbGooglePath.ShortcutsEnabled = true;
            this.tbGooglePath.Size = new System.Drawing.Size(405, 23);
            this.tbGooglePath.TabIndex = 43;
            this.tbGooglePath.Text = "С:\\Program Files (x86)\\Google\\Chrome\\Application\\";
            this.tbGooglePath.UseSelectable = true;
            this.tbGooglePath.WaterMark = "С:\\Program Files (x86)\\Google\\Chrome\\Application\\";
            this.tbGooglePath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbGooglePath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(12, 268);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(144, 19);
            this.metroLabel6.TabIndex = 42;
            this.metroLabel6.Text = "Путь к Google Chrome";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroToggle1
            // 
            this.metroToggle1.AutoSize = true;
            this.metroToggle1.Location = new System.Drawing.Point(433, 83);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(80, 17);
            this.metroToggle1.TabIndex = 41;
            this.metroToggle1.Text = "Off";
            this.metroToggle1.UseSelectable = true;
            this.metroToggle1.Click += new System.EventHandler(this.RusTracksSkipToggle_Click);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(11, 82);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(250, 19);
            this.metroLabel10.TabIndex = 40;
            this.metroLabel10.Text = "Пропускать треки с русским названием";
            // 
            // toggleBigSmallLetters
            // 
            this.toggleBigSmallLetters.AutoSize = true;
            this.toggleBigSmallLetters.Checked = true;
            this.toggleBigSmallLetters.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleBigSmallLetters.Location = new System.Drawing.Point(433, 53);
            this.toggleBigSmallLetters.Name = "toggleBigSmallLetters";
            this.toggleBigSmallLetters.Size = new System.Drawing.Size(80, 17);
            this.toggleBigSmallLetters.TabIndex = 39;
            this.toggleBigSmallLetters.Text = "On";
            this.toggleBigSmallLetters.UseSelectable = true;
            this.toggleBigSmallLetters.Click += new System.EventHandler(this.toggleBigSmallLetters_Click);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(11, 52);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(246, 19);
            this.metroLabel9.TabIndex = 38;
            this.metroLabel9.Text = "Названия станций большими буквами";
            // 
            // toggleBrowserHide
            // 
            this.toggleBrowserHide.AutoSize = true;
            this.toggleBrowserHide.Location = new System.Drawing.Point(433, 22);
            this.toggleBrowserHide.Name = "toggleBrowserHide";
            this.toggleBrowserHide.Size = new System.Drawing.Size(80, 17);
            this.toggleBrowserHide.TabIndex = 37;
            this.toggleBrowserHide.Text = "Off";
            this.toggleBrowserHide.UseSelectable = true;
            this.toggleBrowserHide.CheckedChanged += new System.EventHandler(this.toggleBrowserHide_CheckedChanged);
            this.toggleBrowserHide.Click += new System.EventHandler(this.toggleBrowserHide_Click);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(12, 22);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(214, 19);
            this.metroLabel8.TabIndex = 36;
            this.metroLabel8.Text = "Скрывать браузер после дейтвий";
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 450);
            this.Controls.Add(this.panelMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "Настройки";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel panelMain;
        private MetroFramework.Controls.MetroToggle metroToggle1;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroToggle toggleBigSmallLetters;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroToggle toggleBrowserHide;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroTextBox tbGooglePath;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel btnBackupRadios;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel labalTracks;
        private numUpDownMetr numUpDownMetr2;
        private MetroFramework.Controls.MetroToggle toggleTheme;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton buttonCLose;
        private MetroFramework.Controls.MetroLabel labelCLose;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
    }
}