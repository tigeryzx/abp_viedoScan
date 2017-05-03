namespace VideoScan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFavUserRel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Favorites", "User_Id", "dbo.AbpUsers");
            DropIndex("dbo.Favorites", new[] { "User_Id" });
            AlterColumn("dbo.Favorites", "User_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.Favorites", "User_Id");
            AddForeignKey("dbo.Favorites", "User_Id", "dbo.AbpUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "User_Id", "dbo.AbpUsers");
            DropIndex("dbo.Favorites", new[] { "User_Id" });
            AlterColumn("dbo.Favorites", "User_Id", c => c.Long());
            CreateIndex("dbo.Favorites", "User_Id");
            AddForeignKey("dbo.Favorites", "User_Id", "dbo.AbpUsers", "Id");
        }
    }
}
