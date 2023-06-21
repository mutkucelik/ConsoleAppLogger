using ConsoleAppLogger.DTO;
using ConsoleAppLogger.Entities;
using ConsoleAppLogger.Managers;
using ConsoleAppLogger.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleAppLogger
{
    public partial class HomePage : Form
    {
        
        public HomePage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            lblNameSurname.Text = "Welcome " + Form1.senderNameSurname;
            if (!Form1.senderIsAdmin) AdminPanel.Visible = false;
            gbAddLog.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnShowLogs_Click(object sender, EventArgs e)
        {
            BindingList<LoggingDTO> loggingBindingList = new BindingList<LoggingDTO>();
            LoggingManager loggingManager = new LoggingManager();
            var list = loggingManager.GetLogging();
            foreach(var logging in list) loggingBindingList.Add(logging);
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();           
            dataGridView1.DataSource = loggingBindingList;
            dataGridView1.Columns[0].HeaderCell.Value = "Log Description";
            dataGridView1.Columns[1].HeaderCell.Value = "Log Type";
            dataGridView1.Columns[2].HeaderCell.Value = "User";
            dataGridView1.Columns[3].HeaderCell.Value = "Company Name";
            dataGridView1.Columns[4].HeaderCell.Value = "Log Create Date";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ShowUsers_Click(object sender, EventArgs e)
        {
            BindingList<UserDTO> BindingList = new BindingList<UserDTO>();
            UserManager UserManager = new UserManager();
            var list = UserManager.GetUser();
            foreach (var item in list) BindingList.Add(item);
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.DataSource = BindingList;
            dataGridView1.Columns[0].HeaderCell.Value = "Name Surname";
            dataGridView1.Columns[1].HeaderCell.Value = "Mail";
            dataGridView1.Columns[2].HeaderCell.Value = "Password";
            if (!Form1.senderIsAdmin) dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderCell.Value = "Phone Number";
            dataGridView1.Columns[4].HeaderCell.Value = "User Added Date";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ShowComp_Click(object sender, EventArgs e)
        {
            BindingList<CompanyDTO> BindingList = new BindingList<CompanyDTO>();
            CompanyManager CompanyManager = new CompanyManager();
            var list = CompanyManager.GetCompany();
            foreach (var item in list) BindingList.Add(item);
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.DataSource = BindingList;
            dataGridView1.Columns[0].HeaderCell.Value = "Company Name";
            dataGridView1.Columns[1].HeaderCell.Value = "Sector";
            dataGridView1.Columns[2].HeaderCell.Value = "Company Phone";
            dataGridView1.Columns[3].HeaderCell.Value = "Company Added Date";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserManager UserManager = new UserManager();
            var list = UserManager.GetUser();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyManager CompanyManager = new CompanyManager();
            var list = CompanyManager.GetCompany();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gbAddLog.Visible = true;
        }

        private void btnAddLog_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == null || textBox1.Text == "" || 
                comboBox1.Items == null || comboBox2.Items == null || comboBox3.Items == null)
            {
                MessageBox.Show("All fields are required!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                LoggingManager loggingManager = new LoggingManager();
                Logging log = new Logging()
                {
                    Description = textBox1.Text,
                    UserId = comboBox1.SelectedIndex,
                    CorporateId = comboBox2.SelectedIndex,
                    LogTypeId = comboBox3.SelectedIndex,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                };
                loggingManager.Create(log);
            }
        }
    }
}
