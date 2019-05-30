namespace AbstractRepairPlumbingServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiddleMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MessageInfoes", "ClientId", "dbo.Clients");
            DropIndex("dbo.MessageInfoes", new[] { "ClientId" });
            DropColumn("dbo.Clients", "Mail");
            DropTable("dbo.MessageInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MessageInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageId = c.String(),
                        FromMailAddress = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        DateDelivery = c.DateTime(nullable: false),
                        ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clients", "Mail", c => c.String());
            CreateIndex("dbo.MessageInfoes", "ClientId");
            AddForeignKey("dbo.MessageInfoes", "ClientId", "dbo.Clients", "Id");
        }
    }
}
