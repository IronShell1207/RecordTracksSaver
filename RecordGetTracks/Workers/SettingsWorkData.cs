using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordGetTracks
{
    public class SettingsWorkData
    {
        
       
    }
    public class SettingsM
    {
        private static string _chromePath;
        public static string ChromePath
        {
            get
            {
                if (_chromePath != null)
                    return _chromePath;
                return null;
            }
            set
            {
                _chromePath = value;
            }
        }
    }
}
