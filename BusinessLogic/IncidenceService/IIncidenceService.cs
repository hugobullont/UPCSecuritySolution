using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccess.IncidenceRepository;

namespace BusinessLogic.IncidenceService
{
    public interface IIncidenceService
    {
        List<Incidence> GetAllIncidences();

        void InsertIncidence(Incidence objincidence);

        List<Incidence> GetIncidencesByCustomer(int selectedcustomer);

        List<Incidence> GetIncidencesByDates(DateTime date1, DateTime date2, int selectedcustomer);
        void UpdateIncidence(Incidence objIncidence);
    }
}
