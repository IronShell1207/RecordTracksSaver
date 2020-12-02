using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Components;

namespace RecordGetTracks
{
    public partial class FormSettings : MetroFramework.Forms.MetroForm
    {
        public object ReturnValue1 { get; set; }
        public FormSettings(MetroStyleManager mmsm)
        { 
            InitializeComponent();
            mSM.Style = mmsm.Style;
            mSM.Theme = mmsm.Theme;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
