namespace Uczelnia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baza",
                c => new
                    {
                        BazaId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        PrzedmiotId = c.Int(nullable: false),
                        ProwadzacyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BazaId)
                .ForeignKey("dbo.Prowadzacy", t => t.ProwadzacyId, cascadeDelete: true)
                .ForeignKey("dbo.Przedmiot", t => t.PrzedmiotId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.PrzedmiotId)
                .Index(t => t.ProwadzacyId);
            
            CreateTable(
                "dbo.Prowadzacy",
                c => new
                    {
                        ProwadzacyId = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                    })
                .PrimaryKey(t => t.ProwadzacyId);
            
            CreateTable(
                "dbo.Przedmiot",
                c => new
                    {
                        PrzedmiotId = c.Int(nullable: false, identity: true),
                        NazwaPrzemiotu = c.String(),
                    })
                .PrimaryKey(t => t.PrzedmiotId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Jaka",
                c => new
                    {
                        JakaId = c.Int(nullable: false, identity: true),
                        jakatoocena = c.String(),
                    })
                .PrimaryKey(t => t.JakaId);
            
            CreateTable(
                "dbo.Ocena",
                c => new
                    {
                        OcenaId = c.Int(nullable: false, identity: true),
                        ocenka = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OcenaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Baza", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Baza", "PrzedmiotId", "dbo.Przedmiot");
            DropForeignKey("dbo.Baza", "ProwadzacyId", "dbo.Prowadzacy");
            DropIndex("dbo.Baza", new[] { "ProwadzacyId" });
            DropIndex("dbo.Baza", new[] { "PrzedmiotId" });
            DropIndex("dbo.Baza", new[] { "StudentId" });
            DropTable("dbo.Ocena");
            DropTable("dbo.Jaka");
            DropTable("dbo.Student");
            DropTable("dbo.Przedmiot");
            DropTable("dbo.Prowadzacy");
            DropTable("dbo.Baza");
        }
    }
}
