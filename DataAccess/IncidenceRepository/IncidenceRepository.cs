using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.IncidenceRepository
{
    public class IncidenceRepository : IIncidenceRepository
    {
        public List<Entities.Incidence> GetAllIncidences()
        {
            UPCSecurityEntities UPCModel = new UPCSecurityEntities();
            List<Incidence> incidences = (from c in UPCModel.Incidences
                                        select c).ToList();
            return incidences;
        }

        public void InsertIncidence(Entities.Incidence objincidence)
        {
            using (var model = new UPCSecurityEntities())
            {
                model.Incidences.Add(objincidence);
                model.SaveChanges();
            }
        }
    }
}
