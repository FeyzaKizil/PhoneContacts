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
    public partial class UserLoginScreen : Form
    {
        BusinessLogicLayer.BLL bll;
        public UserLoginScreen()
        {
            InitializeComponent();
            bll = new BusinessLogicLayer.BLL();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {

            ReturnValues returnValue = bll.LoginCheck(txt_Username.Text, txt_Password.Text);

            if (returnValue == ReturnValues.successful)
            {
                MainForm MF = new MainForm();
                MF.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Login, Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
