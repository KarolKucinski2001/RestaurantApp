namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuItems", "OrderMenuItem_OrderMenuItemId", "dbo.OrderMenuItems");
            DropForeignKey("dbo.Orders", "OrderMenuItem_OrderMenuItemId", "dbo.OrderMenuItems");
            DropIndex("dbo.Orders", new[] { "OrderMenuItem_OrderMenuItemId" });
            DropIndex("dbo.MenuItems", new[] { "OrderMenuItem_OrderMenuItemId" });
            RenameColumn(table: "dbo.MenuItems", name: "OrderMenuItem_OrderMenuItemId", newName: "OrderMenuItem_OrderId");
            RenameColumn(table: "dbo.Orders", name: "OrderMenuItem_OrderMenuItemId", newName: "OrderMenuItem_OrderId");
            DropPrimaryKey("dbo.OrderMenuItems");
            AddColumn("dbo.Orders", "OrderMenuItem_MenuItemId", c => c.Int());
            AddColumn("dbo.MenuItems", "OrderMenuItem_MenuItemId", c => c.Int());
            AlterColumn("dbo.OrderMenuItems", "OrderMenuItemId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.OrderMenuItems", new[] { "OrderId", "MenuItemId" });
            CreateIndex("dbo.Orders", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" });
            CreateIndex("dbo.MenuItems", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" });
            AddForeignKey("dbo.MenuItems", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" }, "dbo.OrderMenuItems", new[] { "OrderId", "MenuItemId" });
            AddForeignKey("dbo.Orders", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" }, "dbo.OrderMenuItems", new[] { "OrderId", "MenuItemId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" }, "dbo.OrderMenuItems");
            DropForeignKey("dbo.MenuItems", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" }, "dbo.OrderMenuItems");
            DropIndex("dbo.MenuItems", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" });
            DropIndex("dbo.Orders", new[] { "OrderMenuItem_OrderId", "OrderMenuItem_MenuItemId" });
            DropPrimaryKey("dbo.OrderMenuItems");
            AlterColumn("dbo.OrderMenuItems", "OrderMenuItemId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.MenuItems", "OrderMenuItem_MenuItemId");
            DropColumn("dbo.Orders", "OrderMenuItem_MenuItemId");
            AddPrimaryKey("dbo.OrderMenuItems", "OrderMenuItemId");
            RenameColumn(table: "dbo.Orders", name: "OrderMenuItem_OrderId", newName: "OrderMenuItem_OrderMenuItemId");
            RenameColumn(table: "dbo.MenuItems", name: "OrderMenuItem_OrderId", newName: "OrderMenuItem_OrderMenuItemId");
            CreateIndex("dbo.MenuItems", "OrderMenuItem_OrderMenuItemId");
            CreateIndex("dbo.Orders", "OrderMenuItem_OrderMenuItemId");
            AddForeignKey("dbo.Orders", "OrderMenuItem_OrderMenuItemId", "dbo.OrderMenuItems", "OrderMenuItemId");
            AddForeignKey("dbo.MenuItems", "OrderMenuItem_OrderMenuItemId", "dbo.OrderMenuItems", "OrderMenuItemId");
        }
    }
}
