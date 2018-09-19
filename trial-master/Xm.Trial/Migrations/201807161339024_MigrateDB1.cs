namespace Xm.Trial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Likes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PostStatistics");
        }
    }
}
