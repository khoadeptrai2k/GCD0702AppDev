namespace GCD0702AppDev.Migrations
{
	using System.Data.Entity.Migrations;

	public partial class AddProductTable : DbMigration
	{
		public override void Up()
		{
			CreateTable(
					"dbo.Products",
					c => new
					{
						Id = c.Int(nullable: false, identity: true),
						Name = c.String(nullable: false),
						Price = c.Double(nullable: false),
					})
					.PrimaryKey(t => t.Id);
		}

		public override void Down()
		{
			DropTable("dbo.Products");
		}
	}
}