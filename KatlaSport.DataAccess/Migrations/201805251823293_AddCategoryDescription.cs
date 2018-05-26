using System.Data.Entity.Migrations;

namespace KatlaSport.DataAccess.Migrations
{
    /// <summary>
    /// AddCategoryDescription migration.
    /// </summary>
    public partial class AddCategoryDescription : DbMigration
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
