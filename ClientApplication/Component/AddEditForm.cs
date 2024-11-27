using ClientApplication.BAL;
using ClientApplication.BAL.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using ClientApplication.BAL.Services;
using Client_Application.Component;
using System.Text.RegularExpressions;

namespace Client_Application
{
    public partial class AddEditForm : Form
    {
        private CompanyModel _companymodel;
        private CompanyService _companyService;
        private ContactService _contactService;
        private int companyId = 0;
        public event Action OnCompanySaved;
        public AddEditForm(CompanyModel companyModel)
        {
            this.InitializeComponent();
            _companymodel = companyModel;
            _companyService = new CompanyService();
            _contactService = new ContactService();

            if (_companymodel != null)
            {
                // Edit Mode: Populate fields with company data
                txtCompanyName.Text = _companymodel.CompanyName;
                txtAddress1.Text = _companymodel.Address1;
                txtAddress2.Text = _companymodel.Address2;
                mtxtPhoneNumber.Text = _companymodel.PhoneNumber;
                mtxtZipCode.Text = _companymodel.ZipCode;
                companyId = _companymodel.CompanyID;
                this.Text = "Edit Company";
                InitializeContactGrid();
                LoadContactGrid(companyId);
            }
            else
            {

                // Add Mode: Empty fields
                this.Text = "Add New Company";
                gbContacts.Visible = false;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            try
            {
                // Create a new CompanyDto object with input data
                var companymodel = new CompanyModel
                {
                    CompanyID = companyId,
                    CompanyName = txtCompanyName.Text.Trim(),
                    Address1 = txtAddress1.Text.Trim(),
                    Address2 = txtAddress2.Text.Trim(),
                    ZipCode = mtxtZipCode.Text.Trim(),
                    PhoneNumber = mtxtPhoneNumber.Text,
                };


                companyId = _companyService.InsertUpdateCompany(companymodel);

                // Show success message
                MessageBox.Show($"Company has been saved successfully.");

                ClearFields();
                OnCompanySaved?.Invoke();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void ClearFields()
        {
            txtCompanyName.Clear();
            txtAddress1.Clear();
            txtAddress2.Clear();
            mtxtZipCode.Clear();
            mtxtPhoneNumber.Clear();
            txtCompanyName.Focus();
        }
        private bool ValidateForm()
        {
            bool isValid = true;

            // Reset styles and hide error labels
            ResetValidationStyles();

            // Company Name validation
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                isValid = false;
                lblCompanyNameError.Text = "Company Name is required.";
                lblCompanyNameError.Visible = true;
                lblCompanyNameError.ForeColor = Color.Red;
            }
            else
            {
                var isExist = _companyService.IsCompanyExists(_companymodel?.CompanyID, txtCompanyName.Text);
                if (isExist)
                {
                    isValid = false;
                    lblCompanyNameError.Text = "Company already Exists.";
                    lblCompanyNameError.Visible = true;
                    lblCompanyNameError.ForeColor = Color.Red;
                }
            }

            // Phone Number validation
            if (!string.IsNullOrWhiteSpace(mtxtPhoneNumber.Text))
            {
                string phonePattern = @"^(\+1[- ]?)?(\([0-9]{3}\)|[0-9]{3})[- ]?[0-9]{3}[- ]?[0-9]{4}$";
                if (!Regex.IsMatch(mtxtPhoneNumber.Text.Trim(), phonePattern))
                {
                    isValid = false;
                    lblPhoneNumberError.Text = "Enter a valid phone number (XXX-XXX-XXXX).\n";
                    lblPhoneNumberError.Visible = true;
                    lblPhoneNumberError.ForeColor = Color.Red;
                }
            }
            else
            {
                isValid = false;
                lblPhoneNumberError.Text = "Enter a valid phone number (XXX-XXX-XXXX).\n";
                lblPhoneNumberError.Visible = true;
                lblPhoneNumberError.ForeColor = Color.Red;
            }

            // ZIP Code validation
            if (string.IsNullOrWhiteSpace(mtxtZipCode.Text) || mtxtZipCode.Text.Trim().Length != 10)
            {
                isValid = false;
                lblZipCodeError.Text = "ZIP Code must be exactly 10 digits.";
                lblZipCodeError.Visible = true;
                lblZipCodeError.ForeColor = Color.Red;
            }
            if (string.IsNullOrWhiteSpace(txtAddress1.Text))
            {
                isValid = false;
                lblAddress1Error.Text = "Company Address is required.";
                lblAddress1Error.Visible = true;
                lblAddress1Error.ForeColor = Color.Red;
            }
            return isValid;
        }

        private void ResetValidationStyles()
        {
            // Hide all error labels
            lblCompanyNameError.Visible = false;
            lblPhoneNumberError.Visible = false;
            lblZipCodeError.Visible = false;
            lblAddress1Error.Visible = false;
        }

        private void InitializeContactGrid()
        {
            dgvContacts.Columns.Clear();

            dgvContacts.AutoGenerateColumns = false;
            dgvContacts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContacts.Visible = true;
            dgvContacts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ContactID",
                HeaderText = "Contact ID",
                DataPropertyName = "ContactID",
                Visible = false // Hide if you don't need to display this
            });
            dgvContacts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CompanyID",
                HeaderText = "Company ID",
                DataPropertyName = "CompanyID",
                Visible = false // Hide if you don't need to display this
            });

