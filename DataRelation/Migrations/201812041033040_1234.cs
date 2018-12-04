namespace DataRelation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1234 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Images", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "UserID");
            AddForeignKey("dbo.Images", "UserID", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "UserID", "dbo.Users");
            DropIndex("dbo.Images", new[] { "UserID" });
            DropColumn("dbo.Images", "UserID");
            DropTable("dbo.Users");
        }
    }
}
