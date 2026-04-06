namespace MKVS_Information_System.Forms
{
    partial class EncodeForm
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
            topPanel = new Panel();
            title = new Label();
            pictureBox1 = new PictureBox();
            personalInfoGroupbox = new GroupBox();
            dateReceivedPicker = new DateTimePicker();
            barangayCombobox = new ComboBox();
            additionalinfoTextbox = new TextBox();
            contactnumTextbox = new TextBox();
            lastnameTextbox = new TextBox();
            middlenameTextbox = new TextBox();
            label11 = new Label();
            label10 = new Label();
            label8 = new Label();
            serialNumberLabel = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            firstnameTextbox = new TextBox();
            label1 = new Label();
            requestDetailsGroupbox = new GroupBox();
            statusCombobox = new ComboBox();
            label19 = new Label();
            organizationTextbox = new TextBox();
            eventTextbox = new TextBox();
            remarksTextbox = new TextBox();
            eventvenueTextbox = new TextBox();
            label18 = new Label();
            requestsolicitombobox = new ComboBox();
            label17 = new Label();
            label16 = new Label();
            eventdateDatetimepicker = new DateTimePicker();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            assistanceCombobox = new ComboBox();
            label12 = new Label();
            categoryCombobox = new ComboBox();
            label22 = new Label();
            buttonsPanel = new Panel();
            backButton = new Button();
            clearButton = new Button();
            saveButton = new Button();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            personalInfoGroupbox.SuspendLayout();
            requestDetailsGroupbox.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
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
            topPanel.TabIndex = 1;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Dock = DockStyle.Left;
            title.Font = new Font("Arial Narrow", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title.ForeColor = Color.White;
            title.Location = new Point(0, 0);
            title.Name = "title";
            title.Size = new Size(173, 58);
            title.TabIndex = 2;
            title.Text = "Encode";
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
            // personalInfoGroupbox
            // 
            personalInfoGroupbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            personalInfoGroupbox.Controls.Add(dateReceivedPicker);
            personalInfoGroupbox.Controls.Add(barangayCombobox);
            personalInfoGroupbox.Controls.Add(additionalinfoTextbox);
            personalInfoGroupbox.Controls.Add(contactnumTextbox);
            personalInfoGroupbox.Controls.Add(lastnameTextbox);
            personalInfoGroupbox.Controls.Add(middlenameTextbox);
            personalInfoGroupbox.Controls.Add(label11);
            personalInfoGroupbox.Controls.Add(label10);
            personalInfoGroupbox.Controls.Add(label8);
            personalInfoGroupbox.Controls.Add(serialNumberLabel);
            personalInfoGroupbox.Controls.Add(label5);
            personalInfoGroupbox.Controls.Add(label4);
            personalInfoGroupbox.Controls.Add(label3);
            personalInfoGroupbox.Controls.Add(label2);
            personalInfoGroupbox.Controls.Add(firstnameTextbox);
            personalInfoGroupbox.Controls.Add(label1);
            personalInfoGroupbox.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            personalInfoGroupbox.Location = new Point(385, 76);
            personalInfoGroupbox.Name = "personalInfoGroupbox";
            personalInfoGroupbox.Size = new Size(1187, 371);
            personalInfoGroupbox.TabIndex = 2;
            personalInfoGroupbox.TabStop = false;
            personalInfoGroupbox.Text = "Personal info";
            // 
            // dateReceivedPicker
            // 
            dateReceivedPicker.CalendarForeColor = Color.FromArgb(64, 64, 64);
            dateReceivedPicker.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateReceivedPicker.Location = new Point(476, 37);
            dateReceivedPicker.Name = "dateReceivedPicker";
            dateReceivedPicker.Size = new Size(367, 30);
            dateReceivedPicker.TabIndex = 35;
            // 
            // barangayCombobox
            // 
            barangayCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            barangayCombobox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            barangayCombobox.ForeColor = Color.FromArgb(64, 64, 64);
            barangayCombobox.FormattingEnabled = true;
            barangayCombobox.Items.AddRange(new object[] { "Bagong Kalsada", "Bañadero", "Banlic", "Barandal", "Batino", "Brgy. 1", "Brgy. 2", "Brgy. 3", "Brgy. 4", "Brgy. 5", "Brgy. 6", "Brgy. 7", "Bubuyan", "Bucal", "Bunggo", "Burol", "Camaligan", "Canlubang", "Halang", "Hornalan", "Kay-Anlog", "La Mesa", "Laguerta", "Lawa", "Lecheria", "Lingga", "Looc", "Mabato", "Majada Out", "Makiling", "Mapagong", "Masili", "Maunong", "Mayapa", "Milagrosa", "Paciano Rizal", "Palingon", "Palo-Alto", "Pansol", "Parian", "Prinza", "Punta", "Puting Lupa", "Real", "Saimsim", "Sampiruhan", "San Cristobal", "San Jose", "San Juan", "Sirang Lupa", "Sucol", "Turbina", "Ulango", "Uwisan" });
            barangayCombobox.Location = new Point(199, 233);
            barangayCombobox.Name = "barangayCombobox";
            barangayCombobox.Size = new Size(367, 39);
            barangayCombobox.TabIndex = 35;
            // 
            // additionalinfoTextbox
            // 
            additionalinfoTextbox.BorderStyle = BorderStyle.FixedSingle;
            additionalinfoTextbox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            additionalinfoTextbox.ForeColor = Color.FromArgb(64, 64, 64);
            additionalinfoTextbox.Location = new Point(199, 287);
            additionalinfoTextbox.Name = "additionalinfoTextbox";
            additionalinfoTextbox.Size = new Size(367, 38);
            additionalinfoTextbox.TabIndex = 21;
            // 
            // contactnumTextbox
            // 
            contactnumTextbox.BorderStyle = BorderStyle.FixedSingle;
            contactnumTextbox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            contactnumTextbox.ForeColor = Color.FromArgb(64, 64, 64);
            contactnumTextbox.Location = new Point(199, 180);
            contactnumTextbox.Name = "contactnumTextbox";
            contactnumTextbox.Size = new Size(367, 38);
            contactnumTextbox.TabIndex = 19;
            // 
            // lastnameTextbox
            // 
            lastnameTextbox.BorderStyle = BorderStyle.FixedSingle;
            lastnameTextbox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lastnameTextbox.ForeColor = Color.FromArgb(64, 64, 64);
            lastnameTextbox.Location = new Point(599, 126);
            lastnameTextbox.Name = "lastnameTextbox";
            lastnameTextbox.Size = new Size(194, 38);
            lastnameTextbox.TabIndex = 19;
            // 
            // middlenameTextbox
            // 
            middlenameTextbox.BorderStyle = BorderStyle.FixedSingle;
            middlenameTextbox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            middlenameTextbox.ForeColor = Color.FromArgb(64, 64, 64);
            middlenameTextbox.Location = new Point(399, 126);
            middlenameTextbox.Name = "middlenameTextbox";
            middlenameTextbox.Size = new Size(194, 38);
            middlenameTextbox.TabIndex = 18;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.FromArgb(64, 64, 64);
            label11.Location = new Point(18, 295);
            label11.Name = "label11";
            label11.Size = new Size(175, 24);
            label11.TabIndex = 15;
            label11.Text = "Additional Info: (Sitio)";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.FromArgb(64, 64, 64);
            label10.Location = new Point(95, 242);
            label10.Name = "label10";
            label10.Size = new Size(89, 24);
            label10.TabIndex = 13;
            label10.Text = "Barangay:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.FromArgb(64, 64, 64);
            label8.Location = new Point(344, 43);
            label8.Name = "label8";
            label8.Size = new Size(126, 24);
            label8.TabIndex = 10;
            label8.Text = "Date Received:";
            // 
            // serialNumberLabel
            // 
            serialNumberLabel.AutoSize = true;
            serialNumberLabel.ForeColor = Color.FromArgb(64, 64, 64);
            serialNumberLabel.Location = new Point(95, 43);
            serialNumberLabel.Name = "serialNumberLabel";
            serialNumberLabel.Size = new Size(178, 24);
            serialNumberLabel.TabIndex = 9;
            serialNumberLabel.Text = "[ MKVS-102025-0001 ]";
            serialNumberLabel.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(64, 64, 64);
            label5.Location = new Point(17, 43);
            label5.Name = "label5";
            label5.Size = new Size(72, 24);
            label5.TabIndex = 8;
            label5.Text = "Serial #:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(64, 64, 64);
            label4.Location = new Point(78, 180);
            label4.Name = "label4";
            label4.Size = new Size(116, 24);
            label4.TabIndex = 6;
            label4.Text = "Contact Num:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(599, 99);
            label3.Name = "label3";
            label3.Size = new Size(97, 24);
            label3.TabIndex = 4;
            label3.Text = "Last Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(64, 64, 64);
            label2.Location = new Point(399, 99);
            label2.Name = "label2";
            label2.Size = new Size(115, 24);
            label2.TabIndex = 2;
            label2.Text = "Middle Name:";
            // 
            // firstnameTextbox
            // 
            firstnameTextbox.BorderStyle = BorderStyle.FixedSingle;
            firstnameTextbox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            firstnameTextbox.ForeColor = Color.FromArgb(64, 64, 64);
            firstnameTextbox.Location = new Point(199, 126);
            firstnameTextbox.Name = "firstnameTextbox";
            firstnameTextbox.Size = new Size(194, 38);
            firstnameTextbox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(199, 99);
            label1.Name = "label1";
            label1.Size = new Size(98, 24);
            label1.TabIndex = 0;
            label1.Text = "First Name:";
            label1.Click += label1_Click;
            // 
            // requestDetailsGroupbox
            // 
            requestDetailsGroupbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            requestDetailsGroupbox.Controls.Add(statusCombobox);
            requestDetailsGroupbox.Controls.Add(label19);
            requestDetailsGroupbox.Controls.Add(organizationTextbox);
            requestDetailsGroupbox.Controls.Add(eventTextbox);
            requestDetailsGroupbox.Controls.Add(remarksTextbox);
            requestDetailsGroupbox.Controls.Add(eventvenueTextbox);
            requestDetailsGroupbox.Controls.Add(label18);
            requestDetailsGroupbox.Controls.Add(requestsolicitombobox);
            requestDetailsGroupbox.Controls.Add(label17);
            requestDetailsGroupbox.Controls.Add(label16);
            requestDetailsGroupbox.Controls.Add(eventdateDatetimepicker);
            requestDetailsGroupbox.Controls.Add(label15);
            requestDetailsGroupbox.Controls.Add(label14);
            requestDetailsGroupbox.Controls.Add(label13);
            requestDetailsGroupbox.Controls.Add(assistanceCombobox);
            requestDetailsGroupbox.Controls.Add(label12);
            requestDetailsGroupbox.Controls.Add(categoryCombobox);
            requestDetailsGroupbox.Controls.Add(label22);
            requestDetailsGroupbox.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            requestDetailsGroupbox.Location = new Point(385, 464);
            requestDetailsGroupbox.Name = "requestDetailsGroupbox";
            requestDetailsGroupbox.Size = new Size(1187, 342);
            requestDetailsGroupbox.TabIndex = 17;
            requestDetailsGroupbox.TabStop = false;
            requestDetailsGroupbox.Text = "Request Details";
            // 
            // statusCombobox
            // 
            statusCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusCombobox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            statusCombobox.ForeColor = Color.FromArgb(64, 64, 64);
            statusCombobox.FormattingEnabled = true;
            statusCombobox.Items.AddRange(new object[] { "Pending", "On Process", "Received" });
            statusCombobox.Location = new Point(717, 155);
            statusCombobox.Name = "statusCombobox";
            statusCombobox.Size = new Size(367, 39);
            statusCombobox.TabIndex = 34;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.ForeColor = Color.FromArgb(64, 64, 64);
            label19.Location = new Point(647, 164);
            label19.Name = "label19";
            label19.Size = new Size(64, 24);
            label19.TabIndex = 33;
            label19.Text = "Status:";
            // 
            // organizationTextbox
            // 
            organizationTextbox.BorderStyle = BorderStyle.FixedSingle;
            organizationTextbox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            organizationTextbox.ForeColor = Color.FromArgb(64, 64, 64);
            organizationTextbox.Location = new Point(717, 49);
            organizationTextbox.Name = "organizationTextbox";
            organizationTextbox.Size = new Size(367, 38);
            organizationTextbox.TabIndex = 32;
            // 
            // eventTextbox
            // 
            eventTextbox.BorderStyle = BorderStyle.FixedSingle;
            eventTextbox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            eventTextbox.ForeColor = Color.FromArgb(64, 64, 64);
            eventTextbox.Location = new Point(717, 99);
            eventTextbox.Name = "eventTextbox";
            eventTextbox.Size = new Size(367, 38);
            eventTextbox.TabIndex = 31;
            // 
            // remarksTextbox
            // 
            remarksTextbox.BorderStyle = BorderStyle.FixedSingle;
            remarksTextbox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            remarksTextbox.ForeColor = Color.FromArgb(64, 64, 64);
            remarksTextbox.Location = new Point(186, 263);
            remarksTextbox.Name = "remarksTextbox";
            remarksTextbox.Size = new Size(369, 38);
            remarksTextbox.TabIndex = 30;
            // 
            // eventvenueTextbox
            // 
            eventvenueTextbox.BorderStyle = BorderStyle.FixedSingle;
            eventvenueTextbox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            eventvenueTextbox.ForeColor = Color.FromArgb(64, 64, 64);
            eventvenueTextbox.Location = new Point(186, 155);
            eventvenueTextbox.Name = "eventvenueTextbox";
            eventvenueTextbox.Size = new Size(367, 38);
            eventvenueTextbox.TabIndex = 18;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ForeColor = Color.FromArgb(64, 64, 64);
            label18.Location = new Point(97, 271);
            label18.Name = "label18";
            label18.Size = new Size(83, 24);
            label18.TabIndex = 27;
            label18.Text = "Remarks:";
            // 
            // requestsolicitombobox
            // 
            requestsolicitombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            requestsolicitombobox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            requestsolicitombobox.ForeColor = Color.FromArgb(64, 64, 64);
            requestsolicitombobox.FormattingEnabled = true;
            requestsolicitombobox.Items.AddRange(new object[] { "Cash", "Items", "Raffle" });
            requestsolicitombobox.Location = new Point(186, 208);
            requestsolicitombobox.Name = "requestsolicitombobox";
            requestsolicitombobox.Size = new Size(367, 39);
            requestsolicitombobox.TabIndex = 26;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ForeColor = Color.FromArgb(64, 64, 64);
            label17.Location = new Point(47, 217);
            label17.Name = "label17";
            label17.Size = new Size(131, 24);
            label17.TabIndex = 25;
            label17.Text = "Request Solicit:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = Color.FromArgb(64, 64, 64);
            label16.Location = new Point(67, 163);
            label16.Name = "label16";
            label16.Size = new Size(113, 24);
            label16.TabIndex = 23;
            label16.Text = "Event Venue:";
            // 
            // eventdateDatetimepicker
            // 
            eventdateDatetimepicker.CalendarForeColor = Color.FromArgb(64, 64, 64);
            eventdateDatetimepicker.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            eventdateDatetimepicker.Location = new Point(717, 211);
            eventdateDatetimepicker.Name = "eventdateDatetimepicker";
            eventdateDatetimepicker.Size = new Size(367, 30);
            eventdateDatetimepicker.TabIndex = 22;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = Color.FromArgb(64, 64, 64);
            label15.Location = new Point(612, 214);
            label15.Name = "label15";
            label15.Size = new Size(99, 24);
            label15.TabIndex = 21;
            label15.Text = "Event Date:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = Color.FromArgb(64, 64, 64);
            label14.Location = new Point(652, 107);
            label14.Name = "label14";
            label14.Size = new Size(59, 24);
            label14.TabIndex = 19;
            label14.Text = "Event:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.FromArgb(64, 64, 64);
            label13.Location = new Point(598, 57);
            label13.Name = "label13";
            label13.Size = new Size(113, 24);
            label13.TabIndex = 17;
            label13.Text = "Organization:";
            // 
            // assistanceCombobox
            // 
            assistanceCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            assistanceCombobox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            assistanceCombobox.ForeColor = Color.FromArgb(64, 64, 64);
            assistanceCombobox.FormattingEnabled = true;
            assistanceCombobox.Items.AddRange(new object[] { "Events", "Solicit", "Medical", "Burial", "Hospitalization", "Education" });
            assistanceCombobox.Location = new Point(186, 99);
            assistanceCombobox.Name = "assistanceCombobox";
            assistanceCombobox.Size = new Size(367, 39);
            assistanceCombobox.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = Color.FromArgb(64, 64, 64);
            label12.Location = new Point(81, 108);
            label12.Name = "label12";
            label12.Size = new Size(99, 24);
            label12.TabIndex = 2;
            label12.Text = "Assistance:\r\n";
            // 
            // categoryCombobox
            // 
            categoryCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryCombobox.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            categoryCombobox.ForeColor = Color.FromArgb(64, 64, 64);
            categoryCombobox.FormattingEnabled = true;
            categoryCombobox.Items.AddRange(new object[] { "Barangay Affairs", "Personal Request" });
            categoryCombobox.Location = new Point(186, 49);
            categoryCombobox.Name = "categoryCombobox";
            categoryCombobox.Size = new Size(367, 39);
            categoryCombobox.TabIndex = 1;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.ForeColor = Color.FromArgb(64, 64, 64);
            label22.Location = new Point(95, 58);
            label22.Name = "label22";
            label22.Size = new Size(85, 24);
            label22.TabIndex = 0;
            label22.Text = "Category:";
            // 
            // buttonsPanel
            // 
            buttonsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonsPanel.Controls.Add(backButton);
            buttonsPanel.Controls.Add(clearButton);
            buttonsPanel.Controls.Add(saveButton);
            buttonsPanel.Location = new Point(385, 830);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(1187, 128);
            buttonsPanel.TabIndex = 18;
            // 
            // backButton
            // 
            backButton.Location = new Point(837, 25);
            backButton.Name = "backButton";
            backButton.Size = new Size(218, 83);
            backButton.TabIndex = 2;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(484, 23);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(218, 83);
            clearButton.TabIndex = 1;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(133, 25);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(218, 83);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // EncodeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(topPanel);
            Controls.Add(personalInfoGroupbox);
            Controls.Add(requestDetailsGroupbox);
            Controls.Add(buttonsPanel);
            Name = "EncodeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EncodeForm";
            WindowState = FormWindowState.Maximized;
            FormClosed += EncodeForm_FormClosed;
            Load += EncodeForm_Load;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            personalInfoGroupbox.ResumeLayout(false);
            personalInfoGroupbox.PerformLayout();
            requestDetailsGroupbox.ResumeLayout(false);
            requestDetailsGroupbox.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel topPanel;
        private Label title;
        private PictureBox pictureBox1;
        private GroupBox personalInfoGroupbox;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label serialNumberLabel;
        private Label label5;
        private Label label8;
        private Label label11;
        private Label label10;
        private GroupBox requestDetailsGroupbox;
        private ComboBox categoryCombobox;
        private Label label22;
        private Label label13;
        private Label label12;
        private DateTimePicker eventdateDatetimepicker;
        private Label label15;
        private Label label14;
        private Label label17;
        private Label label16;
        private Label label18;
        private TextBox lastnameTextbox;
        private TextBox middlenameTextbox;
        private TextBox remarksTextbox;
        private TextBox eventvenueTextbox;
        private ComboBox requestsolicitombobox;
        private ComboBox assistanceCombobox;
        private TextBox additionalinfoTextbox;
        private TextBox contactnumTextbox;
        private TextBox firstnameTextbox;
        private TextBox organizationTextbox;
        private TextBox eventTextbox;
        private ComboBox statusCombobox;
        private Label label19;
        private Panel buttonsPanel;
        private Button saveButton;
        private Button backButton;
        private Button clearButton;
        private ComboBox barangayCombobox;
        private DateTimePicker dateReceivedPicker;
    }
}