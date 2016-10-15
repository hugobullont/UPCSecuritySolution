using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.CustomerService;
using BusinessLogic.IncidenceService;
using Entities;

namespace UPCSecurity
{
    public partial class FrmCustomerIncidence7 : Form
    {
        private ICustomerService customerService = new CustomerService();
        private IIncidenceService incidenceService = new IncidenceService();

        private void LoadCustomers()
        {
            try
            {

                this.comboBox1.DataSource = this.customerService.GetAllCustomers();
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void ListDatagridView(int customerid)
        {
            this.dataGridView1.DataSource = this.incidenceService.GetIncidencesByCustomer(customerid);
        }

        public FrmCustomerIncidence7()
        {
            InitializeComponent();
        }

        private void FrmCustomerIncidence7_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListDatagridView(Convert.ToInt32(this.comboBox1.SelectedValue));
        }
    }
}
