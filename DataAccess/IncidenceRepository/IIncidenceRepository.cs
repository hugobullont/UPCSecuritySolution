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

        void InsertIncidence(Incidence objincidence);
    }
}
