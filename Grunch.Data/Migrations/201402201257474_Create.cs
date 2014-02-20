namespace Grunch.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 2),
                        Name = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        Name = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.GroupOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Owner = c.String(),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Person = c.String(),
                        OrderDescription = c.String(),
                        Amount = c.Double(nullable: false),
                        GroupOrder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GroupOrder", t => t.GroupOrder_Id)
                .Index(t => t.GroupOrder_Id);
            
            CreateTable(
                "dbo.MenuGrouping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        Name = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.MenuItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        Name = c.String(maxLength: 25),
                        Description = c.String(maxLength: 250),
                        Price = c.Double(nullable: false),
                        MenuGrouping_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .ForeignKey("dbo.MenuGrouping", t => t.MenuGrouping_Id)
                .Index(t => t.RestaurantId)
                .Index(t => t.MenuGrouping_Id);
            
            CreateTable(
                "dbo.Restaurant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SuburbId = c.Int(nullable: false),
                        Name = c.String(maxLength: 25),
                        Phone = c.String(maxLength: 25),
                        Email = c.String(maxLength: 25),
                        Address = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suburb", t => t.SuburbId, cascadeDelete: true)
                .Index(t => t.SuburbId);
            
            CreateTable(
                "dbo.Suburb",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateId = c.Int(nullable: false),
                        Name = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.State", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItem", "MenuGrouping_Id", "dbo.MenuGrouping");
            DropForeignKey("dbo.MenuItem", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.Suburb", "StateId", "dbo.State");
            DropForeignKey("dbo.Restaurant", "SuburbId", "dbo.Suburb");
            DropForeignKey("dbo.MenuGrouping", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.Order", "GroupOrder_Id", "dbo.GroupOrder");
            DropForeignKey("dbo.State", "CountryId", "dbo.Country");
            DropIndex("dbo.MenuItem", new[] { "MenuGrouping_Id" });
            DropIndex("dbo.MenuItem", new[] { "RestaurantId" });
            DropIndex("dbo.Suburb", new[] { "StateId" });
            DropIndex("dbo.Restaurant", new[] { "SuburbId" });
            DropIndex("dbo.MenuGrouping", new[] { "RestaurantId" });
            DropIndex("dbo.Order", new[] { "GroupOrder_Id" });
            DropIndex("dbo.State", new[] { "CountryId" });
            DropTable("dbo.Suburb");
            DropTable("dbo.Restaurant");
            DropTable("dbo.MenuItem");
            DropTable("dbo.MenuGrouping");
            DropTable("dbo.Order");
            DropTable("dbo.GroupOrder");
            DropTable("dbo.State");
            DropTable("dbo.Country");
        }
    }
}
