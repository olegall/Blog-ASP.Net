namespace Xm.Trial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostStatistics", "Visit", c => c.Int(nullable: false));
            AddColumn("dbo.PostStatistics", "Like", c => c.Int(nullable: false));
            AddColumn("dbo.PostStatistics", "Referrer", c => c.String());
            DropColumn("dbo.PostStatistics", "Visits");
            DropColumn("dbo.PostStatistics", "Likes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostStatistics", "Likes", c => c.Int(nullable: false));
            AddColumn("dbo.PostStatistics", "Visits", c => c.Int(nullable: false));
            DropColumn("dbo.PostStatistics", "Referrer");
            DropColumn("dbo.PostStatistics", "Like");
            DropColumn("dbo.PostStatistics", "Visit");
        }
    }
}
