using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccess.IncidenceRepository
{
    public interface IIncidenceRepository
    {
        List<Incidence> GetAllIncidences();

        List<Incidence> GetIncidencesByCustomer(int selectedcustomer);

        void InsertIncidence(Incidence objincidence);

        List<Incidence> GetIncidencesByDates(DateTime date1, DateTime date2, int selectedcustomer);


    }
}
