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
    }
}
