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
        private FrmNewUser frmNewUser;
        private FrmCustomer frmCustomer;
        private FrmDocument frmDocument;
        private FrmIncidence frmIncidence;

        public FrmNewUser FrmNewUser
        {
            get
            {
                if (frmNewUser == null || frmNewUser.IsDisposed)
                    frmNewUser = new FrmNewUser();
                return frmNewUser;
            }
        }

        public FrmCustomer FrmCustomer
        {
            get
            {
                if (frmCustomer==null || frmCustomer.IsDisposed)
                    frmCustomer = new FrmCustomer();
                return frmCustomer;
            }
        }
        public FrmDocument FrmDocument
        {
            get
            {
                if (frmDocument == null || frmDocument.IsDisposed)
                    frmDocument = new FrmDocument();
                return frmDocument;
            }
        }
        public FrmIncidence FrmIncidence
        {
            get
            {
                if (frmIncidence == null || frmIncidence.IsDisposed)
                    frmIncidence = new FrmIncidence();
                return frmIncidence;
            }
        }

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
            FrmNewUser.MdiParent = this;
            FrmNewUser.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCustomer.MdiParent = this;
            FrmCustomer.Show();
        }

        private void documentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDocument.MdiParent = this;
            FrmDocument.Show();
        }

        private void incidenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIncidence.MdiParent = this;
            FrmIncidence.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin.Show();
        }
    }
}
