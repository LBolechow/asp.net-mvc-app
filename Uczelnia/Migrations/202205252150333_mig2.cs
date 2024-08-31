namespace Uczelnia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "index", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "index");
        }
    }
}
