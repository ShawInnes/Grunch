namespace Grunch.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuDataObjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 2),
                        Name = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryId = c.Int(nullable: false),
                        Name = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.MenuGroupings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        Name = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.MenuItems",
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
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .ForeignKey("dbo.MenuGroupings", t => t.MenuGrouping_Id)
                .Index(t => t.RestaurantId)
                .Index(t => t.MenuGrouping_Id);
            
            CreateTable(
                "dbo.Restaurants",
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
                .ForeignKey("dbo.Suburbs", t => t.SuburbId, cascadeDelete: true)
                .Index(t => t.SuburbId);
            
            CreateTable(
                "dbo.Suburbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateId = c.Int(nullable: false),
                        Name = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .Index(t => t.StateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "MenuGrouping_Id", "dbo.MenuGroupings");
            DropForeignKey("dbo.MenuItems", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Suburbs", "StateId", "dbo.States");
            DropForeignKey("dbo.Restaurants", "SuburbId", "dbo.Suburbs");
            DropForeignKey("dbo.MenuGroupings", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropIndex("dbo.MenuItems", new[] { "MenuGrouping_Id" });
            DropIndex("dbo.MenuItems", new[] { "RestaurantId" });
            DropIndex("dbo.Suburbs", new[] { "StateId" });
            DropIndex("dbo.Restaurants", new[] { "SuburbId" });
            DropIndex("dbo.MenuGroupings", new[] { "RestaurantId" });
            DropIndex("dbo.States", new[] { "CountryId" });
            DropTable("dbo.Suburbs");
            DropTable("dbo.Restaurants");
            DropTable("dbo.MenuItems");
            DropTable("dbo.MenuGroupings");
            DropTable("dbo.States");
            DropTable("dbo.Countries");
        }
    }
}
