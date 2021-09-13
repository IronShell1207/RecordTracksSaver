using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RadioData;

namespace RecordGetTracks
{
    public class ControlsWorker
    {
        public void CreateListRadios(bool isFavorite, ListBox listBox)
        {
            listBox.Invoke(new Action(() => listBox.Items.Clear()));
            if (isFavorite)
                foreach (RadioRec radios in RadioLists.StationsList)
                {
                    if (radios.isFavorite) listBox.Invoke(new Action(() => listBox.Items.Add(radios.Name + " 💙")));
                }
            else if (!isFavorite)
                foreach (RadioRec radios in RadioLists.StationsList)
                {
                    listBox.Invoke(new Action(() => listBox.Items.Add(radios.Name + (radios.isFavorite ? " 💙" : ""))));
                }
        }
        void addLoadingPanel(object form)
        {

        }
    }
}
