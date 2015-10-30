namespace RssReader
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
            this.feedListBox = new System.Windows.Forms.ListBox();
            this.summaryWebBrowser = new System.Windows.Forms.WebBrowser();
            this.refreshButton = new System.Windows.Forms.Button();
            this.preferencesButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.sendFilteredCheckBox = new System.Windows.Forms.CheckBox();
            this.showFilteredCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // feedListBox
            // 
            this.feedListBox.FormattingEnabled = true;
            this.feedListBox.ItemHeight = 16;
            this.feedListBox.Location = new System.Drawing.Point(16, 15);
            this.feedListBox.Margin = new System.Windows.Forms.Padding(4);
            this.feedListBox.Name = "feedListBox";
            this.feedListBox.Size = new System.Drawing.Size(532, 468);
            this.feedListBox.TabIndex = 0;
            this.feedListBox.SelectedIndexChanged += new System.EventHandler(this.feedListBox_SelectedIndexChanged);
            this.feedListBox.DoubleClick += new System.EventHandler(this.feedListBox_DoubleClick);
            // 
            // summaryWebBrowser
            // 
            this.summaryWebBrowser.Location = new System.Drawing.Point(557, 15);
            this.summaryWebBrowser.Margin = new System.Windows.Forms.Padding(4);
            this.summaryWebBrowser.MinimumSize = new System.Drawing.Size(27, 25);
            this.summaryWebBrowser.Name = "summaryWebBrowser";
            this.summaryWebBrowser.Size = new System.Drawing.Size(533, 469);
            this.summaryWebBrowser.TabIndex = 1;
            this.summaryWebBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.summaryWebBrowser_Navigating);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(16, 491);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(133, 37);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // preferencesButton
            // 
            this.preferencesButton.Location = new System.Drawing.Point(157, 491);
            this.preferencesButton.Margin = new System.Windows.Forms.Padding(4);
            this.preferencesButton.Name = "preferencesButton";
            this.preferencesButton.Size = new System.Drawing.Size(133, 37);
            this.preferencesButton.TabIndex = 9;
            this.preferencesButton.Text = "Preferences";
            this.preferencesButton.UseVisualStyleBackColor = true;
            this.preferencesButton.Click += new System.EventHandler(this.preferencesButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(298, 491);
            this.sendButton.Margin = new System.Windows.Forms.Padding(4);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(133, 37);
            this.sendButton.TabIndex = 10;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // sendFilteredCheckBox
            // 
            this.sendFilteredCheckBox.AutoSize = true;
            this.sendFilteredCheckBox.Location = new System.Drawing.Point(966, 500);
            this.sendFilteredCheckBox.Name = "sendFilteredCheckBox";
            this.sendFilteredCheckBox.Size = new System.Drawing.Size(129, 21);
            this.sendFilteredCheckBox.TabIndex = 11;
            this.sendFilteredCheckBox.Text = "Filter newsletter";
            this.sendFilteredCheckBox.UseVisualStyleBackColor = true;
            // 
            // showFilteredCheckBox
            // 
            this.showFilteredCheckBox.AutoSize = true;
            this.showFilteredCheckBox.Location = new System.Drawing.Point(867, 500);
            this.showFilteredCheckBox.Name = "showFilteredCheckBox";
            this.showFilteredCheckBox.Size = new System.Drawing.Size(93, 21);
            this.showFilteredCheckBox.TabIndex = 12;
            this.showFilteredCheckBox.Text = "Filter feed";
            this.showFilteredCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 543);
            this.Controls.Add(this.showFilteredCheckBox);
            this.Controls.Add(this.sendFilteredCheckBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.preferencesButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.summaryWebBrowser);
            this.Controls.Add(this.feedListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "RSS Reader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox feedListBox;
        private System.Windows.Forms.WebBrowser summaryWebBrowser;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button preferencesButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.CheckBox sendFilteredCheckBox;
        private System.Windows.Forms.CheckBox showFilteredCheckBox;
    }
}

