using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using MKVS_Information_System.Database;
using MKVS_Information_System.Repository;
using MySql.Data.MySqlClient;

namespace MKVS_Information_System.Forms
{
    public partial class PayrollForm : Form
    {
        private RecordRepository payrollRepo = new RecordRepository();
        DatabaseConnection db = new DatabaseConnection();
        public PayrollForm()
        {
            InitializeComponent();
            setBackgroundColors();
            SetupDataGridView();
            SetupDataGridViewPayroll();
        }
        private void setBackgroundColors()
        {
            // Color purple
            topPanel.BackColor = Color.FromArgb(106, 13, 173);
            // FIxed border not resizable
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // for the style of search button
            searchButton.BackColor = Color.FromArgb(106, 13, 173);
            searchButton.ForeColor = Color.White;
            searchButton.FlatStyle = FlatStyle.Flat;
            searchButton.FlatAppearance.BorderSize = 0;
            searchButton.Font = new Font("Arial", 12, FontStyle.Bold);

            // for the style of search button
            addtoPayrollButton.BackColor = Color.FromArgb(106, 13, 173);
            addtoPayrollButton.ForeColor = Color.White;
            addtoPayrollButton.FlatStyle = FlatStyle.Flat;
            addtoPayrollButton.FlatAppearance.BorderSize = 0;
            addtoPayrollButton.Font = new Font("Arial", 12, FontStyle.Bold);


            updateAmountButton.BackColor = Color.FromArgb(106, 13, 173);
            updateAmountButton.ForeColor = Color.White;
            updateAmountButton.FlatStyle = FlatStyle.Flat;
            updateAmountButton.FlatAppearance.BorderSize = 0;
            updateAmountButton.Font = new Font("Arial", 12, FontStyle.Bold);

            savetoExcelButton.BackColor = Color.FromArgb(106, 13, 173);
            savetoExcelButton.ForeColor = Color.White;
            savetoExcelButton.FlatStyle = FlatStyle.Flat;
            savetoExcelButton.FlatAppearance.BorderSize = 0;
            savetoExcelButton.Font = new Font("Arial", 12, FontStyle.Bold);


            deleteButton.BackColor = Color.FromArgb(224, 216, 255);
            deleteButton.ForeColor = Color.FromArgb(74, 20, 140);
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Font = new Font("Arial", 12, FontStyle.Bold);

            backButton.BackColor = Color.FromArgb(224, 216, 255);
            backButton.ForeColor = Color.FromArgb(74, 20, 140);
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.FlatAppearance.BorderSize = 0;
            backButton.Font = new Font("Arial", 12, FontStyle.Bold);

            clearTableButton.BackColor = Color.FromArgb(224, 216, 255);
            clearTableButton.ForeColor = Color.FromArgb(74, 20, 140);
            clearTableButton.FlatStyle = FlatStyle.Flat;
            clearTableButton.FlatAppearance.BorderSize = 0;
            clearTableButton.Font = new Font("Arial", 12, FontStyle.Bold);
        }

        private void PayrollForm_Load(object sender, EventArgs e)
        {
            LoadPayrollData();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchName = nameTextbox.Text.Trim();

            if (string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show("Please enter a name to search.");
                return;
            }

            DataTable result = payrollRepo.SearchRecordsForPayroll(searchName);

            if (result.Rows.Count == 0)
            {
                MessageBox.Show("No matching records found.");
            }

            recordDatagridview.DataSource = result;
        }

        private void addtoPayrollButton_Click(object sender, EventArgs e)
        {
            if (recordDatagridview.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record to add to payroll.");
                return;
            }

            int recordId = Convert.ToInt32(recordDatagridview.SelectedRows[0].Cells["Record ID"].Value);

            bool success = payrollRepo.AddToPayroll(recordId);

            if (success)
            {
                MessageBox.Show("Record successfully added to payroll!");

                // ✅ Clear the search textbox
                nameTextbox.Clear();

                // ✅ Clear the search results
                recordDatagridview.DataSource = null;
                recordDatagridview.Rows.Clear();

                // ✅ (Optional) Refresh payroll datagrid if you have one
                LoadPayrollData(); // only if you already implemented this
            }
        }
        private void SetupDataGridView()
        {


            // General styling
            recordDatagridview.BorderStyle = BorderStyle.None;
            recordDatagridview.BackgroundColor = Color.White;
            recordDatagridview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            recordDatagridview.GridColor = Color.FromArgb(230, 230, 230);
            recordDatagridview.EnableHeadersVisualStyles = false;
            recordDatagridview.RowHeadersVisible = false;
            recordDatagridview.AllowUserToResizeRows = false;
            recordDatagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Alternate row color for readability
            recordDatagridview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 255);

