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
            this.manageSourcesButton = new System.Windows.Forms.Button();
            this.applyRefreshIntervalButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.refreshIntervalTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // feedListBox
            // 
            this.feedListBox.FormattingEnabled = true;
            this.feedListBox.Location = new System.Drawing.Point(12, 12);
            this.feedListBox.Name = "feedListBox";
            this.feedListBox.Size = new System.Drawing.Size(400, 381);
            this.feedListBox.TabIndex = 0;
            this.feedListBox.SelectedIndexChanged += new System.EventHandler(this.feedListBox_SelectedIndexChanged);
            this.feedListBox.DoubleClick += new System.EventHandler(this.feedListBox_DoubleClick);
            // 
            // summaryWebBrowser
            // 
            this.summaryWebBrowser.Location = new System.Drawing.Point(418, 12);
            this.summaryWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.summaryWebBrowser.Name = "summaryWebBrowser";
            this.summaryWebBrowser.Size = new System.Drawing.Size(400, 381);
            this.summaryWebBrowser.TabIndex = 1;
            this.summaryWebBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.summaryWebBrowser_Navigating);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(12, 399);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 30);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // manageSourcesButton
            // 
            this.manageSourcesButton.Location = new System.Drawing.Point(118, 399);
            this.manageSourcesButton.Name = "manageSourcesButton";
            this.manageSourcesButton.Size = new System.Drawing.Size(100, 30);
            this.manageSourcesButton.TabIndex = 3;
            this.manageSourcesButton.Text = "Manage Sources";
            this.manageSourcesButton.UseVisualStyleBackColor = true;
            this.manageSourcesButton.Click += new System.EventHandler(this.manageSourcesButton_Click);
            // 
            // applyRefreshIntervalButton
            // 
            this.applyRefreshIntervalButton.Location = new System.Drawing.Point(721, 401);
            this.applyRefreshIntervalButton.Name = "applyRefreshIntervalButton";
            this.applyRefreshIntervalButton.Size = new System.Drawing.Size(100, 30);
            this.applyRefreshIntervalButton.TabIndex = 4;
            this.applyRefreshIntervalButton.Text = "Apply";
            this.applyRefreshIntervalButton.UseVisualStyleBackColor = true;
            this.applyRefreshIntervalButton.Click += new System.EventHandler(this.applyRefreshIntervalButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(704, 409);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "s";
            // 
            // refreshIntervalTextBox
            // 
            this.refreshIntervalTextBox.Location = new System.Drawing.Point(640, 406);
            this.refreshIntervalTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.refreshIntervalTextBox.Name = "refreshIntervalTextBox";
            this.refreshIntervalTextBox.Size = new System.Drawing.Size(61, 20);
            this.refreshIntervalTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(562, 409);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Refresh every";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(363, 411);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 441);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.refreshIntervalTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.applyRefreshIntervalButton);
            this.Controls.Add(this.manageSourcesButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.summaryWebBrowser);
            this.Controls.Add(this.feedListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.Button manageSourcesButton;
        private System.Windows.Forms.Button applyRefreshIntervalButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox refreshIntervalTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

