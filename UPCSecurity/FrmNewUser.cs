using BusinessLogic.UserService;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPCSecurity
{
    public partial class FrmNewUser : Form
    {

        private IUserService UserService;
        public FrmNewUser()
        {
            InitializeComponent();
        }

        private void FrmNewUser_Load(object sender, EventArgs e)
        {
            this.UserService = new UserService();
            updateUserList();
        }

        void updateUserList()
        {
            dgvUsers.DataSource = UserService.GetAllUsers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                User newUser = new User()
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    UserType = cbUserType.Text
                };
                UserService.NewUser(newUser);
                updateUserList();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateFields() && ValidateId())
            {
                User newUser = new User()
                {
                    idUser = Convert.ToInt32(txtID.Text),
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    UserType = cbUserType.Text
                };
                UserService.UpdateUser(newUser);
                updateUserList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ValidateId())
            {
                UserService.DeleteUser(Convert.ToInt32(txtID.Text));
                updateUserList();
            }
        }

        private bool ValidateFields()
        {
            bool pass = true;
            string errorMessage = string.Empty;

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                errorMessage += "Enter a valid username" + System.Environment.NewLine;
                pass = false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorMessage += "Enter a valid password" + System.Environment.NewLine;
                pass = false;
            }
            if (string.IsNullOrEmpty(cbUserType.Text))
            {
                errorMessage += "Enter a valid user type" + System.Environment.NewLine;
                pass = false;
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Error");
            }
            return pass;
        }

        private bool ValidateId()
        {
            int id;
            if (!int.TryParse(txtID.Text, out id))
            {
                MessageBox.Show("Enter a valid id", "Error");
                return false;
            }
            return true;
        }
    }
}
