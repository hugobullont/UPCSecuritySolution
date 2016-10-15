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

namespace UPCSecurity
{
    public partial class FrmDocument : Form
    {
        public FrmDocument()
        {
            InitializeComponent();
        }

        private readonly IDocumentService service = new DocumentService();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Document newDocument = new Document()
            {
                Code = txtCode.Text,
                Name = txtName.Text,
                FilePath = txtFilePath.Text,
                Description = txtDescription.Text,
                DocType = cbDocType.Text,
                idIncidence = Convert.ToInt32(cbIncidence.SelectedValue)
            };
            service.InsertDocument(newDocument);
            UpdateDocumentList();
        }

        private void FrmDocument_Load(object sender, EventArgs e)
        {
            UpdateDocumentList();
        }

        private void UpdateDocumentList()
        {
            dgvDocument.DataSource = service.GetAllDocuments();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
            service.UpdateDocument(newDocument);
            UpdateDocumentList();
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
    }
}
