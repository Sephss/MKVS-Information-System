using System;
using System.Drawing;
using System.Windows.Forms;
using MKVS_Information_System.Database;
using MKVS_Information_System.Forms;
using Timer = System.Windows.Forms.Timer;

namespace MKVS_Information_System
{
    public partial class Form1 : Form
    {
        private Timer timer; // <-- Use Windows Forms Timer

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // To load button colors
            loadButtonColors();

            // Timer for bottom timer and date
            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += (s, ev) =>
            {
                dateTimeLabel.Text = DateTime.Now.ToString("MMMM dd, yyyy | hh:mm:ss tt");
            };
            timer.Start();

            topPanel.BackColor = Color.FromArgb(106, 13, 173);
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            bottomPanel.BackColor = Color.FromArgb(237, 231, 246);





        }
        private void loadButtonColors()
        {
            encodeButton.BackColor = Color.FromArgb(142, 36, 170); // #8E24AA
            encodeButton.ForeColor = Color.White;
            encodeButton.FlatStyle = FlatStyle.Flat;
            encodeButton.FlatAppearance.BorderSize = 0;
            encodeButton.Font = new Font("Arial", 12, FontStyle.Bold);

            viewSearchButton.BackColor = Color.FromArgb(142, 36, 170); // #8E24AA
            viewSearchButton.ForeColor = Color.White;
            viewSearchButton.FlatStyle = FlatStyle.Flat;
            viewSearchButton.FlatAppearance.BorderSize = 0;
            viewSearchButton.Font = new Font("Arial", 12, FontStyle.Bold);

            payrollButton.BackColor = Color.FromArgb(142, 36, 170); // #8E24AA
            payrollButton.ForeColor = Color.White;
            payrollButton.FlatStyle = FlatStyle.Flat;
            payrollButton.FlatAppearance.BorderSize = 0;
            payrollButton.Font = new Font("Arial", 12, FontStyle.Bold);

            encodeButton.MouseEnter += (s, e) => encodeButton.BackColor = Color.FromArgb(156, 39, 176); // #9C27B0
            encodeButton.MouseLeave += (s, e) => encodeButton.BackColor = Color.FromArgb(142, 36, 170);

            viewSearchButton.MouseEnter += (s, e) => viewSearchButton.BackColor = Color.FromArgb(156, 39, 176); // #9C27B0
            viewSearchButton.MouseLeave += (s, e) => viewSearchButton.BackColor = Color.FromArgb(142, 36, 170);

            payrollButton.MouseEnter += (s, e) => payrollButton.BackColor = Color.FromArgb(156, 39, 176); // #9C27B0
            payrollButton.MouseLeave += (s, e) => payrollButton.BackColor = Color.FromArgb(142, 36, 170);
        }

        private void encodeButton_Click(object sender, EventArgs e)
        {
            EncodeForm encodeForm = new EncodeForm();
            encodeForm.Show();
            this.Hide();
        }

        private void viewSearchButton_Click(object sender, EventArgs e)
        {
            ViewForm viewForm = new ViewForm();
            viewForm.Show();
            this.Hide();
        }

        private void payrollButton_Click(object sender, EventArgs e)
        {
            PayrollForm p = new PayrollForm();
            p.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
