namespace Uczelnia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prowadzacy", "Identyfikator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prowadzacy", "Identyfikator");
        }
    }
}
