
namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailAuthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "Email");
        }
    }
}
