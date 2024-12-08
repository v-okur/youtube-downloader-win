namespace YoutubeDownloader
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            debugLabel2 = new Label();
            saveFileDialog = new SaveFileDialog();
            urlTextBox = new TextBox();
            messageLabel = new Label();
            debugLabel = new Label();
            submitButton = new Button();
            progressBar = new ProgressBar();
            authorLabel = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            titleLabel = new Label();
            panel3 = new Panel();
            durationLabel = new Label();
            thumbnailBox = new PictureBox();
            qualityPanel = new Panel();
            audioQualityLabel = new Label();
            videoQualitySelection = new ComboBox();
            videoQualityLabel = new Label();
            downloadButton = new Button();
            audioQualitySelection = new ComboBox();
            resetButton = new Button();
            pictureBox1 = new PictureBox();
            cancelButton = new Button();
            panel1 = new Panel();
            panel5 = new Panel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            setDefaultDownloadFolderToolStripMenuItem = new ToolStripMenuItem();
            setDefaultTemporaryFolderToolStripMenuItem = new ToolStripMenuItem();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)thumbnailBox).BeginInit();
            qualityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // debugLabel2
            // 
            debugLabel2.AutoSize = true;
            debugLabel2.Location = new Point(30, 451);
            debugLabel2.Name = "debugLabel2";
            debugLabel2.Size = new Size(0, 15);
            debugLabel2.TabIndex = 4;
            // 
            // urlTextBox
            // 
            urlTextBox.Dock = DockStyle.Right;
            urlTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            urlTextBox.Location = new Point(0, 0);
            urlTextBox.Margin = new Padding(3, 3, 3, 15);
            urlTextBox.Name = "urlTextBox";
            urlTextBox.PlaceholderText = "Enter video URL or ID";
            urlTextBox.Size = new Size(273, 29);
            urlTextBox.TabIndex = 0;
            urlTextBox.KeyPress += urlTextBox_KeyPress;
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Location = new Point(18, 62);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(0, 15);
            messageLabel.TabIndex = 3;
            // 
            // debugLabel
            // 
            debugLabel.AutoSize = true;
            debugLabel.Location = new Point(18, 163);
            debugLabel.Name = "debugLabel";
            debugLabel.Size = new Size(0, 15);
            debugLabel.TabIndex = 4;
            // 
            // submitButton
            // 
            submitButton.BackColor = Color.RoyalBlue;
            submitButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            submitButton.ForeColor = SystemColors.ButtonFace;
            submitButton.Location = new Point(297, 18);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(65, 29);
            submitButton.TabIndex = 5;
            submitButton.Text = "Search";
            submitButton.UseVisualStyleBackColor = false;
            submitButton.Click += submitButton_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(18, 386);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(285, 23);
            progressBar.Step = 100;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 6;
            progressBar.Visible = false;
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Location = new Point(259, 96);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(44, 15);
            authorLabel.TabIndex = 999;
            authorLabel.Text = "Author";
            authorLabel.Visible = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(qualityPanel);
            panel2.Location = new Point(0, 62);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(15);
            panel2.Size = new Size(379, 318);
            panel2.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel4.Controls.Add(titleLabel);
            panel4.Location = new Point(18, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(344, 43);
            panel4.TabIndex = 16;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(-5, 5);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(0, 30);
            titleLabel.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.Controls.Add(durationLabel);
            panel3.Controls.Add(thumbnailBox);
            panel3.Location = new Point(18, 52);
            panel3.Name = "panel3";
            panel3.Size = new Size(343, 180);
            panel3.TabIndex = 15;
            // 
            // durationLabel
            // 
            durationLabel.AutoSize = true;
            durationLabel.BackColor = SystemColors.InactiveCaptionText;
            durationLabel.ForeColor = SystemColors.ButtonFace;
            durationLabel.Location = new Point(294, 150);
            durationLabel.Margin = new Padding(15);
            durationLabel.Name = "durationLabel";
            durationLabel.Size = new Size(0, 15);
            durationLabel.TabIndex = 14;
            durationLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // thumbnailBox
            // 
            thumbnailBox.BackColor = Color.Transparent;
            thumbnailBox.BackgroundImageLayout = ImageLayout.Stretch;
            thumbnailBox.ImageLocation = "";
            thumbnailBox.Location = new Point(0, 0);
            thumbnailBox.Name = "thumbnailBox";
            thumbnailBox.Size = new Size(343, 180);
            thumbnailBox.TabIndex = 0;
            thumbnailBox.TabStop = false;
            thumbnailBox.WaitOnLoad = true;
            // 
            // qualityPanel
            // 
            qualityPanel.Controls.Add(audioQualityLabel);
            qualityPanel.Controls.Add(videoQualitySelection);
            qualityPanel.Controls.Add(videoQualityLabel);
            qualityPanel.Controls.Add(downloadButton);
            qualityPanel.Controls.Add(audioQualitySelection);
            qualityPanel.Location = new Point(18, 238);
            qualityPanel.Name = "qualityPanel";
            qualityPanel.Size = new Size(344, 63);
            qualityPanel.TabIndex = 2;
            qualityPanel.Visible = false;
            // 
            // audioQualityLabel
            // 
            audioQualityLabel.AutoSize = true;
            audioQualityLabel.Location = new Point(241, 12);
            audioQualityLabel.Name = "audioQualityLabel";
            audioQualityLabel.Size = new Size(78, 15);
            audioQualityLabel.TabIndex = 10;
            audioQualityLabel.Text = "Audio quality";
            // 
            // videoQualitySelection
            // 
            videoQualitySelection.FormattingEnabled = true;
            videoQualitySelection.Location = new Point(3, 29);
            videoQualitySelection.Name = "videoQualitySelection";
            videoQualitySelection.Size = new Size(100, 23);
            videoQualitySelection.TabIndex = 7;
            // 
            // videoQualityLabel
            // 
            videoQualityLabel.AutoSize = true;
            videoQualityLabel.Location = new Point(3, 11);
            videoQualityLabel.Name = "videoQualityLabel";
            videoQualityLabel.Size = new Size(76, 15);
            videoQualityLabel.TabIndex = 8;
            videoQualityLabel.Text = "Video quality";
            // 
            // downloadButton
            // 
            downloadButton.Location = new Point(121, 30);
            downloadButton.Margin = new Padding(15, 3, 15, 3);
            downloadButton.Name = "downloadButton";
            downloadButton.Size = new Size(102, 23);
            downloadButton.TabIndex = 11;
            downloadButton.Text = "Download";
            downloadButton.UseVisualStyleBackColor = true;
            downloadButton.Click += downloadButton_Click;
            // 
            // audioQualitySelection
            // 
            audioQualitySelection.FormattingEnabled = true;
            audioQualitySelection.Location = new Point(241, 30);
            audioQualitySelection.Name = "audioQualitySelection";
            audioQualitySelection.Size = new Size(100, 23);
            audioQualitySelection.TabIndex = 9;
            // 
            // resetButton
            // 
            resetButton.BackColor = Color.Transparent;
            resetButton.Location = new Point(0, 0);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(32, 29);
            resetButton.TabIndex = 1001;
            resetButton.Text = "X";
            resetButton.UseVisualStyleBackColor = false;
            resetButton.Click += resetButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Gainsboro;
            pictureBox1.ImageLocation = "file:///C:/Users/sunot/Downloads/loading.gif";
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(297, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(10, 7, 10, 7);
            pictureBox1.Size = new Size(64, 29);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(309, 386);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(53, 23);
            cancelButton.TabIndex = 1000;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Visible = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(cancelButton);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(authorLabel);
            panel1.Controls.Add(progressBar);
            panel1.Controls.Add(submitButton);
            panel1.Controls.Add(debugLabel);
            panel1.Controls.Add(messageLabel);
            panel1.Location = new Point(12, 24);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(379, 423);
            panel1.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(urlTextBox);
            panel5.Controls.Add(resetButton);
            panel5.Location = new Point(18, 18);
            panel5.Name = "panel5";
            panel5.Size = new Size(273, 29);
            panel5.TabIndex = 1002;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(404, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setDefaultDownloadFolderToolStripMenuItem, setDefaultTemporaryFolderToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(61, 20);
            fileToolStripMenuItem.Text = "Settings";
            // 
            // setDefaultDownloadFolderToolStripMenuItem
            // 
            setDefaultDownloadFolderToolStripMenuItem.Name = "setDefaultDownloadFolderToolStripMenuItem";
            setDefaultDownloadFolderToolStripMenuItem.Size = new Size(226, 22);
            setDefaultDownloadFolderToolStripMenuItem.Text = "Set Default Download Folder";
            setDefaultDownloadFolderToolStripMenuItem.Click += setDefaultDownloadFolderToolStripMenuItem_Click;
            // 
            // setDefaultTemporaryFolderToolStripMenuItem
            // 
            setDefaultTemporaryFolderToolStripMenuItem.Name = "setDefaultTemporaryFolderToolStripMenuItem";
            setDefaultTemporaryFolderToolStripMenuItem.Size = new Size(226, 22);
            setDefaultTemporaryFolderToolStripMenuItem.Text = "Set Default Temporary Folder";
            setDefaultTemporaryFolderToolStripMenuItem.Click += setDefaultTemporaryFolderToolStripMenuItem_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 521);
            Controls.Add(panel1);
            Controls.Add(debugLabel2);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MaximumSize = new Size(420, 560);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Youtube Downloader";
            Load += FormMain_Load;
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)thumbnailBox).EndInit();
            qualityPanel.ResumeLayout(false);
            qualityPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Button button1;
        private SaveFileDialog saveFileDialog;
        private Label debugLabel2;
        private TextBox urlTextBox;
        private Label messageLabel;
        private Label debugLabel;
        private Button submitButton;
        private ProgressBar progressBar;
        private Label authorLabel;
        private Panel panel2;
        private Panel panel4;
        private Label titleLabel;
        private Panel panel3;
        private Label durationLabel;
        private PictureBox thumbnailBox;
        private Panel qualityPanel;
        private Label audioQualityLabel;
        private ComboBox videoQualitySelection;
        private Label videoQualityLabel;
        private Button downloadButton;
        private ComboBox audioQualitySelection;
        private PictureBox pictureBox1;
        private Button cancelButton;
        private Panel panel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem setDefaultDownloadFolderToolStripMenuItem;
        private Button resetButton;
        private Panel panel5;
        private ToolStripMenuItem setDefaultTemporaryFolderToolStripMenuItem;
    }
}
