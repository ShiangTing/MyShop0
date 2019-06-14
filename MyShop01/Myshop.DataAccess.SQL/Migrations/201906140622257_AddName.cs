namespace Myshop.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Name");
        }
    }
}
