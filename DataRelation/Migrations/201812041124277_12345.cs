namespace DataRelation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12345 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "DatePosted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "DatePosted");
        }
    }
}
