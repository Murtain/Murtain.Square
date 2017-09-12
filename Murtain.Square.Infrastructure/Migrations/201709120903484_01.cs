namespace Murtain.Square.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sentence",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FamousName = c.String(nullable: false, maxLength: 40),
                        FamousSaying = c.String(nullable: false, maxLength: 500),
                        CreateTime = c.DateTime(),
                        CreateUser = c.String(maxLength: 50),
                        ChangeUser = c.String(maxLength: 50),
                        ChangeTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sentence");
        }
    }
}
