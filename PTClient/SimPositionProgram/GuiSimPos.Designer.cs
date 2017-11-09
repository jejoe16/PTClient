namespace PeopleTrackingC.SimPosition
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
            this.SetPosition.Location = new System.Drawing.Point(651, 85);
            this.SetPosition.Name = "SetPosition";
            this.SetPosition.Size = new System.Drawing.Size(75, 23);
            this.SetPosition.TabIndex = 1;
            this.SetPosition.Text = "Set Position";
            this.SetPosition.UseVisualStyleBackColor = true;
            this.SetPosition.Click += new System.EventHandler(this.SetPosition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(621, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lat:";
            // 
            // latLabel
            // 
            this.latLabel.AutoSize = true;
            this.latLabel.Location = new System.Drawing.Point(662, 198);
            this.latLabel.Name = "latLabel";
            this.latLabel.Size = new System.Drawing.Size(0, 13);
            this.latLabel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(612, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Long:";
            // 
            // longLabel
            // 
            this.longLabel.AutoSize = true;
            this.longLabel.Location = new System.Drawing.Point(662, 233);
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
            this.label4.Location = new System.Drawing.Point(621, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Current Position";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(601, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Use rightclick to navigate on the map\r\n";
            // 
            // GuiSimPos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.longLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.latLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SetPosition);
            this.Controls.Add(this.gMapSim);
            this.Name = "GuiSimPos";
            this.Text = "GuiSimPos";
            this.Load += new System.EventHandler(this.OnLoad);
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
    }
}