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
            int ReturnValue = bll.AddContact(txt_Name.Text, txt_Lastname.Text, txt_PhoneNumber1.Text, txt_PhoneNumber2.Text, txt_PhoneNumber3.Text,
                txt_EmailAddress.Text, txt_WebAddress.Text, txt_Address.Text, txt_Info.Text);
            if (ReturnValue > 0)
            {
                FillContactList();
                MessageBox.Show("New record succesfully added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearGrpBox_NewRecord();
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
            int ReturnValue = bll.EditContact(ID, txt_s_Name.Text, txt_s_Lastname.Text, txt_s_PhoneNumber1.Text, txt_s_PhoneNumber2.Text, txt_s_PhoneNumber3.Text, 
                txt_s_EmailAddress.Text, txt_s_WebAddress.Text, txt_s_Address.Text, txt_s_Info.Text);
            if (ReturnValue > 0)
            {
                FillContactList();
                MessageBox.Show("Record edited successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearGrpBox_SelectedRecord();
            }
        }

        private void btn_DeleteContact_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL bll = new BusinessLogicLayer.BLL();
            Guid ID = ((Entities.Contacts)lstbox_Contacts.SelectedItem).ID;
            int ReturnValue = bll.DeleteContact(ID);
            if (ReturnValue > 0)
            {
                FillContactList();
                MessageBox.Show("Deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearGrpBox_SelectedRecord();
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
