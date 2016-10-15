﻿using System;
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
using BusinessLogic.IncidenceService;


namespace UPCSecurity
{
    public partial class FrmIncidence : Form
    {

        private User user;
        private ICustomerService customerService = new CustomerService();
        private IIncidenceService incidenceService = new IncidenceService();
        public FrmIncidence(User valueUser)
        {
            InitializeComponent();
            user = valueUser;
        }

        private void LoadCustomers()
        {
            try
            {

                this.comboBox4.DataSource = this.customerService.GetAllCustomers();
                comboBox4.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }

        private void UpdateIncidenceList()
        {
            List<Incidence> incidenceList = incidenceService.GetAllIncidences();
            this.dataGridView1.DataSource = incidenceList;
        }
        
        private void FrmIncidence_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            UpdateIncidenceList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                Incidence objIncidence = new Incidence();
                objIncidence.Code = this.textBox2.Text;
                objIncidence.Description = this.textBox3.Text;
                objIncidence.Date = this.dateTimePicker1.Value.Date;
                objIncidence.State = this.comboBox1.Text;
                objIncidence.Environment = this.comboBox2.Text;
                objIncidence.Local = this.comboBox3.Text;
                objIncidence.idCustomer = Convert.ToInt32(this.comboBox4.SelectedValue);


            //AQUI VA EL ID DEL USUARIO ACTUALMENTE LOGUEADO
                objIncidence.idUser = user.idUser;

                

                this.incidenceService.InsertIncidence(objIncidence);
                UpdateIncidenceList();
                MessageBox.Show("The incidence was inserted!", "Success");
            }
            
        }
    }


