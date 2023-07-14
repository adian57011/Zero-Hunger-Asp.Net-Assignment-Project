namespace Assingment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DATABASEANDTABLESADDEDWITHRELATIONS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Qunatity = c.Int(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        DonorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Donors", t => t.DonorId, cascadeDelete: false)
                .Index(t => t.DonorId);
            
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        DonorId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Donors", t => t.DonorId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .Index(t => t.DonorId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Requests", "DonorId", "dbo.Donors");
            DropForeignKey("dbo.Donations", "DonorId", "dbo.Donors");
            DropIndex("dbo.Requests", new[] { "EmployeeId" });
            DropIndex("dbo.Requests", new[] { "DonorId" });
            DropIndex("dbo.Donations", new[] { "DonorId" });
            DropTable("dbo.Requests");
            DropTable("dbo.Employees");
            DropTable("dbo.Donors");
            DropTable("dbo.Donations");
            DropTable("dbo.Admins");
        }
    }
}
