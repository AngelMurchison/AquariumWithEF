namespace EFAquarium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAqCreatureTablee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AquariumCreatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatureId = c.Int(),
                        AquariumId = c.Int(),
                        OceanId = c.Int(),
                        AquariumName = c.String(),
                        OceanName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AquariumCreatures");
        }
    }
}
