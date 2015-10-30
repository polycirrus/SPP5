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
    public partial class PreferencesDialog : Form
    {
        private FeedAggregator aggregator;

        public PreferencesDialog(FeedAggregator aggregator)
        {
            InitializeComponent();

            this.aggregator = aggregator;
            RefreshForm();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                int interval;
                if (!int.TryParse(refreshIntervalTextBox.Text, out interval))
                {
                    MessageBox.Show(refreshIntervalTextBox.Text + " is not a valid double value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                aggregator.RefreshInterval = new TimeSpan(0, 0, interval);

                aggregator.SourceFilter = filterSourcesListBox.Items.Cast<string>().ToArray();

                aggregator.RecipientAddresses = emailListBox.Items.Cast<string>().ToArray();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RefreshForm();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void RefreshForm()
        {
            sourcesListBox.Items.Clear();
            sourcesListBox.Items.AddRange(aggregator.GetSources());

            filterSourcesListBox.Items.Clear();
            string[] filterSources = aggregator.SourceFilter;
            if (filterSources != null)
                filterSourcesListBox.Items.AddRange(filterSources);

            emailListBox.Items.Clear();
            emailListBox.Items.AddRange(aggregator.RecipientAddresses);

            refreshIntervalTextBox.Text = aggregator.RefreshInterval.TotalSeconds.ToString();
        }

        private void addSourceButton_Click(object sender, EventArgs e)
        {
            try
            {
                aggregator.AddSource(newSourceTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            newSourceTextBox.Text = "";
            RefreshForm();
        }

        private void removeSourceButton_Click(object sender, EventArgs e)
        {
            if (sourcesListBox.SelectedItem != null)
            {
                try
                {
                    aggregator.RemoveSource((string)sourcesListBox.SelectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RefreshForm();
            }
        }

        private void addEmailButton_Click(object sender, EventArgs e)
        {
            if (addEmailTextBox.Text != "")
                emailListBox.Items.Add(addEmailTextBox.Text);
        }

        private void removeEmailButton_Click(object sender, EventArgs e)
        {
            if (sourcesListBox.SelectedItem != null)
            {
                sourcesListBox.Items.Remove(sourcesListBox.SelectedItem);
            }
        }

        private void addFilterSourceButton_Click(object sender, EventArgs e)
        {
            if (addFilterSourceTextBox.Text != "")
                filterSourcesListBox.Items.Add(addFilterSourceTextBox.Text);
        }

        private void removeFilterSourceButton_Click(object sender, EventArgs e)
        {
            if (filterSourcesListBox.SelectedItem != null)
            {
                filterSourcesListBox.Items.Remove(filterSourcesListBox.SelectedItem);
            }
        }
    }
}
