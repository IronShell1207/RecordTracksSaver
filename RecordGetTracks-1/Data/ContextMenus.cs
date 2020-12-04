using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecordGetTracks
{
    public class ContextMenus
    {
        Form1 form;
        public ContextMenus(object for1m)
        {
            form = for1m as Form1;

        }
        private ContextMenuStrip _ctxFile;
        private ContextMenuStrip _ctxExport;
        private ContextMenuStrip _ctxSupp;
        public ContextMenuStrip ctxFile
        {
            get
            {
                if (_ctxFile != null)
                    return _ctxFile;
                _ctxFile = new ContextMenuStrip
                {
                    BackColor = Color.FromArgb(20, 20, 20),
                    ForeColor = Color.Silver,
                    RenderMode = ToolStripRenderMode.System
                };
                ToolStripMenuItem setts = new ToolStripMenuItem("Настройки") { BackColor = Color.FromArgb(20, 20, 20), ForeColor = Color.Silver };
                ToolStripMenuItem exitBtn = new ToolStripMenuItem("Выход", null) { BackColor = Color.FromArgb(20, 20, 20), ForeColor = Color.Silver };
                setts.Click += SettsOpen;
                // ToolStripMenuItem export = new ToolStripMenuItem("Экспортировать в") { BackColor = Color.FromArgb(20, 20, 20), ForeColor = Color.Silver };
                _ctxFile.Items.AddRange(new[] { setts, exitBtn });
                return _ctxFile;
            }
        }
        public ContextMenuStrip ctxExport
        {
            get
            {
                if (_ctxExport != null)
                    return _ctxExport;
                _ctxExport = new ContextMenuStrip
                {
                    BackColor = Color.FromArgb(20, 20, 20),
                    ForeColor = Color.Silver,
                    RenderMode = ToolStripRenderMode.System
                };
                ToolStripMenuItem spoti = new ToolStripMenuItem("В Spotify") { BackColor = Color.FromArgb(20, 20, 20), ForeColor = Color.Silver };
                spoti.Click += ExSpotiOpen;
                _ctxExport.Items.AddRange(new[] { spoti });
                return _ctxExport;
            }
        }
        private void ExSpotiOpen(object sender, EventArgs e)
        {
            form.panelSpotiMain.Visible = true;
            form.panelSpotiMain.Dock = DockStyle.Fill;
            form.panelRecMain.Visible = false;

        }
        private void SettsOpen(object sender, EventArgs e)
        {
            form.panelShoweer(form.panelSettings);
        }

    }
}
