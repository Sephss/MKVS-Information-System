namespace MKVS_Information_System.Forms
{
    partial class ViewForm
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
            recordsDataGridView = new DataGridView();
            label1 = new Label();
            searchTextbox = new TextBox();
            searchButton = new Button();
            buttonsPanel = new Panel();
            updateStatusButton = new Button();
            backButton = new Button();
            editButton = new Button();
            addButton = new Button();
            savetoExcelButton = new Button();
            filterButton = new Button();
            clearButton = new Button();
            panel1 = new Panel();
            exportDB = new Button();
            topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)recordsDataGridView).BeginInit();
            buttonsPanel.SuspendLayout();
            panel1.SuspendLayout();
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
            topPanel.TabIndex = 2;
            topPanel.Paint += topPanel_Paint;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Dock = DockStyle.Left;
            title.Font = new Font("Arial Narrow", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title.ForeColor = Color.White;
            title.Location = new Point(0, 0);
            title.Name = "title";
            title.Size = new Size(118, 58);
            title.TabIndex = 2;
            title.Text = "View";
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
            // recordsDataGridView
            // 
            recordsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            recordsDataGridView.Location = new Point(273, 166);
            recordsDataGridView.Name = "recordsDataGridView";
            recordsDataGridView.RowHeadersWidth = 51;
            recordsDataGridView.Size = new Size(1371, 583);
            recordsDataGridView.TabIndex = 3;
            recordsDataGridView.CellClick += recordsDataGridView_CellClick;
            recordsDataGridView.CellContentClick += recordsDataGridView_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(470, 103);
            label1.Name = "label1";
            label1.Size = new Size(120, 33);
            label1.TabIndex = 4;
            label1.Text = "Search:";
            // 
            // searchTextbox
            // 
            searchTextbox.BorderStyle = BorderStyle.FixedSingle;
            searchTextbox.Font = new Font("Arial", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchTextbox.ForeColor = Color.FromArgb(64, 64, 64);
            searchTextbox.Location = new Point(596, 101);
            searchTextbox.Name = "searchTextbox";
            searchTextbox.Size = new Size(315, 39);
            searchTextbox.TabIndex = 5;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(917, 101);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(173, 39);
            searchButton.TabIndex = 6;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buttonsPanel.Controls.Add(updateStatusButton);
            buttonsPanel.Controls.Add(backButton);
            buttonsPanel.Controls.Add(editButton);
            buttonsPanel.Controls.Add(addButton);
            buttonsPanel.Location = new Point(485, 755);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(910, 93);
            buttonsPanel.TabIndex = 19;
            // 
            // updateStatusButton
            // 
            updateStatusButton.Location = new Point(471, 13);
            updateStatusButton.Name = "updateStatusButton";
            updateStatusButton.Size = new Size(187, 65);
            updateStatusButton.TabIndex = 3;
            updateStatusButton.Text = "Update status";
            updateStatusButton.UseVisualStyleBackColor = true;
            updateStatusButton.Click += updateStatusButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(682, 13);
            backButton.Name = "backButton";
            backButton.Size = new Size(187, 65);
            backButton.TabIndex = 2;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(257, 13);
            editButton.Name = "editButton";
            editButton.Size = new Size(187, 65);
            editButton.TabIndex = 1;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += updateButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(41, 13);
            addButton.Name = "addButton";
            addButton.Size = new Size(187, 65);
            addButton.TabIndex = 0;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // savetoExcelButton
            // 
            savetoExcelButton.Location = new Point(16, 12);
            savetoExcelButton.Name = "savetoExcelButton";
            savetoExcelButton.Size = new Size(218, 83);
            savetoExcelButton.TabIndex = 3;
            savetoExcelButton.Text = "Save to excel";
            savetoExcelButton.UseVisualStyleBackColor = true;
            savetoExcelButton.Click += savetoExcelButton_Click;
            // 
            // filterButton
            // 
            filterButton.Location = new Point(1096, 101);
            filterButton.Name = "filterButton";
            filterButton.Size = new Size(173, 39);
            filterButton.TabIndex = 20;
            filterButton.Text = "Filter";
            filterButton.UseVisualStyleBackColor = true;
            filterButton.Click += filterButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(1275, 103);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(173, 39);
            clearButton.TabIndex = 21;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(exportDB);
            panel1.Controls.Add(savetoExcelButton);
            panel1.Location = new Point(705, 854);
            panel1.Name = "panel1";
            panel1.Size = new Size(473, 104);
            panel1.TabIndex = 20;
            // 
            // exportDB
            // 
            exportDB.Location = new Point(240, 12);
            exportDB.Name = "exportDB";
            exportDB.Size = new Size(218, 83);
            exportDB.TabIndex = 4;
            exportDB.Text = "Export DB";
            exportDB.UseVisualStyleBackColor = true;
            exportDB.Click += exportDB_Click;
            // 
            // ViewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(panel1);
            Controls.Add(clearButton);
            Controls.Add(filterButton);
            Controls.Add(buttonsPanel);
            Controls.Add(searchButton);
            Controls.Add(searchTextbox);
            Controls.Add(label1);
            Controls.Add(recordsDataGridView);
            Controls.Add(topPanel);
            Name = "ViewForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewForm";
            WindowState = FormWindowState.Maximized;
            FormClosed += ViewForm_FormClosed;
            Load += ViewForm_Load;
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)recordsDataGridView).EndInit();
            buttonsPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel topPanel;
        private Label title;
        private PictureBox pictureBox1;
        private DataGridView recordsDataGridView;
        private Label label1;
        private TextBox searchTextbox;
        private Button searchButton;
        private Panel buttonsPanel;
        private Button backButton;
        private Button editButton;
        private Button addButton;
        private Button filterButton;
        private Button clearButton;
        private Button savetoExcelButton;
        private Panel panel1;
        private Button exportDB;
        private Button updateStatusButton;
    }
}