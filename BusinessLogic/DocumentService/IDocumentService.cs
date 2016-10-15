using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BusinessLogic.DocumentService
{
    public interface IDocumentService
    {
        void InsertDocument(Document objDocument);
        void UpdateDocument(Document objDocument);
        List<Document> GetAllDocuments();
    }
}
