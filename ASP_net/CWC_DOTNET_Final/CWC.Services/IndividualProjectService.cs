using CompteServicesPattern;
using CWC.Data.Infrastructure;
using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Services
{
    public class IndividualProjectService : Service<IndividualProject>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public IndividualProjectService() : base(ut)
        {

        }
        public IndividualProject GetIndividual(int id)
        {
            return ut.getRepository<IndividualProject>().GetMany(p => p.ProjectId == id).FirstOrDefault();
        }
    }
}
