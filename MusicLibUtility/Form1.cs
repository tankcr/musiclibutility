using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using TagLib;
using System.Xml.Serialization;
using iTunesLib;
using System.Xml;
using System.Xml.Linq;
using System.Diagnostics;

namespace MusicLibUtility
{
    
    public partial class Form1 : Form
    {
        private BackgroundWorker worker = new BackgroundWorker();
        private AutoResetEvent _resetEvent = new AutoResetEvent(false);
        public static iTunesAppClass itunes = new iTunesAppClass();
        iTunesApp itunesApp = new iTunesLib.iTunesApp();
        public static IITLibraryPlaylist mainLibrary = itunes.LibraryPlaylist;
        public static IITTrackCollection ittracks = mainLibrary.Tracks;
        List<string> folders = new List<string>();
        List<string> files = new List<string>();
        List<string> musicfiles = new List<string>();
        List<string> badfiles = new List<string>();
        List<string> songlist = new List<string>();
        FileInfo[] filesacc = null;
        DirectoryInfo[] subDirs = null;
        string currfilePath;
        string currDirPath;
        DataTable MLTable;
        DataTable badTable;
        //List<string> extensions = new List<string>();
        
        public Form1()
        {
            InitializeComponent();
            try
            {label17.Text = itunes.CurrentTrack.Name;}
            catch
            { }
            try
            { 
                label14.Text = itunes.CurrentTrack.Artist;
            }
            catch
            { }
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
                            currfilePath = file.Location;
                            currDirPath = fi.Directory.ToString();
                        }
                        else
                            currfilePath = "not found " + file.Location;
                    }
                }
                label13.Text = currfilePath;
            }
            catch{}
            try 
            { 
                try { 
                        var file = TagLib.File.Create(currfilePath);
                        if (file.Tag.Pictures.Length >= 1)
                        {
                            var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                            panel7.BackgroundImage = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(95, 95, null, IntPtr.Zero);
                        }
                        else { int albumart = 0; panel7.BackgroundImage = MusicLibUtility.Properties.Resources.nocover1; }
                    }
                catch 
                { 
                    int albumart = 0;
                    panel7.BackgroundImage = MusicLibUtility.Properties.Resources.nocover1; 
                }
            }
            catch { }
            var myiTunes = new iTunesAppClass();
            this.pictureBox1.Image = Properties.Resources.skinitunes;
            itunesApp.OnPlayerPlayEvent += new _IiTunesEvents_OnPlayerPlayEventEventHandler(itunesApp_OnPlayerPlayEvent);       
            dataGridView1.DataSource = dataTable1;
            backgroundWorker4.RunWorkerAsync();

        }

        private void itunesApp_OnPlayerPlayEvent(object iTrack)
        {
            IITTrack currentTrack = (IITTrack)iTrack;
            string playerstate = itunes.PlayerState.ToString();
            string trackName = currentTrack.Name;
            string artist = currentTrack.Artist;
            string album = currentTrack.Album;
            label17.Text = trackName;
            label14.Text = artist;
            if (itunes.CurrentTrack.Kind == ITTrackKind.ITTrackKindFile)
            {
                IITFileOrCDTrack file = (IITFileOrCDTrack)itunes.CurrentTrack;
                if (file.Location != null)
                {
                    FileInfo fi = new FileInfo(file.Location);
                    if (fi.Exists)
                    {
                        currfilePath = file.Location;
                        currDirPath = fi.Directory.ToString();
                    }
                    else
                        currfilePath = "not found " + file.Location;
                }
            }
            label13.Text = currfilePath;
            try
            { panel7.BackgroundImage.Dispose(); }
            catch { }
                try
                {
                    var file = TagLib.File.Create(currfilePath);
                    if (file.Tag.Pictures.Length >= 1)
                    {
                        var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                        panel7.BackgroundImage = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(95, 95, null, IntPtr.Zero);
                    }
                    else { int albumart = 0; panel7.BackgroundImage = MusicLibUtility.Properties.Resources.nocover1; }
                }
                catch { int albumart = 0; panel7.BackgroundImage = MusicLibUtility.Properties.Resources.nocover1; }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = itunes.LibraryXMLPath;
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void folderPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.label4.Text = folderBrowserDialog1.SelectedPath;
                string dir = label4.Text;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            iTunesAppClass itunes = new iTunesAppClass();
            string iTXMLPath = itunes.LibraryXMLPath;
            label1.Text = iTXMLPath;
            label4.Text = Path.GetDirectoryName(iTXMLPath);
            if (!backgroundWorker4.IsBusy)
            { backgroundWorker4.RunWorkerAsync(); }
            if ((int)itunes.PlayerState == 0)
            {
                button5.Image = MusicLibUtility.Properties.Resources.playTrans; 
            }
            
            else if ((int)itunes.PlayerState == 1)
            {
                button5.Image = MusicLibUtility.Properties.Resources.pauseTrans;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Application.DoEvents();
            label6.Text = null;
            label11.Text = null;
            label12.Text = null;
            pictureBox4.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox3.Image = null;
            pictureBox5.Image = null;
            pictureBox8.Image = null;
            pictureBox1.Image = Properties.Resources.running;
            string filepath = label4.Text;
            DirectoryInfo rootDir = new DirectoryInfo(filepath);
//            string[] allfiles = Directory.GetFiles(rootDir.FullName, "*.*", SearchOption.AllDirectories);
//            foreach (string filename in allfiles) { System.Diagnostics.Debug.WriteLine(filename + " "); }
//            string extensionstring = extensions.ToString();
//            System.IO.File.WriteAllLines(@filepath + "\\testfiles.txt", allfiles);

            if (!backgroundWorker1.IsBusy)
            { backgroundWorker1.RunWorkerAsync(); }
            pictureBox3.Image = Properties.Resources.scanning;
            if (!backgroundWorker2.IsBusy)
            { backgroundWorker2.RunWorkerAsync(); }
            if (!backgroundWorker3.IsBusy)
            { backgroundWorker3.RunWorkerAsync(); }
            if (!backgroundWorker7.IsBusy)
            { backgroundWorker7.RunWorkerAsync(); }

            //label6.Text = "Task Completed";
            //this.pictureBox1.Image = Properties.Resources.skinitunes;

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string filepath = label4.Text;
            DirectoryInfo rootDir = new DirectoryInfo(filepath);
            label7.Text = rootDir.FullName;
            Control.CheckForIllegalCrossThreadCalls = false;
            backgroundWorker2.Dispose();
            backgroundWorker3.Dispose();
            backgroundWorker1.WorkerSupportsCancellation = true;
            label6.Text = null;
            System.Diagnostics.Debug.WriteLine(Directory.GetDirectories(filepath)+ " ");
            System.Diagnostics.Debug.WriteLine(rootDir + " ");
            string[] allfiles = null;
            string[] Dirs = null;
            RecursiveFileSearch rfs = new RecursiveFileSearch();
            rfs.FullDirList(rootDir,"*");
//            rfs.dirInfo;
            foreach (string s in rfs.log)
            {
                Console.WriteLine(s);
            }
            // Keep the console window open in debug mode.
            List<FileInfo>filelist = rfs.Files;
//            try
//            { Dirs = Directory.GetDirectories(filepath); }
//            catch (UnauthorizedAccessException) { }


//            try
//            {
//                allfiles = Directory.GetFiles(rootDir.FullName, "*.*", SearchOption.AllDirectories);
//            }
//            catch (UnauthorizedAccessException) { };
            //foreach (string filename in allfiles) { System.Diagnostics.Debug.WriteLine(filename + " "); }
            string extensionstring = extensions.ToString();
//           System.IO.File.WriteAllLines(@filepath + "\\testfiles.txt", allfiles);
            foreach (KeyValuePair<string, string> ext in extensions)
            {
                System.IO.File.WriteAllText(@filepath + "\\testext.txt", ext.ToString());
                foreach (FileInfo file in filelist)
                {
                    FileInfo fi = file;
                    label8.Text = Path.GetFileName(file.FullName+file.Name);
                    if (extensions.ContainsKey(fi.Extension))
                    {
                        files.Add(fi.FullName.ToString()); label8.Text = fi.FullName;
                        System.IO.File.WriteAllText("@C:\test.txt", files.ToString());
                    }
                }
                foreach (string GFI in files)
                {
                    label7.Text = Path.GetDirectoryName(GFI);
                    label8.Text = Path.GetFileName(GFI);
                    label7.Text = "Directory";
                    label8.Text = "File";
                }
            }
            this.pictureBox3.Image = null;
            Int32 filecount = files.Count;
            label7.Text = "Directories";
            this.pictureBox4.Image = Properties.Resources.music16;
            pictureBox5.Image = MusicLibUtility.Properties.Resources.scanning;
            this.pictureBox1.Image = Properties.Resources.skinitunes;
            label11.Text = "Preparing to scan for corupt media files";
            Thread.Sleep(2000);

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            pictureBox3.Image = null;     
            label8.Text = "Complete";

        }

        private void label7_Click(object sender, EventArgs e)
        {
            try 
            {             
                Process.Start(@label7.Text.ToString()); 
            }
            catch { }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {

                label6.Text = "Your Directories are Being Scanned";
                Thread.Sleep(200);

                label6.Text = "Your Directories are Being Scanned.";
                Thread.Sleep(200);

                label6.Text = "Your Directories are Being Scanned..";
                Thread.Sleep(200);

                label6.Text = "Your Directories are Being Scanned...";
                Thread.Sleep(200);

                label6.Text = "Your Directories are Being Scanned....";
                Thread.Sleep(200);
            }
            while (backgroundWorker1.IsBusy);
            label6.Text = "Directory Scan Complete " + files.Count.ToString() + " Media Files located";
            string ITPlaypat = "ITPlayerState";
            int state = ((int)itunes.PlayerState);
            string statestring = null;
            if (state < 1) { statestring = "Stopped"; };
            if (state == 1) { statestring = "Playing"; };
            if (state == 1)
            {
                do
                {
                    label17.Text = ("Pausing iTunes to maintain file integrity");
                    itunes.Pause();
                    state = (int)itunes.PlayerState;
                }
                while (state == 1);
            }
            if (state < 1) { statestring = "Stopped"; };
            if (state == 1) { statestring = "Playing"; };

            //label5.Text = "Itunes is now " + Regex.Replace(itunes.PlayerState.ToString(), ITPlaypat, "");

            pictureBox1.Image = Properties.Resources.running;
            foreach (string file in files)
            {
                label8.Text = "Scanning "+ file;
                try { string taglibfile = TagLib.File.Create(file).Tag.Title; musicfiles.Add(file); Console.WriteLine(taglibfile); }
                catch { badfiles.Add(file); }
            }
            XDocument baddoc = new XDocument
            (new XElement("Corrupt",
               badfiles.Select(badfile =>
               new XElement("File", badfile))));
            baddoc.Save(label4.Text + "\\badfiles.xml");
        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            pictureBox5.Image = null;
            pictureBox6.Image = Properties.Resources.music16;
            backgroundWorker2.CancelAsync();

        }
        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {

            do { Thread.Sleep(800); }
            while (backgroundWorker1.IsBusy);
            do
            {

                label11.Text = "Scanning For Corrupt Files";
                Thread.Sleep(200);
                label11.Text = "Scanning For Corrupt Files.";
                Thread.Sleep(200);
                label11.Text = "Scanning For Corrupt Files..";
                Thread.Sleep(200);
                label11.Text = "Scanning For Corrupt Files...";
                Thread.Sleep(200);
                label11.Text = "Scanning For Corrupt Files....";
                Thread.Sleep(200);
            }
            while (backgroundWorker2.IsBusy);
            pictureBox5.Image = null;
            pictureBox6.Image = Properties.Resources.music16;
            label11.Text = badfiles.Count + " Corrupt Files Found";
            pictureBox8.Image = MusicLibUtility.Properties.Resources.scanning;
            XDocument doc = new XDocument();
            XElement songsElement = new XElement("Songs");
            foreach (var musicfile in musicfiles)
            {
                XElement songElement = new XElement("Song");
                string songTitle;
                try { songTitle = (TagLib.File.Create(musicfile).Tag.Title); }
                catch { songTitle = "Missing"; }
                uint songTNint;
                try { songTNint = (TagLib.File.Create(musicfile).Tag.Track); }
                catch { songTNint = 00; }
                string songTN = songTNint.ToString();
                string songPath = musicfile;
                string songArtist;
                try { songArtist = (TagLib.File.Create(musicfile).Tag.Performers[0]); }
                catch { songArtist = "Missing"; }
                List<string> songGenres = new List<string>();
                foreach (string Genre in (TagLib.File.Create(musicfile).Tag.Genres))
                { songGenres.Add(Genre); }
                string songGenre;
                if (songGenres.Count > 1) { songGenre = (songGenres[0] + "/" + songGenres[1]); }
                else { try { songGenre = songGenres[0]; } catch { songGenre = "Missing"; } }
                //songGenre = string.Join(songGenres.Select(songGenre=>songGenre+"/"));
                songArtist = Regex.Replace(songArtist, @"[^\u0020-\u007E]", string.Empty);
                //songlist.Add("Adding "+songTitle+", Artist "+songArtist+", at path "+songPath+" to DirLib file.");
                XElement titleElement = new XElement("Title", songTitle);
                XElement tnElement = new XElement("Track", songTN);
                XElement pathElement = new XElement("Path", musicfile);
                XElement artistElement = new XElement("Artist", songArtist);
                XElement genreElement = new XElement("Genre", songGenre);
                songElement.Add(titleElement);
                songElement.Add(tnElement);
                songElement.Add(pathElement);
                songElement.Add(artistElement);
                songElement.Add(genreElement);
                songsElement.Add(songElement);
            }
            //System.IO.File.WriteAllLines(@libraryPath+"\\WriteLines.txt", songlist);    
            doc.Add(songsElement);
            doc.Save(label4.Text + "\\DirLib.xml");
            itunes.Play();
        }
        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            pictureBox8.Image = null;
            pictureBox7.Image = Properties.Resources.music16;
            label12.Text = "Media Library Database Created";
            pictureBox1.Image = MusicLibUtility.Properties.Resources.skinitunes;
            backgroundWorker3.CancelAsync();


        }

        private void button2_Click(object sender, EventArgs e)
        {         
            backgroundWorker1.CancelAsync();
        }
              
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text.ToString() == "iTunes Playlists")
            {
                comboBox1.Enabled = true;
                string playlist = comboBox1.SelectedItem.ToString();
                foreach (IITPlaylist pl in itunes.LibrarySource.Playlists)
                {
                    if (pl.Name == playlist)
                    {
                        GetTracks(pl);
                        break;
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        //    IITPlaylistCollection selection = 
        }
        private void GetTracks(IITPlaylist playlist)
        {
            long totalfilesize = 0;
            dataTable1.Rows.Clear();
            IITTrackCollection tracks = playlist.Tracks;
            int numTracks = tracks.Count;
            for (int currTrackIndex = 1; currTrackIndex <= numTracks; currTrackIndex++)
            {
                DataRow drnew = dataTable1.NewRow();
                IITTrack currTrack = tracks[currTrackIndex];
                if (currTrack.Artist == null) { drnew["artist"] = "missing"; } else { drnew["artist"] = currTrack.Artist; }
                if (currTrack.Name == null) { drnew["song name"] = "missing"; } else { drnew["song name"] = currTrack.Name; }
                drnew["album"] = currTrack.Album;
                drnew["genre"] = currTrack.Genre;


                if (currTrack.Kind == ITTrackKind.ITTrackKindFile)
                {
                    IITFileOrCDTrack file = (IITFileOrCDTrack)currTrack;
                    if (file.Location != null)
                    {
                        FileInfo fi = new FileInfo(file.Location);
                        if (fi.Exists)
                        {
                            drnew["FileLocation"] = file.Location;
                            totalfilesize += fi.Length;
                        }
                        else
                            drnew["FileLocation"] = "not found " + file.Location;
                    }
                }

                dataTable1.Rows.Add(drnew);
            }
            Control.CheckForIllegalCrossThreadCalls = false;
            lbl_numsongs.Text = dataTable1.Rows.Count.ToString() + " Songs" + ", " + (totalfilesize / 1024.00 / 1024.00).ToString("###,### mb");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            backgroundWorker8.RunWorkerAsync();
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            backgroundWorker4.WorkerSupportsCancellation = true;
            foreach (IITPlaylist pl in itunes.LibrarySource.Playlists)
            {
                comboBox1.Items.Add(pl.Name);
            }
        }
        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker5.IsBusy)
            { backgroundWorker5.RunWorkerAsync(); }
        }
        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {
            IITPlaylist playlist = itunes.LibraryPlaylist;
            {
                long totalfilesize = 0;
                dataTable1.Rows.Clear();
                IITTrackCollection tracks = playlist.Tracks;
                int numTracks = tracks.Count;
                for (int currTrackIndex = 1; currTrackIndex <= numTracks; currTrackIndex++)
                {
                    DataRow drnew = dataTable1.NewRow();
                    IITTrack currTrack = tracks[currTrackIndex];
                    if (currTrack.Artist == null) { drnew["artist"] = "missing"; } else { drnew["artist"] = currTrack.Artist; }
                    if (currTrack.Name == null) { drnew["song name"] = "missing"; } else { drnew["song name"] = currTrack.Name; }
                    drnew["album"] = currTrack.Album;
                    drnew["genre"] = currTrack.Genre;


                    if (currTrack.Kind == ITTrackKind.ITTrackKindFile)
                    {
                        IITFileOrCDTrack file = (IITFileOrCDTrack)currTrack;
                        if (file.Location != null)
                        {
                            FileInfo fi = new FileInfo(file.Location);
                            if (fi.Exists)
                            {
                                drnew["FileLocation"] = file.Location;
                                totalfilesize += fi.Length;
                            }
                            else
                                drnew["FileLocation"] = "not found " + file.Location;
                        }
                    }

                    dataTable1.Rows.Add(drnew);
                }
                Control.CheckForIllegalCrossThreadCalls = false;
                lbl_numsongs.Text = dataTable1.Rows.Count.ToString() + " Songs" + ", " + (totalfilesize / 1024.00 / 1024.00).ToString("###,### mb");
            }
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            string playerstate = itunes.PlayerState.ToString();
            if (playerstate == "ITPlayerStatePlaying")
            {
                itunes.Pause();
                button5.Image = MusicLibUtility.Properties.Resources.playTrans;
                //label5.Text = "iTunes is now Paused";
                playerstate = null;
            }
            else if (playerstate == "ITPlayerStateStopped")
            {
                itunes.Play();
                button5.Image = MusicLibUtility.Properties.Resources.pauseTrans;
                //label5.Text = "iTunes is now Playing";
                playerstate = null;
            }

            
        }

        private void label17_Click(object sender, EventArgs e)
        {
            try
            { label17.Text = itunes.CurrentTrack.Name; }
            catch
            { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            itunes.NextTrack();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            itunes.BackTrack();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            try
            {
                var file = TagLib.File.Create(currfilePath);
                if (file.Tag.Pictures.Length >= 1)
                {
                    var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                    Image artwork = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(400, 400, null, IntPtr.Zero);
                    string temp = (label4.Text + "\\temp.jpg");
                    artwork.Save(temp);

                    Process.Start(@temp);
                }
            }
            catch { int albumart = 0; }
        }

        private void label13_Click_3(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@currDirPath);
            }
            catch
            { }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@currDirPath);
            }
            catch
            { }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            try
            { Process.Start(label4.Text + "\\badfiles.xml"); }
            catch { }
        }

        private void backgroundWorker7_DoWork(object sender, DoWorkEventArgs e)
        {
            do {Thread.Sleep(800);}
            while (backgroundWorker1.IsBusy);
            do { Thread.Sleep(800); }
            while (backgroundWorker2.IsBusy);
            do { 
            label12.Text = "Creating Media File Report";
            }
            while(backgroundWorker3.IsBusy);
            label12.Text = "Media Library Database Created";
            pictureBox8.Image = null;
            pictureBox7.Image = Properties.Resources.music16;
            pictureBox1.Image = MusicLibUtility.Properties.Resources.skinitunes;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                try { dataTable1.Rows.Clear(); }
                catch { }
                try { MLTable.Rows.Clear(); }
                catch { }
                try { badTable.Rows.Clear(); }
                catch { }


                if (comboBox2.SelectedItem.ToString() == "iTunes Playlists")
                {
                    comboBox1.Enabled = true;
                    comboBox1.Text = "Playlists";
                    dataGridView1.DataSource = dataTable1;
                }
                else if (comboBox2.SelectedItem.ToString() == "Media Library Database")
                {
                    comboBox1.Enabled = false;
                    comboBox1.Text = "Media Files";
                    lbl_numsongs.Text = null;
                    try
                    {
                        MLDataset.Clear();
                        this.MLDataset.ReadXml(this.label4.Text + "\\DirLib.xml");
                    }
                    catch { }
                    try
                    {
                        DataTable MLTable = MLDataset.Tables[0];
                        int rowcount = MLTable.Rows.Count; ;
                        lbl_numsongs.Text = rowcount.ToString();
                        dataGridView1.DataSource = MLTable;
                    }
                    catch
                    {
                        comboBox1.Text = "Library File Inaccessible";
                        dataTable1.Rows.Clear();
                    }
                    comboBox1.Enabled = false;
                }
                else if (comboBox2.SelectedItem.ToString() == "iTunes Database Backup")
                {
                    comboBox1.Enabled = false;
                    comboBox1.Text = "iTunes Library";
                    lbl_numsongs.Text = null;
                    try
                    {
                        MLDataset.Clear();
                        this.MLDataset.ReadXml(this.label4.Text + "\\ItunesLib.xml");
                    }
                    catch { }
                    try
                    {
                        DataTable MLTable = MLDataset.Tables[0];
                        int rowcount = MLTable.Rows.Count; ;
                        lbl_numsongs.Text = rowcount.ToString();
                        dataGridView1.DataSource = MLTable;
                    }
                    catch
                    {
                        comboBox1.Text = "Library File Inaccessible";
                        dataTable1.Rows.Clear();
                    }
                    comboBox1.Enabled = false;
                }

                else if (comboBox2.SelectedItem.ToString() == "Bad Media Files")
                {
                    comboBox1.Enabled = false;
                    lbl_numsongs.Text = null;
                    try
                    {
                        comboBox1.Text = "Corrupt Media Files";
                        BadMediaDataset.Clear();
                        this.BadMediaDataset.ReadXml(this.label4.Text + "\\badfiles.xml");
                    }
                    catch { }
                    try
                    {
                        DataTable badTable = BadMediaDataset.Tables[0];
                        dataGridView1.DataSource = badTable;
                    }
                    catch
                    {
                        comboBox1.Text = "Library File Inaccessible";
                        dataTable1.Rows.Clear();
                    }
                    comboBox1.Enabled = false;
                }
            }
        }
        
        Dictionary<string, string> extensions = new Dictionary<string, string>();     
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) extensions["*.mp3"] = "MP3 Audio"; else extensions.Remove("*.mp3");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) extensions["*.mp4"] = "MP4 Audio/Video"; else extensions.Remove("*.mp4");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) extensions["*.m4a"] = "iTunes Audio"; else extensions.Remove("*.m4a");
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) extensions["*.m4v"] = "iTunes Video"; else extensions.Remove("*.m4a");
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) extensions["*.m4p"] = "iTunes Protected Audio"; else extensions.Remove("*.m4p");
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) extensions["*.m4b"] = "iTunes Audio Book"; else extensions.Remove("*.m4b");
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) extensions["*.flac"] = "Lossless Audio"; else extensions.Remove("*.flac");
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) extensions["*.wav"] = "Windows Audio/Video"; else extensions.Remove("*.wav");
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2
            {
                Text = "Media Player",
                Location = new Point(Right, Top),
                StartPosition = FormStartPosition.Manual,
            };
            form2.Show();
        }

        private void backgroundWorker8_DoWork(object sender, DoWorkEventArgs e)
        {
            {
                XDocument doc = new XDocument();
                XElement songsElement = new XElement("Songs");
                IITPlaylist playlist = itunes.LibraryPlaylist;
                IITTrackCollection tracks = playlist.Tracks;
                int numtracks = tracks.Count;
                char[] delimiters = new char[] { ' ', '\\', '/' };
                for (int currtrackindex = 1; currtrackindex <= numtracks; currtrackindex++)
                {
                    IITTrack currTrack = tracks[currtrackindex];
                    string songPath;
                    try 
                    { 
                        IITFileOrCDTrack file = (IITFileOrCDTrack)currTrack;
                        songPath = file.Location.ToString();
                    }
                    catch { songPath = "Missing"; }
                    XElement songElement = new XElement("Song");
                     string songTitle;
                    try { songTitle = currTrack.Name; }
                    catch { songTitle = "Missing"; }
                    int songTNint;
                    try { songTNint = (currTrack.TrackNumber); }
                    catch { songTNint = 00; }
                    string songTN = songTNint.ToString();
                    string songArtist;
                    try { songArtist = (currTrack.Artist); }
                    catch { songArtist = "Missing"; }
                    string songGenre;
                    List<string> songGenres = new List<string>();
                    try
                    {
                        string G = currTrack.Genre.ToString();
                        string[] Genres = G.Split(delimiters);
                        foreach (string Genre in Genres)
                        { songGenres.Add(Genre); }
                    }
                    catch { songGenre = "Missing"; };
                    if (songGenres.Count > 1) { songGenre = (songGenres[0] + "/" + songGenres[1]); }
                    else { try { songGenre = songGenres[0]; } catch { songGenre = "Missing"; } }
                    //songGenre = string.Join(songGenres.Select(songGenre=>songGenre+"/"));
                    try
                    {
                        songArtist = Regex.Replace(songArtist, @"[^\u0020-\u007E]", string.Empty);
                    }
                    catch { };
                    //songlist.Add("Adding "+songTitle+", Artist "+songArtist+", at path "+songPath+" to DirLib file.");
                    XElement titleElement = new XElement("Title", songTitle);
                    XElement tnElement = new XElement("Track", songTN);
                    XElement pathElement = new XElement("Path", songPath);
                    XElement artistElement = new XElement("Artist", songArtist);
                    XElement genreElement = new XElement("Genre", songGenre);
                    songElement.Add(titleElement);
                    songElement.Add(tnElement);
                    songElement.Add(pathElement);
                    songElement.Add(artistElement);
                    songElement.Add(genreElement);
                    songsElement.Add(songElement);
                }

                //pictureBox5.Image = null;
                //pictureBox6.Image = Properties.Resources.music16;
                //label11.Text = badfiles.Count + " Corrupt Files Found";
                //pictureBox8.Image = MusicLibUtility.Properties.Resources.scanning;
                //System.IO.File.WriteAllLines(@libraryPath+"\\WriteLines.txt", songlist);    
                doc.Add(songsElement);
                doc.Save(label4.Text + "\\ItunesLib.xml");
            }
        }

        private void backgroundWorker9_DoWork(object sender, DoWorkEventArgs e)
        {
            
            do { Thread.Sleep(800); }
            while (backgroundWorker8.IsBusy);
        }
    }

}
