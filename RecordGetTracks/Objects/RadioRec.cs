using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyData;
using RadioData;

namespace RecordGetTracks
{
    public class RadioRec // ОСНОВНОЙ КЛасс радио станций ВКЛЮЧАЮЩИЙ Список треков.!!
    {
        private List<Track> _tracksList;
        public string Name { get; set; }
        public string LinkTracksList { get; set; }
        public bool isFavorite { get; set; }
        public string DateLoadedTracks { get; set; }
        public List<Track> TracksList // список треков, пусть тоже записывается в json с датой создания
        {
            get
            {
                if (_tracksList != null)
                    return _tracksList;
                _tracksList = new List<Track> { };
                return _tracksList;
            }
            set =>
                _tracksList = value;
        }

    }
}