            // Header style
            recordDatagridview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(106, 13, 173);
            recordDatagridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            recordDatagridview.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            recordDatagridview.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            recordDatagridview.ColumnHeadersHeight = 40;

            // Default row style
            recordDatagridview.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            recordDatagridview.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            recordDatagridview.DefaultCellStyle.BackColor = Color.White;
            recordDatagridview.DefaultCellStyle.SelectionBackColor = Color.FromArgb(155, 89, 182);
            recordDatagridview.DefaultCellStyle.SelectionForeColor = Color.White;
            recordDatagridview.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);

            // Row height
            recordDatagridview.RowTemplate.Height = 35;

            // Auto sizing — fill proportionally but slightly balanced
            recordDatagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            recordDatagridview.AutoGenerateColumns = true;

            // Apply column widths once data is bound
            recordDatagridview.DataBindingComplete += (s, e) =>
            {
                if (recordDatagridview.Columns.Count > 0)
                {
                    foreach (DataGridViewColumn col in recordDatagridview.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        col.MinimumWidth = 100;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // Specific wider columns
                    if (recordDatagridview.Columns.Contains("Remarks"))
                        recordDatagridview.Columns["Remarks"].Width = 200;

                    if (recordDatagridview.Columns.Contains("Event Name"))
                        recordDatagridview.Columns["Event Name"].Width = 180;

                    if (recordDatagridview.Columns.Contains("Organization"))
                        recordDatagridview.Columns["Organization"].Width = 150;

                }
            };
        }
        private void SetupDataGridViewPayroll()
        {


            // General styling
            payrollDatagridview.BorderStyle = BorderStyle.None;
            payrollDatagridview.BackgroundColor = Color.White;
            payrollDatagridview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            payrollDatagridview.GridColor = Color.FromArgb(230, 230, 230);
            payrollDatagridview.EnableHeadersVisualStyles = false;
            payrollDatagridview.RowHeadersVisible = false;
            payrollDatagridview.AllowUserToResizeRows = false;
            payrollDatagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Alternate row color for readability
            payrollDatagridview.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 255);

            // Header style
            payrollDatagridview.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(106, 13, 173);
            payrollDatagridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            payrollDatagridview.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            payrollDatagridview.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            payrollDatagridview.ColumnHeadersHeight = 40;

            // Default row style
            payrollDatagridview.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            payrollDatagridview.DefaultCellStyle.ForeColor = Color.FromArgb(60, 60, 60);
            payrollDatagridview.DefaultCellStyle.BackColor = Color.White;
            payrollDatagridview.DefaultCellStyle.SelectionBackColor = Color.FromArgb(155, 89, 182);
            payrollDatagridview.DefaultCellStyle.SelectionForeColor = Color.White;
            payrollDatagridview.DefaultCellStyle.Padding = new Padding(5, 5, 5, 5);

            // Row height
            payrollDatagridview.RowTemplate.Height = 35;

            // Auto sizing — fill proportionally but slightly balanced
            payrollDatagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            payrollDatagridview.AutoGenerateColumns = true;

