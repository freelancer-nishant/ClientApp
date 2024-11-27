namespace Client_Application
{
    partial class AddEditForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPhoneNumberError = new System.Windows.Forms.Label();
            this.lblZipCodeError = new System.Windows.Forms.Label();
            this.lblAddress1Error = new System.Windows.Forms.Label();
            this.lblCompanyNameError = new System.Windows.Forms.Label();
            this.mtxtZipCode = new System.Windows.Forms.MaskedTextBox();
            this.mtxtPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblZipCode = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.btnContactAdd = new System.Windows.Forms.Button();
            this.gbContacts = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.gbContacts.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPhoneNumberError);
            this.groupBox1.Controls.Add(this.lblZipCodeError);
            this.groupBox1.Controls.Add(this.lblAddress1Error);
            this.groupBox1.Controls.Add(this.lblCompanyNameError);
            this.groupBox1.Controls.Add(this.mtxtZipCode);
            this.groupBox1.Controls.Add(this.mtxtPhoneNumber);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.lblPhoneNumber);
            this.groupBox1.Controls.Add(this.lblZipCode);
            this.groupBox1.Controls.Add(this.txtAddress2);
            this.groupBox1.Controls.Add(this.lblAddress2);
            this.groupBox1.Controls.Add(this.txtAddress1);
            this.groupBox1.Controls.Add(this.lblAddress1);
            this.groupBox1.Controls.Add(this.txtCompanyName);
            this.groupBox1.Controls.Add(this.lblCompanyName);
            this.groupBox1.Location = new System.Drawing.Point(32, 29);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Size = new System.Drawing.Size(3283, 601);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company";
            // 
            // lblPhoneNumberError
            // 
            this.lblPhoneNumberError.AutoSize = true;
            this.lblPhoneNumberError.Location = new System.Drawing.Point(1733, 486);
            this.lblPhoneNumberError.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPhoneNumberError.Name = "lblPhoneNumberError";
            this.lblPhoneNumberError.Size = new System.Drawing.Size(0, 32);
            this.lblPhoneNumberError.TabIndex = 17;
            // 
            // lblZipCodeError
            // 
            this.lblZipCodeError.AutoSize = true;
            this.lblZipCodeError.Location = new System.Drawing.Point(435, 486);
            this.lblZipCodeError.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblZipCodeError.Name = "lblZipCodeError";
            this.lblZipCodeError.Size = new System.Drawing.Size(0, 32);
            this.lblZipCodeError.TabIndex = 16;
            // 
            // lblAddress1Error
            // 
            this.lblAddress1Error.AutoSize = true;
            this.lblAddress1Error.Location = new System.Drawing.Point(435, 267);
            this.lblAddress1Error.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblAddress1Error.Name = "lblAddress1Error";
            this.lblAddress1Error.Size = new System.Drawing.Size(0, 32);
            this.lblAddress1Error.TabIndex = 14;
            // 
            // lblCompanyNameError
            // 
            this.lblCompanyNameError.AutoSize = true;
            this.lblCompanyNameError.Location = new System.Drawing.Point(435, 155);
            this.lblCompanyNameError.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCompanyNameError.Name = "lblCompanyNameError";
            this.lblCompanyNameError.Size = new System.Drawing.Size(0, 32);
            this.lblCompanyNameError.TabIndex = 13;
            // 
            // mtxtZipCode
            // 
            this.mtxtZipCode.Location = new System.Drawing.Point(443, 420);
            this.mtxtZipCode.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.mtxtZipCode.Mask = "00000-9999";
            this.mtxtZipCode.Name = "mtxtZipCode";
            this.mtxtZipCode.Size = new System.Drawing.Size(473, 38);
            this.mtxtZipCode.TabIndex = 4;
            // 
            // mtxtPhoneNumber
            // 
            this.mtxtPhoneNumber.Location = new System.Drawing.Point(1741, 427);
            this.mtxtPhoneNumber.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.mtxtPhoneNumber.Mask = "(999) 000-0000";
            this.mtxtPhoneNumber.Name = "mtxtPhoneNumber";
            this.mtxtPhoneNumber.Size = new System.Drawing.Size(361, 38);
            this.mtxtPhoneNumber.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Location = new System.Drawing.Point(2939, 486);
            this.btnSave.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(312, 100);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(1411, 427);
            this.lblPhoneNumber.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(215, 32);
            this.lblPhoneNumber.TabIndex = 8;
            this.lblPhoneNumber.Text = "Phone Number*";
            // 
            // lblZipCode
            // 
            this.lblZipCode.AutoSize = true;
            this.lblZipCode.Location = new System.Drawing.Point(88, 427);
            this.lblZipCode.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblZipCode.Name = "lblZipCode";
            this.lblZipCode.Size = new System.Drawing.Size(133, 32);
            this.lblZipCode.TabIndex = 6;
            this.lblZipCode.Text = "ZipCode*";
            // 
            // txtAddress2
            // 
            this.txtAddress2.AccessibleName = "";
            this.txtAddress2.Location = new System.Drawing.Point(443, 327);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtAddress2.Multiline = true;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(2801, 42);
            this.txtAddress2.TabIndex = 3;
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Location = new System.Drawing.Point(88, 334);
            this.lblAddress2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(134, 32);
            this.lblAddress2.TabIndex = 4;
            this.lblAddress2.Text = "Address2";
            // 
            // txtAddress1
            // 
            this.txtAddress1.AccessibleName = "";
            this.txtAddress1.Location = new System.Drawing.Point(443, 212);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtAddress1.Multiline = true;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(2801, 42);
            this.txtAddress1.TabIndex = 2;
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Location = new System.Drawing.Point(88, 219);
            this.lblAddress1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(145, 32);
            this.lblAddress1.TabIndex = 2;
            this.lblAddress1.Text = "Address1*";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.AccessibleName = "";
            this.txtCompanyName.Location = new System.Drawing.Point(443, 100);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(2801, 38);
            this.txtCompanyName.TabIndex = 1;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(88, 107);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(228, 32);
            this.lblCompanyName.TabIndex = 0;
            this.lblCompanyName.Text = "Company Name*";
            // 
            // dgvContacts
            // 
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.Location = new System.Drawing.Point(32, 124);
            this.dgvContacts.Margin = new System.Windows.Forms.Padding(0);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.RowHeadersWidth = 102;
            this.dgvContacts.Size = new System.Drawing.Size(3219, 415);
            this.dgvContacts.TabIndex = 1;
            this.dgvContacts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContacts_CellClick);
            // 
            // btnContactAdd
            // 
            this.btnContactAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnContactAdd.Location = new System.Drawing.Point(2949, 31);
            this.btnContactAdd.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnContactAdd.Name = "btnContactAdd";
            this.btnContactAdd.Size = new System.Drawing.Size(301, 91);
            this.btnContactAdd.TabIndex = 7;
            this.btnContactAdd.Text = "ADD CONTACT";
            this.btnContactAdd.UseVisualStyleBackColor = true;
            this.btnContactAdd.Click += new System.EventHandler(this.btnContactAdd_Click);
            // 
            // gbContacts
            // 
            this.gbContacts.Controls.Add(this.dgvContacts);
            this.gbContacts.Controls.Add(this.btnContactAdd);
            this.gbContacts.Location = new System.Drawing.Point(32, 651);
            this.gbContacts.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbContacts.Name = "gbContacts";
            this.gbContacts.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.gbContacts.Size = new System.Drawing.Size(3283, 572);
            this.gbContacts.TabIndex = 5;
            this.gbContacts.TabStop = false;
            this.gbContacts.Text = "Contacts";
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(3336, 1235);
            this.Controls.Add(this.gbContacts);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "AddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddEditForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.gbContacts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

    
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblZipCode;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.MaskedTextBox mtxtPhoneNumber;
        private System.Windows.Forms.MaskedTextBox mtxtZipCode;
        private System.Windows.Forms.Label lblAddress1Error;
        private System.Windows.Forms.Label lblCompanyNameError;
        private System.Windows.Forms.Label lblPhoneNumberError;
        private System.Windows.Forms.Label lblZipCodeError;
        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.Button btnContactAdd;
        private System.Windows.Forms.GroupBox gbContacts;
    }
}