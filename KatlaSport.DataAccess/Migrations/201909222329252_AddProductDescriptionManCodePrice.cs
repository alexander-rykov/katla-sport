namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddProductDescriptionManCodePrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.catalogue_products", "product_description", c => c.String(maxLength: 300));
            AddColumn("dbo.catalogue_products", "product_manufacturer_code", c => c.String(maxLength: 10));
            AddColumn("dbo.catalogue_products", "product_price", c => c.Decimal(precision: 18, scale: 2));
        }

        public override void Down()
        {
            DropColumn("dbo.catalogue_products", "product_price");
            DropColumn("dbo.catalogue_products", "product_manufacturer_code");
            DropColumn("dbo.catalogue_products", "product_description");
        }
    }
}
