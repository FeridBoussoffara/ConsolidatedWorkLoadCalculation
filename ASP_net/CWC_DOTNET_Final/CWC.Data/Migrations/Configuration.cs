namespace CWC.Data.Migrations
{
    using Domain.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.MyCWCContexte>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.MyCWCContexte context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Microsoft.AspNet.Identity.EntityFramework.IdentityRole Role1 = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("Administrator");
            Microsoft.AspNet.Identity.EntityFramework.IdentityRole Role2 = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("TeamLeader");
            Microsoft.AspNet.Identity.EntityFramework.IdentityRole Role3 = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("Trainer");
            Microsoft.AspNet.Identity.EntityFramework.IdentityRole Role4 = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole("Employee");

            context.Roles.Add(Role1);
            context.Roles.Add(Role2);
            context.Roles.Add(Role3);
            context.Roles.Add(Role4);
            var passwordHash = new PasswordHasher();
            passwordHash.HashPassword("Password@123");
            Employee A = new Employee
            {
                FirstName = "Le Grand",
                LastName = "Manitou",
                UserName = "master@grand.com",
                Email = "master@grand.com",
                HireDate = new DateTime(2014, 1, 1),
                EmailConfirmed = true,
                PhoneNumberConfirmed = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                TwoFactorEnabled = false,
                PasswordHash = passwordHash.HashPassword("Tunisia22²"),
                SecurityStamp="CCCC"
            };
            Trainor T = new Trainor
            {
                FirstName = "Jotaro",
                LastName = "Kujo",
                UserName = "jotaro.kujo@oraora.com",
                Email = "jotaro.kujo@oraora.com",
                HireDate = new DateTime(2014, 1, 1),
                EmailConfirmed = true,
                PhoneNumberConfirmed = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                TwoFactorEnabled = false,
                PasswordHash = passwordHash.HashPassword("Tunisia22²"),
                SecurityStamp="AAAA"

        };
            TeamLeader TL = new TeamLeader
            {
                FirstName = "Joestar",
                LastName = "Joseph",
                UserName = "joseph.joestar@ohno.com",
                Email = "joseph.joestar@ohno.com",
                HireDate = new DateTime(2013, 1, 1),
                EmailConfirmed = true,
                PhoneNumberConfirmed = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                TwoFactorEnabled = false,
                PasswordHash = passwordHash.HashPassword("Tunisia22²"),
                SecurityStamp="BBBB"

            };
            context.Users.Add(TL);
            context.Set<IdentityUserRole>().Add(new IdentityUserRole
            {
                RoleId = Role2.Id,
                UserId = TL.Id
            });
            context.Users.Add(T);
            context.Set<IdentityUserRole>().Add(new IdentityUserRole
            {
                RoleId = Role3.Id,
                UserId = T.Id
            });
            context.Users.Add(A);
            context.Set<IdentityUserRole>().Add(new IdentityUserRole
            {
                RoleId = Role1.Id,
                UserId = A.Id
            });
            Random Generator = new Random();
            Random RandMonth = new Random();
            Random RandDay = new Random();
            Random BudgetGenerator = new Random();
            int Month;
            int Day;
            for (int i = 0; i < 50; i++)
            {
                Month = RandMonth.Next(1, 13);
                Day = RandDay.Next(1, 32);
                Activity a = new Activity
                {
                    DateActivity = new DateTime(2014, Month, Day),
                    State = "Done",
                    TrainerId = T.Id,
                    Name = "Workshop 2014/" + Month + "/" + Day,
                    Type = "Workshop"
                };
                context.DbActivity.Add(a);
            }
           

            for (int i = 0; i < 10; i++)
            {
                GroupProject b = new GroupProject
                {
                    Budget = BudgetGenerator.Next(10000, 20000),
                    Name = "Project" + i,
                    StartDate = new DateTime(2014, 1, 1),
                    EndDate = new DateTime(2014, RandMonth.Next(1, 13), RandDay.Next(1, 32)),
                    State = Generator.Next(1, 100) > 50 ? "En cours" : "Terminé",
                    TeamLeader = TL
                };
                for (int c = 0; c < Generator.Next(4, 8); c++)
                {
                    Task t = new Task
                    {
                        DeadLine = new DateTime(2014, RandMonth.Next(1, 13), RandDay.Next(1, 32)),
                        StartDate = new DateTime(2014, 1, 1),
                        EndDate = new DateTime(2014, RandMonth.Next(1, 13), RandDay.Next(1, 32)),
                        Name = "Task" + c,
                        Priority = Generator.Next(1, 100),
                        State = Generator.Next(1, 100) > 50 ? true : false,
                        Project = b,
                        EmployeeId = A.Id
                    };
                    
                    context.DbTask.Add(t);
                    b.Tasks.Add(t);
                    };
                 
                context.DbProject.Add(b);
                }

            for (int i = 0; i < 10; i++)
            {
                Customer c = new Customer
                {
                    Name = "Customer" + i,
                    Email = "cutomser" + i + "@cwc.com",
                    Adresse = "Address" + i,
                    PhoneNumber = (i * 100000).ToString(),
                    Type = Generator.Next(1, 100) > 50 ? "Active" : "Regular"
                };
                Product p = new Product
                {
                    Name = "Product" + i,
                    Price = (float)Generator.NextDouble() * 100,
                    Quantity = Generator.Next(1, 5000),
                    AddedDate = new DateTime(2016, RandMonth.Next(1, 13), RandDay.Next(1, 32)),



                };
                OrderSale os = new OrderSale
                {
                    //ProductId= Generator.Next(1, 10),
                    //CustomerId= Generator.Next(1, 10),
                    Product = p,
                    customer = c,
                    DateOrder = new DateTime(2016, RandMonth.Next(1, 13), RandDay.Next(1, 32)),
                    DateSale = new DateTime(2016, RandMonth.Next(1, 13), RandDay.Next(1, 32)),

                    quantity = Generator.Next(1, 100),
                     
                }; 
                context.DbProduct.Add(p);

                context.DbCustomer.Add(c);
                context.DbOrderSale.Add(os);


            }
        }
        }

    }
