using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MKVS_Information_System.Models;

namespace MKVS_Information_System.Forms
{
    public partial class FilterForm : Form
    {
        public RecordFilter Filter { get; private set; } = new RecordFilter();

        public FilterForm()
        {
            InitializeComponent();
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            settingUpButtons();

            // bg color
            this.BackColor = Color.FromArgb(237, 231, 246);

            // Default dates
            fromDatePicker.Value = DateTime.Now.AddMonths(-1);
            toDatePicker.Value = DateTime.Now;

        }
        private void settingUpButtons()
        {
            applyFilterButton.BackColor = Color.FromArgb(106, 13, 173);
            applyFilterButton.ForeColor = Color.White;
            applyFilterButton.FlatStyle = FlatStyle.Flat;
            applyFilterButton.FlatAppearance.BorderSize = 0;
            applyFilterButton.Font = new Font("Arial", 12, FontStyle.Bold);

            clearButton.BackColor = Color.FromArgb(155, 89, 182);
            clearButton.ForeColor = Color.White;
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.FlatAppearance.BorderSize = 0;
            clearButton.Font = new Font("Arial", 12, FontStyle.Bold);


        }

        private void applyFilterButton_Click(object sender, EventArgs e)
        {
            Filter.FromDate = fromDatePicker.Value;
            Filter.ToDate = toDatePicker.Value;
            Filter.Barangay = barangayCombobox.Text.Trim();
            Filter.Category = categoryCombobox.Text.Trim();
            Filter.AssistanceType = assistanceCombobox.Text.Trim();
            Filter.Status = statusCombobox.Text.Trim();
            Filter.Event = eventsCombobox.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {

        }

        private void FilterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
