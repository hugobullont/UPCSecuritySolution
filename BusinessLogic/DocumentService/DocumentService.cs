using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DocumentRepository;
using Entities;

namespace BusinessLogic.DocumentService
{
    public class DocumentService : IDocumentService
    {
        public void InsertDocument(Document objDocument)
        {
            IDocumentRepository repository = new DocumentRepository();
            repository.InsertDocument(objDocument);
        }

        public void UpdateDocument(Document objDocument)
        {
            IDocumentRepository repository = new DocumentRepository();
            repository.UpdateDocument(objDocument);
        }

        public List<Document> GetAllDocuments()
        {
            IDocumentRepository repository = new DocumentRepository();
            return repository.GetAllDocuments();
        }
    }
}
