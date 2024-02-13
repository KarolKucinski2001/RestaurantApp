namespace RestaurantApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Payment = c.Int(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        Comments = c.String(),
                        CustomerId = c.Int(nullable: false),
                        WaiterId = c.Int(nullable: false),
                        TableSeatingId = c.Int(nullable: false),
                        OrderMenuItem_OrderMenuItemId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.TableSeatings", t => t.TableSeatingId, cascadeDelete: true)
                .ForeignKey("dbo.Waiters", t => t.WaiterId, cascadeDelete: true)
                .ForeignKey("dbo.OrderMenuItems", t => t.OrderMenuItem_OrderMenuItemId)
                .Index(t => t.CustomerId)
                .Index(t => t.WaiterId)
                .Index(t => t.TableSeatingId)
                .Index(t => t.OrderMenuItem_OrderMenuItemId);
            
            CreateTable(
                "dbo.TableSeatings",
                c => new
                    {
                        TableSeatingId = c.Int(nullable: false, identity: true),
                        Seats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TableSeatingId);
            
            CreateTable(
                "dbo.Waiters",
                c => new
                    {
                        WaiterId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Salary = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.WaiterId);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        MenuItemId = c.Int(nullable: false, identity: true),
                        MenuItemName = c.String(),
                        Calories = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                        OrderMenuItem_OrderMenuItemId = c.Int(),
                    })
                .PrimaryKey(t => t.MenuItemId)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .ForeignKey("dbo.OrderMenuItems", t => t.OrderMenuItem_OrderMenuItemId)
                .Index(t => t.MenuId)
                .Index(t => t.OrderMenuItem_OrderMenuItemId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        MenuDescription = c.String(),
                    })
                .PrimaryKey(t => t.MenuId);
            
            CreateTable(
                "dbo.OrderMenuItems",
                c => new
                    {
                        OrderMenuItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        MenuItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.OrderMenuItemId)
                .ForeignKey("dbo.MenuItems", t => t.MenuItemId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.MenuItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderMenuItem_OrderMenuItemId", "dbo.OrderMenuItems");
            DropForeignKey("dbo.OrderMenuItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.MenuItems", "OrderMenuItem_OrderMenuItemId", "dbo.OrderMenuItems");
            DropForeignKey("dbo.OrderMenuItems", "MenuItemId", "dbo.MenuItems");
            DropForeignKey("dbo.MenuItems", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.Orders", "WaiterId", "dbo.Waiters");
            DropForeignKey("dbo.Orders", "TableSeatingId", "dbo.TableSeatings");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderMenuItems", new[] { "MenuItemId" });
            DropIndex("dbo.OrderMenuItems", new[] { "OrderId" });
            DropIndex("dbo.MenuItems", new[] { "OrderMenuItem_OrderMenuItemId" });
            DropIndex("dbo.MenuItems", new[] { "MenuId" });
            DropIndex("dbo.Orders", new[] { "OrderMenuItem_OrderMenuItemId" });
            DropIndex("dbo.Orders", new[] { "TableSeatingId" });
            DropIndex("dbo.Orders", new[] { "WaiterId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.OrderMenuItems");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuItems");
            DropTable("dbo.Waiters");
            DropTable("dbo.TableSeatings");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
