using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MKVS_Information_System.Repository;
using MKVS_Information_System.Models;
using MySql.Data.MySqlClient;
using MKVS_Information_System.Database;


namespace MKVS_Information_System.Forms
{
    public partial class EncodeForm : Form
    {


        public EncodeForm()
        {
            InitializeComponent();
        }

        private void EncodeForm_Load(object sender, EventArgs e)
        {
            // FIxed border not resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            setBackgroundColors();
            settingUpButtons();


            RecordRepository repo = new RecordRepository();
            string previewSerial = repo.PeekNextSerialNumber();
            serialNumberLabel.Text = previewSerial;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        // Method for setting background colors
        private void setBackgroundColors()
        {
            // Color purple
            topPanel.BackColor = Color.FromArgb(106, 13, 173);

            // Set the background color of the groupboxes
            personalInfoGroupbox.BackColor = Color.FromArgb(237, 231, 246);
            requestDetailsGroupbox.BackColor = Color.FromArgb(237, 231, 246);

            // Set the background color of buttons panel
            buttonsPanel.BackColor = Color.FromArgb(237, 231, 246);
        }
        private void settingUpButtons()
        {
            saveButton.BackColor = Color.FromArgb(106, 13, 173);
            saveButton.ForeColor = Color.White;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.Font = new Font("Arial", 12, FontStyle.Bold);

            clearButton.BackColor = Color.FromArgb(155, 89, 182);
            clearButton.ForeColor = Color.White;
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.FlatAppearance.BorderSize = 0;
            clearButton.Font = new Font("Arial", 12, FontStyle.Bold);

            backButton.BackColor = Color.FromArgb(224, 216, 255);
            backButton.ForeColor = Color.FromArgb(74, 20, 140);
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Font = new Font("Arial", 12, FontStyle.Bold);
        }
        public void getValues()
        {
            string firstName = firstnameTextbox.Text;
            string middleName = middlenameTextbox.Text;
            string lastName = lastnameTextbox.Text;
            string contactNumber = contactnumTextbox.Text;
            string barangay = barangayCombobox.SelectedItem?.ToString();
            string additionalInfo = additionalinfoTextbox.Text;
            string category = categoryCombobox.SelectedItem?.ToString();
            string assistancce = assistanceCombobox.SelectedItem?.ToString();
            string eventVenus = eventvenueTextbox.Text;
            string requestSolicit = requestsolicitombobox.SelectedItem?.ToString();
            string remarks = remarksTextbox.Text;
            string organization = organizationTextbox.Text;
            string theEvent = eventTextbox.Text;
            string status = statusCombobox.SelectedItem?.ToString();
            string eventDate = eventdateDatetimepicker.Value.ToString("yyyy-MM-dd");



            string serialNumber;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                RecordRepository repo = new RecordRepository();

                // 🟢 1️⃣ Get address ID (insert if new)
                int addressId = repo.GetOrInsertAddress(barangayCombobox.SelectedItem?.ToString(), additionalinfoTextbox.Text);

                // 🟢 2️⃣ Generate new Serial Number
                string serialNo = repo.GenerateSerialNumber();

                // 🟢 3️⃣ Create Record object
                Records record = new Records
                {
                    SerialNo = serialNo,
                    DateReceived = dateReceivedPicker.Value.ToString("yyyy-MM-dd"),
                    FirstName = firstnameTextbox.Text,
                    MiddleName = middlenameTextbox.Text,
                    LastName = lastnameTextbox.Text,
                    ContactNo = contactnumTextbox.Text,
                    AddressId = addressId,
                    Category = categoryCombobox.SelectedItem?.ToString(),
                    AssistanceType = assistanceCombobox.SelectedItem?.ToString(),
                    Organization = organizationTextbox.Text,
                    EventName = eventTextbox.Text,
                    EventDate = eventdateDatetimepicker.Value.ToString("yyyy-MM-dd"),
                    EventVenue = eventvenueTextbox.Text,
                    RequestSolicit = requestsolicitombobox.SelectedItem?.ToString(),
                    Remarks = remarksTextbox.Text,
                    Status = statusCombobox.SelectedItem?.ToString()
                };

                // 🟢 4️⃣ Insert record into database
                bool success = repo.InsertRecord(record);

                if (success)
                {
                    MessageBox.Show("✅ Record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 🟢 Refresh Serial Number for next entry
                    serialNumberLabel.Text = repo.PeekNextSerialNumber();


                    // 🟢 Optionally clear inputs
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("❌ Failed to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving record:\n" + ex.Message);
            }
        }
        private void ClearFields()
        {
            firstnameTextbox.Clear();
            middlenameTextbox.Clear();
            lastnameTextbox.Clear();
            contactnumTextbox.Clear();
            barangayCombobox.SelectedIndex = -1;
            additionalinfoTextbox.Clear();
            organizationTextbox.Clear();
            eventTextbox.Clear();
            eventvenueTextbox.Clear();
            remarksTextbox.Clear();

            categoryCombobox.SelectedIndex = -1;
            assistanceCombobox.SelectedIndex = -1;
            requestsolicitombobox.SelectedIndex = -1;
            statusCombobox.SelectedIndex = -1;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void EncodeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
