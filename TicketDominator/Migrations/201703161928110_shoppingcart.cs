namespace TicketDominator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingcart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingCarts", "UserId");
        }
    }
}
