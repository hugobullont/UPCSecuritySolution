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
    public partial class FrmSupervisor : Form
    {
        private FrmLogin frmLogin;
        public FrmSupervisor()
        {
            InitializeComponent();
        }
        public FrmSupervisor(FrmLogin value)
        {
            InitializeComponent();
            frmLogin = value;
        }

        private void FrmSupervisor_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin.Show();
        }

        private void incidenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIncidence frmIncidence = new FrmIncidence();
            frmIncidence.MdiParent = this;
            frmIncidence.Show();
        }

        private void documentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDocument frmDocument = new FrmDocument();
            frmDocument.MdiParent = this;
            frmDocument.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin.Show();
        }

        private void FrmSupervisor_Load(object sender, EventArgs e)
        {
            
        }
    }
}
