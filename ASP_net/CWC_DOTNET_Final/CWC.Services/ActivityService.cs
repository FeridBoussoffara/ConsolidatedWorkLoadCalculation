using CompteServicesPattern;
using CWC.Data.Infrastructure;
using CWC.Domain.Entities;
using CWC.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Services
{
    public class ActivityService : Service<Activity>, IActivityService
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public ActivityService() : base(ut)
        {
        }

        public IEnumerable<ActivitiesPerMonth> GetActivitiesByYearAndTrainerPerMonth(int Year, Employee trainer)
        {
            List<ActivitiesPerMonth> APMs = new List<ActivitiesPerMonth>();
            var counts = GetAll()
                .Where(A => A.DateActivity.Year == Year && A.Trainor.Id == trainer.Id)
                .GroupBy(A => A.DateActivity.Month)
                .OrderBy(G => G.Key)
                .Select(g => new
                {
                    Month = g.Key,
                    Count = g.Count()
                });
            foreach (var count in counts)
            {
                APMs.Add(new ActivitiesPerMonth
                {
                    Month = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(count.Month),
                    Count = count.Count
                });
            }
            return APMs;
        }
    }
    public class ActivitiesPerMonth
    {
        public string Month { get; set; }
        public int Count { get; set; }
    }
    public interface IActivityService : IService<Activity>
    {
        IEnumerable<ActivitiesPerMonth> GetActivitiesByYearAndTrainerPerMonth(int Year, Employee trainer);
    }
}
