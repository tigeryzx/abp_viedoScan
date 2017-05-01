namespace VideoScan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddResAndSetting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SettingName = c.String(),
                        SettingValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResDirs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DirName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Favorites", "User_Id", c => c.Long());
            CreateIndex("dbo.Favorites", "User_Id");
            AddForeignKey("dbo.Favorites", "User_Id", "dbo.AbpUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "User_Id", "dbo.AbpUsers");
            DropIndex("dbo.Favorites", new[] { "User_Id" });
            DropColumn("dbo.Favorites", "User_Id");
            DropTable("dbo.ResDirs");
            DropTable("dbo.AppSettings");
        }
    }
}
