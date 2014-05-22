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
    
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.folderPath = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.lbl_numsongs = new System.Windows.Forms.Label();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker5 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker6 = new System.ComponentModel.BackgroundWorker();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.button10 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker7 = new System.ComponentModel.BackgroundWorker();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.MLDataset = new System.Data.DataSet();
            this.BadMediaDataset = new System.Data.DataSet();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker8 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker9 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MLDataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BadMediaDataset)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "None";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Current Itunes Library";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 90);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "iTunes Controls";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(205)))), ((int)(((byte)(209)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.button9);
            this.panel5.Controls.Add(this.button8);
            this.panel5.Controls.Add(this.pictureBox16);
            this.panel5.Controls.Add(this.button5);
            this.panel5.Controls.Add(this.pictureBox17);
            this.panel5.Location = new System.Drawing.Point(6, 19);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(148, 65);
            this.panel5.TabIndex = 18;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.BackgroundImage = global::MusicLibUtility.Properties.Resources.back;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.Location = new System.Drawing.Point(8, 10);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(39, 30);
            this.button9.TabIndex = 19;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = global::MusicLibUtility.Properties.Resources.next;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.Location = new System.Drawing.Point(98, 10);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(39, 30);
            this.button8.TabIndex = 18;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // pictureBox16
            // 
            this.pictureBox16.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox16.BackgroundImage")));
            this.pictureBox16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox16.Location = new System.Drawing.Point(0, -2);
            this.pictureBox16.MaximumSize = new System.Drawing.Size(5, 0);
            this.pictureBox16.MinimumSize = new System.Drawing.Size(5, 100);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(5, 100);
            this.pictureBox16.TabIndex = 9;
            this.pictureBox16.TabStop = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.Location = new System.Drawing.Point(53, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(39, 30);
            this.button5.TabIndex = 0;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox17
            // 
            this.pictureBox17.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox17.BackgroundImage")));
            this.pictureBox17.Location = new System.Drawing.Point(1, -2);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(144, 10);
            this.pictureBox17.TabIndex = 17;
            this.pictureBox17.TabStop = false;
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.button3.Location = new System.Drawing.Point(120, 73);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "Backup";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.button4.Location = new System.Drawing.Point(10, 73);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 23;
            this.button4.Text = "Repair";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(739, 194);
            this.comboBox1.MaximumSize = new System.Drawing.Size(175, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(159, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 22;
            this.comboBox1.Text = "Please Select Option";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(26, 16);
            this.label6.MinimumSize = new System.Drawing.Size(305, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(305, 16);
            this.label6.TabIndex = 10;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label11.Location = new System.Drawing.Point(26, 39);
            this.label11.MinimumSize = new System.Drawing.Size(305, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(305, 16);
            this.label11.TabIndex = 14;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label12.Location = new System.Drawing.Point(26, 65);
            this.label12.MinimumSize = new System.Drawing.Size(305, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(305, 16);
            this.label12.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(5, 69);
            this.label8.MaximumSize = new System.Drawing.Size(280, 16);
            this.label8.MinimumSize = new System.Drawing.Size(280, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(280, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Media Files";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(6, 28);
            this.label7.MaximumSize = new System.Drawing.Size(280, 16);
            this.label7.MinimumSize = new System.Drawing.Size(280, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(280, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Directories";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Media Files";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Directories";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel4);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 475);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Media Management";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(205)))), ((int)(((byte)(209)))));
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.checkBox8);
            this.panel6.Controls.Add(this.checkBox7);
            this.panel6.Controls.Add(this.checkBox6);
            this.panel6.Controls.Add(this.checkBox5);
            this.panel6.Controls.Add(this.checkBox4);
            this.panel6.Controls.Add(this.checkBox3);
            this.panel6.Controls.Add(this.checkBox2);
            this.panel6.Controls.Add(this.checkBox1);
            this.panel6.Controls.Add(this.pictureBox18);
            this.panel6.Controls.Add(this.pictureBox19);
            this.panel6.Location = new System.Drawing.Point(9, 20);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(290, 97);
            this.panel6.TabIndex = 23;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(178, 40);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(46, 17);
            this.checkBox8.TabIndex = 27;
            this.checkBox8.Text = "wav";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(178, 17);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(43, 17);
            this.checkBox7.TabIndex = 26;
            this.checkBox7.Text = "flac";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(98, 63);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(46, 17);
            this.checkBox6.TabIndex = 25;
            this.checkBox6.Text = "m4b";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(98, 40);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(46, 17);
            this.checkBox5.TabIndex = 24;
            this.checkBox5.Text = "m4p";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(98, 17);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(46, 17);
            this.checkBox4.TabIndex = 23;
            this.checkBox4.Text = "m4v";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(12, 63);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(46, 17);
            this.checkBox3.TabIndex = 22;
            this.checkBox3.Text = "m4a";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 40);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(46, 17);
            this.checkBox2.TabIndex = 21;
            this.checkBox2.Text = "mp4";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 17);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(46, 17);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "mp3";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pictureBox18
            // 
            this.pictureBox18.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox18.BackgroundImage")));
            this.pictureBox18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox18.Location = new System.Drawing.Point(0, -2);
            this.pictureBox18.MaximumSize = new System.Drawing.Size(5, 0);
            this.pictureBox18.MinimumSize = new System.Drawing.Size(5, 100);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(5, 100);
            this.pictureBox18.TabIndex = 18;
            this.pictureBox18.TabStop = false;
            // 
            // pictureBox19
            // 
            this.pictureBox19.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox19.BackgroundImage")));
            this.pictureBox19.Location = new System.Drawing.Point(3, -2);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(290, 10);
            this.pictureBox19.TabIndex = 19;
            this.pictureBox19.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(205)))), ((int)(((byte)(209)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.pictureBox14);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.pictureBox15);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(9, 364);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(290, 103);
            this.panel4.TabIndex = 22;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox14.BackgroundImage")));
            this.pictureBox14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox14.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox14.MaximumSize = new System.Drawing.Size(5, 0);
            this.pictureBox14.MinimumSize = new System.Drawing.Size(5, 100);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(5, 100);
            this.pictureBox14.TabIndex = 18;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox15.BackgroundImage")));
            this.pictureBox15.Location = new System.Drawing.Point(0, 0);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(290, 10);
            this.pictureBox15.TabIndex = 10;
            this.pictureBox15.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(205)))), ((int)(((byte)(209)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pictureBox11);
            this.panel2.Controls.Add(this.pictureBox9);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(9, 238);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 103);
            this.panel2.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(166, 52);
            this.label5.MaximumSize = new System.Drawing.Size(120, 16);
            this.label5.MinimumSize = new System.Drawing.Size(120, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "File Type";
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox11.BackgroundImage")));
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox11.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox11.MaximumSize = new System.Drawing.Size(5, 0);
            this.pictureBox11.MinimumSize = new System.Drawing.Size(5, 100);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(5, 100);
            this.pictureBox11.TabIndex = 18;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox9.BackgroundImage")));
            this.pictureBox9.Location = new System.Drawing.Point(0, 0);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(290, 10);
            this.pictureBox9.TabIndex = 10;
            this.pictureBox9.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(205)))), ((int)(((byte)(209)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox10);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.folderPath);
            this.panel1.Location = new System.Drawing.Point(9, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 104);
            this.panel1.TabIndex = 14;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(0, -2);
            this.pictureBox2.MaximumSize = new System.Drawing.Size(5, 0);
            this.pictureBox2.MinimumSize = new System.Drawing.Size(5, 100);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(5, 100);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox10.BackgroundImage")));
            this.pictureBox10.Location = new System.Drawing.Point(1, -2);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(290, 10);
            this.pictureBox10.TabIndex = 17;
            this.pictureBox10.TabStop = false;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.button2.Location = new System.Drawing.Point(183, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Halt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Directory to Scan";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label4.Location = new System.Drawing.Point(86, 35);
            this.label4.MinimumSize = new System.Drawing.Size(185, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Scan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // folderPath
            // 
            this.folderPath.Location = new System.Drawing.Point(5, 31);
            this.folderPath.Name = "folderPath";
            this.folderPath.Size = new System.Drawing.Size(75, 23);
            this.folderPath.TabIndex = 3;
            this.folderPath.Text = "Path";
            this.folderPath.UseVisualStyleBackColor = true;
            this.folderPath.Click += new System.EventHandler(this.folderPath_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(342, 238);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(556, 364);
            this.dataGridView1.TabIndex = 1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5});
            this.dataTable1.TableName = "Table1";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Song Name";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Artist";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Album";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Genre";
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "FileLocation";
            // 
            // lbl_numsongs
            // 
            this.lbl_numsongs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_numsongs.AutoSize = true;
            this.lbl_numsongs.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lbl_numsongs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_numsongs.Location = new System.Drawing.Point(740, 218);
            this.lbl_numsongs.MaximumSize = new System.Drawing.Size(175, 16);
            this.lbl_numsongs.MinimumSize = new System.Drawing.Size(158, 16);
            this.lbl_numsongs.Name = "lbl_numsongs";
            this.lbl_numsongs.Size = new System.Drawing.Size(158, 16);
            this.lbl_numsongs.TabIndex = 23;
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            // 
            // backgroundWorker5
            // 
            this.backgroundWorker5.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker5_DoWork);
            // 
            // backgroundWorker6
            // 
            this.backgroundWorker6.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker6_DoWork);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label17.Location = new System.Drawing.Point(169, 16);
            this.label17.MaximumSize = new System.Drawing.Size(260, 16);
            this.label17.MinimumSize = new System.Drawing.Size(260, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(260, 16);
            this.label17.TabIndex = 18;
            this.label17.Text = "Title";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox8);
            this.groupBox3.Controls.Add(this.pictureBox5);
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.pictureBox4);
            this.groupBox3.Controls.Add(this.pictureBox7);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.pictureBox6);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(343, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(391, 90);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Running Status";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox8.ImageLocation = "";
            this.pictureBox8.Location = new System.Drawing.Point(281, 65);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(96, 16);
            this.pictureBox8.TabIndex = 18;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox5.ImageLocation = "";
            this.pictureBox5.Location = new System.Drawing.Point(281, 39);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(96, 16);
            this.pictureBox5.TabIndex = 15;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.ImageLocation = "";
            this.pictureBox3.Location = new System.Drawing.Point(281, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(96, 16);
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Location = new System.Drawing.Point(4, 16);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Location = new System.Drawing.Point(4, 65);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(16, 16);
            this.pictureBox7.TabIndex = 19;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Location = new System.Drawing.Point(4, 39);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 16);
            this.pictureBox6.TabIndex = 16;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::MusicLibUtility.Properties.Resources.skinitunes;
            this.pictureBox1.Location = new System.Drawing.Point(842, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label14.Location = new System.Drawing.Point(169, 52);
            this.label14.MaximumSize = new System.Drawing.Size(260, 16);
            this.label14.MinimumSize = new System.Drawing.Size(260, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(260, 16);
            this.label14.TabIndex = 25;
            this.label14.Text = "Artist";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::MusicLibUtility.Properties.Resources.wrkbkg;
            this.panel3.Controls.Add(this.pictureBox20);
            this.panel3.Controls.Add(this.button10);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Location = new System.Drawing.Point(12, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(550, 135);
            this.panel3.TabIndex = 26;
            // 
            // pictureBox20
            // 
            this.pictureBox20.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox20.BackgroundImage = global::MusicLibUtility.Properties.Resources.popout;
            this.pictureBox20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox20.Location = new System.Drawing.Point(508, 6);
            this.pictureBox20.MaximumSize = new System.Drawing.Size(32, 32);
            this.pictureBox20.MinimumSize = new System.Drawing.Size(32, 32);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(32, 32);
            this.pictureBox20.TabIndex = 29;
            this.pictureBox20.TabStop = false;
            this.pictureBox20.Click += new System.EventHandler(this.pictureBox20_Click);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(9, 106);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 28;
            this.button10.Text = "Open";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label13.Location = new System.Drawing.Point(90, 110);
            this.label13.MaximumSize = new System.Drawing.Size(480, 16);
            this.label13.MinimumSize = new System.Drawing.Size(180, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(180, 16);
            this.label13.TabIndex = 27;
            this.label13.Text = "Path";
            this.label13.Click += new System.EventHandler(this.label13_Click_3);
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.BackgroundImage = global::MusicLibUtility.Properties.Resources.artcover1;
            this.pictureBox12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox12.Location = new System.Drawing.Point(0, -1);
            this.pictureBox12.MaximumSize = new System.Drawing.Size(140, 140);
            this.pictureBox12.MinimumSize = new System.Drawing.Size(140, 140);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(140, 140);
            this.pictureBox12.TabIndex = 26;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Click += new System.EventHandler(this.pictureBox12_Click);
            // 
            // backgroundWorker7
            // 
            this.backgroundWorker7.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker7_DoWork);
            // 
            // comboBox2
            // 
            this.comboBox2.AllowDrop = true;
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Bad Media Files",
            "iTunes Database Backup",
            "iTunes Playlists",
            "Media Library Database"});
            this.comboBox2.Location = new System.Drawing.Point(739, 167);
            this.comboBox2.MaximumSize = new System.Drawing.Size(175, 0);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(159, 21);
            this.comboBox2.Sorted = true;
            this.comboBox2.TabIndex = 28;
            this.comboBox2.Text = "Options";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // MLDataset
            // 
            this.MLDataset.DataSetName = "NewDataSet";
            // 
            // BadMediaDataset
            // 
            this.BadMediaDataset.DataSetName = "NewDataSet";
            // 
            // panel7
            // 
            this.panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel7.Controls.Add(this.pictureBox12);
            this.panel7.Location = new System.Drawing.Point(687, 6);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(140, 140);
            this.panel7.TabIndex = 29;
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackgroundImage = global::MusicLibUtility.Properties.Resources.workingrt;
            this.pictureBox13.Location = new System.Drawing.Point(558, 0);
            this.pictureBox13.MaximumSize = new System.Drawing.Size(4, 98);
            this.pictureBox13.MinimumSize = new System.Drawing.Size(4, 98);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(4, 98);
            this.pictureBox13.TabIndex = 30;
            this.pictureBox13.TabStop = false;
            // 
            // backgroundWorker8
            // 
            this.backgroundWorker8.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker8_DoWork);
            // 
            // backgroundWorker9
            // 
            this.backgroundWorker9.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker9_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = global::MusicLibUtility.Properties.Resources.bkgrnd;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(910, 627);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lbl_numsongs);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Music Library Utility";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MLDataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BadMediaDataset)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
         private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Windows.Forms.Label lbl_numsongs;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.ComponentModel.BackgroundWorker backgroundWorker5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button folderPath;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.ComponentModel.BackgroundWorker backgroundWorker6;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox15;
        public System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.PictureBox pictureBox17;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button10;
        private System.ComponentModel.BackgroundWorker backgroundWorker7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Data.DataSet MLDataset;
        private System.Data.DataSet BadMediaDataset;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox18;
        private System.Windows.Forms.PictureBox pictureBox19;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox20;
        private BackgroundWorker backgroundWorker8;
        private BackgroundWorker backgroundWorker9;
        public Label label7;
    }
}

