using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.DocumentService;
using Entities;
using BusinessLogic.IncidenceService;

namespace UPCSecurity
{
    public partial class FrmDocument : Form
    {
        public FrmDocument()
        {
            InitializeComponent();
        }

        private readonly IDocumentService DocumentService = new DocumentService();
        private readonly IIncidenceService IncidenceService = new IncidenceService();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                Document newDocument = new Document()
                {
                    Code = txtCode.Text,
                    Name = txtName.Text,
                    FilePath = txtFilePath.Text,
                    Description = txtDescription.Text,
                    DocType = cbDocType.Text,
                    idIncidence = Convert.ToInt32(cbIncidence.Text)
                };
                DocumentService.InsertDocument(newDocument);
                UpdateDocumentList();
            }
        }

        private void FrmDocument_Load(object sender, EventArgs e)
        {
            UpdateDocumentList();
            
        }

        private void UpdateDocumentList()
        {
            cbIncidence.DataSource = IncidenceService.GetAllIncidences();
            dgvDocument.DataSource = DocumentService.GetAllDocuments();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidateId() && ValidateFields())
            {
                Document newDocument = new Document()
                {
                    idDocument = Convert.ToInt32(txtId.Text),
                    Code = txtCode.Text,
                    Name = txtName.Text,
                    FilePath = txtFilePath.Text,
                    Description = txtDescription.Text,
                    DocType = cbDocType.Text,
                    idIncidence = Convert.ToInt32(cbIncidence.SelectedValue)
                };
                DocumentService.UpdateDocument(newDocument);
                UpdateDocumentList();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select a File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }

        private bool ValidateFields()
        {
            bool pass = true;
            string errorMessage = string.Empty;

            if (string.IsNullOrEmpty(txtCode.Text))
            {
                errorMessage += "Enter a valid code" + System.Environment.NewLine;
                pass = false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorMessage += "Enter a valid name" + System.Environment.NewLine;
                pass = false;
            }

            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                errorMessage += "Enter a valid file path" + System.Environment.NewLine;
                pass = false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorMessage += "Enter a description" + System.Environment.NewLine;
                pass = false;
            }
            if (string.IsNullOrEmpty(cbDocType.Text))
            {
                errorMessage += "Enter a valid document type" + System.Environment.NewLine;
                pass = false;
            }
            if (string.IsNullOrEmpty(cbIncidence.Text))
            {
                errorMessage += "Enter a valid incidence id" + System.Environment.NewLine;
                pass = false;
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage, "Error");
            }
            return pass;
        }

        private bool ValidateId()
        {
            int id;
            if (!int.TryParse(txtId.Text, out id))
            {
                MessageBox.Show("Enter a valid id", "Error");
                return false;
            }
            return true;
        }
    }
}
