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
                if (ValidateFields())
                {
                    Customer objCustomer = new Customer();
                    objCustomer.Name = this.textBox2.Text;
                    objCustomer.DNI = Convert.ToInt32(this.textBox3.Text);
                    objCustomer.CustomerType = this.comboBox1.Text;

                    this.customerService.InsertCustomer(objCustomer);
                    this.UpdateCustomerList();
                    MessageBox.Show("The customer was inserted!", "Success");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool ValidateFields()
        {
            bool pass = true;
            string errorMessage = string.Empty;

            int dni;
            if (!int.TryParse(textBox3.Text, out dni))
            {
                errorMessage += "Enter a valid DNI" + System.Environment.NewLine;
                pass = false;
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorMessage += "Enter a valid name" + System.Environment.NewLine;
                pass = false;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Error");
            }
            return pass;
        }

        bool ValidateId()
        {
            int id;
            if (!int.TryParse(textBox1.Text, out id))
            {
                MessageBox("Enter a valid id", "Error");
                return false;
            }
            return true;
        }

    }
}