            dgvContacts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FirstName",
                HeaderText = "First Name",
                DataPropertyName = "FirstName"
            });

            dgvContacts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LastName",
                HeaderText = "Last Name",
                DataPropertyName = "LastName"
            });

            dgvContacts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PhoneNumber",
                HeaderText = "Phone Number",
                DataPropertyName = "PhoneNumber"
            });

            dgvContacts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmailID",
                HeaderText = "Email ID",
                DataPropertyName = "EmailID"
            });


            // Add an "Edit" button column
            var editButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Actions",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Name = "EditButton"
            };
            dgvContacts.Columns.Add(editButtonColumn);

            // Set additional grid properties
            dgvContacts.AllowUserToAddRows = false;
            dgvContacts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void LoadContactGrid(int companyId)
        {
            try
            {
                var contacts = _contactService.GetAllContacts(companyId);

                if (contacts.Count > 0)
                {
                    // Bind data to DataGridView
                    dgvContacts.DataSource = contacts;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading contacts: {ex.Message}");
            }
        }

        private void btnContactAdd_Click(object sender, EventArgs e)
        {
            AddEditContactForm addEditContactForm = new AddEditContactForm(null, companyId);
            addEditContactForm.OnContactSaved += LoadContactGrid; // Subscribe to the event
            addEditContactForm.ShowDialog();
        }
        private void dgvContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvContacts.Columns["EditButton"].Index && e.RowIndex >= 0)
            {
                // Get the selected contact
                var selectedRow = dgvContacts.Rows[e.RowIndex];
                int contactId = Convert.ToInt32(selectedRow.Cells["ContactID"].Value);

                string firstName = selectedRow.Cells["FirstName"].Value?.ToString();
                string lastName = selectedRow.Cells["LastName"].Value?.ToString();
                string email = selectedRow.Cells["EmailID"].Value?.ToString();
                string phoneNumber = selectedRow.Cells["PhoneNumber"].Value?.ToString();
                int companyId = Convert.ToInt32(selectedRow.Cells["CompanyID"].Value);
                var contactModel = new ContactModel()
                {
                    CompanyID = companyId,
                    ContactID = contactId,
                    FirstName = firstName,
                    LastName = lastName,
                    EmailID = email,
                    PhoneNumber = phoneNumber
                };

                AddEditContactForm addEditContactForm = new AddEditContactForm(contactModel, companyId);
                addEditContactForm.OnContactSaved += LoadContactGrid; // Subscribe to the event
                addEditContactForm.ShowDialog();
            }
        }
    }
}
