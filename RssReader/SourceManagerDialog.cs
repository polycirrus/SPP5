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
    public partial class SourceManagerDialog : Form
    {
        private FeedAggregator aggregator;

        public SourceManagerDialog(FeedAggregator aggregator)
        {
            InitializeComponent();

            this.aggregator = aggregator;
            DisplaySources();
        }

        private void addButton_Click(object sender, EventArgs e)
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
            DisplaySources();
        }

        private void DisplaySources()
        {
            sourcesListBox.Items.Clear();
            sourcesListBox.Items.AddRange(aggregator.GetSources());
        }

        private void removeButton_Click(object sender, EventArgs e)
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

                DisplaySources();
            }
        }
    }
}
