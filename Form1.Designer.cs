namespace TerminalForBeginners
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.consoleControl = new ConsoleControl.ConsoleControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.directoryTree = new System.Windows.Forms.TreeView();
            this.fileBrowserIcons = new System.Windows.Forms.ImageList(this.components);
            this.fileView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.listBoxPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // consoleControl
            // 
            this.consoleControl.IsInputEnabled = true;
            this.consoleControl.Location = new System.Drawing.Point(741, 13);
            this.consoleControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.consoleControl.Name = "consoleControl";
            this.consoleControl.SendKeyboardCommandsToProcess = false;
            this.consoleControl.ShowDiagnostics = false;
            this.consoleControl.Size = new System.Drawing.Size(1144, 735);
            this.consoleControl.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(13, 47);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.directoryTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fileView);
            this.splitContainer1.Size = new System.Drawing.Size(721, 939);
            this.splitContainer1.SplitterDistance = 390;
            this.splitContainer1.TabIndex = 1;
            // 
            // directoryTree
            // 
            this.directoryTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directoryTree.ImageIndex = 0;
            this.directoryTree.ImageList = this.fileBrowserIcons;
            this.directoryTree.Location = new System.Drawing.Point(0, 0);
            this.directoryTree.Name = "directoryTree";
            this.directoryTree.SelectedImageIndex = 0;
            this.directoryTree.Size = new System.Drawing.Size(390, 939);
            this.directoryTree.TabIndex = 0;
            // 
            // fileBrowserIcons
            // 
            this.fileBrowserIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("fileBrowserIcons.ImageStream")));
            this.fileBrowserIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.fileBrowserIcons.Images.SetKeyName(0, "icons8-folder-32.png");
            this.fileBrowserIcons.Images.SetKeyName(1, "icons8-file-32.png");
            // 
            // fileView
            // 
            this.fileView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.fileView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileView.HideSelection = false;
            this.fileView.Location = new System.Drawing.Point(0, 0);
            this.fileView.Name = "fileView";
            this.fileView.Size = new System.Drawing.Size(327, 939);
            this.fileView.SmallImageList = this.fileBrowserIcons;
            this.fileView.TabIndex = 0;
            this.fileView.UseCompatibleStateImageBehavior = false;
            this.fileView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 105;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 77;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1730, 756);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(1730, 793);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(156, 31);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 13);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(40, 29);
            this.backButton.TabIndex = 8;
            this.backButton.Text = "←";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // listBoxPanel
            // 
            this.listBoxPanel.Location = new System.Drawing.Point(741, 756);
            this.listBoxPanel.Name = "listBoxPanel";
            this.listBoxPanel.Size = new System.Drawing.Size(983, 230);
            this.listBoxPanel.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1898, 994);
            this.Controls.Add(this.listBoxPanel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.consoleControl);
            this.Name = "MainForm";
            this.Text = "Terminal For Beginners";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ConsoleControl.ConsoleControl consoleControl;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView directoryTree;
        private System.Windows.Forms.ImageList fileBrowserIcons;
        private System.Windows.Forms.ListView fileView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Panel listBoxPanel;
    }
}

