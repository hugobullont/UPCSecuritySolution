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
    public partial class FrmAdmin : Form
    {
        private FrmLogin frmLogin;
        public FrmAdmin()
        {
            InitializeComponent();
        }
        public FrmAdmin(FrmLogin value)
        {
            InitializeComponent();
            frmLogin = value;
        }

        private void FrmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewUser frmUser = new FrmNewUser();
            frmUser.Show();
        }
    }
}
