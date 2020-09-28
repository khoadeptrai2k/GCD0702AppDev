namespace GCD0702AppDev.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddCartsToDb : DbMigration
	{
		public override void Up()
		{
			CreateTable(
					"dbo.Carts",
					c => new
					{
						Id = c.Int(nullable: false, identity: true),
						CustomerId = c.String(maxLength: 128),
						ProductId = c.Int(nullable: false),
					})
					.PrimaryKey(t => t.Id)
					.ForeignKey("dbo.AspNetUsers", t => t.CustomerId)
					.ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
					.Index(t => t.CustomerId)
					.Index(t => t.ProductId);

		}

		public override void Down()
		{
			DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
			DropForeignKey("dbo.Carts", "CustomerId", "dbo.AspNetUsers");
			DropIndex("dbo.Carts", new[] { "ProductId" });
			DropIndex("dbo.Carts", new[] { "CustomerId" });
			DropTable("dbo.Carts");
		}
	}
}
