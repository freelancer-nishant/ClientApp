using ClientApplication.BAL.Models;
using ClientApplication.BAL.Services;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Client_Application.Component
{
    public partial class AddEditContactForm : Form
    {
        private ContactModel _contactModel;
        private ContactService _contactService;
        private int companyId = 0;
        public delegate void OnContactSavedHandler(int companyId);
        public event OnContactSavedHandler OnContactSaved;
        public AddEditContactForm(ContactModel contactModel,int companyID)
        {
            InitializeComponent();
            _contactModel = contactModel;
            _contactService = new ContactService();

            if (_contactModel != null)
            {
                // Edit Mode: Populate fields with company data
                txtFirstName.Text = _contactModel.FirstName;
                txtLastName.Text = _contactModel.LastName;
                txtEmail.Text = _contactModel.EmailID;
                mtxtPhoneNumber.Text = _contactModel.PhoneNumber;
                
                companyId = _contactModel.CompanyID;
                this.Text = "Edit Contact";
            }
            else
            {
                // Add Mode: Empty fields
                this.Text = "Add New Contact";
                companyId = companyID;
            }
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;
            try
            {
                // Create a new ContactModel object with input data
                var contactmodel = new ContactModel
                {
                    ContactID = _contactModel == null ? 0 : _contactModel.ContactID,
                    CompanyID = companyId,
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    EmailID = txtEmail.Text.Trim(),
                    PhoneNumber = mtxtPhoneNumber.Text,
                };


                var contactId = _contactService.InsertUpdateContact(contactmodel);

                MessageBox.Show($"Contact has been saved successfully");

                ClearFields();
                OnContactSaved?.Invoke(companyId);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        
        private bool ValidateForm()
        {
            bool isValid = true;

            // Reset styles and hide error labels
            ResetValidationStyles();

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                isValid = false;
                lblFirstNameError.Text = "First Name is required.";
                lblFirstNameError.Visible = true;
                lblFirstNameError.ForeColor = Color.Red;
            }

            if (!string.IsNullOrWhiteSpace(mtxtPhoneNumber.Text))
            {
                string phonePattern = @"^(\+1[- ]?)?(\([0-9]{3}\)|[0-9]{3})[- ]?[0-9]{3}[- ]?[0-9]{4}$";
                if (!Regex.IsMatch(mtxtPhoneNumber.Text.Trim(), phonePattern))
                {
                    isValid = false;
                    lblPhoneNumberError.Text = "Invalid Phone number format.\n";
                    lblPhoneNumberError.Visible = true;
                    lblPhoneNumberError.ForeColor = Color.Red;
                }
            }
            else
            {
                isValid = false;
                lblPhoneNumberError.Text = "Invalid Phone number format.\n";
                lblPhoneNumberError.Visible = true;

                lblPhoneNumberError.ForeColor = Color.Red;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                isValid = false;
                lblLastNameError.Text = "Last Name is rquired.";
                lblLastNameError.Visible = true;
                lblLastNameError.ForeColor = Color.Red;
            }
          
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                string emailPattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
                if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern))
                {
                    isValid = false;
                    lblEmailError.Text = "Invalid email format.";
                    lblEmailError.Visible = true;
                    lblEmailError.ForeColor = Color.Red;
                }
            }
            else
            {
                isValid = false;
                lblEmailError.Text = "Invalid email format.";
                lblEmailError.Visible = true;
                lblEmailError.ForeColor = Color.Red;
            }
            return isValid;
        }

        private void ResetValidationStyles()
        {
            // Hide all error labels
            lblFirstNameError.Visible = false;
            lblPhoneNumberError.Visible = false;
            lblLastNameError.Visible = false;
            lblEmailError.Visible = false;
        }
        
        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            mtxtPhoneNumber.Clear();
            txtFirstName.Focus();
        }
    }
}
