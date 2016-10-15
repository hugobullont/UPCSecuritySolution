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
    public partial class FrmCustomerIncidenceDate : Form
    {

        private ICustomerService customerService = new CustomerService();
        private IIncidenceService incidenceService = new IncidenceService();
        public FrmCustomerIncidenceDate()
        {
            InitializeComponent();
        }


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

        private void FrmCustomerIncidenceDate_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void ListIncidences(DateTime date1, DateTime date2, int selectedcustomer)
        {
            this.dataGridView1.DataSource = this.incidenceService.GetIncidencesByDates(date1, date2, selectedcustomer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListIncidences(this.dateTimePicker1.Value.Date, this.dateTimePicker2.Value.Date, Convert.ToInt32(this.comboBox1.SelectedValue));
        }
    }
}
