namespace MVCLabData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class im : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "PictureID", "dbo.Pictures");
            DropForeignKey("dbo.Pictures", "GalleryID", "dbo.Galleries");
            AddForeignKey("dbo.Comments", "PictureID", "dbo.Pictures", "id", cascadeDelete: true);
            AddForeignKey("dbo.Pictures", "GalleryID", "dbo.Galleries", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "GalleryID", "dbo.Galleries");
            DropForeignKey("dbo.Comments", "PictureID", "dbo.Pictures");
            AddForeignKey("dbo.Pictures", "GalleryID", "dbo.Galleries", "id");
            AddForeignKey("dbo.Comments", "PictureID", "dbo.Pictures", "id");
        }
    }
}
