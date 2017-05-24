namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Mail = c.String(),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Amount = c.Double(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Client_Id = c.Int(),
                        Material_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id)
                .ForeignKey("dbo.Materials", t => t.Material_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Material_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "Material_Id", "dbo.Materials");
            DropForeignKey("dbo.Rents", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Materials", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Clients", "Country_Id", "dbo.Countries");
            DropIndex("dbo.Rents", new[] { "Material_Id" });
            DropIndex("dbo.Rents", new[] { "Client_Id" });
            DropIndex("dbo.Materials", new[] { "Category_Id" });
            DropIndex("dbo.Clients", new[] { "Country_Id" });
            DropTable("dbo.Rents");
            DropTable("dbo.Materials");
            DropTable("dbo.Countries");
            DropTable("dbo.Clients");
            DropTable("dbo.Categories");
        }
    }
}
