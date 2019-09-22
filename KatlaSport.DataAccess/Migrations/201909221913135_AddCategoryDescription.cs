namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

#pragma warning disable SA1601 // Partial elements must be documented
    public partial class AddCategoryDescription : DbMigration
#pragma warning restore SA1601 // Partial elements must be documented
    {
        public override void Up()
        {
            AddColumn("dbo.product_categories", "category_description", c => c.String(maxLength: 300));
        }

        public override void Down()
        {
            DropColumn("dbo.product_categories", "category_description");
        }
    }
}
