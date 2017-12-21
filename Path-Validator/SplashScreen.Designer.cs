namespace Path_Validator
{
    partial class SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.pb_loading = new System.Windows.Forms.PictureBox();
            this.SplahProgress = new System.Windows.Forms.ProgressBar();
            this.SplashClock = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_loading)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_loading
            // 
            this.pb_loading.BackColor = System.Drawing.Color.Transparent;
            this.pb_loading.Image = global::Path_Validator.Properties.Resources.Denner_Parreiras___Logo;
            this.pb_loading.Location = new System.Drawing.Point(31, 52);
            this.pb_loading.Name = "pb_loading";
            this.pb_loading.Size = new System.Drawing.Size(496, 225);
            this.pb_loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_loading.TabIndex = 0;
            this.pb_loading.TabStop = false;
            // 
            // SplahProgress
            // 
            this.SplahProgress.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.SplahProgress.Location = new System.Drawing.Point(12, 361);
            this.SplahProgress.Name = "SplahProgress";
            this.SplahProgress.Size = new System.Drawing.Size(538, 10);
            this.SplahProgress.TabIndex = 1;
            // 
            // SplashClock
            // 
            this.SplashClock.Enabled = true;
            this.SplashClock.Tick += new System.EventHandler(this.SplashClock_Tick);
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BackgroundImage = global::Path_Validator.Properties.Resources.back;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(562, 383);
            this.ControlBox = false;
            this.Controls.Add(this.SplahProgress);
            this.Controls.Add(this.pb_loading);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Path Validator by Denner Parreiras";
            ((System.ComponentModel.ISupportInitialize)(this.pb_loading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_loading;
        private System.Windows.Forms.ProgressBar SplahProgress;
        private System.Windows.Forms.Timer SplashClock;
    }
}