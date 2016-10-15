using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.DocumentRepository
{
    public interface IDocumentRepository
    {
        void InsertDocument(Document objDocument);
        void UpdateDocument(Document objDocument);

        List<Document> GetAllDocuments();
    }
}
