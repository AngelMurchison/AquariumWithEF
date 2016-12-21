namespace EFAquarium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAQCreatureVirtuality : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AquariumCreatures", "Aquarium_Id", c => c.Int());
            AddColumn("dbo.AquariumCreatures", "Creature_Id", c => c.Int());
            AddColumn("dbo.AquariumCreatures", "Ocean_Id", c => c.Int());
            CreateIndex("dbo.AquariumCreatures", "Aquarium_Id");
            CreateIndex("dbo.AquariumCreatures", "Creature_Id");
            CreateIndex("dbo.AquariumCreatures", "Ocean_Id");
            AddForeignKey("dbo.AquariumCreatures", "Aquarium_Id", "dbo.Aquaria", "Id");
            AddForeignKey("dbo.AquariumCreatures", "Creature_Id", "dbo.Creatures", "Id");
            AddForeignKey("dbo.AquariumCreatures", "Ocean_Id", "dbo.Oceans", "Id");
            DropColumn("dbo.AquariumCreatures", "CreatureId");
            DropColumn("dbo.AquariumCreatures", "AquariumId");
            DropColumn("dbo.AquariumCreatures", "OceanId");
            DropColumn("dbo.AquariumCreatures", "AquariumName");
            DropColumn("dbo.AquariumCreatures", "OceanName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AquariumCreatures", "OceanName", c => c.String());
            AddColumn("dbo.AquariumCreatures", "AquariumName", c => c.String());
            AddColumn("dbo.AquariumCreatures", "OceanId", c => c.Int());
            AddColumn("dbo.AquariumCreatures", "AquariumId", c => c.Int());
            AddColumn("dbo.AquariumCreatures", "CreatureId", c => c.Int());
            DropForeignKey("dbo.AquariumCreatures", "Ocean_Id", "dbo.Oceans");
            DropForeignKey("dbo.AquariumCreatures", "Creature_Id", "dbo.Creatures");
            DropForeignKey("dbo.AquariumCreatures", "Aquarium_Id", "dbo.Aquaria");
            DropIndex("dbo.AquariumCreatures", new[] { "Ocean_Id" });
            DropIndex("dbo.AquariumCreatures", new[] { "Creature_Id" });
            DropIndex("dbo.AquariumCreatures", new[] { "Aquarium_Id" });
            DropColumn("dbo.AquariumCreatures", "Ocean_Id");
            DropColumn("dbo.AquariumCreatures", "Creature_Id");
            DropColumn("dbo.AquariumCreatures", "Aquarium_Id");
        }
    }
}
