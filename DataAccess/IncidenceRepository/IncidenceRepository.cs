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

        public List<Incidence> GetIncidencesByCustomer(int selectedcustomer)
        {
            UPCSecurityEntities UPCModel = new UPCSecurityEntities();
            List<Incidence> incidences = (from c in UPCModel.Incidences
                                       where c.idCustomer.Equals(selectedcustomer)
                                    select c).ToList();
            return incidences;
        }


        public List<Incidence> GetIncidencesByDates(DateTime date1, DateTime date2, int selectedcustomer)
        {
            UPCSecurityEntities UPCModel = new UPCSecurityEntities();
            List<Incidence> incidences = (from c in UPCModel.Incidences
                                          where c.Date>=date1 && c.Date<=date2 &&c.idCustomer.Equals(selectedcustomer)
                                          select c).ToList();
            return incidences;
        }
    }
}
