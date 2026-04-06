namespace MKVS_Information_System.Forms
{
    partial class PayrollForm
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
            searchButton = new Button();
            nameTextbox = new TextBox();
            label1 = new Label();
            recordDatagridview = new DataGridView();
            addtoPayrollButton = new Button();
            topPanel = new Panel();
            title = new Label();
            pictureBox1 = new PictureBox();
            payrollDatagridview = new DataGridView();
            deleteButton = new Button();
            savetoExcelButton = new Button();
            backButton = new Button();
            updateAmountButton = new Button();
            clearTableButton = new Button();
            ((System.ComponentModel.ISupportInitialize)recordDatagridview).BeginInit();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)payrollDatagridview).BeginInit();
            SuspendLayout();
            // 
            // searchButton
            // 
            searchButton.Location = new Point(1038, 181);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(173, 39);
            searchButton.TabIndex = 9;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // nameTextbox
            // 
            nameTextbox.BorderStyle = BorderStyle.FixedSingle;
            nameTextbox.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameTextbox.ForeColor = Color.FromArgb(64, 64, 64);
            nameTextbox.Location = new Point(700, 181);
            nameTextbox.Name = "nameTextbox";
            nameTextbox.Size = new Size(315, 39);
            nameTextbox.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(591, 183);
            label1.Name = "label1";
            label1.Size = new Size(103, 33);
            label1.TabIndex = 7;
            label1.Text = "Name:";
            // 
            // recordDatagridview
            // 
            recordDatagridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            recordDatagridview.Location = new Point(448, 240);
            recordDatagridview.Name = "recordDatagridview";
            recordDatagridview.RowHeadersWidth = 51;
            recordDatagridview.Size = new Size(916, 110);
            recordDatagridview.TabIndex = 10;
            // 
            // addtoPayrollButton
            // 
            addtoPayrollButton.Location = new Point(448, 373);
            addtoPayrollButton.Name = "addtoPayrollButton";
            addtoPayrollButton.Size = new Size(227, 76);
            addtoPayrollButton.TabIndex = 11;
            addtoPayrollButton.Text = "Add to payroll";
            addtoPayrollButton.UseVisualStyleBackColor = true;
            addtoPayrollButton.Click += addtoPayrollButton_Click;
            // 
            // topPanel
            // 
            topPanel.BackColor = SystemColors.ControlDarkDark;
            topPanel.Controls.Add(title);
            topPanel.Controls.Add(pictureBox1);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1924, 70);
            topPanel.TabIndex = 12;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Dock = DockStyle.Left;
            title.Font = new Font("Arial Narrow", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title.ForeColor = Color.White;
            title.Location = new Point(0, 0);
            title.Name = "title";
            title.Size = new Size(161, 58);
            title.TabIndex = 2;
            title.Text = "Payroll";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logoInformationSystem;
            pictureBox1.Location = new Point(1610, 129);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(263, 124);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // payrollDatagridview
            // 
            payrollDatagridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            payrollDatagridview.Location = new Point(579, 527);
            payrollDatagridview.Name = "payrollDatagridview";
            payrollDatagridview.RowHeadersWidth = 51;
            payrollDatagridview.Size = new Size(697, 252);
            payrollDatagridview.TabIndex = 13;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(700, 373);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(227, 76);
            deleteButton.TabIndex = 14;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // savetoExcelButton
            // 
            savetoExcelButton.Location = new Point(448, 817);
            savetoExcelButton.Name = "savetoExcelButton";
            savetoExcelButton.Size = new Size(227, 76);
            savetoExcelButton.TabIndex = 15;
            savetoExcelButton.Text = "Save to excel";
            savetoExcelButton.UseVisualStyleBackColor = true;
            savetoExcelButton.Click += savetoExcelButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(700, 817);
            backButton.Name = "backButton";
            backButton.Size = new Size(227, 76);
            backButton.TabIndex = 16;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // updateAmountButton
            // 
            updateAmountButton.Location = new Point(1049, 817);
            updateAmountButton.Name = "updateAmountButton";
            updateAmountButton.Size = new Size(227, 76);
            updateAmountButton.TabIndex = 17;
            updateAmountButton.Text = "Update amount";
            updateAmountButton.UseVisualStyleBackColor = true;
            updateAmountButton.Click += updateAmountButton_Click;
            // 
            // clearTableButton
            // 
            clearTableButton.Location = new Point(1298, 817);
            clearTableButton.Name = "clearTableButton";
            clearTableButton.Size = new Size(227, 76);
            clearTableButton.TabIndex = 18;
            clearTableButton.Text = "Clear table";
            clearTableButton.UseVisualStyleBackColor = true;
            clearTableButton.Click += clearTableButton_Click;
            // 
            // PayrollForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(clearTableButton);
            Controls.Add(updateAmountButton);
            Controls.Add(backButton);
            Controls.Add(savetoExcelButton);
            Controls.Add(deleteButton);
            Controls.Add(payrollDatagridview);
            Controls.Add(topPanel);
            Controls.Add(addtoPayrollButton);
            Controls.Add(recordDatagridview);
            Controls.Add(searchButton);
            Controls.Add(nameTextbox);
            Controls.Add(label1);
            Name = "PayrollForm";
            Text = "PayrollForm";
            WindowState = FormWindowState.Maximized;
            FormClosed += PayrollForm_FormClosed;
            Load += PayrollForm_Load;
            ((System.ComponentModel.ISupportInitialize)recordDatagridview).EndInit();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)payrollDatagridview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button searchButton;
        private TextBox nameTextbox;
        private Label label1;
        private DataGridView recordDatagridview;
        private Button addtoPayrollButton;
        private Panel topPanel;
        private Label title;
        private PictureBox pictureBox1;
        private DataGridView payrollDatagridview;
        private Button deleteButton;
        private Button savetoExcelButton;
        private Button backButton;
        private Button updateAmountButton;
        private Button clearTableButton;
    }
}