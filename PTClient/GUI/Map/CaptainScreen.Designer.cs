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
            this.WorkerLocations = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SimPos = new System.Windows.Forms.Button();
            this.Emergency = new System.Windows.Forms.Button();
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
            this.WorkerLocations.Size = new System.Drawing.Size(208, 343);
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
            // Emergency
            // 
            this.Emergency.Location = new System.Drawing.Point(622, 414);
            this.Emergency.Name = "Emergency";
            this.Emergency.Size = new System.Drawing.Size(206, 23);
            this.Emergency.TabIndex = 18;
            this.Emergency.Text = "Emergency";
            this.Emergency.UseVisualStyleBackColor = true;
            this.Emergency.Click += new System.EventHandler(this.button2_Click);
            // 
            // CaptainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 561);
            this.Controls.Add(this.SimPos);
            this.Controls.Add(this.Emergency);
            this.Controls.Add(this.WorkerLocations);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gmap);
            this.Name = "CaptainScreen";
            this.Text = "Overview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CaptainScreen_FormClosing);
            this.Load += new System.EventHandler(this.Onload);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private Button buttonCheckin;
        private Button buttonCheckout;
        private ContextMenuStrip contextMenuStrip1;
        private Button button1;
        private ListView WorkerLocations;
        private HelpProvider helpProvider1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button SimPos;
        private Button Emergency;

    }

}
