using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using MKVS_Information_System.Database;
using MKVS_Information_System.Models;
using MKVS_Information_System.Repository;

namespace MKVS_Information_System.Forms
{
    public partial class ViewForm : Form
    {
        private readonly DatabaseConnection db = new DatabaseConnection();

        private string selectedSerialNo = "";

        public ViewForm()
        {
            InitializeComponent();
            setBackgroundColors();
            SetupDataGridView();
            settingUpButtons();

            // FIxed border not resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Fetching data in datagridview
            RecordRepository repo = new RecordRepository();
            recordsDataGridView.DataSource = repo.GetAllRecords();




            // for the style of search button
            searchButton.BackColor = Color.FromArgb(106, 13, 173);
            searchButton.ForeColor = Color.White;
            searchButton.FlatStyle = FlatStyle.Flat;
            searchButton.FlatAppearance.BorderSize = 0;
            searchButton.Font = new Font("Arial", 12, FontStyle.Bold);

            // for the style of filter button
            filterButton.BackColor = Color.FromArgb(106, 13, 173);
            filterButton.ForeColor = Color.White;
            filterButton.FlatStyle = FlatStyle.Flat;
            filterButton.FlatAppearance.BorderSize = 0;
            filterButton.Font = new Font("Arial", 12, FontStyle.Bold);


            // for the style of clear button
            clearButton.BackColor = Color.FromArgb(106, 13, 173);
            clearButton.ForeColor = Color.White;
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.FlatAppearance.BorderSize = 0;
            clearButton.Font = new Font("Arial", 12, FontStyle.Bold);

            savetoExcelButton.BackColor = Color.FromArgb(106, 13, 173);
            savetoExcelButton.ForeColor = Color.White;
            savetoExcelButton.FlatStyle = FlatStyle.Flat;
            savetoExcelButton.FlatAppearance.BorderSize = 0;
            savetoExcelButton.Font = new Font("Arial", 12, FontStyle.Bold);
        }

        // For setting background colors
        private void setBackgroundColors()
        {
            // Color purple
            topPanel.BackColor = Color.FromArgb(106, 13, 173);
        }
        private void SetupDataGridView()
        {
            // 🎨 General styling
            recordsDataGridView.BorderStyle = BorderStyle.None;
            recordsDataGridView.BackgroundColor = Color.White;
            recordsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            recordsDataGridView.GridColor = Color.FromArgb(230, 230, 230);
            recordsDataGridView.EnableHeadersVisualStyles = false;
            recordsDataGridView.RowHeadersVisible = false;
            recordsDataGridView.AllowUserToResizeRows = false;
            recordsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Alternate row color
            recordsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 255);

            // Header style
            recordsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(106, 13, 173);
            recordsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            recordsDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            recordsDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            recordsDataGridView.ColumnHeadersHeight = 40;

            // Row style
            recordsDataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            recordsDataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            recordsDataGridView.DefaultCellStyle.BackColor = Color.White;
            recordsDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(155, 89, 182);
            recordsDataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            recordsDataGridView.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);

            // Row height
            recordsDataGridView.RowTemplate.Height = 35;

            // Auto sizing
            recordsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            recordsDataGridView.AutoGenerateColumns = true;

            // 📦 Apply adjustments after data binding
            recordsDataGridView.DataBindingComplete += (s, e) =>
            {
                if (recordsDataGridView.Columns.Count > 0)
                {
                    foreach (DataGridViewColumn col in recordsDataGridView.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        col.MinimumWidth = 100;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // Specific wider columns
                    if (recordsDataGridView.Columns.Contains("Remarks"))
                        recordsDataGridView.Columns["Remarks"].Width = 200;

                    if (recordsDataGridView.Columns.Contains("Event Name"))
                        recordsDataGridView.Columns["Event Name"].Width = 180;

                    if (recordsDataGridView.Columns.Contains("Organization"))
                        recordsDataGridView.Columns["Organization"].Width = 150;

                    // ✅ Convert the Status column into ComboBox style
                    if (recordsDataGridView.Columns.Contains("Status"))
                    {
                        int statusColIndex = recordsDataGridView.Columns["Status"].Index;

                        // Prevent duplicate combo creation
                        if (!(recordsDataGridView.Columns["Status"] is DataGridViewComboBoxColumn))
                        {
                            DataGridViewComboBoxColumn comboStatus = new DataGridViewComboBoxColumn
                            {
                                Name = "Status",
                                HeaderText = "Status",
                                DataPropertyName = "Status",
                                FlatStyle = FlatStyle.Flat,
                                DataSource = new string[] { "Pending", "On Process", "Received" }
                            };

                            // Replace old column with ComboBox column
                            recordsDataGridView.Columns.RemoveAt(statusColIndex);
                            recordsDataGridView.Columns.Insert(statusColIndex, comboStatus);
                        }
                    }
                }
            };
        }

