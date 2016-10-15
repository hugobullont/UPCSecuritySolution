using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BusinessLogic.UserService;

namespace UPCSecurity
{
    public partial class FrmLogin : Form
    {
        private IUserService UserService;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = this.txtUser.Text;
            string password = this.txtPass.Text;
            string typeUser = UserService.TypeUser(userName, password);
   
            switch (typeUser)
            {
                case "Admin": FrmAdmin frmAdmin = new FrmAdmin(this, UserService.GetUser(userName,password)); Hide(); frmAdmin.Show();  break;
                case "Sup": FrmSupervisor frmSup = new FrmSupervisor(this, UserService.GetUser(userName, password)); Hide(); frmSup.Show(); break;
                case "null": MessageBox.Show("Wrong Username/Password!!!", "Try Again", MessageBoxButtons.OK); break;
            }
                



        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.UserService = new UserService();
        }
    }
}
