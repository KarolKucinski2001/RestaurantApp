namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fourth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "FirstName", c => c.String());
            AddColumn("dbo.Customers", "Surname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Surname");
            DropColumn("dbo.Customers", "FirstName");
        }
    }
}