        private void LoadRecords(string search = "")
        {
            RecordRepository repo = new RecordRepository();
            DataTable records = repo.GetAllRecords(search);
            recordsDataGridView.DataSource = records;

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            RecordRepository repo = new RecordRepository();
            string search = searchTextbox.Text.Trim();

            if (string.IsNullOrEmpty(search))
            {
                LoadRecords(); // reload all if empty
            }
            else
            {
                recordsDataGridView.DataSource = repo.SearchRecords(search);
            }
        }
        // Button Styling
        private void settingUpButtons()
        {
            addButton.BackColor = Color.FromArgb(106, 13, 173);
            addButton.ForeColor = Color.White;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.Font = new Font("Arial", 12, FontStyle.Bold);

            editButton.BackColor = Color.FromArgb(155, 89, 182);
            editButton.ForeColor = Color.White;
            editButton.FlatStyle = FlatStyle.Flat;
            editButton.FlatAppearance.BorderSize = 0;
            editButton.Font = new Font("Arial", 12, FontStyle.Bold);


            updateStatusButton.BackColor = Color.FromArgb(155, 89, 182);
            updateStatusButton.ForeColor = Color.White;
            updateStatusButton.FlatStyle = FlatStyle.Flat;
            updateStatusButton.FlatAppearance.BorderSize = 0;
            updateStatusButton.Font = new Font("Arial", 12, FontStyle.Bold);

            backButton.BackColor = Color.FromArgb(224, 216, 255);
            backButton.ForeColor = Color.FromArgb(74, 20, 140);
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Font = new Font("Arial", 12, FontStyle.Bold);

            // Set the background color of buttons panel
            buttonsPanel.BackColor = Color.FromArgb(237, 231, 246);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            EncodeForm ef = new EncodeForm();
            ef.Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void recordsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (recordsDataGridView.SelectedRows.Count == 0)
                return;

            string serialNo = recordsDataGridView.SelectedRows[0].Cells["Serial No"].Value.ToString();

            RecordRepository repo = new RecordRepository();
            Records record = repo.GetRecordBySerialNo(serialNo);

            if (record != null)
            {
                UpdateForm updateForm = new UpdateForm(record);
                updateForm.ShowDialog();
            }
            // Refresh the DataGridView after update
            LoadRecords();

        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            using (FilterForm filterForm = new FilterForm())
            {
                if (filterForm.ShowDialog() == DialogResult.OK)
                {
                    var filter = filterForm.Filter;
                    LoadFilteredRecords(filter);
                }
            }

        }
        private void LoadFilteredRecords(RecordFilter filter)
        {
            RecordRepository repo = new RecordRepository();
            DataTable dt = repo.GetFilteredRecords(filter);
            recordsDataGridView.DataSource = dt;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            RecordRepository repo = new RecordRepository();
            DataTable dt = repo.GetAllRecords();
            recordsDataGridView.DataSource = dt;
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {

        }

        private void recordsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void savetoExcelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (recordsDataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    string fileName = $"MKVSRECORDS_{DateTime.Now:yyyyMMdd}.xlsx";
                    sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    sfd.FileName = fileName;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Records");

                            // Add column headers
                            for (int i = 0; i < recordsDataGridView.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = recordsDataGridView.Columns[i].HeaderText;
                            }

                            // Add data
                            for (int i = 0; i < recordsDataGridView.Rows.Count; i++)
                            {
                                for (int j = 0; j < recordsDataGridView.Columns.Count; j++)
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = recordsDataGridView.Rows[i].Cells[j].Value?.ToString();
                                }
                            }

                            worksheet.Columns().AdjustToContents(); // Auto-fit columns

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Excel file saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportDB_Click(object sender, EventArgs e)
        {
            string mysqldumpPath = @"C:\xampp\mysql\bin\mysqldump.exe";  // ✅ your actual path
            string server = "localhost";
            string database = "mkvs_information_system";
            string user = "root";
            string password = ""; // fill in if you have one

            // ask where to save
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "SQL Backup (*.sql)|*.sql";
                sfd.FileName = $"MKVS_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql";

                if (sfd.ShowDialog() != DialogResult.OK) return;
                string outputFile = sfd.FileName;

                try
                {
                    string passwordArg = $"--password={password}";
                    string args = $"--user={user} {passwordArg} --host={server} --routines --events --databases {database}";

                    var psi = new ProcessStartInfo
                    {
                        FileName = mysqldumpPath,
                        Arguments = args,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    using (Process proc = Process.Start(psi))
                    {
                        string stdout = proc.StandardOutput.ReadToEnd();
                        string stderr = proc.StandardError.ReadToEnd();
                        proc.WaitForExit();

                        File.WriteAllText(outputFile, stdout, Encoding.UTF8);

                        if (!string.IsNullOrEmpty(stderr))
                            MessageBox.Show("mysqldump reported:\n\n" + stderr, "Export warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                            MessageBox.Show("Database exported successfully!\n\nSaved as:\n" + outputFile, "Export complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Export failed:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateStatusButton_Click(object sender, EventArgs e)
        {
            if (recordsDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Please select a record first.");
                return;
            }

            try
            {
                int recordId = Convert.ToInt32(recordsDataGridView.CurrentRow.Cells["Record ID"].Value);
                string newStatus = recordsDataGridView.CurrentRow.Cells["Status"].Value?.ToString();

                if (string.IsNullOrEmpty(newStatus))
                {
                    MessageBox.Show("Please select a valid status.");
                    return;
                }

                RecordRepository repo = new RecordRepository();
                bool updated = repo.UpdateRecordStatus(recordId, newStatus);

                if (updated)
                {
                    MessageBox.Show("Status updated successfully!");
                    LoadRecords(); // refresh table
                }
                else
                {
                    MessageBox.Show("Failed to update status. Please try again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record status:\n" + ex.Message);
            }
        }

        private void ViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
