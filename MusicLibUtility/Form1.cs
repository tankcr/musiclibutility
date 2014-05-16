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
        List<string> extensions = new List<string>();
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
            //string statestring = null;
            //int state = ((int)itunes.PlayerState);
            //if (state < 1) { statestring = "Stopped"; };
            //if (state == 1) { statestring = "Playing"; };

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            backgroundWorker2.Dispose();
            backgroundWorker3.Dispose();
            backgroundWorker1.WorkerSupportsCancellation = true;
            label6.Text = null;
            label7.Text = null;
            
            {

                string filepath = label4.Text;
                DirectoryInfo rootDir = new DirectoryInfo(filepath);

                foreach (string ext in extensions)
                {
                    try
                    {
                        filesacc = rootDir.GetFiles(ext);
                        if (ext == "*.mp3")
                        { label5.Text = "MP3 Audio"; }
                        else if (ext == "*.m4a")
                        { label5.Text = "iTunes AAC Audio"; }
                        else if (ext == "*.m4b")
                        { label5.Text = "iTunes Audio Book"; }
                        else if (ext == "*.m4v")
                        { label5.Text = "iTunes Video"; }
                        else if (ext == "*.m4p")
                        { label5.Text = "iTunes Protected Audio"; }
                        else if (ext == "*.flac")
                        { label5.Text = "Lossless Flac Audio"; }
                        else if (ext == "*.wav")
                        { label5.Text = "Windows Audio"; }
                        else if (ext == "*.mp4")
                        { label5.Text = "Mp4 Audio/Video"; }
                    }
                    catch (UnauthorizedAccessException)
                    { }
                    if (filesacc != null)
                    {
                        foreach (FileInfo fi in filesacc)
                        { 
                            files.Add(fi.FullName.ToString());
                            label8.Text = fi.FullName;
                        }
                    }
                    subDirs = rootDir.GetDirectories();
                    foreach (DirectoryInfo dirInfo in subDirs)
                    {
                        try
                        {
                            foreach (string GFI in Directory.GetFiles(dirInfo.FullName, ext, SearchOption.AllDirectories))
                            {
                                label7.Text = Path.GetDirectoryName(GFI);
                                label8.Text = Path.GetFileName(GFI);
                                files.Add(GFI);
                                label7.Text = "Directory";
                                label8.Text = "File";
                            }
                        }
                        catch (UnauthorizedAccessException) { }
                    }

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

        private void label6_Click(object sender, EventArgs e)
        {
            label6.Text = "";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            pictureBox3.Image = null;     
            label8.Text = "Complete";
            backgroundWorker1.CancelAsync();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            try 
            {             
                Process.Start(@label7.Text.ToString()); 
            }
            catch { }
        }

        private void label5_Click(object sender, EventArgs e)
        {

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
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            backgroundWorker1.CancelAsync();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

         private void label13_Click(object sender, EventArgs e)
        {
        
        }
        private void comboBox1_Paint(object sender, EventArgs e)
         {

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

        private void dataGridView1_Load(object sender, DataGridViewCellEventArgs e)
        { 
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

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
            {
                //Nothing Here! this is just so your the app doesn't blow up if iTunes is busy. instead it will just try again in 1 second
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            itunes.NextTrack();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            itunes.BackTrack();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click_2(object sender, EventArgs e)
        {

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
        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

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
                        int rowcount = MLTable.Rows.Count;;
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
                    comboBox1.Text = "Library File Inaccessible";
                    comboBox1.Enabled = false;
                    lbl_numsongs.Text = null;
                    MLTable = null;
                    dataGridView1.DataSource = MLTable;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            { extensions.Add("*.mp3"); }
            if (checkBox1.Checked == false)
            { extensions.Remove("*.mp3"); }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            { extensions.Add("*.mp4"); }
            if (checkBox2.Checked == false)
            { extensions.Remove("*.mp4"); }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            { extensions.Add("*.m4a"); }
            if (checkBox3.Checked == false)
            { extensions.Remove("*.m4a"); }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            { extensions.Add("*.m4v"); }
            if (checkBox4.Checked == false)
            { extensions.Remove("*.m4v"); }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            { extensions.Add("*.m4p"); }
            if (checkBox5.Checked == false)
            { extensions.Remove("*.m4p"); }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            { extensions.Add("*.m4b"); }
            if (checkBox6.Checked == false)
            { extensions.Remove("*.m4b"); }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            { extensions.Add("*.flac"); }
            if (checkBox7.Checked == false)
            { extensions.Remove("*.false"); }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            { extensions.Add("*.wav"); }
            if (checkBox8.Checked == false)
            { extensions.Remove("*.wav"); }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
