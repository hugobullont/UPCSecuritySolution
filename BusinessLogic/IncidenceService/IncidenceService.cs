using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccess.IncidenceRepository;

namespace BusinessLogic.IncidenceService
{
    public class IncidenceService : IIncidenceService
    {
        public List<Entities.Incidence> GetAllIncidences()
        {
            IIncidenceRepository repository = new IncidenceRepository();
            return repository.GetAllIncidences();
        }

        public void InsertIncidence(Entities.Incidence objincidence)
        {
            IIncidenceRepository repository = new IncidenceRepository();
            repository.InsertIncidence(objincidence);
        }


        public List<Incidence> GetIncidencesByCustomer(int selectedcustomer)
        {
            IIncidenceRepository repository = new IncidenceRepository();
            return repository.GetIncidencesByCustomer(selectedcustomer);
        }


        public List<Incidence> GetIncidencesByDates(DateTime date1, DateTime date2, int selectedcustomer)
        {
            IIncidenceRepository repository = new IncidenceRepository();
            return repository.GetIncidencesByDates(date1, date2, selectedcustomer);
        }

        public void UpdateIncidence(Incidence objIncidence)
        {
            IIncidenceRepository repository = new IncidenceRepository();
            repository.UpdateIncidence(objIncidence);
        }
    }
}
