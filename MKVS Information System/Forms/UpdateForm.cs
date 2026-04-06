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
using MKVS_Information_System.Repository;

namespace MKVS_Information_System.Forms
   
{
    public partial class UpdateForm : Form

    {
        private Records currentRecord;
        public UpdateForm(Records record)
        {
            InitializeComponent();
            currentRecord = record;
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            settingUpButtons();
            // Populate textboxes, comboboxes, datetimepicker
            firstnameTextbox.Text = currentRecord.FirstName;
            middlenameTextbox.Text = currentRecord.MiddleName;
            lastnameTextbox.Text = currentRecord.LastName;
            contactnumTextbox.Text = currentRecord.ContactNo;
            organizationTextbox.Text = currentRecord.Organization;
            eventTextbox.Text = currentRecord.EventName;
            if (!string.IsNullOrEmpty(currentRecord.EventDate))
                eventdateDatetimepicker.Value = DateTime.Parse(currentRecord.EventDate);
            eventvenueTextbox.Text = currentRecord.EventVenue;
            requestsolicitombobox.SelectedItem = currentRecord.RequestSolicit;
            remarksTextbox.Text = currentRecord.Remarks;
            statusCombobox.SelectedItem = currentRecord.Status;
            categoryCombobox.SelectedItem = currentRecord.Category;
            assistanceCombobox.SelectedItem = currentRecord.AssistanceType;

            // Address
            barangayCombobox.SelectedItem = currentRecord.Barangay;
            additionalinfoTextbox.Text = currentRecord.AdditionalInfo;


            this.BackColor = Color.FromArgb(237, 231, 246);
            // Color purple
            topPanel.BackColor = Color.FromArgb(106, 13, 173);

        }
        private void settingUpButtons()
        {
            updateButton.BackColor = Color.FromArgb(106, 13, 173);
            updateButton.ForeColor = Color.White;
            updateButton.FlatStyle = FlatStyle.Flat;
            updateButton.FlatAppearance.BorderSize = 0;
            updateButton.Font = new Font("Arial", 12, FontStyle.Bold);

            deleteButton.BackColor = Color.FromArgb(155, 89, 182);
            deleteButton.ForeColor = Color.White;
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Font = new Font("Arial", 12, FontStyle.Bold);

            backButton.BackColor = Color.FromArgb(224, 216, 255);
            backButton.ForeColor = Color.FromArgb(74, 20, 140);
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Font = new Font("Arial", 12, FontStyle.Bold);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            RecordRepository repo = new RecordRepository();

            // Update the address in place using AddressId
            bool addressUpdated = repo.UpdateAddress(currentRecord.AddressId,
                                                     barangayCombobox.SelectedItem?.ToString(),
                                                     additionalinfoTextbox.Text.Trim());

            if (!addressUpdated)
            {
                MessageBox.Show("Failed to update address.");
                return;
            }

            // Update record
            Records updated = new Records
            {
                SerialNo = currentRecord.SerialNo,
                FirstName = firstnameTextbox.Text.Trim(),
                MiddleName = middlenameTextbox.Text.Trim(),
                LastName = lastnameTextbox.Text.Trim(),
                ContactNo = contactnumTextbox.Text.Trim(),
                AddressId = currentRecord.AddressId, // keep the same
                Category = categoryCombobox.SelectedItem?.ToString(),
                AssistanceType = assistanceCombobox.SelectedItem?.ToString(),
                Organization = organizationTextbox.Text.Trim(),
                EventName = eventTextbox.Text.Trim(),
                EventDate = eventdateDatetimepicker.Value.ToString("yyyy-MM-dd"),
                EventVenue = eventvenueTextbox.Text.Trim(),
                RequestSolicit = requestsolicitombobox.SelectedItem?.ToString(),
                Remarks = remarksTextbox.Text.Trim(),
                Status = statusCombobox.SelectedItem?.ToString()
            };

            bool ok = repo.UpdateRecord(updated);
            if (ok)
            {
                MessageBox.Show("Record updated successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Update failed.");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Delete this record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            RecordRepository repo = new RecordRepository();

            // Ensure currentRecord has RecordId filled (if you loaded it via GetRecordBySerialNo earlier)
            if (currentRecord == null || currentRecord.RecordId <= 0)
            {
                MessageBox.Show("Unable to determine record id. Please select a record first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool deleted = repo.DeleteRecord(currentRecord.RecordId);
            if (deleted)
            {
                MessageBox.Show("Record deleted successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Delete failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UpdateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
