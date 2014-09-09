using System;
using System.Text;
using iTunesLib;
using System.IO;

namespace MusicLibUtility
{
    public class CurrTrack
    {
        public string trackPath;
        public string dirPath;
        public string playerstate;
        public string trackName;
        public string artist;
        public string album;
    }
    
    public class Currtracks
    {
        public event EventHandler TrackChanged;
        private CurrTrack _currTrack;
        public CurrTrack currTrack
        {
            get { return _currTrack; }
            set
            {
                _currTrack = value;
                if (TrackChanged != null)
                {
                    TrackChanged(this, EventArgs.Empty);
                }
            }
        }

        public partial class GetiTunestrack
        {
            public static iTunesAppClass itunes = new iTunesAppClass();
            iTunesApp itunesApp = new iTunesLib.iTunesApp();

            public static Currtracks GetTrackInfo()
            {
                Currtracks curtracks = new Currtracks();
                CurrTrack curtrack;
                {
                try
                {
                    if (itunes.CurrentTrack.Kind == ITTrackKind.ITTrackKindFile)
                    {
                        IITFileOrCDTrack file = (IITFileOrCDTrack)itunes.CurrentTrack;
                        if (file.Location != null)
                        {
                            FileInfo fi = new FileInfo(file.Location);
                            if (fi.Exists)
                            {
                                curtrack = new CurrTrack();
                                curtrack.trackName = file.Name;
                                curtrack.trackPath = file.Location;
                                curtrack.dirPath = fi.Directory.ToString();
                                curtrack.album = file.Album;
                                curtrack.artist = file.Artist;
                                curtrack.playerstate = itunes.PlayerState.ToString();
                                curtracks._currTrack = curtrack;
                            }
                            else
                            {
                                curtrack = new CurrTrack();
                                curtrack.trackPath = "not found " + file.Location;
                                curtracks._currTrack = curtrack;
                            }
                        }
                    }
                }
                catch { }
                return curtracks;
            }
        }
        }
    }
}
