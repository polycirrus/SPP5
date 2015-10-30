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
        private object syncRoot = new object();

        public MainForm()
        {
            InitializeComponent();

            aggregator = new FeedAggregator();
            aggregator.FeedRefreshed += OnFeedRefreshed;
            aggregator.FilteredFeedRefreshed += OnFilteredFeedRefreshed;
            aggregator.NewsletterSent += OnNewsletterSent;

            RefreshForm();
        }

        private void OnNewsletterSent(object sender, EventArgs e)
        {
            this.Invoke(new Action(ShowNewsletterSentAlert));
        }

        private void OnFilteredFeedRefreshed(object sender, EventArgs e)
        {
            this.Invoke(new Action(RefreshForm));
        }

        private void OnFeedRefreshed(object sender, EventArgs e)
        {
            this.Invoke(new Action(RefreshForm));
        }

        private void RefreshForm()
        {
            lock (syncRoot)
            {
                feedListBox.Items.Clear();
                feedListBox.Items.AddRange(showFilteredCheckBox.Checked ? aggregator.FilteredFeed : aggregator.Feed);
            }

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

        private void preferencesButton_Click(object sender, EventArgs e)
        {
            var dialog = new PreferencesDialog(aggregator);
            dialog.ShowDialog();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                aggregator.SendNewsletter(sendFilteredCheckBox.Checked);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowNewsletterSentAlert()
        {
            MessageBox.Show("E-mails sent.");
        }
    }
}
