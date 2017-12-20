namespace Path_Validator
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.tb_Urls = new System.Windows.Forms.TextBox();
            this.gb_Options = new System.Windows.Forms.GroupBox();
            this.SelectDirectoryButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_Arquivo = new System.Windows.Forms.RadioButton();
            this.rb_Varredura = new System.Windows.Forms.RadioButton();
            this.rb_WEB = new System.Windows.Forms.RadioButton();
            this.labelDiretorioPai = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.tb_DiretorioPai = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.LogoLabel = new System.Windows.Forms.Label();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.MainProgress = new System.Windows.Forms.ProgressBar();
            this.fb_DiretorioPai = new System.Windows.Forms.FolderBrowserDialog();
            this.gb_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_Urls
            // 
            this.tb_Urls.AcceptsReturn = true;
            this.tb_Urls.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.tb_Urls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Urls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Urls.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Urls.Location = new System.Drawing.Point(12, 98);
            this.tb_Urls.Multiline = true;
            this.tb_Urls.Name = "tb_Urls";
            this.tb_Urls.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Urls.Size = new System.Drawing.Size(376, 393);
            this.tb_Urls.TabIndex = 1;
            // 
            // gb_Options
            // 
            this.gb_Options.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Options.BackColor = System.Drawing.Color.Transparent;
            this.gb_Options.Controls.Add(this.MainProgress);
            this.gb_Options.Controls.Add(this.SelectDirectoryButton);
            this.gb_Options.Controls.Add(this.label1);
            this.gb_Options.Controls.Add(this.rb_Arquivo);
            this.gb_Options.Controls.Add(this.rb_Varredura);
            this.gb_Options.Controls.Add(this.rb_WEB);
            this.gb_Options.Controls.Add(this.labelDiretorioPai);
            this.gb_Options.Controls.Add(this.label3);
            this.gb_Options.Controls.Add(this.SaveButton);
            this.gb_Options.Controls.Add(this.RunButton);
            this.gb_Options.Controls.Add(this.OpenButton);
            this.gb_Options.Controls.Add(this.tb_DiretorioPai);
            this.gb_Options.ForeColor = System.Drawing.Color.White;
            this.gb_Options.Location = new System.Drawing.Point(394, 98);
            this.gb_Options.Name = "gb_Options";
            this.gb_Options.Size = new System.Drawing.Size(291, 393);
            this.gb_Options.TabIndex = 2;
            this.gb_Options.TabStop = false;
            this.gb_Options.Text = "Configurações";
            // 
            // SelectDirectoryButton
            // 
            this.SelectDirectoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectDirectoryButton.BackgroundImage = global::Path_Validator.Properties.Resources.if_folder_299060;
            this.SelectDirectoryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SelectDirectoryButton.Enabled = false;
            this.SelectDirectoryButton.FlatAppearance.BorderSize = 0;
            this.SelectDirectoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectDirectoryButton.ForeColor = System.Drawing.Color.Transparent;
            this.SelectDirectoryButton.Location = new System.Drawing.Point(9, 250);
            this.SelectDirectoryButton.Name = "SelectDirectoryButton";
            this.SelectDirectoryButton.Size = new System.Drawing.Size(25, 29);
            this.SelectDirectoryButton.TabIndex = 5;
            this.SelectDirectoryButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SelectDirectoryButton.UseVisualStyleBackColor = true;
            this.SelectDirectoryButton.Visible = false;
            this.SelectDirectoryButton.Click += new System.EventHandler(this.SelectDirectoryButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(90, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "EXECUTAR";
            // 
            // rb_Arquivo
            // 
            this.rb_Arquivo.AutoSize = true;
            this.rb_Arquivo.Checked = true;
            this.rb_Arquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Arquivo.Location = new System.Drawing.Point(9, 138);
            this.rb_Arquivo.Name = "rb_Arquivo";
            this.rb_Arquivo.Size = new System.Drawing.Size(273, 24);
            this.rb_Arquivo.TabIndex = 1;
            this.rb_Arquivo.TabStop = true;
            this.rb_Arquivo.Text = "Validação de diretórios de arquivos";
            this.rb_Arquivo.UseVisualStyleBackColor = true;
            this.rb_Arquivo.CheckedChanged += new System.EventHandler(this.rb_Varredura_CheckedChanged);
            // 
            // rb_Varredura
            // 
            this.rb_Varredura.AutoSize = true;
            this.rb_Varredura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Varredura.Location = new System.Drawing.Point(9, 198);
            this.rb_Varredura.Name = "rb_Varredura";
            this.rb_Varredura.Size = new System.Drawing.Size(225, 24);
            this.rb_Varredura.TabIndex = 1;
            this.rb_Varredura.Text = "Varredura de (sub)diretórios";
            this.rb_Varredura.UseVisualStyleBackColor = true;
            this.rb_Varredura.CheckedChanged += new System.EventHandler(this.rb_Varredura_CheckedChanged);
            // 
            // rb_WEB
            // 
            this.rb_WEB.AutoSize = true;
            this.rb_WEB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_WEB.Location = new System.Drawing.Point(9, 168);
            this.rb_WEB.Name = "rb_WEB";
            this.rb_WEB.Size = new System.Drawing.Size(242, 24);
            this.rb_WEB.TabIndex = 1;
            this.rb_WEB.Text = "Validação de links web (URLs)";
            this.rb_WEB.UseVisualStyleBackColor = true;
            this.rb_WEB.CheckedChanged += new System.EventHandler(this.rb_Varredura_CheckedChanged);
            // 
            // labelDiretorioPai
            // 
            this.labelDiretorioPai.AutoSize = true;
            this.labelDiretorioPai.BackColor = System.Drawing.Color.Transparent;
            this.labelDiretorioPai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDiretorioPai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelDiretorioPai.ForeColor = System.Drawing.Color.White;
            this.labelDiretorioPai.Location = new System.Drawing.Point(6, 228);
            this.labelDiretorioPai.Name = "labelDiretorioPai";
            this.labelDiretorioPai.Size = new System.Drawing.Size(103, 18);
            this.labelDiretorioPai.TabIndex = 4;
            this.labelDiretorioPai.Text = "Diretório Pai";
            this.labelDiretorioPai.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Configuração de Execução";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.BackgroundImage = global::Path_Validator.Properties.Resources.if_floppy_285657;
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SaveButton.Enabled = false;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.ForeColor = System.Drawing.Color.Transparent;
            this.SaveButton.Location = new System.Drawing.Point(185, 24);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(69, 59);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RunButton.BackgroundImage = global::Path_Validator.Properties.Resources.if_Play_701486;
            this.RunButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RunButton.FlatAppearance.BorderSize = 0;
            this.RunButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RunButton.ForeColor = System.Drawing.Color.Transparent;
            this.RunButton.Location = new System.Drawing.Point(79, 315);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(128, 59);
            this.RunButton.TabIndex = 0;
            this.RunButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // OpenButton
            // 
            this.OpenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenButton.BackgroundImage = global::Path_Validator.Properties.Resources.if_folder_299060;
            this.OpenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OpenButton.FlatAppearance.BorderSize = 0;
            this.OpenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenButton.ForeColor = System.Drawing.Color.Transparent;
            this.OpenButton.Location = new System.Drawing.Point(45, 24);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(69, 59);
            this.OpenButton.TabIndex = 0;
            this.OpenButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // tb_DiretorioPai
            // 
            this.tb_DiretorioPai.AcceptsReturn = true;
            this.tb_DiretorioPai.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.tb_DiretorioPai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_DiretorioPai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_DiretorioPai.Enabled = false;
            this.tb_DiretorioPai.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_DiretorioPai.Location = new System.Drawing.Point(40, 257);
            this.tb_DiretorioPai.Name = "tb_DiretorioPai";
            this.tb_DiretorioPai.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_DiretorioPai.Size = new System.Drawing.Size(237, 20);
            this.tb_DiretorioPai.TabIndex = 1;
            this.tb_DiretorioPai.Visible = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TitleLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(12, 71);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(70, 24);
            this.TitleLabel.TabIndex = 4;
            this.TitleLabel.Text = "INPUT";
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.Image = global::Path_Validator.Properties.Resources.if_epc_1931213;
            this.Logo.Location = new System.Drawing.Point(12, 12);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(47, 40);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 5;
            this.Logo.TabStop = false;
            // 
            // LogoLabel
            // 
            this.LogoLabel.AutoSize = true;
            this.LogoLabel.BackColor = System.Drawing.Color.Transparent;
            this.LogoLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoLabel.Font = new System.Drawing.Font("Consolas", 25F);
            this.LogoLabel.ForeColor = System.Drawing.Color.White;
            this.LogoLabel.Location = new System.Drawing.Point(65, 12);
            this.LogoLabel.Name = "LogoLabel";
            this.LogoLabel.Size = new System.Drawing.Size(283, 40);
            this.LogoLabel.TabIndex = 4;
            this.LogoLabel.Text = "PATH VALIDATOR";
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "OpenFile";
            this.OpenFile.Filter = "\"TXT files|*.txt\"";
            // 
            // MainProgress
            // 
            this.MainProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainProgress.Location = new System.Drawing.Point(4, 377);
            this.MainProgress.Name = "MainProgress";
            this.MainProgress.Size = new System.Drawing.Size(281, 10);
            this.MainProgress.TabIndex = 6;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Path_Validator.Properties.Resources.abstract_wallpaper_images_5;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(697, 503);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.LogoLabel);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.gb_Options);
            this.Controls.Add(this.tb_Urls);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(705, 490);
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Path Validator by Denner Parreiras";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreen_FormClosing);
            this.gb_Options.ResumeLayout(false);
            this.gb_Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_Urls;
        private System.Windows.Forms.GroupBox gb_Options;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.RadioButton rb_Arquivo;
        private System.Windows.Forms.RadioButton rb_WEB;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label LogoLabel;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.ProgressBar MainProgress;
        private System.Windows.Forms.RadioButton rb_Varredura;
        private System.Windows.Forms.Label labelDiretorioPai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_DiretorioPai;
        private System.Windows.Forms.FolderBrowserDialog fb_DiretorioPai;
        private System.Windows.Forms.Button SelectDirectoryButton;
    }
}

