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
    }
}
