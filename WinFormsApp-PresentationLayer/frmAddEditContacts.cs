using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsBusinessLayer;

namespace WinFormsApp_PresentationLayer
{
    public partial class frmAddEditContacts : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        int _ContactID;
        clsContact _Contact;

        //Constructor
        public frmAddEditContacts(int ContactID)
        {
            InitializeComponent();

            _ContactID = ContactID;

            if(_ContactID == -1) { 
            
                _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
            }
        }

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {

                cbCountry.Items.Add(row["CountryName"]);

            }

        }

        private void LoadData()
        {

            _FillCountriesInComoboBox();
            cbCountry.SelectedIndex = 0;

            // Add Mode
            if (_Mode == enMode.AddNew)
            {
                lbmode.Text = "Add Contact";
                _Contact = new clsContact();
                return;
            }


            // Update Mode
            else
            {

                lbmode.Text = $"Update Contact {_ContactID}";

                _Contact = clsContact.Find(_ContactID);

                if (_Contact == null)
                {
                    MessageBox.Show("This form will be closed because No Contact with ID = " + _ContactID);
                    this.Close();

                    return;
                }

                lbContactIDValue.Text = _ContactID.ToString();
                txtFirstName.Text = _Contact.FirstName;
                txtLastName.Text = _Contact.LastName;
                txtAddress.Text = _Contact.Address;
                txtEmail.Text = _Contact.Email;
                txtEmail.Text = _Contact.Email;
                txtPhone.Text = _Contact.Phone;
                dateTimePicker1.Value = _Contact.DateOfBirth;

                cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.Find(_Contact.CountryID).CountryName);

            }

        }

        private void frmAddEditContacts_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CountryID = clsCountry.Find(cbCountry.Text).ID;


               _Contact.FirstName = txtFirstName.Text;
               _Contact.LastName = txtLastName.Text;
               _Contact.Address = txtAddress.Text;
               _Contact.Email = txtEmail.Text;
               _Contact.Phone = txtPhone.Text;
               _Contact.Address = txtAddress.Text;
               _Contact.DateOfBirth = dateTimePicker1.Value;
               _Contact.CountryID = CountryID;

                if (_Contact.Save())
                {
                    MessageBox.Show("Saved Succssefully");
                    lbContactIDValue.Text = _Contact.ID.ToString();
                    

                }

                else
                {
                    MessageBox.Show("Save Failed");
                }

            _Mode = enMode.Update;
            lbmode.Text = "Update Mode";
        }


    }
}
