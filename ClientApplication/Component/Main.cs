using Client_Application.Component;
using ClientApplication.BAL;
using ClientApplication.BAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Application
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyGridForm companyGridForm = new CompanyGridForm();
            companyGridForm.MdiParent = this; // Set parent if applicable
            companyGridForm.Show();
            companyGridForm.WindowState = FormWindowState.Maximized;
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactListForm contactListForm = new ContactListForm();
            contactListForm.MdiParent = this; // Set parent if applicable
            contactListForm.Show();
            contactListForm.WindowState = FormWindowState.Maximized;
        }
    }
}
