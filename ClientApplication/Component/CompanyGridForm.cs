using ClientApplication.BAL.Models;
using ClientApplication.BAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Application.Component
{
    public partial class CompanyGridForm : Form
    {
        private CompanyService _companyService;

        public CompanyGridForm()
        {
            _companyService = new CompanyService();
            InitializeComponent();
            InitializeForm();
        }

        /// <summary>
        /// This method is called very first time when form is loaded and can be used to load compnents.
        /// </summary>
        private void InitializeForm() 
        {
            InitializeDataGridView();
            GetCompanyData();
        }

        private void InitializeDataGridView()
        {
            // Initialize the DataGridView
            dgvCompany.AutoGenerateColumns = false;
            dgvCompany.Columns.Clear();
            // Add columns to the DataGridView
            dgvCompany.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CompanyID",
                HeaderText = "Company ID",
                DataPropertyName = "CompanyID",
                ReadOnly = true,
                Visible = false,

            });

            dgvCompany.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CompanyName",
                HeaderText = "Company Name",
                DataPropertyName = "CompanyName",
                ReadOnly = true
            });

            dgvCompany.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Address1",
                HeaderText = "Address 1",
                DataPropertyName = "Address1",
                ReadOnly = true
            });

            dgvCompany.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Address2",
                HeaderText = "Address 2",
                DataPropertyName = "Address2",
                ReadOnly = true
            });

            dgvCompany.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ZipCode",
                HeaderText = "Zip Code",
                DataPropertyName = "ZipCode",
                ReadOnly = true
            });

            dgvCompany.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PhoneNumber",
                HeaderText = "Phone Number",
                DataPropertyName = "PhoneNumber",
                ReadOnly = true
            });

            // Add the Edit button column
            var editButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Actions",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "EditButton"
            };
            dgvCompany.Columns.Add(editButtonColumn);
        }

        private void dgvCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dgvCompany.Columns["EditButton"].Index && e.RowIndex >= 0)
            {
                // Get the selected company
                var selectedRow = dgvCompany.Rows[e.RowIndex];
                int companyId = Convert.ToInt32(selectedRow.Cells["CompanyID"].Value);
                string companyName = selectedRow.Cells["CompanyName"].Value?.ToString();
                string address1 = selectedRow.Cells["Address1"].Value?.ToString();
                string address2 = selectedRow.Cells["Address2"].Value?.ToString();
                string zipCode = selectedRow.Cells["ZipCode"].Value?.ToString();
                string phoneNumber = selectedRow.Cells["PhoneNumber"].Value?.ToString();
                var companymodel = new CompanyModel()
                {
                    CompanyID = companyId,
                    CompanyName = companyName,
                    Address1 = address1,
                    Address2 = address2,
                    ZipCode = zipCode,
                    PhoneNumber = phoneNumber
                };
              
                AddEditForm addForm = new AddEditForm(companymodel);
                addForm.StartPosition = FormStartPosition.Manual;
                addForm.Location = new Point(100, 100);
                addForm.AutoSize = true;
                addForm.OnCompanySaved += GetCompanyData; // Subscribe to the event
                addForm.ShowDialog();
            }
        }

        private void GetCompanyData()
        {
            List<CompanyModel> companies = _companyService.GetAllCompanies();
            if (companies != null && companies.Count > 0)
            {
                dgvCompany.DataSource = companies;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditForm addForm = new AddEditForm(null);
            addForm.StartPosition = FormStartPosition.Manual;
            addForm.Location = new Point(100, 100);
            addForm.AutoSize = true;
            addForm.OnCompanySaved += GetCompanyData; // Subscribe to the event
            addForm.ShowDialog();
        }
    }
}
