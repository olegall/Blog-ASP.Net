namespace Xm.Trial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostStatistics", "Visits", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostStatistics", "Visits");
        }
    }
}
