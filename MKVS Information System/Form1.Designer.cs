namespace MKVS_Information_System
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bottomPanel = new Panel();
            dateTimeLabel = new Label();
            centerPanel = new Panel();
            payrollButton = new Button();
            viewSearchButton = new Button();
            encodeButton = new Button();
            pictureBox1 = new PictureBox();
            topPanel = new Panel();
            label1 = new Label();
            title = new Label();
            bottomPanel.SuspendLayout();
            centerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            topPanel.SuspendLayout();
            SuspendLayout();
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(dateTimeLabel);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 783);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(1924, 70);
            bottomPanel.TabIndex = 1;
            // 
            // dateTimeLabel
            // 
            dateTimeLabel.AutoSize = true;
            dateTimeLabel.Font = new Font("Arial Narrow", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateTimeLabel.ForeColor = Color.Black;
            dateTimeLabel.Location = new Point(1262, 26);
            dateTimeLabel.Name = "dateTimeLabel";
            dateTimeLabel.Size = new Size(111, 27);
            dateTimeLabel.TabIndex = 0;
            dateTimeLabel.Text = "Date | Time";
            // 
            // centerPanel
            // 
            centerPanel.Controls.Add(payrollButton);
            centerPanel.Controls.Add(viewSearchButton);
            centerPanel.Controls.Add(encodeButton);
            centerPanel.Dock = DockStyle.Fill;
            centerPanel.Location = new Point(0, 253);
            centerPanel.Name = "centerPanel";
            centerPanel.Size = new Size(1924, 530);
            centerPanel.TabIndex = 2;
            // 
            // payrollButton
            // 
            payrollButton.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            payrollButton.Location = new Point(1282, 208);
            payrollButton.Name = "payrollButton";
            payrollButton.Size = new Size(215, 102);
            payrollButton.TabIndex = 2;
            payrollButton.Text = "Payroll";
            payrollButton.UseVisualStyleBackColor = true;
            payrollButton.Click += payrollButton_Click;
            // 
            // viewSearchButton
            // 
            viewSearchButton.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewSearchButton.Location = new Point(872, 208);
            viewSearchButton.Name = "viewSearchButton";
            viewSearchButton.Size = new Size(215, 102);
            viewSearchButton.TabIndex = 1;
            viewSearchButton.Text = "View/Search";
            viewSearchButton.UseVisualStyleBackColor = true;
            viewSearchButton.Click += viewSearchButton_Click;
            // 
            // encodeButton
            // 
            encodeButton.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            encodeButton.Location = new Point(451, 208);
            encodeButton.Name = "encodeButton";
            encodeButton.Size = new Size(215, 102);
            encodeButton.TabIndex = 0;
            encodeButton.Text = "Encode";
            encodeButton.UseVisualStyleBackColor = true;
            encodeButton.Click += encodeButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Right;
            pictureBox1.Image = Properties.Resources.logoInformationSystem;
            pictureBox1.Location = new Point(1407, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(517, 253);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // topPanel
            // 
            topPanel.BackColor = SystemColors.ControlDarkDark;
            topPanel.Controls.Add(label1);
            topPanel.Controls.Add(title);
            topPanel.Controls.Add(pictureBox1);
            topPanel.Dock = DockStyle.Top;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1924, 253);
            topPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Narrow", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(222, 45);
            label1.Name = "label1";
            label1.Size = new Size(290, 110);
            label1.TabIndex = 3;
            label1.Text = "City Councilor\r\nKath Silva";
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Arial Narrow", 45F, FontStyle.Bold, GraphicsUnit.Point, 0);
            title.ForeColor = Color.White;
            title.Location = new Point(212, 56);
            title.Name = "title";
            title.Size = new Size(611, 176);
            title.TabIndex = 2;
            title.Text = "\r\nInformation System";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 853);
            Controls.Add(centerPanel);
            Controls.Add(bottomPanel);
            Controls.Add(topPanel);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            centerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel bottomPanel;
        private Label dateTimeLabel;
        private Panel centerPanel;
        private Button encodeButton;
        private Button payrollButton;
        private Button viewSearchButton;
        private PictureBox pictureBox1;
        private Panel topPanel;
        private Label title;
        private Label label1;
    }
}
