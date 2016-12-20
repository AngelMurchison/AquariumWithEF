namespace EFAquarium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Oceans", "Aquarium_Id", "dbo.Aquaria");
            DropIndex("dbo.Oceans", new[] { "Aquarium_Id" });
            DropColumn("dbo.Oceans", "Aquarium_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Oceans", "Aquarium_Id", c => c.Int());
            CreateIndex("dbo.Oceans", "Aquarium_Id");
            AddForeignKey("dbo.Oceans", "Aquarium_Id", "dbo.Aquaria", "Id");
        }
    }
}
