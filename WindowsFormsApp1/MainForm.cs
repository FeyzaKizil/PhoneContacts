using DatabaseLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneContacts
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FillContactList();
        }

        private void btn_AddContact_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            ReturnValues myenum = bll.AddContact(txt_Name.Text, txt_Lastname.Text, txt_PhoneNumber1.Text, txt_PhoneNumber2.Text, txt_PhoneNumber3.Text,
                txt_EmailAddress.Text, txt_WebAddress.Text, txt_Address.Text, txt_Info.Text);
            if (myenum == ReturnValues.successful)
            {
                FillContactList();
                MessageBox.Show("New record successfully added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearGrpBox_NewRecord();
            }
            else if (myenum == ReturnValues.failed)
            {
                MessageBox.Show("Check Name, Surname, PhoneNumber1. These fields must be full.");
            }

        }

        private void FillContactList()
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            List<Entities.Contacts> ContactsList = bll.ShowContacts();
            if (ContactsList != null && ContactsList.Count > 0)
            {
                lstbox_Contacts.DataSource = ContactsList; 
            }
            else
            {
                lstbox_Contacts.DataSource = null;
            }
        }

        private void btn_EditContact_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            Guid ID = ((Entities.Contacts)lstbox_Contacts.SelectedItem).ID;
            ReturnValues myenum = bll.EditContact(ID, txt_s_Name.Text, txt_s_Lastname.Text, txt_s_PhoneNumber1.Text, txt_s_PhoneNumber2.Text, txt_s_PhoneNumber3.Text, 
                txt_s_EmailAddress.Text, txt_s_WebAddress.Text, txt_s_Address.Text, txt_s_Info.Text);
            if (myenum == ReturnValues.successful)
            {
                FillContactList();
                MessageBox.Show("Record edited successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearGrpBox_SelectedRecord();
            }
            else if (myenum == ReturnValues.failed)
            {
                MessageBox.Show("Check Name, Surname, PhoneNumber1. These fields must be full.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

        }

        private void btn_DeleteContact_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            Guid ID = ((Entities.Contacts)lstbox_Contacts.SelectedItem).ID;
            ReturnValues myenum = bll.DeleteContact(ID);
            if (myenum == ReturnValues.successful)
            {
                FillContactList();
                MessageBox.Show("Deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearGrpBox_SelectedRecord();
            }
            else if (myenum == ReturnValues.failed)
            {
                MessageBox.Show("Deletion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lstbox_Contacts_DoubleClick(object sender, EventArgs e)
        {
            ListBox ContactsList = (ListBox)sender;
            Entities.Contacts SelectedContact = (Entities.Contacts)ContactsList.SelectedItem;
            if (SelectedContact != null)
            {
                txt_s_Name.Text = SelectedContact.Name;
                txt_s_Lastname.Text = SelectedContact.Lastname;
                txt_s_PhoneNumber1.Text = SelectedContact.PhoneNumber1;
                txt_s_PhoneNumber2.Text = SelectedContact.PhoneNumber2;
                txt_s_PhoneNumber3.Text = SelectedContact.PhoneNumber3;
                txt_s_EmailAddress.Text = SelectedContact.EmailAddress;
                txt_s_WebAddress.Text = SelectedContact.WebAddress;
                txt_s_Address.Text = SelectedContact.Address;
                txt_s_Info.Text = SelectedContact.Info;
            }
        }

        private void ClearGrpBox_NewRecord()
        {
            foreach (Control c in grpBox_NewRecord.Controls)
            {
                if (c is TextBox)
                {
                    c.ResetText();
                }
            }           
        }

        private void ClearGrpBox_SelectedRecord()
        {
            foreach (Control c in grpBox_SelectedRecord.Controls)
            {
                if (c is TextBox)
                {
                    c.ResetText();
                }
            }
        }
    }
}
