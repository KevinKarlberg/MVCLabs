namespace Kunskapskollen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class im : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonAdresses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Namn = c.String(nullable: false),
                        Telefonnummer = c.String(nullable: false),
                        Adress = c.String(nullable: false),
                        Updaterades = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonAdresses");
        }
    }
}
