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
    public class GroupProjectService : Service<GroupProject>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public GroupProjectService() : base(ut)
        {

        }

        public GroupProject GetGroup(int id)
        {
            return ut.getRepository<GroupProject>().GetMany(p => p.ProjectId == id).FirstOrDefault();
        }
    }
}
