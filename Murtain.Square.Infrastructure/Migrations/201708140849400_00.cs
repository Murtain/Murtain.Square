namespace Murtain.Square.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _00 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Focus",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Content = c.String(maxLength: 40),
                        Status = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                        CreateUser = c.String(maxLength: 50),
                        ChangeUser = c.String(maxLength: 50),
                        ChangeTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Focus");
        }
    }
}
