using ClientApplication.BAL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Application.Component
{
    public partial class ContactListForm : Form
    {
        private ContactService _contactService;
        public ContactListForm()
        {
            InitializeComponent();
            _contactService = new ContactService();
            InitializeContactGrid();
            LoadContactGrid(0);
        }

        private void InitializeContactGrid()
        {
            dataContactGridView.Columns.Clear();

            dataContactGridView.AutoGenerateColumns = false;
            dataContactGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataContactGridView.Visible = true;
            dataContactGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ContactID",
                HeaderText = "Contact ID",
                DataPropertyName = "ContactID",
                Visible = false // Hide if you don't need to display this
            });
            dataContactGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CompanyID",
                HeaderText = "Company ID",
                DataPropertyName = "CompanyID",
                Visible = false // Hide if you don't need to display this
            });
            dataContactGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CompanyName",
                HeaderText = "Company Name",
                DataPropertyName = "CompanyName",
                Visible = true // Hide if you don't need to display this
            });
            dataContactGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FirstName",
                HeaderText = "First Name",
                DataPropertyName = "FirstName"
            });

            dataContactGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LastName",
                HeaderText = "Last Name",
                DataPropertyName = "LastName"
            });

            dataContactGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PhoneNumber",
                HeaderText = "Phone Number",
                DataPropertyName = "PhoneNumber"
            });

            dataContactGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmailID",
                HeaderText = "Email ID",
                DataPropertyName = "EmailID"
            });


            // Add an "Edit" button column
            //var editButtonColumn = new DataGridViewButtonColumn
            //{
            //    HeaderText = "Actions",
            //    Text = "Edit",
            //    UseColumnTextForButtonValue = true,
            //    Name = "EditButton"
            //};
            //dataContactGridView.Columns.Add(editButtonColumn);

            // Set additional grid properties
            dataContactGridView.AllowUserToAddRows = false;
            dataContactGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void LoadContactGrid(int companyId)
        {
            try
            {
                var contacts = _contactService.GetAllContacts(companyId);

                if (contacts.Count > 0)
                {
                    // Bind data to DataGridView
                    dataContactGridView.DataSource = contacts;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading contacts: {ex.Message}");
            }
        }
    }
}
