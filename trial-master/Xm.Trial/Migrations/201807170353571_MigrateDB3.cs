namespace Xm.Trial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostStatistics", "Title", c => c.String());
            DropColumn("dbo.PostStatistics", "PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PostStatistics", "PostId", c => c.Int(nullable: false));
            DropColumn("dbo.PostStatistics", "Title");
        }
    }
}
