using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordGetTracks
{
    public class RadioList
    {
        private static List<RadioRec> _stationList;
        public static List<RadioRec> StationsList
        {
            get
            {
                if (_stationList != null)
                    return _stationList;
                try
                {
                    _stationList = JsnWorker1.ReadJsnFile();
                    return _stationList;
                }
                catch (Exception ex) { }
                if (_stationList != null)
                    return _stationList;
                _stationList = new List<RadioRec> { };
                return _stationList;
            }
            set
            {
                _stationList = value;
            }
        }
    }
}
