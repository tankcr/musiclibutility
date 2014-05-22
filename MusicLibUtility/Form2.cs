using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTunesLib;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MusicLibUtility
{
    public partial class Form2 : Form
    {
        string currfilePath;
        string currDirPath;
        FileInfo fi;
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        public static class NativeMethods
        {
            //Winm WindowsSound
            [DllImport("winmm.dll")]
            
internal static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
            [DllImport("winmm.dll")]
            internal static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);
        }

        public static iTunesAppClass itunes = new iTunesAppClass();
        iTunesApp itunesApp = new iTunesLib.iTunesApp();
        public Form2()
        {
            InitializeComponent();
            try
            { label17.Text = itunes.CurrentTrack.Name; }
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
                label1.Text = itunes.CurrentTrack.Album;
            }
            catch
            { }
            if (itunes.CurrentTrack.Rating == 0)
            {
                pictureBox4.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox5.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox6.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox7.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox8.Image = MusicLibUtility.Properties.Resources.rate_blank;

            }
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
            catch { }
            try
            {
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
                catch
                {
                    int albumart = 0;
                    panel7.BackgroundImage = MusicLibUtility.Properties.Resources.nocover1;
                }
            }
            catch { }
            var myiTunes = new iTunesAppClass();
            itunesApp.OnPlayerPlayEvent += new _IiTunesEvents_OnPlayerPlayEventEventHandler(itunesApp_OnPlayerPlayEvent);
            if ((int)itunes.PlayerState == 0)
            {
                button5.Image = MusicLibUtility.Properties.Resources.playTrans;
            }

            else if ((int)itunes.PlayerState == 1)
            {
                button5.Image = MusicLibUtility.Properties.Resources.pauseTrans;
            }
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
                    string temp = (currDirPath + "\\temp.jpg");
                    artwork.Save(temp);

                    Process.Start(@temp);
                }
            }
            catch { int albumart = 0; }
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
        private void itunesApp_OnPlayerPlayEvent(object iTrack)
        {
            IITTrack currentTrack = (IITTrack)iTrack;
            string playerstate = itunes.PlayerState.ToString();
            string trackName = currentTrack.Name;
            string artist = currentTrack.Artist;
            string album = currentTrack.Album;
            label17.Text = trackName;
            label14.Text = artist;
            label1.Text = itunes.CurrentTrack.Album;
            if (itunes.CurrentTrack.Rating == 0)
            { 
                pictureBox4.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox5.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox6.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox7.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox8.Image = MusicLibUtility.Properties.Resources.rate_blank;
            
            }
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

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@currDirPath);
            }
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.rate_highlight;
        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            if (itunes.CurrentTrack.Rating == 0)
            {
                pictureBox4.Image = MusicLibUtility.Properties.Resources.rate_blank;
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Image = MusicLibUtility.Properties.Resources.rate_highlight;
            pictureBox5.Image = MusicLibUtility.Properties.Resources.rate_highlight;
            pictureBox6.Image = MusicLibUtility.Properties.Resources.rate_highlight;
            pictureBox7.Image = MusicLibUtility.Properties.Resources.rate_highlight;
        }
        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            if (itunes.CurrentTrack.Rating == 0)
            {
                pictureBox4.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox5.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox6.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox7.Image = MusicLibUtility.Properties.Resources.rate_blank;
            }
        }
        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Image = MusicLibUtility.Properties.Resources.rate_highlight;
            pictureBox5.Image = MusicLibUtility.Properties.Resources.rate_highlight;
            pictureBox6.Image = MusicLibUtility.Properties.Resources.rate_highlight;
        }
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            if (itunes.CurrentTrack.Rating == 0)
            {
                pictureBox4.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox5.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox6.Image = MusicLibUtility.Properties.Resources.rate_blank;
            }
        }
        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Image = MusicLibUtility.Properties.Resources.rate_highlight;
            pictureBox5.Image = MusicLibUtility.Properties.Resources.rate_highlight;
        }
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            if (itunes.CurrentTrack.Rating == 0)
            {
                pictureBox4.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox5.Image = MusicLibUtility.Properties.Resources.rate_blank;
            }
        }
        private void pictureBox8_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.Image = MusicLibUtility.Properties.Resources.rate_highlight;
            pictureBox5.Image = MusicLibUtility.Properties.Resources.rate_highlight;
            pictureBox6.Image = MusicLibUtility.Properties.Resources.rate_highlight;
            pictureBox7.Image = MusicLibUtility.Properties.Resources.rate_highlight;
            pictureBox8.Image = MusicLibUtility.Properties.Resources.rate_highlight;
        }
        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            if (itunes.CurrentTrack.Rating == 0)
            {
                pictureBox4.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox5.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox6.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox7.Image = MusicLibUtility.Properties.Resources.rate_blank;
                pictureBox8.Image = MusicLibUtility.Properties.Resources.rate_blank;
            }
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            uint CurrVol = ushort.MaxValue / 2;
            NativeMethods.waveOutGetVolume(IntPtr.Zero, out CurrVol);
            ushort CalcVol = (ushort)(CurrVol & 0x0000ffff);
            int NewVolume = ((ushort.MaxValue / 100) * trackBar1.Value);
            uint NewVolumeAllChannels = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
            NativeMethods.waveOutSetVolume(IntPtr.Zero, NewVolumeAllChannels);
            label1.Text = Convert.ToString("Volume: " + trackBar1.Value + "%");
        }
    }

}

