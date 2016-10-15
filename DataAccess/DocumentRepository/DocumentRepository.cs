using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.DocumentRepository
{
    public class DocumentRepository : IDocumentRepository
    {
        public void InsertDocument(Document objDocument)
        {
            using (var model = new UPCSecurityEntities())
            {
                model.Documents.Add(objDocument);
                model.SaveChanges();
            }
        }

        public void UpdateDocument(Document objDocument)
        {
            using (var model = new UPCSecurityEntities())
            {
                var original = model.Documents.Find(objDocument.idDocument);
                if (original != null)
                {
                    model.Entry(original).CurrentValues.SetValues(objDocument);
                    model.SaveChanges();
                }
            }
    }

        public List<Document> GetAllDocuments()
        {
            return (from d in new UPCSecurityEntities().Documents.Include("Incidences") select d)
                .ToList();
        }
    }
}
