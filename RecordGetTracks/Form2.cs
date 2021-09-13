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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var rc = new Rectangle(0, 0, this.ClientSize.Width, Height);
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                rc,
                Color.FromArgb(255, Color.Black),
                Color.FromArgb(20, Color.Black),
                -90f))
            {
                e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                e.Graphics.FillRectangle(brush, rc);
            }
        }
    }
}
