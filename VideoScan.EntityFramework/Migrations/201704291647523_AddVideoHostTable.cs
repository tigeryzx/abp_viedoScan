namespace VideoScan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVideoHostTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        PhysicalPath = c.String(),
                        AppendDate = c.DateTime(nullable: false),
                        IsSkip = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        IsCover = c.Boolean(nullable: false),
                        IsStoryCascade = c.Boolean(nullable: false),
                        OrderCode = c.Int(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Video_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Videos", t => t.Video_Id)
                .Index(t => t.Video_Id);
            
            CreateTable(
                "dbo.VideoFavorites",
                c => new
                    {
                        Video_Id = c.Int(nullable: false),
                        Favorite_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Video_Id, t.Favorite_Id })
                .ForeignKey("dbo.Videos", t => t.Video_Id, cascadeDelete: true)
                .ForeignKey("dbo.Favorites", t => t.Favorite_Id, cascadeDelete: true)
                .Index(t => t.Video_Id)
                .Index(t => t.Favorite_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "Video_Id", "dbo.Videos");
            DropForeignKey("dbo.VideoFavorites", "Favorite_Id", "dbo.Favorites");
            DropForeignKey("dbo.VideoFavorites", "Video_Id", "dbo.Videos");
            DropIndex("dbo.VideoFavorites", new[] { "Favorite_Id" });
            DropIndex("dbo.VideoFavorites", new[] { "Video_Id" });
            DropIndex("dbo.Images", new[] { "Video_Id" });
            DropTable("dbo.VideoFavorites");
            DropTable("dbo.Images");
            DropTable("dbo.Videos");
            DropTable("dbo.Favorites");
        }
    }
}
