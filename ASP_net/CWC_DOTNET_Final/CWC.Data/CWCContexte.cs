using CWC.Data.Configuration;
using CWC.Domain;
using CWC.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.History;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]

    public class MyCWCContexte : IdentityDbContext
    {
        public MyCWCContexte()
            : base("name=CWCDB_final")
        {

        }
        static MyCWCContexte()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ActivityConfiguration());
            modelBuilder.Configurations.Add(new AssignementConfiguration());
            modelBuilder.Configurations.Add(new EmployeConfiguration());
            modelBuilder.Configurations.Add(new ERPAppConfiguration());
            modelBuilder.Configurations.Add(new LeaveConfiguration());
            modelBuilder.Configurations.Add(new OrderPurchaseConfiguration());
            modelBuilder.Configurations.Add(new OrderSaleConfiguration()); 
            modelBuilder.Configurations.Add(new PayslipConfiguration());
            modelBuilder.Configurations.Add(new RatingConfiguration());
            modelBuilder.Configurations.Add(new RatingActivityConfiguration());
            modelBuilder.Configurations.Add(new TaskConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProjectConfiguration());
            modelBuilder.Configurations.Add(new AttendenceConfiguration());
            modelBuilder.Configurations.Add(new RewardConfiguration());
            modelBuilder.Configurations.Add(new GroupProjectConfiguration());
            modelBuilder.Configurations.Add(new TeamLeaderConfiguration());
            modelBuilder.Entity<HistoryRow>().HasKey(h => h.MigrationId);
            modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>()
            .Property(c => c.Name).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<IdentityUser>().Property(u => u.UserName).HasMaxLength(128);
            modelBuilder.Entity<IdentityUser>().Property(u => u.Email).HasMaxLength(128);


        }
        public DbSet<Activity> DbActivity { get; set; }
        public DbSet<Attendance> DbAttendance { get; set; }
        public DbSet<Project> DbProject { get; set; }
        public DbSet<CWC.Domain.Entities.Task> DbTask { get; set; }
        public DbSet<Reward> DbReward { get; set; }
        public DbSet<ERPApp> DbERPApp { get; set; }
        public DbSet<Rating> DbRating { get; set; }

        public DbSet<Leave> DbLeave { get; set; }

        public DbSet<Product> DbProduct { get; set; }
        public DbSet<Customer> DbCustomer { get; set; }
        public DbSet<Provider> DbProvider { get; set; }
        public DbSet<OrderPurchase> DbOrderPurchase { get; set; }
        public DbSet<OrderSale> DbOrderSale { get; set; }


        public DbSet<Assignement> DbAssignement { get; set; }

        public DbSet<RatingActivity> DbRatingActivity { get; set; }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }






        public static MyCWCContexte Create()
        {
            return new MyCWCContexte();
        }


    }
}
