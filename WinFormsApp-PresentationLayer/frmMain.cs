using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp_PresentationLayer;

namespace WinFormsApp_PresentationLayer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void _RefreshContactsList()
        {
            dataGridViewListContacts.DataSource = clsContact.GetAllContacts();
          
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _RefreshContactsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditContacts frm = new frmAddEditContacts((int)dataGridViewListContacts.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            _RefreshContactsList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ContactID = dataGridViewListContacts.CurrentRow.Cells[0].Value.ToString();
            DialogResult result = 
            MessageBox.Show($"Are you sure you want to delete contact {ContactID}", 
                "Delete Contact", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
               if( clsContact.DeleteContact((int)dataGridViewListContacts.CurrentRow.Cells[0].Value))
                MessageBox.Show("Deleted Sucssefully");
                _RefreshContactsList();
            }



        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            frmAddEditContacts frm = new frmAddEditContacts(-1);
            frm.ShowDialog();
            _RefreshContactsList();

        }
    }
}

      
