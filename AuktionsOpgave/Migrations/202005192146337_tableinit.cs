namespace AuktionsOpgave.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableinit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Amount = c.Int(nullable: false),
                        Expire = c.DateTime(nullable: false),
                        Buyer_Id = c.Int(),
                        Seller_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Buyer_Id)
                .ForeignKey("dbo.People", t => t.Seller_Id)
                .Index(t => t.Buyer_Id)
                .Index(t => t.Seller_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Telnr = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Seller_Id", "dbo.People");
            DropForeignKey("dbo.Items", "Buyer_Id", "dbo.People");
            DropIndex("dbo.Items", new[] { "Seller_Id" });
            DropIndex("dbo.Items", new[] { "Buyer_Id" });
            DropTable("dbo.People");
            DropTable("dbo.Items");
        }
    }
}
