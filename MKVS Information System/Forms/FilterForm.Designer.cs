namespace MKVS_Information_System.Forms
{
    partial class FilterForm
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
            fromDatePicker = new DateTimePicker();
            label15 = new Label();
            barangayCombobox = new ComboBox();
            label10 = new Label();
            statusCombobox = new ComboBox();
            label19 = new Label();
            assistanceCombobox = new ComboBox();
            label12 = new Label();
            categoryCombobox = new ComboBox();
            label22 = new Label();
            toDatePicker = new DateTimePicker();
            label1 = new Label();
            applyFilterButton = new Button();
            clearButton = new Button();
            eventsCombobox = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // fromDatePicker
            // 
            fromDatePicker.CalendarForeColor = Color.FromArgb(64, 64, 64);
            fromDatePicker.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fromDatePicker.Location = new Point(140, 45);
            fromDatePicker.Name = "fromDatePicker";
            fromDatePicker.Size = new Size(367, 30);
            fromDatePicker.TabIndex = 24;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = Color.FromArgb(64, 64, 64);
            label15.Location = new Point(40, 53);
            label15.Name = "label15";
            label15.Size = new Size(82, 20);
            label15.TabIndex = 23;
            label15.Text = "Date From:";
            // 
            // barangayCombobox
            // 
            barangayCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            barangayCombobox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            barangayCombobox.ForeColor = Color.FromArgb(64, 64, 64);
            barangayCombobox.FormattingEnabled = true;
            barangayCombobox.Items.AddRange(new object[] { "Bagong Kalsada", "Bañadero", "Banlic", "Barandal", "Batino", "Brgy. 1", "Brgy. 2", "Brgy. 3", "Brgy. 4", "Brgy. 5", "Brgy. 6", "Brgy. 7", "Bubuyan", "Bucal", "Bunggo", "Burol", "Camaligan", "Canlubang", "Halang", "Hornalan", "Kay-Anlog", "La Mesa", "Laguerta", "Lawa", "Lecheria", "Lingga", "Looc", "Mabato", "Majada Out", "Makiling", "Mapagong", "Masili", "Maunong", "Mayapa", "Milagrosa", "Paciano Rizal", "Palingon", "Palo-Alto", "Pansol", "Parian", "Prinza", "Punta", "Puting Lupa", "Real", "Saimsim", "Sampiruhan", "San Cristobal", "San Jose", "San Juan", "Sirang Lupa", "Sucol", "Turbina", "Ulango", "Uwisan" });
            barangayCombobox.Location = new Point(140, 294);
            barangayCombobox.Name = "barangayCombobox";
            barangayCombobox.Size = new Size(367, 39);
            barangayCombobox.TabIndex = 43;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.FromArgb(64, 64, 64);
            label10.Location = new Point(36, 303);
            label10.Name = "label10";
            label10.Size = new Size(74, 20);
            label10.TabIndex = 40;
            label10.Text = "Barangay:";
            // 
            // statusCombobox
            // 
            statusCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusCombobox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            statusCombobox.ForeColor = Color.FromArgb(64, 64, 64);
            statusCombobox.FormattingEnabled = true;
            statusCombobox.Items.AddRange(new object[] { "Pending", "On Process", "Received" });
            statusCombobox.Location = new Point(140, 240);
            statusCombobox.Name = "statusCombobox";
            statusCombobox.Size = new Size(367, 39);
            statusCombobox.TabIndex = 42;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.ForeColor = Color.FromArgb(64, 64, 64);
            label19.Location = new Point(70, 249);
            label19.Name = "label19";
            label19.Size = new Size(52, 20);
            label19.TabIndex = 41;
            label19.Text = "Status:";
            // 
            // assistanceCombobox
            // 
            assistanceCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            assistanceCombobox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            assistanceCombobox.ForeColor = Color.FromArgb(64, 64, 64);
            assistanceCombobox.FormattingEnabled = true;
            assistanceCombobox.Items.AddRange(new object[] { "Events", "Solicit", "Medical", "Burial", "Hospitalization", "Education" });
            assistanceCombobox.Location = new Point(140, 185);
            assistanceCombobox.Name = "assistanceCombobox";
            assistanceCombobox.Size = new Size(367, 39);
            assistanceCombobox.TabIndex = 39;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = Color.FromArgb(64, 64, 64);
            label12.Location = new Point(35, 194);
            label12.Name = "label12";
            label12.Size = new Size(80, 20);
            label12.TabIndex = 38;
            label12.Text = "Assistance:\r\n";
            // 
            // categoryCombobox
            // 
            categoryCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryCombobox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            categoryCombobox.ForeColor = Color.FromArgb(64, 64, 64);
            categoryCombobox.FormattingEnabled = true;
            categoryCombobox.Items.AddRange(new object[] { "Barangay Affairs", "Personal Request" });
            categoryCombobox.Location = new Point(140, 135);
            categoryCombobox.Name = "categoryCombobox";
            categoryCombobox.Size = new Size(367, 39);
            categoryCombobox.TabIndex = 37;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.ForeColor = Color.FromArgb(64, 64, 64);
            label22.Location = new Point(49, 144);
            label22.Name = "label22";
            label22.Size = new Size(72, 20);
            label22.TabIndex = 36;
            label22.Text = "Category:";
            // 
            // toDatePicker
            // 
            toDatePicker.CalendarForeColor = Color.FromArgb(64, 64, 64);
            toDatePicker.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toDatePicker.Location = new Point(140, 90);
            toDatePicker.Name = "toDatePicker";
            toDatePicker.Size = new Size(367, 30);
            toDatePicker.TabIndex = 45;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(51, 90);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 44;
            label1.Text = "Date To:";
            // 
            // applyFilterButton
            // 
            applyFilterButton.Location = new Point(35, 437);
            applyFilterButton.Name = "applyFilterButton";
            applyFilterButton.Size = new Size(218, 83);
            applyFilterButton.TabIndex = 46;
            applyFilterButton.Text = "Apply Filter";
            applyFilterButton.UseVisualStyleBackColor = true;
            applyFilterButton.Click += applyFilterButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(330, 437);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(218, 83);
            clearButton.TabIndex = 47;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // eventsCombobox
            // 
            eventsCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            eventsCombobox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            eventsCombobox.ForeColor = Color.FromArgb(64, 64, 64);
            eventsCombobox.FormattingEnabled = true;
            eventsCombobox.Items.AddRange(new object[] { "Xmas" });
            eventsCombobox.Location = new Point(140, 349);
            eventsCombobox.Name = "eventsCombobox";
            eventsCombobox.Size = new Size(367, 39);
            eventsCombobox.TabIndex = 49;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(49, 361);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 48;
            label2.Text = "Events:";
            // 
            // FilterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 624);
            Controls.Add(eventsCombobox);
            Controls.Add(label2);
            Controls.Add(clearButton);
            Controls.Add(applyFilterButton);
            Controls.Add(toDatePicker);
            Controls.Add(label1);
            Controls.Add(barangayCombobox);
            Controls.Add(label10);
            Controls.Add(statusCombobox);
            Controls.Add(label19);
            Controls.Add(assistanceCombobox);
            Controls.Add(label12);
            Controls.Add(categoryCombobox);
            Controls.Add(label22);
            Controls.Add(fromDatePicker);
            Controls.Add(label15);
            Name = "FilterForm";
            Text = "FilterForm";
            FormClosed += FilterForm_FormClosed;
            Load += FilterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker fromDatePicker;
        private Label label15;
        private ComboBox barangayCombobox;
        private Label label10;
        private ComboBox statusCombobox;
        private Label label19;
        private ComboBox assistanceCombobox;
        private Label label12;
        private ComboBox categoryCombobox;
        private Label label22;
        private DateTimePicker toDatePicker;
        private Label label1;
        private Button applyFilterButton;
        private Button clearButton;
        private ComboBox eventsCombobox;
        private Label label2;
    }
}