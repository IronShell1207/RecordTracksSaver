
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.mSM = new MetroFramework.Components.MetroStyleManager(this.components);
            this.panelMain = new MetroFramework.Controls.MetroPanel();
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.toggleBigSmallLetters = new MetroFramework.Controls.MetroToggle();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.toggleBrowserHide = new MetroFramework.Controls.MetroToggle();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.tbGooglePath = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.btnBackupRadios = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.panelNumUpDown = new MetroFramework.Controls.MetroPanel();
            this.tbTracksNum = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel6 = new MetroFramework.Controls.MetroPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.labalTracks = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.mSM)).BeginInit();
            this.panelMain.SuspendLayout();
            this.panelNumUpDown.SuspendLayout();
            this.metroPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // mSM
            // 
            this.mSM.Owner = this;
            this.mSM.Style = MetroFramework.MetroColorStyle.Brown;
            this.mSM.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.labalTracks);
            this.panelMain.Controls.Add(this.panelNumUpDown);
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
            // metroToggle1
            // 
            this.metroToggle1.AutoSize = true;
            this.metroToggle1.Location = new System.Drawing.Point(433, 83);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(80, 17);
            this.metroToggle1.TabIndex = 41;
            this.metroToggle1.Text = "Off";
            this.metroToggle1.UseSelectable = true;
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
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(354, 107);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(159, 23);
            this.metroButton2.TabIndex = 44;
            this.metroButton2.Text = "Указать папку";
            this.metroButton2.UseSelectable = true;
            // 
            // tbGooglePath
            // 
            // 
            // 
            // 
            this.tbGooglePath.CustomButton.Image = null;
            this.tbGooglePath.CustomButton.Location = new System.Drawing.Point(479, 1);
            this.tbGooglePath.CustomButton.Name = "";
            this.tbGooglePath.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbGooglePath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbGooglePath.CustomButton.TabIndex = 1;
            this.tbGooglePath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbGooglePath.CustomButton.UseSelectable = true;
            this.tbGooglePath.CustomButton.Visible = false;
            this.tbGooglePath.Lines = new string[] {
        "С:\\Program Files (x86)\\Google\\Chrome\\Application\\"};
            this.tbGooglePath.Location = new System.Drawing.Point(12, 136);
            this.tbGooglePath.MaxLength = 32767;
            this.tbGooglePath.Name = "tbGooglePath";
            this.tbGooglePath.PasswordChar = '\0';
            this.tbGooglePath.PromptText = "С:\\Program Files (x86)\\Google\\Chrome\\Application\\";
            this.tbGooglePath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbGooglePath.SelectedText = "";
            this.tbGooglePath.SelectionLength = 0;
            this.tbGooglePath.SelectionStart = 0;
            this.tbGooglePath.ShortcutsEnabled = true;
            this.tbGooglePath.Size = new System.Drawing.Size(501, 23);
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
            this.metroLabel6.Location = new System.Drawing.Point(12, 114);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(144, 19);
            this.metroLabel6.TabIndex = 42;
            this.metroLabel6.Text = "Путь к Google Chrome";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // 
            // panelNumUpDown
            // 
            this.panelNumUpDown.Controls.Add(this.tbTracksNum);
            this.panelNumUpDown.Controls.Add(this.metroPanel6);
            this.panelNumUpDown.HorizontalScrollbarBarColor = true;
            this.panelNumUpDown.HorizontalScrollbarHighlightOnWheel = false;
            this.panelNumUpDown.HorizontalScrollbarSize = 10;
            this.panelNumUpDown.Location = new System.Drawing.Point(400, 170);
            this.panelNumUpDown.Name = "panelNumUpDown";
            this.panelNumUpDown.Size = new System.Drawing.Size(112, 26);
            this.panelNumUpDown.TabIndex = 49;
            this.panelNumUpDown.VerticalScrollbarBarColor = true;
            this.panelNumUpDown.VerticalScrollbarHighlightOnWheel = false;
            this.panelNumUpDown.VerticalScrollbarSize = 10;
            // 
            // tbTracksNum
            // 
            // 
            // 
            // 
            this.tbTracksNum.CustomButton.Image = null;
            this.tbTracksNum.CustomButton.Location = new System.Drawing.Point(63, 2);
            this.tbTracksNum.CustomButton.Name = "";
            this.tbTracksNum.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbTracksNum.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbTracksNum.CustomButton.TabIndex = 1;
            this.tbTracksNum.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbTracksNum.CustomButton.UseSelectable = true;
            this.tbTracksNum.CustomButton.Visible = false;
            this.tbTracksNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTracksNum.Lines = new string[0];
            this.tbTracksNum.Location = new System.Drawing.Point(0, 0);
            this.tbTracksNum.MaxLength = 32767;
            this.tbTracksNum.Name = "tbTracksNum";
            this.tbTracksNum.PasswordChar = '\0';
            this.tbTracksNum.PromptText = "Все";
            this.tbTracksNum.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbTracksNum.SelectedText = "";
            this.tbTracksNum.SelectionLength = 0;
            this.tbTracksNum.SelectionStart = 0;
            this.tbTracksNum.ShortcutsEnabled = true;
            this.tbTracksNum.Size = new System.Drawing.Size(87, 26);
            this.tbTracksNum.TabIndex = 19;
            this.tbTracksNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTracksNum.UseSelectable = true;
            this.tbTracksNum.WaterMark = "Все";
            this.tbTracksNum.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbTracksNum.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroPanel6
            // 
            this.metroPanel6.Controls.Add(this.button4);
            this.metroPanel6.Controls.Add(this.button3);
            this.metroPanel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroPanel6.HorizontalScrollbarBarColor = true;
            this.metroPanel6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel6.HorizontalScrollbarSize = 10;
            this.metroPanel6.Location = new System.Drawing.Point(87, 0);
            this.metroPanel6.Name = "metroPanel6";
            this.metroPanel6.Size = new System.Drawing.Size(25, 26);
            this.metroPanel6.TabIndex = 20;
            this.metroPanel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel6.VerticalScrollbarBarColor = true;
            this.metroPanel6.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel6.VerticalScrollbarSize = 10;
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Himalaya", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.Color.Silver;
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(25, 13);
            this.button4.TabIndex = 22;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.Silver;
            this.button3.Location = new System.Drawing.Point(0, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 13);
            this.button3.TabIndex = 20;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // labalTracks
            // 
            this.labalTracks.AutoSize = true;
            this.labalTracks.Location = new System.Drawing.Point(12, 172);
            this.labalTracks.Name = "labalTracks";
            this.labalTracks.Size = new System.Drawing.Size(251, 19);
            this.labalTracks.TabIndex = 50;
            this.labalTracks.Text = "Кол-во загружаемых в плейлист треков";
            this.labalTracks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 450);
            this.Controls.Add(this.panelMain);
            this.Name = "FormSettings";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mSM)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelNumUpDown.ResumeLayout(false);
            this.metroPanel6.ResumeLayout(false);
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
        public MetroFramework.Components.MetroStyleManager mSM;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroTextBox tbGooglePath;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel btnBackupRadios;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroPanel panelNumUpDown;
        private MetroFramework.Controls.MetroTextBox tbTracksNum;
        private MetroFramework.Controls.MetroPanel metroPanel6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private MetroFramework.Controls.MetroLabel labalTracks;
    }
}