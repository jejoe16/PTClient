using System;
using System.Drawing;
using System.Windows.Forms;

namespace PTClient.GUI.Map
{
    partial class CaptainScreen
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
            this.components = new System.ComponentModel.Container();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.buttonCheckin = new System.Windows.Forms.Button();
            this.buttonCheckout = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.EngineStartButton = new System.Windows.Forms.Button();
            this.EngineStopButton = new System.Windows.Forms.Button();
            this.pictureSouthEast = new System.Windows.Forms.PictureBox();
            this.pictureSouth = new System.Windows.Forms.PictureBox();
            this.pictureSouthWest = new System.Windows.Forms.PictureBox();
            this.pictureWest = new System.Windows.Forms.PictureBox();
            this.pictureNorthEast = new System.Windows.Forms.PictureBox();
            this.pictureNorthWest = new System.Windows.Forms.PictureBox();
            this.pictureEast = new System.Windows.Forms.PictureBox();
            this.pictureNorth = new System.Windows.Forms.PictureBox();
            this.WorkerLocations = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SimPos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSouthEast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSouth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSouthWest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNorthEast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNorthWest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNorth)).BeginInit();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(12, 12);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = false;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = false;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(582, 527);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 0D;
            // 
            // buttonCheckin
            // 
            this.buttonCheckin.Location = new System.Drawing.Point(0, 0);
            this.buttonCheckin.Name = "buttonCheckin";
            this.buttonCheckin.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckin.TabIndex = 0;
            // 
            // buttonCheckout
            // 
            this.buttonCheckout.Location = new System.Drawing.Point(0, 0);
            this.buttonCheckout.Name = "buttonCheckout";
            this.buttonCheckout.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckout.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(736, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Logoff";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Logout_Click);
            // 
            // EngineStartButton
            // 
            this.EngineStartButton.Location = new System.Drawing.Point(693, 360);
            this.EngineStartButton.Name = "EngineStartButton";
            this.EngineStartButton.Size = new System.Drawing.Size(65, 30);
            this.EngineStartButton.TabIndex = 5;
            this.EngineStartButton.Text = "Start";
            this.EngineStartButton.UseVisualStyleBackColor = true;
            this.EngineStartButton.Click += new System.EventHandler(this.start_Click);
            // 
            // EngineStopButton
            // 
            this.EngineStopButton.Enabled = false;
            this.EngineStopButton.Location = new System.Drawing.Point(693, 396);
            this.EngineStopButton.Name = "EngineStopButton";
            this.EngineStopButton.Size = new System.Drawing.Size(65, 28);
            this.EngineStopButton.TabIndex = 6;
            this.EngineStopButton.Text = "Stop";
            this.EngineStopButton.UseVisualStyleBackColor = true;
            this.EngineStopButton.Click += new System.EventHandler(this.stop_Click);
            // 
            // pictureSouthEast
            // 
            this.pictureSouthEast.Image = global::PTClient.Properties.Resources.arrow_southeast;
            this.pictureSouthEast.Location = new System.Drawing.Point(763, 430);
            this.pictureSouthEast.Name = "pictureSouthEast";
            this.pictureSouthEast.Size = new System.Drawing.Size(65, 64);
            this.pictureSouthEast.TabIndex = 16;
            this.pictureSouthEast.TabStop = false;
            this.pictureSouthEast.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // pictureSouth
            // 
            this.pictureSouth.Image = global::PTClient.Properties.Resources.arrow_south;
            this.pictureSouth.Location = new System.Drawing.Point(693, 430);
            this.pictureSouth.Name = "pictureSouth";
            this.pictureSouth.Size = new System.Drawing.Size(65, 64);
            this.pictureSouth.TabIndex = 15;
            this.pictureSouth.TabStop = false;
            this.pictureSouth.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // pictureSouthWest
            // 
            this.pictureSouthWest.Image = global::PTClient.Properties.Resources.arrow_southwest;
            this.pictureSouthWest.Location = new System.Drawing.Point(622, 430);
            this.pictureSouthWest.Name = "pictureSouthWest";
            this.pictureSouthWest.Size = new System.Drawing.Size(65, 64);
            this.pictureSouthWest.TabIndex = 14;
            this.pictureSouthWest.TabStop = false;
            this.pictureSouthWest.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // pictureWest
            // 
            this.pictureWest.Image = global::PTClient.Properties.Resources.arrow_west;
            this.pictureWest.Location = new System.Drawing.Point(622, 360);
            this.pictureWest.Name = "pictureWest";
            this.pictureWest.Size = new System.Drawing.Size(65, 64);
            this.pictureWest.TabIndex = 13;
            this.pictureWest.TabStop = false;
            this.pictureWest.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // pictureNorthEast
            // 
            this.pictureNorthEast.Image = global::PTClient.Properties.Resources.arrow_northeast;
            this.pictureNorthEast.Location = new System.Drawing.Point(763, 290);
            this.pictureNorthEast.Name = "pictureNorthEast";
            this.pictureNorthEast.Size = new System.Drawing.Size(65, 64);
            this.pictureNorthEast.TabIndex = 12;
            this.pictureNorthEast.TabStop = false;
            this.pictureNorthEast.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // pictureNorthWest
            // 
            this.pictureNorthWest.Image = global::PTClient.Properties.Resources.arrow_northwest;
            this.pictureNorthWest.Location = new System.Drawing.Point(622, 290);
            this.pictureNorthWest.Name = "pictureNorthWest";
            this.pictureNorthWest.Size = new System.Drawing.Size(65, 64);
            this.pictureNorthWest.TabIndex = 11;
            this.pictureNorthWest.TabStop = false;
            this.pictureNorthWest.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // pictureEast
            // 
            this.pictureEast.Image = global::PTClient.Properties.Resources.arrow_east;
            this.pictureEast.Location = new System.Drawing.Point(763, 360);
            this.pictureEast.Name = "pictureEast";
            this.pictureEast.Size = new System.Drawing.Size(65, 64);
            this.pictureEast.TabIndex = 10;
            this.pictureEast.TabStop = false;
            this.pictureEast.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // pictureNorth
            // 
            this.pictureNorth.Image = global::PTClient.Properties.Resources.arrow_north;
            this.pictureNorth.Location = new System.Drawing.Point(693, 290);
            this.pictureNorth.Name = "pictureNorth";
            this.pictureNorth.Size = new System.Drawing.Size(65, 64);
            this.pictureNorth.TabIndex = 9;
            this.pictureNorth.TabStop = false;
            this.pictureNorth.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // WorkerLocations
            // 
            this.WorkerLocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.WorkerLocations.FullRowSelect = true;
            this.WorkerLocations.GridLines = true;
            this.WorkerLocations.Location = new System.Drawing.Point(622, 55);
            this.WorkerLocations.Margin = new System.Windows.Forms.Padding(2);
            this.WorkerLocations.Name = "WorkerLocations";
            this.WorkerLocations.Size = new System.Drawing.Size(208, 222);
            this.WorkerLocations.TabIndex = 17;
            this.WorkerLocations.UseCompatibleStateImageBehavior = false;
            this.WorkerLocations.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 155;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Location";
            this.columnHeader2.Width = 154;
            // 
            // SimPos
            // 
            this.SimPos.Location = new System.Drawing.Point(636, 15);
            this.SimPos.Name = "SimPos";
            this.SimPos.Size = new System.Drawing.Size(75, 23);
            this.SimPos.TabIndex = 18;
            this.SimPos.Text = "SimPos";
            this.SimPos.UseVisualStyleBackColor = true;
            this.SimPos.Click += new System.EventHandler(this.SimPosBot_Click);
            // 
            // CaptainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 561);
            this.Controls.Add(this.SimPos);
            this.Controls.Add(this.WorkerLocations);
            this.Controls.Add(this.pictureSouthEast);
            this.Controls.Add(this.pictureSouth);
            this.Controls.Add(this.pictureSouthWest);
            this.Controls.Add(this.pictureWest);
            this.Controls.Add(this.pictureNorthEast);
            this.Controls.Add(this.pictureNorthWest);
            this.Controls.Add(this.pictureEast);
            this.Controls.Add(this.pictureNorth);
            this.Controls.Add(this.EngineStopButton);
            this.Controls.Add(this.EngineStartButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gmap);
            this.Name = "CaptainScreen";
            this.Text = "Overview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CaptainScreen_FormClosing);
            this.Load += new System.EventHandler(this.Onload);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSouthEast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSouth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSouthWest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNorthEast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNorthWest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNorth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private Button buttonCheckin;
        private Button buttonCheckout;
        private ContextMenuStrip contextMenuStrip1;
        private Button button1;
        private Button EngineStartButton;
        private Button EngineStopButton;
        private PictureBox pictureNorth;
        private PictureBox pictureEast;
        private PictureBox pictureNorthWest;
        private PictureBox pictureNorthEast;
        private PictureBox pictureWest;
        private PictureBox pictureSouthWest;
        private PictureBox pictureSouth;
        private PictureBox pictureSouthEast;
        private ListView WorkerLocations;
        private HelpProvider helpProvider1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button SimPos;
    }

}
