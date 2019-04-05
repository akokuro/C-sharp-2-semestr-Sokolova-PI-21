namespace AbstractRepairPlumbingServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        RepairId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Repairs", t => t.RepairId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.RepairId);
            
            CreateTable(
                "dbo.Repairs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RepairName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RepairPlumbings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RepairId = c.Int(nullable: false),
                        PlumbingId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plumbings", t => t.PlumbingId, cascadeDelete: true)
                .ForeignKey("dbo.Repairs", t => t.RepairId, cascadeDelete: true)
                .Index(t => t.RepairId)
                .Index(t => t.PlumbingId);
            
            CreateTable(
                "dbo.Plumbings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlumbingName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoragePlumbings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorageId = c.Int(nullable: false),
                        ComponentId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plumbings", t => t.ComponentId, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.StorageId)
                .Index(t => t.ComponentId);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorageName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RepairPlumbings", "RepairId", "dbo.Repairs");
            DropForeignKey("dbo.StoragePlumbings", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.StoragePlumbings", "ComponentId", "dbo.Plumbings");
            DropForeignKey("dbo.RepairPlumbings", "PlumbingId", "dbo.Plumbings");
            DropForeignKey("dbo.Orders", "RepairId", "dbo.Repairs");
            DropForeignKey("dbo.Orders", "ClientId", "dbo.Clients");
            DropIndex("dbo.StoragePlumbings", new[] { "ComponentId" });
            DropIndex("dbo.StoragePlumbings", new[] { "StorageId" });
            DropIndex("dbo.RepairPlumbings", new[] { "PlumbingId" });
            DropIndex("dbo.RepairPlumbings", new[] { "RepairId" });
            DropIndex("dbo.Orders", new[] { "RepairId" });
            DropIndex("dbo.Orders", new[] { "ClientId" });
            DropTable("dbo.Storages");
            DropTable("dbo.StoragePlumbings");
            DropTable("dbo.Plumbings");
            DropTable("dbo.RepairPlumbings");
            DropTable("dbo.Repairs");
            DropTable("dbo.Orders");
            DropTable("dbo.Clients");
        }
    }
}
