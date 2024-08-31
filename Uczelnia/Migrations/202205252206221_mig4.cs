namespace Uczelnia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Baza", "OcenaId", c => c.Int(nullable: false));
            AddColumn("dbo.Baza", "JakaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Baza", "OcenaId");
            CreateIndex("dbo.Baza", "JakaId");
            AddForeignKey("dbo.Baza", "JakaId", "dbo.Jaka", "JakaId", cascadeDelete: true);
            AddForeignKey("dbo.Baza", "OcenaId", "dbo.Ocena", "OcenaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Baza", "OcenaId", "dbo.Ocena");
            DropForeignKey("dbo.Baza", "JakaId", "dbo.Jaka");
            DropIndex("dbo.Baza", new[] { "JakaId" });
            DropIndex("dbo.Baza", new[] { "OcenaId" });
            DropColumn("dbo.Baza", "JakaId");
            DropColumn("dbo.Baza", "OcenaId");
        }
    }
}
