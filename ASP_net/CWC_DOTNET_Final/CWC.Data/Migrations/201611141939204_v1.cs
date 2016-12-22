namespace CWC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Type = c.String(unicode: false),
                        State = c.String(unicode: false),
                        DateActivity = c.DateTime(nullable: false, precision: 0),
                        TrainerId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.AspNetUsers", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.RatingActivities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false),
                        EmployeId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Note = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.ActivityId, t.EmployeId })
                .ForeignKey("dbo.Activities", t => t.ActivityId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeId)
                .Index(t => t.ActivityId)
                .Index(t => t.EmployeId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Email = c.String(maxLength: 128, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        CIN = c.String(unicode: false),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        HireDate = c.DateTime(precision: 0),
                        Photo = c.String(unicode: false),
                        Adresse = c.String(unicode: false),
                        Discriminator = c.String(maxLength: 128, storeType: "nvarchar"),
                        GroupProject_ProjectId = c.Int(),
                        Type = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.GroupProject_ProjectId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.GroupProject_ProjectId);
            
            CreateTable(
                "dbo.Assignements",
                c => new
                    {
                        AssignementId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProjectId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false, precision: 0),
                        DateOut = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.AssignementId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false, precision: 0),
                        EndDate = c.DateTime(nullable: false, precision: 0),
                        Budget = c.Single(nullable: false),
                        TypeProject = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Name = c.String(unicode: false),
                        State = c.String(unicode: false),
                        TeamLeaderId = c.String(maxLength: 128, storeType: "nvarchar"),
                        SingleEmployeeId = c.String(maxLength: 128, storeType: "nvarchar"),
                        Type = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.AspNetUsers", t => t.TeamLeaderId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.SingleEmployeeId)
                .Index(t => t.TeamLeaderId)
                .Index(t => t.SingleEmployeeId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        DeadLine = c.DateTime(nullable: false, precision: 0),
                        StartDate = c.DateTime(nullable: false, precision: 0),
                        EndDate = c.DateTime(precision: 0),
                        Priority = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        EmployeeId = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        CheckIn = c.DateTime(nullable: false, precision: 0),
                        CheckOut = c.DateTime(nullable: false, precision: 0),
                        EmployeeId = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ERPApps",
                c => new
                    {
                        ERPAppId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        fonder = c.String(unicode: false),
                        logo = c.String(unicode: false),
                        type = c.Int(nullable: false),
                        Administrator_Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ERPAppId)
                .ForeignKey("dbo.AspNetUsers", t => t.Administrator_Id)
                .Index(t => t.Administrator_Id);
            
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        LeaveId = c.Int(nullable: false, identity: true),
                        Category = c.String(unicode: false),
                        StartDate = c.DateTime(nullable: false, precision: 0),
                        EndDate = c.DateTime(nullable: false, precision: 0),
                        State = c.Boolean(nullable: false),
                        EmployeeId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.LeaveId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PaySlips",
                c => new
                    {
                        PaySlipId = c.Int(nullable: false, identity: true),
                        GrossPay = c.Single(nullable: false),
                        NetPay = c.Single(nullable: false),
                        Prime = c.Single(nullable: false),
                        EmployeeId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.PaySlipId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        Number = c.Single(nullable: false),
                        DateRating = c.DateTime(nullable: false, precision: 0),
                        TeamLeaderId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.AspNetUsers", t => t.TeamLeaderId, cascadeDelete: true)
                .Index(t => t.TeamLeaderId);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        RewardId = c.Int(nullable: false, identity: true),
                        RewardType = c.String(unicode: false),
                        DateReward = c.DateTime(nullable: false, precision: 0),
                        EmployeeId = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.RewardId)
                .ForeignKey("dbo.AspNetUsers", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        Photo = c.String(unicode: false),
                        Type = c.String(unicode: false),
                        Adresse = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderSales",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        DateOrder = c.DateTime(nullable: false, precision: 0),
                        DateSale = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => new { t.ProductId, t.CustomerId })
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Photo = c.String(unicode: false),
                        Price = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        AddedDate = c.DateTime(nullable: false, precision: 0),
                        Category = c.Int(),
                        ValidityDate = c.DateTime(precision: 0),
                        Brand = c.String(unicode: false),
                        weightElec = c.Single(),
                        weightFur = c.Single(),
                        Material = c.String(unicode: false),
                        Version = c.String(unicode: false),
                        Technology = c.String(unicode: false),
                        WheelsNbr = c.Int(),
                        Capacity = c.Int(),
                        VehiculeType = c.String(unicode: false),
                        weightveh = c.Single(),
                        Type = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.OrderPurchases",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        ProviderId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        DateOrder = c.DateTime(nullable: false, precision: 0),
                        DatePurchase = c.DateTime(precision: 0),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ProviderId })
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Providers", t => t.ProviderId)
                .Index(t => t.ProductId)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ProviderId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        NumTel = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Logo = c.String(unicode: false),
                        Adresse = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ProviderId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.HistoryRows",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        ContextKey = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Model = c.Binary(),
                        ProductVersion = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.MigrationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderSales", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderPurchases", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.OrderPurchases", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderSales", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Activities", "TrainerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RatingActivities", "EmployeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rewards", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "TeamLeaderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PaySlips", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Leaves", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "SingleEmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "TeamLeaderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ERPApps", "Administrator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attendances", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "GroupProject_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Assignements", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Assignements", "EmployeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RatingActivities", "ActivityId", "dbo.Activities");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderPurchases", new[] { "ProviderId" });
            DropIndex("dbo.OrderPurchases", new[] { "ProductId" });
            DropIndex("dbo.OrderSales", new[] { "CustomerId" });
            DropIndex("dbo.OrderSales", new[] { "ProductId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Rewards", new[] { "EmployeeId" });
            DropIndex("dbo.Ratings", new[] { "TeamLeaderId" });
            DropIndex("dbo.PaySlips", new[] { "EmployeeId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Leaves", new[] { "EmployeeId" });
            DropIndex("dbo.ERPApps", new[] { "Administrator_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Attendances", new[] { "EmployeeId" });
            DropIndex("dbo.Tasks", new[] { "EmployeeId" });
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "SingleEmployeeId" });
            DropIndex("dbo.Projects", new[] { "TeamLeaderId" });
            DropIndex("dbo.Assignements", new[] { "ProjectId" });
            DropIndex("dbo.Assignements", new[] { "EmployeeId" });
            DropIndex("dbo.AspNetUsers", new[] { "GroupProject_ProjectId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.RatingActivities", new[] { "EmployeId" });
            DropIndex("dbo.RatingActivities", new[] { "ActivityId" });
            DropIndex("dbo.Activities", new[] { "TrainerId" });
            DropTable("dbo.HistoryRows");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Providers");
            DropTable("dbo.OrderPurchases");
            DropTable("dbo.Products");
            DropTable("dbo.OrderSales");
            DropTable("dbo.Customers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Rewards");
            DropTable("dbo.Ratings");
            DropTable("dbo.PaySlips");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Leaves");
            DropTable("dbo.ERPApps");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Attendances");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
            DropTable("dbo.Assignements");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.RatingActivities");
            DropTable("dbo.Activities");
        }
    }
}
