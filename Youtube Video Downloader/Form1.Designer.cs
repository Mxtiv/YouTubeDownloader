using System;

namespace Youtube_Video_Downloader
{
    partial class VideoDownloader
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.cmbVideoQuality = new System.Windows.Forms.ComboBox();
            this.videoQuality = new System.Windows.Forms.Label();
            this.audioQuality = new System.Windows.Forms.Label();
            this.cmbAudioQuality = new System.Windows.Forms.ComboBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.labelFileFormat = new System.Windows.Forms.Label();
            this.cmbFileFormat = new System.Windows.Forms.ComboBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.BackColor = System.Drawing.Color.Silver;
            this.txtUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtUrl.Location = new System.Drawing.Point(14, 23);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(5);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(772, 30);
            this.txtUrl.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(110)))), ((int)(((byte)(174)))));
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(243)))), ((int)(((byte)(230)))));
            this.btnLoad.Location = new System.Drawing.Point(657, 71);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(129, 49);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.Silver;
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtTitle.Location = new System.Drawing.Point(101, 137);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(5);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(685, 30);
            this.txtTitle.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelTitle.Location = new System.Drawing.Point(26, 138);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(67, 29);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Title:";
            // 
            // cmbVideoQuality
            // 
            this.cmbVideoQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cmbVideoQuality.FormattingEnabled = true;
            this.cmbVideoQuality.Location = new System.Drawing.Point(194, 195);
            this.cmbVideoQuality.Name = "cmbVideoQuality";
            this.cmbVideoQuality.Size = new System.Drawing.Size(200, 32);
            this.cmbVideoQuality.TabIndex = 4;
            // 
            // videoQuality
            // 
            this.videoQuality.AutoSize = true;
            this.videoQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.videoQuality.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.videoQuality.Location = new System.Drawing.Point(26, 198);
            this.videoQuality.Name = "videoQuality";
            this.videoQuality.Size = new System.Drawing.Size(162, 29);
            this.videoQuality.TabIndex = 5;
            this.videoQuality.Text = "Video Quality:";
            // 
            // audioQuality
            // 
            this.audioQuality.AutoSize = true;
            this.audioQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.audioQuality.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.audioQuality.Location = new System.Drawing.Point(419, 198);
            this.audioQuality.Name = "audioQuality";
            this.audioQuality.Size = new System.Drawing.Size(161, 29);
            this.audioQuality.TabIndex = 6;
            this.audioQuality.Text = "Audio Quality:";
            // 
            // cmbAudioQuality
            // 
            this.cmbAudioQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cmbAudioQuality.FormattingEnabled = true;
            this.cmbAudioQuality.Location = new System.Drawing.Point(586, 195);
            this.cmbAudioQuality.Name = "cmbAudioQuality";
            this.cmbAudioQuality.Size = new System.Drawing.Size(200, 32);
            this.cmbAudioQuality.TabIndex = 7;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(110)))), ((int)(((byte)(174)))));
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDownload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(243)))), ((int)(((byte)(230)))));
            this.btnDownload.Location = new System.Drawing.Point(657, 291);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(129, 49);
            this.btnDownload.TabIndex = 8;
            this.btnDownload.Text = "DOWNLOAD";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // labelFileFormat
            // 
            this.labelFileFormat.AutoSize = true;
            this.labelFileFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.labelFileFormat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelFileFormat.Location = new System.Drawing.Point(26, 250);
            this.labelFileFormat.Name = "labelFileFormat";
            this.labelFileFormat.Size = new System.Drawing.Size(142, 29);
            this.labelFileFormat.TabIndex = 9;
            this.labelFileFormat.Text = "File Format:";
            // 
            // cmbFileFormat
            // 
            this.cmbFileFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cmbFileFormat.FormattingEnabled = true;
            this.cmbFileFormat.Items.AddRange(new object[] {
            "mp4",
            "mp3",
            "webm"});
            this.cmbFileFormat.Location = new System.Drawing.Point(194, 247);
            this.cmbFileFormat.Name = "cmbFileFormat";
            this.cmbFileFormat.Size = new System.Drawing.Size(200, 32);
            this.cmbFileFormat.TabIndex = 10;
            this.cmbFileFormat.SelectedIndexChanged += new System.EventHandler(this.cmbFileFormat_SelectedIndexChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(14, 355);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(772, 23);
            this.progressBar.TabIndex = 11;
            // 
            // VideoDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(798, 392);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.cmbAudioQuality);
            this.Controls.Add(this.audioQuality);
            this.Controls.Add(this.videoQuality);
            this.Controls.Add(this.cmbVideoQuality);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.labelFileFormat);
            this.Controls.Add(this.cmbFileFormat);
            this.Controls.Add(this.progressBar);
            this.Name = "VideoDownloader";
            this.Text = "YouTube Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ComboBox cmbVideoQuality;
        private System.Windows.Forms.Label videoQuality;
        private System.Windows.Forms.Label audioQuality;
        private System.Windows.Forms.ComboBox cmbAudioQuality;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ComboBox cmbFileFormat;
        private System.Windows.Forms.Label labelFileFormat;
        private System.Windows.Forms.ProgressBar progressBar;

    }
}

