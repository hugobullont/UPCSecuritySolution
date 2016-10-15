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
            User newUser = new User()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                UserType = cbUserType.Text
            };
            UserService.NewUser(newUser);
            updateUserList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UserService.DeleteUser(Convert.ToInt32(txtID.Text));
            updateUserList();
        }
    }
}
