using MetroFramework.Controls;
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
                ToolStripMenuItem file = new ToolStripMenuItem("В файл") { BackColor = Color.FromArgb(20, 20, 20), ForeColor = Color.Silver };
                ToolStripMenuItem download = new ToolStripMenuItem("Скачать плейлист с youtube") { BackColor = Color.FromArgb(20, 20, 20), ForeColor = Color.Silver };
                download.Click += Download_Click;
                spoti.Click += ExSpotiOpen;
                file.Click += File_Click;

                _ctxExport.Items.AddRange(new[] { spoti,file, download });
                return _ctxExport;
            }
        }

        private void Download_Click(object sender, EventArgs e)
        {
            PanelSwitcher(form.panelDownladTracks);
        }

        private void File_Click(object sender, EventArgs e)
        {
            PanelSwitcher(form.panelExportFile);
            form.tbSaveName.PromptText = form.listBox.SelectedItem.ToString();
            form.tbSavePath.PromptText = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void ExSpotiOpen(object sender, EventArgs e)
        {
            PanelSwitcher(form.panelSpotiMain);

        }
        private void SettsOpen(object sender, EventArgs e)
        {
           // form.panelShoweer(form.panelSettings);
            using (var formSets = new FormSettings(form))
            {
                var result = formSets.ShowDialog();
                if (DialogResult.Cancel==result)
                {
                    form.RefreshTheme();
                }
            }
        }
        private void PanelSwitcher(object panel )
        {
            List<MetroPanel> panels = new List<MetroPanel> { form.panelSpotiMain, form.panelDownladTracks, form.panelExportFile, form.panelRecMain };
            foreach (MetroPanel pnl in panels)
                if (pnl != panel as MetroPanel)
                    pnl.Visible = false;
                else if (pnl == panel as MetroPanel)
                {
                    pnl.Visible = true;
                    pnl.Dock = DockStyle.Fill;
                }
        }
    }
}
