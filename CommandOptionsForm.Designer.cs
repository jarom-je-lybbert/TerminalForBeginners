namespace TerminalForBeginners
{
    partial class CommandOptionsForm
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
            this.commandInfoLabel = new System.Windows.Forms.Label();
            this.okayButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.commandDescLabel = new System.Windows.Forms.Label();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // commandInfoLabel
            // 
            this.commandInfoLabel.AutoSize = true;
            this.commandInfoLabel.Location = new System.Drawing.Point(8, 9);
            this.commandInfoLabel.Name = "commandInfoLabel";
            this.commandInfoLabel.Size = new System.Drawing.Size(167, 20);
            this.commandInfoLabel.TabIndex = 1;
            this.commandInfoLabel.Text = "Command Information";
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(899, 352);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(75, 31);
            this.okayButton.TabIndex = 2;
            this.okayButton.Text = "Okay";
            this.okayButton.UseVisualStyleBackColor = true;
            // 
            // commandDescLabel
            // 
            this.commandDescLabel.AutoSize = true;
            this.commandDescLabel.Location = new System.Drawing.Point(12, 29);
            this.commandDescLabel.Name = "commandDescLabel";
            this.commandDescLabel.Size = new System.Drawing.Size(124, 20);
            this.commandDescLabel.TabIndex = 3;
            this.commandDescLabel.Text = "Information Text";
            // 
            // optionsPanel
            // 
            this.optionsPanel.Location = new System.Drawing.Point(16, 133);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(958, 213);
            this.optionsPanel.TabIndex = 4;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(818, 352);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 31);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // CommandOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 415);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.commandDescLabel);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.commandInfoLabel);
            this.Name = "CommandOptionsForm";
            this.Text = "Command Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label commandInfoLabel;
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label commandDescLabel;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Button cancelButton;
    }
}