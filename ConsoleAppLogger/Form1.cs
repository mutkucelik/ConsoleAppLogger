using ConsoleAppLogger.Core.EntityFramework;
using ConsoleAppLogger.Managers;
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
    public partial class Form1 : Form
    {
        public static string senderNameSurname;
        public static bool senderIsAdmin;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassAdmin.PasswordChar = '*';
            txtPassU.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            UserManager _userManager = new UserManager();
            _userManager.LogControl(true, txtMailAdmin.Text, txtPassAdmin.Text, this);
        }

        private void btnLoginU_Click(object sender, EventArgs e)
        {
            UserManager _userManager = new UserManager();
            _userManager.LogControl(false, txtMailAdmin.Text, txtPassAdmin.Text, this);
        }
    }
}
