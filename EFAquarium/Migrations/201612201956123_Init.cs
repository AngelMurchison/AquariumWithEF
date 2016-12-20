namespace EFAquarium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aquaria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        city = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Creatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        type = c.String(),
                        length = c.Double(),
                        weight = c.Double(),
                        color = c.String(),
                        name = c.String(),
                        oceanId = c.Int(),
                        aquariumId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aquaria", t => t.aquariumId)
                .ForeignKey("dbo.Oceans", t => t.oceanId)
                .Index(t => t.oceanId)
                .Index(t => t.aquariumId);
            
            CreateTable(
                "dbo.Oceans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        averageTemperature = c.String(),
                        Aquarium_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aquaria", t => t.Aquarium_Id)
                .Index(t => t.Aquarium_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oceans", "Aquarium_Id", "dbo.Aquaria");
            DropForeignKey("dbo.Creatures", "oceanId", "dbo.Oceans");
            DropForeignKey("dbo.Creatures", "aquariumId", "dbo.Aquaria");
            DropIndex("dbo.Oceans", new[] { "Aquarium_Id" });
            DropIndex("dbo.Creatures", new[] { "aquariumId" });
            DropIndex("dbo.Creatures", new[] { "oceanId" });
            DropTable("dbo.Oceans");
            DropTable("dbo.Creatures");
            DropTable("dbo.Aquaria");
        }
    }
}
