namespace Grunch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Owner = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 50),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Person = c.String(nullable: false),
                        OrderDescription = c.String(nullable: false),
                        Amount = c.Double(nullable: false),
                        GroupOrder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GroupOrders", t => t.GroupOrder_Id)
                .Index(t => t.GroupOrder_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "GroupOrder_Id", "dbo.GroupOrders");
            DropIndex("dbo.Orders", new[] { "GroupOrder_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.GroupOrders");
        }
    }
}
