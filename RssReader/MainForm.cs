using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RssReader
{
    public partial class MainForm : Form
    {
        private FeedAggregator aggregator;

        public MainForm()
        {
            InitializeComponent();

            aggregator = new FeedAggregator();
            aggregator.FeedRefreshed += OnFeedRefreshed;

            RefreshForm();
        }

        private void OnFeedRefreshed(object sender, EventArgs e)
        {
            this.Invoke(new Action(RefreshForm));
        }

        private void RefreshForm()
        {
            feedListBox.Items.Clear();
            feedListBox.Items.AddRange(aggregator.Feed.ToArray());

            refreshIntervalTextBox.Text = aggregator.RefreshInterval.TotalSeconds.ToString();

            refreshButton.Enabled = true;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            refreshButton.Enabled = false;
            aggregator.Refresh();
        }

        private void feedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (feedListBox.SelectedItem != null)
            {
                summaryWebBrowser.DocumentText = ((FeedItem)feedListBox.SelectedItem).Summary;
            }
        }

        private void feedListBox_DoubleClick(object sender, EventArgs e)
        {
            if (feedListBox.SelectedItem != null)
            {
                var uri = ((FeedItem)feedListBox.SelectedItem).Link;
                if (!uri.IsFile)
                    System.Diagnostics.Process.Start(((FeedItem)feedListBox.SelectedItem).Link.ToString());
            }
        }

        private void summaryWebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString() != @"about:blank")
            {
                e.Cancel = true;
                System.Diagnostics.Process.Start(e.Url.ToString());
            }
        }

        private void manageSourcesButton_Click(object sender, EventArgs e)
        {
            var dialog = new SourceManagerDialog(aggregator);
            dialog.ShowDialog();
        }

        private void applyRefreshIntervalButton_Click(object sender, EventArgs e)
        {
            int interval; //in seconds
            if (!int.TryParse(refreshIntervalTextBox.Text, out interval))
            {
                MessageBox.Show(refreshIntervalTextBox.Text + " is not a valid double value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            aggregator.RefreshInterval = new TimeSpan(0, 0, interval);

            RefreshForm();
        }
    }
}
