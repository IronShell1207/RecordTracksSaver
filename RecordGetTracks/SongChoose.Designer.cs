namespace RecordGetTracks
{
    partial class SongChoose
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
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.panemSOngs = new MetroFramework.Controls.MetroPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.labeltr = new MetroFramework.Controls.MetroLabel();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(646, -1);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(143, 29);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "Пропустить трек";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // panemSOngs
            // 
            this.panemSOngs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panemSOngs.HorizontalScrollbarBarColor = true;
            this.panemSOngs.HorizontalScrollbarHighlightOnWheel = false;
            this.panemSOngs.HorizontalScrollbarSize = 10;
            this.panemSOngs.Location = new System.Drawing.Point(20, 60);
            this.panemSOngs.Name = "panemSOngs";
            this.panemSOngs.Size = new System.Drawing.Size(789, 487);
            this.panemSOngs.TabIndex = 1;
            this.panemSOngs.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.panemSOngs.VerticalScrollbarBarColor = true;
            this.panemSOngs.VerticalScrollbarHighlightOnWheel = false;
            this.panemSOngs.VerticalScrollbarSize = 10;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.metroButton2);
            this.metroPanel2.Controls.Add(this.labeltr);
            this.metroPanel2.Controls.Add(this.metroButton1);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(20, 547);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(789, 28);
            this.metroPanel2.TabIndex = 2;
            this.metroPanel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // labeltr
            // 
            this.labeltr.AutoSize = true;
            this.labeltr.Location = new System.Drawing.Point(2, 5);
            this.labeltr.Name = "labeltr";
            this.labeltr.Size = new System.Drawing.Size(103, 19);
            this.labeltr.TabIndex = 2;
            this.labeltr.Text = "Искомый трек: ";
            this.labeltr.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(497, -1);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(143, 29);
            this.metroButton2.TabIndex = 3;
            this.metroButton2.Text = "Нет подходящего";
            this.metroButton2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // SongChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 595);
            this.Controls.Add(this.panemSOngs);
            this.Controls.Add(this.metroPanel2);
            this.Name = "SongChoose";
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Выбери наиболее подходящий трек";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroPanel panemSOngs;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel labeltr;
        private MetroFramework.Controls.MetroButton metroButton2;
    }
}