            // Apply column widths once data is bound
            payrollDatagridview.DataBindingComplete += (s, e) =>
            {
                if (payrollDatagridview.Columns.Count > 0)
                {
                    foreach (DataGridViewColumn col in payrollDatagridview.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        col.MinimumWidth = 100;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // Specific wider columns
                    if (payrollDatagridview.Columns.Contains("Remarks"))
                        payrollDatagridview.Columns["Remarks"].Width = 200;

                    if (payrollDatagridview.Columns.Contains("Event Name"))
                        payrollDatagridview.Columns["Event Name"].Width = 180;

                    if (payrollDatagridview.Columns.Contains("Organization"))
                        payrollDatagridview.Columns["Organization"].Width = 150;

                }
            };
        }
        private void LoadPayrollData()
        {

            payrollDatagridview.DataSource = payrollRepo.GetAllPayrollRecords();

            // Optional – clean styling
            payrollDatagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            payrollDatagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (recordDatagridview.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a record from the list first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = recordDatagridview.SelectedRows[0];
            int recordId = Convert.ToInt32(row.Cells["Record ID"].Value); // ✅ Fixed

            RecordRepository repo = new RecordRepository();

            if (!repo.IsRecordInPayroll(recordId))
            {
                MessageBox.Show("This record is not in payroll.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to remove this record from payroll?",
                                          "Confirm Delete",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool deleted = repo.DeleteFromPayroll(recordId);
                if (deleted)
                {
                    MessageBox.Show("Record successfully removed from payroll.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPayrollData();
                }
                else
                {
                    MessageBox.Show("Failed to delete record from payroll.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void savetoExcelButton_Click(object sender, EventArgs e)
        {
            if (payrollDatagridview.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 🕒 Auto-generate filename
            string fileName = $"MKVSPAYROLL_{DateTime.Now:yyyyMMdd}.xlsx";

            using (SaveFileDialog sfd = new SaveFileDialog()
            { Filter = "Excel Workbook|*.xlsx", FileName = fileName })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("Payroll Report");

                            // Define desired column headers and corresponding DataGridView column names
                            var columnsToExport = new (string header, string columnName)[]
                            {
                        ("Name", "Full Name"),
                        ("Barangay", "Barangay"),
                        ("Contact Number", "Contact No"),
                        ("Gross Amount", "Gross Amount"),
                        ("Date", "Date Added")
                            };

                            // Write headers
                            for (int i = 0; i < columnsToExport.Length; i++)
                            {
                                ws.Cell(1, i + 1).Value = columnsToExport[i].header;
                                ws.Cell(1, i + 1).Style.Font.Bold = true;
                                ws.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                            }

                            // Write rows
                            int rowIndex = 2;
                            foreach (DataGridViewRow row in payrollDatagridview.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    for (int colIndex = 0; colIndex < columnsToExport.Length; colIndex++)
                                    {
                                        string colName = columnsToExport[colIndex].columnName;
                                        ws.Cell(rowIndex, colIndex + 1).Value = row.Cells[colName].Value?.ToString();
                                    }
                                    rowIndex++;
                                }
                            }

                            // Auto-fit columns
                            ws.Columns().AdjustToContents();

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show($"Payroll report successfully saved as:\n\n{Path.GetFileName(sfd.FileName)}",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting to Excel:\n" + ex.Message, "Export Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void backButton_Click(object sender, EventArgs e)
        {
            Form1 s = new Form1();
            s.Show();
            this.Hide();
        }

        private void updateAmountButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (payrollDatagridview.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a payroll record to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = payrollDatagridview.SelectedRows[0];

                int payrollId = Convert.ToInt32(selectedRow.Cells["Payroll ID"].Value);
                string newAmount = selectedRow.Cells["Gross Amount"].Value?.ToString()?.Trim();

                if (string.IsNullOrEmpty(newAmount))
                {
                    MessageBox.Show("Please enter a valid Gross Amount before updating.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                RecordRepository repo = new RecordRepository();
                bool success = repo.UpdateGrossAmount(payrollId, newAmount);

                if (success)
                {
                    MessageBox.Show("✅ Gross amount updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    payrollRepo.GetAllPayrollRecords();
                }
                else
                {
                    MessageBox.Show("❌ Failed to update gross amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating gross amount:\n" + ex.Message);
            }
        }

        private void PayrollForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void clearTableButton_Click(object sender, EventArgs e)
        {
            if (payrollDatagridview.Rows.Count == 0)
            {
                MessageBox.Show("No records to clear.", "Clear Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to mark all displayed records as exported?",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                DatabaseConnection db = new DatabaseConnection();

                try
                {
                    if (db.OpenConnection())
                    {
                        foreach (DataGridViewRow row in payrollDatagridview.Rows)
                        {
                            if (row.Cells["Payroll ID"].Value != null)
                            {
                                int payrollId = Convert.ToInt32(row.Cells["Payroll ID"].Value);

                                string query = "UPDATE payroll SET exported = 'Yes' WHERE payroll_id = @id";
                                using (MySqlCommand cmd = new MySqlCommand(query, db.GetConnection()))
                                {
                                    cmd.Parameters.AddWithValue("@id", payrollId);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        MessageBox.Show("All displayed records have been marked as exported.",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 🔄 Refresh to show only non-exported records
                        LoadPayrollData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error clearing table:\n" + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    db.CloseConnection();
                }
            }
        }

    }
}
