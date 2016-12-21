namespace EFAquarium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restructured : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Creatures", "aquariumId", "dbo.Aquaria");
            DropForeignKey("dbo.Creatures", "oceanId", "dbo.Oceans");
            DropIndex("dbo.Creatures", new[] { "oceanId" });
            DropIndex("dbo.Creatures", new[] { "aquariumId" });
            RenameColumn(table: "dbo.AquariumCreatures", name: "Aquarium_Id", newName: "AquariumID");
            RenameColumn(table: "dbo.AquariumCreatures", name: "Creature_Id", newName: "CreatureID");
            RenameColumn(table: "dbo.AquariumCreatures", name: "Ocean_Id", newName: "OceanID");
            RenameIndex(table: "dbo.AquariumCreatures", name: "IX_Creature_Id", newName: "IX_CreatureID");
            RenameIndex(table: "dbo.AquariumCreatures", name: "IX_Aquarium_Id", newName: "IX_AquariumID");
            RenameIndex(table: "dbo.AquariumCreatures", name: "IX_Ocean_Id", newName: "IX_OceanID");
            DropColumn("dbo.Creatures", "oceanId");
            DropColumn("dbo.Creatures", "aquariumId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Creatures", "aquariumId", c => c.Int());
            AddColumn("dbo.Creatures", "oceanId", c => c.Int());
            RenameIndex(table: "dbo.AquariumCreatures", name: "IX_OceanID", newName: "IX_Ocean_Id");
            RenameIndex(table: "dbo.AquariumCreatures", name: "IX_AquariumID", newName: "IX_Aquarium_Id");
            RenameIndex(table: "dbo.AquariumCreatures", name: "IX_CreatureID", newName: "IX_Creature_Id");
            RenameColumn(table: "dbo.AquariumCreatures", name: "OceanID", newName: "Ocean_Id");
            RenameColumn(table: "dbo.AquariumCreatures", name: "CreatureID", newName: "Creature_Id");
            RenameColumn(table: "dbo.AquariumCreatures", name: "AquariumID", newName: "Aquarium_Id");
            CreateIndex("dbo.Creatures", "aquariumId");
            CreateIndex("dbo.Creatures", "oceanId");
            AddForeignKey("dbo.Creatures", "oceanId", "dbo.Oceans", "Id");
            AddForeignKey("dbo.Creatures", "aquariumId", "dbo.Aquaria", "Id");
        }
    }
}
