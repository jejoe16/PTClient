using System.Windows.Forms;

namespace PTClient.SimPosition
{
    partial class GuiSimPos
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
            this.gMapSim = new GMap.NET.WindowsForms.GMapControl();
            this.SetPosition = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.latLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.longLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
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
            // gMapSim
            // 
            this.gMapSim.Bearing = 0F;
            this.gMapSim.CanDragMap = true;
            this.gMapSim.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapSim.GrayScaleMode = false;
            this.gMapSim.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapSim.LevelsKeepInMemmory = 5;
            this.gMapSim.Location = new System.Drawing.Point(12, 12);
            this.gMapSim.MarkersEnabled = true;
            this.gMapSim.MaxZoom = 2;
            this.gMapSim.MinZoom = 2;
            this.gMapSim.MouseWheelZoomEnabled = true;
            this.gMapSim.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapSim.Name = "gMapSim";
            this.gMapSim.NegativeMode = false;
            this.gMapSim.PolygonsEnabled = true;
            this.gMapSim.RetryLoadTile = 0;
            this.gMapSim.RoutesEnabled = true;
            this.gMapSim.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapSim.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapSim.ShowTileGridLines = false;
            this.gMapSim.Size = new System.Drawing.Size(588, 537);
            this.gMapSim.TabIndex = 0;
            this.gMapSim.Zoom = 0D;
            // 
            // SetPosition
            // 
            this.SetPosition.Location = new System.Drawing.Point(626, 74);
            this.SetPosition.Name = "SetPosition";
            this.SetPosition.Size = new System.Drawing.Size(76, 27);
            this.SetPosition.TabIndex = 1;
            this.SetPosition.Text = "Set Position";
            this.SetPosition.UseVisualStyleBackColor = true;
            this.SetPosition.Click += new System.EventHandler(this.SetPosition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(637, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lat:";
            // 
            // latLabel
            // 
            this.latLabel.AutoSize = true;
            this.latLabel.Location = new System.Drawing.Point(668, 159);
            this.latLabel.Name = "latLabel";
            this.latLabel.Size = new System.Drawing.Size(0, 13);
            this.latLabel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(628, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Long:";
            // 
            // longLabel
            // 
            this.longLabel.AutoSize = true;
            this.longLabel.Location = new System.Drawing.Point(668, 185);
            this.longLabel.Name = "longLabel";
            this.longLabel.Size = new System.Drawing.Size(0, 13);
            this.longLabel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(615, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Position Simulation!";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(616, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Current Position";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(616, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Use rightclick to navigate on the map\r\n";
            // 
            // EngineStartButton
            // 
            this.EngineStartButton.Location = new System.Drawing.Point(697, 403);
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
            this.EngineStopButton.Location = new System.Drawing.Point(697, 439);
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
            this.pictureSouthEast.Location = new System.Drawing.Point(767, 473);
            this.pictureSouthEast.Name = "pictureSouthEast";
            this.pictureSouthEast.Size = new System.Drawing.Size(65, 64);
            this.pictureSouthEast.TabIndex = 16;
            this.pictureSouthEast.TabStop = false;
            this.pictureSouthEast.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // pictureSouth
            // 
            this.pictureSouth.Image = global::PTClient.Properties.Resources.arrow_south;
            this.pictureSouth.Location = new System.Drawing.Point(697, 473);
            this.pictureSouth.Name = "pictureSouth";
            this.pictureSouth.Size = new System.Drawing.Size(65, 64);
            this.pictureSouth.TabIndex = 15;
            this.pictureSouth.TabStop = false;
            this.pictureSouth.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // pictureSouthWest
            // 
            this.pictureSouthWest.Image = global::PTClient.Properties.Resources.arrow_southwest;
            this.pictureSouthWest.Location = new System.Drawing.Point(626, 473);
            this.pictureSouthWest.Name = "pictureSouthWest";
            this.pictureSouthWest.Size = new System.Drawing.Size(65, 64);
            this.pictureSouthWest.TabIndex = 14;
            this.pictureSouthWest.TabStop = false;
            this.pictureSouthWest.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // pictureWest
            // 
            this.pictureWest.Image = global::PTClient.Properties.Resources.arrow_west;
            this.pictureWest.Location = new System.Drawing.Point(626, 403);
            this.pictureWest.Name = "pictureWest";
            this.pictureWest.Size = new System.Drawing.Size(65, 64);
            this.pictureWest.TabIndex = 13;
            this.pictureWest.TabStop = false;
            this.pictureWest.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // pictureNorthEast
            // 
            this.pictureNorthEast.Image = global::PTClient.Properties.Resources.arrow_northeast;
            this.pictureNorthEast.Location = new System.Drawing.Point(767, 333);
            this.pictureNorthEast.Name = "pictureNorthEast";
            this.pictureNorthEast.Size = new System.Drawing.Size(65, 64);
            this.pictureNorthEast.TabIndex = 12;
            this.pictureNorthEast.TabStop = false;
            this.pictureNorthEast.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // pictureNorthWest
            // 
            this.pictureNorthWest.Image = global::PTClient.Properties.Resources.arrow_northwest;
            this.pictureNorthWest.Location = new System.Drawing.Point(626, 333);
            this.pictureNorthWest.Name = "pictureNorthWest";
            this.pictureNorthWest.Size = new System.Drawing.Size(65, 64);
            this.pictureNorthWest.TabIndex = 11;
            this.pictureNorthWest.TabStop = false;
            this.pictureNorthWest.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // pictureEast
            // 
            this.pictureEast.Image = global::PTClient.Properties.Resources.arrow_east;
            this.pictureEast.Location = new System.Drawing.Point(767, 403);
            this.pictureEast.Name = "pictureEast";
            this.pictureEast.Size = new System.Drawing.Size(65, 64);
            this.pictureEast.TabIndex = 10;
            this.pictureEast.TabStop = false;
            this.pictureEast.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // pictureNorth
            // 
            this.pictureNorth.Image = global::PTClient.Properties.Resources.arrow_north;
            this.pictureNorth.Location = new System.Drawing.Point(697, 333);
            this.pictureNorth.Name = "pictureNorth";
            this.pictureNorth.Size = new System.Drawing.Size(65, 64);
            this.pictureNorth.TabIndex = 9;
            this.pictureNorth.TabStop = false;
            this.pictureNorth.Click += new System.EventHandler(this.pictureBoxDir_Click);
            // 
            // GuiSimPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 561);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.longLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.latLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SetPosition);
            this.Controls.Add(this.gMapSim);
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
            this.Name = "GuiSimPos";
            this.Text = "GuiSimPos";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSouthEast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSouth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSouthWest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNorthEast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNorthWest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNorth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapSim;
        private System.Windows.Forms.Button SetPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label latLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label longLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
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
    }
}