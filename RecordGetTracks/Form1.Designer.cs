namespace RecordGetTracks
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox = new System.Windows.Forms.ListBox();
            this.buttongetTitle = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.toggleIsFav = new MetroFramework.Controls.MetroToggle();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.buttonAllList = new MetroFramework.Controls.MetroButton();
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.buttonSettings = new MetroFramework.Controls.MetroButton();
            this.buttonMakePlaylist = new MetroFramework.Controls.MetroButton();
            this.panelSpotify = new MetroFramework.Controls.MetroPanel();
            this.metroButton7 = new MetroFramework.Controls.MetroButton();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.tbPlName = new MetroFramework.Controls.MetroTextBox();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.tbpass = new MetroFramework.Controls.MetroTextBox();
            this.tblogin = new MetroFramework.Controls.MetroTextBox();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton8 = new MetroFramework.Controls.MetroButton();
            this.panelSpotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox.ForeColor = System.Drawing.Color.White;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(23, 81);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(195, 272);
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // buttongetTitle
            // 
            this.buttongetTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttongetTitle.Enabled = false;
            this.buttongetTitle.Location = new System.Drawing.Point(23, 472);
            this.buttongetTitle.Name = "buttongetTitle";
            this.buttongetTitle.Size = new System.Drawing.Size(195, 26);
            this.buttongetTitle.TabIndex = 1;
            this.buttongetTitle.Text = "Загрузить список треков";
            this.buttongetTitle.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttongetTitle.UseSelectable = true;
            this.buttongetTitle.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroButton2.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.metroButton2.Location = new System.Drawing.Point(23, 387);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(195, 23);
            this.metroButton2.TabIndex = 1;
            this.metroButton2.Text = "Загрузить список плейлистов";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(11)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(232, 81);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(324, 450);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(21, 56);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(75, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Плейлисты";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(231, 56);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(45, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Треки";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Enabled = false;
            this.metroButton1.Location = new System.Drawing.Point(481, 51);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 6;
            this.metroButton1.Text = "Удалить";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // toggleIsFav
            // 
            this.toggleIsFav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toggleIsFav.AutoSize = true;
            this.toggleIsFav.DisplayStatus = false;
            this.toggleIsFav.Location = new System.Drawing.Point(168, 417);
            this.toggleIsFav.Name = "toggleIsFav";
            this.toggleIsFav.Size = new System.Drawing.Size(50, 17);
            this.toggleIsFav.TabIndex = 7;
            this.toggleIsFav.Text = "Off";
            this.toggleIsFav.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.toggleIsFav.UseSelectable = true;
            this.toggleIsFav.CheckedChanged += new System.EventHandler(this.toggleIsFav_CheckedChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(22, 417);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(143, 15);
            this.metroLabel3.TabIndex = 8;
            this.metroLabel3.Text = "Использовать избранное";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroButton4.Enabled = false;
            this.metroButton4.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButton4.Location = new System.Drawing.Point(23, 358);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(122, 23);
            this.metroButton4.TabIndex = 9;
            this.metroButton4.Text = "Добавить в избранное";
            this.metroButton4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroButton5.Enabled = false;
            this.metroButton5.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButton5.Location = new System.Drawing.Point(153, 358);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(65, 23);
            this.metroButton5.TabIndex = 10;
            this.metroButton5.Text = "Удалить";
            this.metroButton5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton5.UseSelectable = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // buttonAllList
            // 
            this.buttonAllList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAllList.Enabled = false;
            this.buttonAllList.Location = new System.Drawing.Point(342, 51);
            this.buttonAllList.Name = "buttonAllList";
            this.buttonAllList.Size = new System.Drawing.Size(129, 23);
            this.buttonAllList.TabIndex = 11;
            this.buttonAllList.Text = "Показать весь список";
            this.buttonAllList.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonAllList.UseSelectable = true;
            this.buttonAllList.Click += new System.EventHandler(this.metroButton3_Click_1);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(22, 541);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(533, 23);
            this.progressBar.TabIndex = 12;
            this.progressBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.progressBar.Click += new System.EventHandler(this.metroProgressBar1_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSettings.Enabled = false;
            this.buttonSettings.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.buttonSettings.Location = new System.Drawing.Point(23, 442);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(195, 23);
            this.buttonSettings.TabIndex = 13;
            this.buttonSettings.Text = "Настройки";
            this.buttonSettings.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonSettings.UseSelectable = true;
            // 
            // buttonMakePlaylist
            // 
            this.buttonMakePlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMakePlaylist.Location = new System.Drawing.Point(23, 505);
            this.buttonMakePlaylist.Name = "buttonMakePlaylist";
            this.buttonMakePlaylist.Size = new System.Drawing.Size(195, 26);
            this.buttonMakePlaylist.TabIndex = 14;
            this.buttonMakePlaylist.Text = "Создать плейлист из треков";
            this.buttonMakePlaylist.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonMakePlaylist.UseSelectable = true;
            this.buttonMakePlaylist.Click += new System.EventHandler(this.buttonMakePlaylist_Click);
            // 
            // panelSpotify
            // 
            this.panelSpotify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSpotify.Controls.Add(this.metroButton7);
            this.panelSpotify.Controls.Add(this.metroCheckBox2);
            this.panelSpotify.Controls.Add(this.metroButton6);
            this.panelSpotify.Controls.Add(this.metroLabel7);
            this.panelSpotify.Controls.Add(this.metroLabel6);
            this.panelSpotify.Controls.Add(this.tbPlName);
            this.panelSpotify.Controls.Add(this.metroCheckBox1);
            this.panelSpotify.Controls.Add(this.metroLabel5);
            this.panelSpotify.Controls.Add(this.metroLabel4);
            this.panelSpotify.Controls.Add(this.tbpass);
            this.panelSpotify.Controls.Add(this.tblogin);
            this.panelSpotify.Controls.Add(this.metroButton3);
            this.panelSpotify.HorizontalScrollbarBarColor = true;
            this.panelSpotify.HorizontalScrollbarHighlightOnWheel = false;
            this.panelSpotify.HorizontalScrollbarSize = 10;
            this.panelSpotify.Location = new System.Drawing.Point(477, 21);
            this.panelSpotify.Name = "panelSpotify";
            this.panelSpotify.Size = new System.Drawing.Size(470, 164);
            this.panelSpotify.TabIndex = 15;
            this.panelSpotify.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.panelSpotify.VerticalScrollbarBarColor = true;
            this.panelSpotify.VerticalScrollbarHighlightOnWheel = false;
            this.panelSpotify.VerticalScrollbarSize = 10;
            this.panelSpotify.Visible = false;
            // 
            // metroButton7
            // 
            this.metroButton7.Location = new System.Drawing.Point(64, 2);
            this.metroButton7.Name = "metroButton7";
            this.metroButton7.Size = new System.Drawing.Size(75, 23);
            this.metroButton7.TabIndex = 13;
            this.metroButton7.Text = "metroButton7";
            this.metroButton7.UseSelectable = true;
            this.metroButton7.Visible = false;
            this.metroButton7.Click += new System.EventHandler(this.metroButton7_Click);
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.Checked = true;
            this.metroCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox2.Location = new System.Drawing.Point(151, 124);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(121, 15);
            this.metroCheckBox2.TabIndex = 12;
            this.metroCheckBox2.Text = "Создать плейлист";
            this.metroCheckBox2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox2.UseSelectable = true;
            // 
            // metroButton6
            // 
            this.metroButton6.Location = new System.Drawing.Point(42, 127);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(75, 23);
            this.metroButton6.TabIndex = 11;
            this.metroButton6.Text = "Отмена";
            this.metroButton6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton6.UseSelectable = true;
            this.metroButton6.Click += new System.EventHandler(this.buttonCancelSpoti_Click);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(172, 7);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(117, 19);
            this.metroLabel7.TabIndex = 10;
            this.metroLabel7.Text = "Spotify настройки";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(11, 96);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(135, 19);
            this.metroLabel6.TabIndex = 9;
            this.metroLabel6.Text = "Название плейлиста";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tbPlName
            // 
            // 
            // 
            // 
            this.tbPlName.CustomButton.Image = null;
            this.tbPlName.CustomButton.Location = new System.Drawing.Point(144, 1);
            this.tbPlName.CustomButton.Name = "";
            this.tbPlName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbPlName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbPlName.CustomButton.TabIndex = 1;
            this.tbPlName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbPlName.CustomButton.UseSelectable = true;
            this.tbPlName.CustomButton.Visible = false;
            this.tbPlName.Lines = new string[] {
        "Default"};
            this.tbPlName.Location = new System.Drawing.Point(152, 95);
            this.tbPlName.MaxLength = 32767;
            this.tbPlName.Name = "tbPlName";
            this.tbPlName.PasswordChar = '\0';
            this.tbPlName.PromptText = "Название плейлиста";
            this.tbPlName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbPlName.SelectedText = "";
            this.tbPlName.SelectionLength = 0;
            this.tbPlName.SelectionStart = 0;
            this.tbPlName.ShortcutsEnabled = true;
            this.tbPlName.Size = new System.Drawing.Size(166, 23);
            this.tbPlName.TabIndex = 8;
            this.tbPlName.Text = "Default";
            this.tbPlName.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tbPlName.UseSelectable = true;
            this.tbPlName.WaterMark = "Название плейлиста";
            this.tbPlName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbPlName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Checked = true;
            this.metroCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox1.Location = new System.Drawing.Point(369, 95);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(84, 15);
            this.metroCheckBox1.TabIndex = 7;
            this.metroCheckBox1.Text = "Запомнить";
            this.metroCheckBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox1.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(11, 66);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(54, 19);
            this.metroLabel5.TabIndex = 6;
            this.metroLabel5.Text = "Пароль";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(11, 38);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(47, 19);
            this.metroLabel4.TabIndex = 5;
            this.metroLabel4.Text = "Логин";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tbpass
            // 
            // 
            // 
            // 
            this.tbpass.CustomButton.Image = null;
            this.tbpass.CustomButton.Location = new System.Drawing.Point(348, 1);
            this.tbpass.CustomButton.Name = "";
            this.tbpass.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbpass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbpass.CustomButton.TabIndex = 1;
            this.tbpass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbpass.CustomButton.UseSelectable = true;
            this.tbpass.CustomButton.Visible = false;
            this.tbpass.Lines = new string[] {
        "VItalik007"};
            this.tbpass.Location = new System.Drawing.Point(83, 66);
            this.tbpass.MaxLength = 32767;
            this.tbpass.Name = "tbpass";
            this.tbpass.PasswordChar = '*';
            this.tbpass.PromptText = "Пароль от Spotify";
            this.tbpass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbpass.SelectedText = "";
            this.tbpass.SelectionLength = 0;
            this.tbpass.SelectionStart = 0;
            this.tbpass.ShortcutsEnabled = true;
            this.tbpass.Size = new System.Drawing.Size(370, 23);
            this.tbpass.TabIndex = 4;
            this.tbpass.Text = "VItalik007";
            this.tbpass.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tbpass.UseSelectable = true;
            this.tbpass.WaterMark = "Пароль от Spotify";
            this.tbpass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbpass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tblogin
            // 
            // 
            // 
            // 
            this.tblogin.CustomButton.Image = null;
            this.tblogin.CustomButton.Location = new System.Drawing.Point(348, 1);
            this.tblogin.CustomButton.Name = "";
            this.tblogin.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tblogin.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tblogin.CustomButton.TabIndex = 1;
            this.tblogin.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tblogin.CustomButton.UseSelectable = true;
            this.tblogin.CustomButton.Visible = false;
            this.tblogin.Lines = new string[] {
        "fdaada"};
            this.tblogin.Location = new System.Drawing.Point(83, 37);
            this.tblogin.MaxLength = 32767;
            this.tblogin.Name = "tblogin";
            this.tblogin.PasswordChar = '\0';
            this.tblogin.PromptText = "Логин от Spotify";
            this.tblogin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tblogin.SelectedText = "";
            this.tblogin.SelectionLength = 0;
            this.tblogin.SelectionStart = 0;
            this.tblogin.ShortcutsEnabled = true;
            this.tblogin.Size = new System.Drawing.Size(370, 23);
            this.tblogin.TabIndex = 3;
            this.tblogin.Text = "fdaada";
            this.tblogin.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tblogin.UseSelectable = true;
            this.tblogin.WaterMark = "Логин от Spotify";
            this.tblogin.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tblogin.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(348, 127);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(75, 23);
            this.metroButton3.TabIndex = 2;
            this.metroButton3.Text = "Начать";
            this.metroButton3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.buttonStartSpoti_Click);
            // 
            // metroButton8
            // 
            this.metroButton8.Location = new System.Drawing.Point(353, 21);
            this.metroButton8.Name = "metroButton8";
            this.metroButton8.Size = new System.Drawing.Size(75, 23);
            this.metroButton8.TabIndex = 16;
            this.metroButton8.Text = "metroButton8";
            this.metroButton8.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton8.UseSelectable = true;
            this.metroButton8.Visible = false;
            this.metroButton8.Click += new System.EventHandler(this.metroButton8_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 579);
            this.Controls.Add(this.metroButton8);
            this.Controls.Add(this.panelSpotify);
            this.Controls.Add(this.buttonMakePlaylist);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonAllList);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.toggleIsFav);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.buttongetTitle);
            this.Controls.Add(this.listBox);
            this.MinimumSize = new System.Drawing.Size(506, 374);
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Record Radio Worker";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSpotify.ResumeLayout(false);
            this.panelSpotify.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ListBox listBox;
        private MetroFramework.Controls.MetroButton buttongetTitle;
        private MetroFramework.Controls.MetroButton metroButton2;
        public System.Windows.Forms.ListBox listBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroToggle toggleIsFav;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton metroButton5;
        private MetroFramework.Controls.MetroButton buttonAllList;
        private MetroFramework.Controls.MetroProgressBar progressBar;
        private MetroFramework.Controls.MetroButton buttonSettings;
        private MetroFramework.Controls.MetroButton buttonMakePlaylist;
        private MetroFramework.Controls.MetroPanel panelSpotify;
        private MetroFramework.Controls.MetroButton metroButton6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox tbPlName;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox tbpass;
        private MetroFramework.Controls.MetroTextBox tblogin;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
        private MetroFramework.Controls.MetroButton metroButton7;
        private MetroFramework.Controls.MetroButton metroButton8;
    }
}

