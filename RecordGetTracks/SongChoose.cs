using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecordGetTracks
{
    public partial class SongChoose : MetroFramework.Forms.MetroForm
    {
        public int ReturnValue1 { get; set; }
        private List<MetroLabel> mpnls;
        private List<string> SongNames;
        public SongChoose(List<string> songnames, string NeededSong)
        {
            InitializeComponent();
            SongNames = songnames;
            labeltr.Text = $"Искомый трек: {NeededSong}";
            mpnls = new List<MetroLabel> { };
            foreach (string song in songnames)
            {
                panemSOngs.Controls.Add(panelSongs(song.Replace("\r\n"," - ")));
            }
           
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private MetroPanel panelSongs(string songname)
        {
            MetroPanel _p = new MetroPanel()
            {
                Size = new Size(360, 28),
                Dock = DockStyle.Top,
                Theme = MetroFramework.MetroThemeStyle.Dark,
                BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            };
            MetroLabel lb = new MetroLabel()
            {
                Theme = MetroFramework.MetroThemeStyle.Dark,
                Dock = DockStyle.Fill,
                FontSize = MetroFramework.MetroLabelSize.Tall,
                Text = songname,
                Cursor = Cursors.Hand,
            };
            lb.Click += Lb_Click;
            _p.Controls.Add(lb);
            mpnls.Add(lb);
            return _p;
        }
        private void Lb_Click(object sender, EventArgs e)
        {
            var tn = sender as MetroLabel;
            var indx = mpnls.FindIndex(x => x == tn);
            ReturnValue1 = indx+1;
            DialogResult= DialogResult.OK;
            Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
