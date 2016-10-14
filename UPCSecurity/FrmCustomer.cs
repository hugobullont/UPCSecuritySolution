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
using BusinessLogic.CustomerService;

namespace UPCSecurity
{
    public partial class FrmCustomer : Form
    {

        private ICustomerService customerService = new CustomerService();

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void UpdateCustomerList()
        {
            List<Customer> customerList = customerService.GetAllCustomers();
            this.dataGridView1.DataSource = customerList;
        }


        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            UpdateCustomerList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Customer objCustomer = new Customer();
                objCustomer.Name = this.textBox2.Text;
                objCustomer.DNI = Convert.ToInt32(this.textBox3.Text);
                objCustomer.CustomerType = this.comboBox1.Text;

                this.customerService.InsertCustomer(objCustomer);
                this.UpdateCustomerList();
                MessageBox.Show("The customer was inserted!", "Success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
